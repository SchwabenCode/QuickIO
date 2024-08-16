namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when a worker has stopped successfully
/// </summary>
public class QuickIOTransferWorkerShutdownEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferWorkerShutdownEventArgs"/>
    /// </summary>
    /// <param name="workerID">Affected Worker ID</param>
    public QuickIOTransferWorkerShutdownEventArgs(int workerID)
    {
        WorkerID = workerID;
    }

    /// <summary>
    /// Affected Worker ID
    /// </summary>
    public int WorkerID { get; private set; }
}
