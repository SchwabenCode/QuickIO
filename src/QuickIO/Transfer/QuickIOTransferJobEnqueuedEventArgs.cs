namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information of an enqueued job
/// </summary>
public class QuickIOTransferJobEnqueuedEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobEnqueuedEventArgs"/>
    /// </summary>
    /// <param name="job">Enqueued Job</param>
    public QuickIOTransferJobEnqueuedEventArgs(IQuickIOTransferJob job)
    {
        Job = job;
    }

    /// <summary>
    /// Enqueued Job
    /// </summary>
    public IQuickIOTransferJob Job { get; private set; }
}
