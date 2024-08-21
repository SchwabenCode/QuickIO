namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when a worker picked up a new job from the queue
/// </summary>
public class QuickIOTransferWorkerPickedJobEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferWorkerWokeUpEventArgs"/>
    /// </summary>
    /// <param name="workerID">Affected Worker ID</param>
    /// <param name="job">Picked job</param>
    public QuickIOTransferWorkerPickedJobEventArgs(int workerID, IQuickIOTransferJob job)
    {
        WorkerID = workerID;
        Job = job;
    }

    /// <summary>
    /// Affected Worker ID
    /// </summary>
    public int WorkerID { get; private set; }


    /// <summary>
    /// Picked Job
    /// </summary>
    public IQuickIOTransferJob Job { get; private set; }
}
