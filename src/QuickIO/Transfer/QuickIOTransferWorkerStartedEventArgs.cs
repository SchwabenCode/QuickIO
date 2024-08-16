namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when a worker started
/// </summary>
public class QuickIOTransferWorkerStartedEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferWorkerStartedEventArgs"/>
    /// </summary>
    /// <param name="workerID">Affected Worker ID</param>
    public QuickIOTransferWorkerStartedEventArgs(int workerID)
    {
        WorkerID = workerID;
    }

    /// <summary>
    /// Affected Worker ID
    /// </summary>
    public int WorkerID { get; private set; }
}
