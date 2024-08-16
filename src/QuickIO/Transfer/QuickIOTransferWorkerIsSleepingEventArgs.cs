namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information if a workers wait for a new element in queue
/// </summary>
public class QuickIOTransferWorkerIsSleepingEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferWorkerIsSleepingEventArgs"/>
    /// </summary>
    /// <param name="workerID">Affected Worker ID</param>
    public QuickIOTransferWorkerIsSleepingEventArgs(int workerID)
    {
        WorkerID = workerID;
    }

    /// <summary>
    /// Affected Worker ID
    /// </summary>
    public int WorkerID { get; private set; }
}
