namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when a new worker has been created
/// </summary>
public class QuickIOTransferWorkerCreatedEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferWorkerCreatedEventArgs"/>
    /// </summary>
    /// <param name="workerID">Affected Worker ID</param>
    public QuickIOTransferWorkerCreatedEventArgs(int workerID)
    {
        WorkerID = workerID;
    }

    /// <summary>
    /// Affected Worker ID
    /// </summary>
    public int WorkerID { get; private set; }
}
