using System.ComponentModel;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Base Class for transfer service implementations.<br/>
/// <br/>
/// A QuickIO service is an instance for processing multiple jobs. QuickIO services offer multiple workers (one worker = one <see cref="Thread"/>), to enable parallel processing for jobs.<br />
/// By default the priority that a job has, is observed during the processing with <see cref="PriorityComparer"/>.
/// </summary>
/// <remarks>All methods and properties are thread-safe</remarks>
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class QuickIOTransferServiceBase
{
    private readonly object _workerShutdownLock = new( );
    private volatile int _maxWorkerCount;
    private volatile int _workerCountRemoveRequested;
    private readonly Dictionary<int, Thread> _workerThreads;
    private readonly object _workerCountRemoveRequestedLock = new( );

    /// <summary>
    /// Provides Events and Settings for transfer monitoring
    /// </summary>
    public IQuickIOTransferObserver Observer { get; private set; }


    /// <summary>
    /// Max count of active workers
    /// </summary>
    public int MaxWorkerCount
    {
        get
        {
            return _maxWorkerCount;
        }
        private set
        {
            _maxWorkerCount = value;
        }
    }

    #region Fields
    private int _maxBufferSize = 32768;
    private volatile int _maxJobRetryAttempts;
    private readonly object _jobQueueLock = new( );
    private readonly object _workerThreadsLock = new( );
    #endregion

    /// <summary>
    /// Size of Buffer
    /// </summary>
    public int MaxBufferSize
    {
        get
        {
            return _maxBufferSize;
        }
        private set
        {
            _maxBufferSize = Math.Max(1024, value);
        }
    }
    /// <summary>
    /// Max Job Retry Count
    /// </summary>
    public int MaxJobRetryAttempts
    {
        get
        {
            return _maxJobRetryAttempts;
        }
        private set
        {
            _maxJobRetryAttempts = Math.Max(1, value);
        }
    }

    /// <summary>
    /// Count of active workers
    /// </summary>
    public int WorkerCount
    {
        get
        {
            lock (_workerThreadsLock)
            {
                return _workerThreads.Count;
            }
        }
    }

    /// <summary>
    /// True if service is running
    /// </summary>
    protected bool IsWorking
    {
        get { return WorkerCount != 0; }
    }

    /// <summary>
    /// Starts the service
    /// </summary>
    /// <returns>false if service is already started</returns>
    protected bool StartWorking()
    {
        if (IsWorking)
        {
            return false;
        }

        CreateWorkers();
        StartWorkers();

        return true;
    }

    #region Finalizing

    /// <summary>
    /// true is cancel is requested
    /// </summary>
    public bool CancelRequested { get; private set; }

    /// <summary>
    /// true if queue adding is completed. No more items will be added.
    /// </summary>
    public bool AddingCompleted { get; private set; }

    /// <summary>
    /// Cancels the file provider and all transfers
    /// </summary>
    public void Cancel()
    {
        OnCancellationRequested();

        CancelRequested = true;
    }

    /// <summary>
    /// Marks the queue as completed. No more items can be added.
    /// </summary>
    public void CompleteAdding()
    {
        OnCompletedAddingRequested();

        AddingCompleted = true;

        lock (_workerThreadsLock)
        {
            foreach (KeyValuePair<int, Thread> w in _workerThreads)
            {
                WakeUpSleepingWorkers();
            }
        }
    }
    #endregion

    /// <summary>
    /// Comparer for job sorting. By default it's <see cref="QuickIOTransferJobPriorityComparer"/>.
    /// FIFO if comparer is null.
    /// </summary>
    public IComparer<IQuickIOTransferJob> PriorityComparer { get; set; }

    /// <summary>
    /// Resorts the Queue
    /// </summary>
    private void InternalReSortLockedQueue()
    {
        if (PriorityComparer != null)
        {
            _jobQueue.Sort(PriorityComparer);
        }
    }
    /// <summary>
    /// Queue
    /// </summary>
    private readonly List<IQuickIOTransferJob> _jobQueue = [];

    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferServiceBase"/>
    /// </summary>
    /// <param name="observer">Required server. Can be null to create default observer</param>
    /// <param name="maxWorkerCount">Count of parallel workers to transfer the files</param>
    /// <param name="maxFileRetry">Max retry on transfer failure</param>
    protected QuickIOTransferServiceBase(IQuickIOTransferObserver? observer, int maxWorkerCount = 1, int maxFileRetry = 3)
    {
        MaxWorkerCount = maxWorkerCount;
        _maxJobRetryAttempts = Math.Max(1, maxFileRetry);
        _workerThreads = [];

        Observer = observer ?? new QuickIOTransferObserver();
        PriorityComparer = new QuickIOTransferJobPriorityComparer();
    }

    /// <summary>
    /// Creates the amount of workers
    /// </summary>
    protected void CreateWorkers()
    {
        lock (_workerThreadsLock)
        {
            for (int i = 0; i < MaxWorkerCount; i++)
            {
                _ = InternalCreateNewWorker();
            }
        }
    }

    /// <summary>
    /// Creates a new worker
    /// </summary>
    /// <returns>Created thread</returns>
    private Thread InternalCreateNewWorker()
    {
        ParameterizedThreadStart tParams = new( StartConsuming );

        Thread wt = new( tParams );
        _workerThreads.Add(wt.ManagedThreadId, wt);
        OnWorkerCreated(wt.ManagedThreadId);

        return wt;
    }

    /// <summary>
    /// Creates the amount of workers
    /// </summary>
    protected void StartWorkers()
    {
        lock (_workerThreadsLock)
        {
            foreach (KeyValuePair<int, Thread> w in _workerThreads)
            {
                Thread worker = w.Value;
                InternalStartWorker(worker);
            }
        }
    }

    /// <summary>
    /// Starts the given worker by ID
    /// </summary>
    private void InternalStartWorker(Thread wt)
    {
        if (wt.IsAlive)
        {
            return;
        }

        wt.Start(wt.ManagedThreadId);
        OnWorkerStarted(wt.ManagedThreadId);
    }

    /// <summary>
    /// Adds a new worker to the service. Worker will be created and started instantly.
    /// </summary>
    /// <param name="count">Must be 1 or greater</param>
    /// <remarks>It's not recommended to use more workers than the count of useable CPU cores.</remarks>
    protected void AddWorker(int count = 1)
    {
        Invariant.Greater(count, 0);

        lock (_workerThreadsLock)
        {
            for (int i = 0; i < count; i++)
            {
                Thread w = InternalCreateNewWorker( );
                InternalStartWorker(w);
            }
        }
    }

    /// <summary>
    /// Remove workers from the service.
    /// </summary>
    /// <param name="count">Must be 1 or greater</param>
    protected void RemoveWorker(int count = 1)
    {
        Invariant.Greater(count, 0);

        lock (_workerCountRemoveRequestedLock)
        {
            _workerCountRemoveRequested += count;
        }

        WakeUpSleepingWorkers();

    }

    /// <summary>
    /// Wakes sleeping workers up
    /// </summary>
    private void WakeUpSleepingWorkers()
    {
        lock (_jobQueueLock)
        {
            Monitor.Pulse(_jobQueueLock);
        }
    }

    /// <summary>
    /// waits for queue items
    /// </summary>
    private void InternalWaitForNewQueueItems()
    {
        _ = Monitor.Wait(_jobQueueLock);
    }

    /// <summary>
    /// Locks the queue and adds the element.
    /// </summary>
    /// <param name="queueItem">Item to add </param>
    /// <remarks>The service will inject his observer to the job. If the job already has an observer, it will be overwritten.</remarks>
    protected void InternalAdd(QuickIOTransferJob queueItem)
    {
        queueItem.Observer = Observer;

        lock (_jobQueueLock)
        {
            _jobQueue.Add(queueItem);

            InternalReSortLockedQueue(); // Sort by priority

            Monitor.Pulse(_jobQueueLock); // wake up sleeping workers
        }

        OnJobEnqueued(queueItem);
    }

    /// <summary>
    /// Locks the queue and adds the collection to the queue.
    /// </summary>
    /// <param name="queueItems">Collection of items to add</param>
    protected void InternalAddRange(IEnumerable<QuickIOTransferJob> queueItems)
    {
        lock (_jobQueueLock)
        {
            foreach (QuickIOTransferJob queueItem in queueItems)
            {
                queueItem.Observer = Observer;

                _jobQueue.Add(queueItem);
                OnJobEnqueued(queueItem);
            }

            InternalReSortLockedQueue(); // Sort by priority

            Monitor.Pulse(_jobQueueLock);// wake up sleeping workers
        }
    }

    /// <summary>
    /// Clears the queue and returns all queued elements
    /// </summary>
    /// <returns>Collection of <see cref="IQuickIOTransferJob"/></returns>
    protected IEnumerable<IQuickIOTransferJob> Clear()
    {
        List<IQuickIOTransferJob> queued;
        lock (_jobQueue)
        {
            queued = new List<IQuickIOTransferJob>(_jobQueue);
            _jobQueue.Clear();
        }

        return queued;
    }

    /// <summary>
    /// Joins all threads and blocks until all threads and queue items are completed.
    /// Queue has to be completed.
    /// </summary>
    protected void WaitForFinish()
    {
        if (!AddingCompleted)
        {
            throw new Exception("Queue is not completed.");
        }

        lock (_workerThreadsLock)
        {
            if (_workerThreads.Count == 0)
            {
                return;
            }
        }

        lock (_workerShutdownLock)
        {
            _ = Monitor.Wait(_workerShutdownLock);
        }
    }

    /// <summary>
    /// Removes a Thread from <see cref="_workerThreads"/> and raises <see cref="OnWorkerShutdown"/>
    /// </summary>
    /// <param name="threadId">Affcted Thread ID</param>
    private void RemoveThread(int threadId)
    {
        lock (_workerThreadsLock)
        {
            _ = _workerThreads.Remove(threadId);

            if (_workerThreads.Count == 0)
            {
                lock (_workerShutdownLock)
                {
                    Monitor.Pulse(_workerShutdownLock);
                }
            }
        }
        OnWorkerShutdown(threadId);
    }

}
