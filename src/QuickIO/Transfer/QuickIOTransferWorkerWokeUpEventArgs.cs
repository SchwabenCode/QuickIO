namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when when a worker, which so far has been waiting for an item, was notified of a new item in the queue.
/// It may be that he gets no element from the queue, because another thread was faster. He would sleep lie down again, if no more items available.
/// </summary>
public class QuickIOTransferWorkerWokeUpEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferWorkerWokeUpEventArgs"/>
    /// </summary>
    /// <param name="workerID">Affected Worker ID</param>
    public QuickIOTransferWorkerWokeUpEventArgs(int workerID)
    {
        WorkerID = workerID;
    }

    /// <summary>
    /// Affected Worker ID
    /// </summary>
    public int WorkerID { get; private set; }
}
