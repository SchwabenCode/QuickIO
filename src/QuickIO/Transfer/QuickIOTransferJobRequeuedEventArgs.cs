namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information of a job that is re-queued.
/// A re-queue happens when a job execution failes and the service retries the operation 
/// </summary>
public class QuickIOTransferJobRequeuedEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobRequeuedEventArgs"/>
    /// </summary>
    /// <param name="job">Enqueued Job</param>
    /// <param name="e">Exception of last error</param>
    public QuickIOTransferJobRequeuedEventArgs(IQuickIOTransferJob job, Exception e)
    {
        Job = job;
        Exception = e;
    }

    /// <summary>
    /// Requeued Job
    /// </summary>
    public IQuickIOTransferJob Job { get; private set; }

    /// <summary>
    /// Raised exception caused the requeue
    /// </summary>
    public Exception Exception { get; private set; }
}
