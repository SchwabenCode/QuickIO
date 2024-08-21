namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// provides information for job error
/// </summary>
public class QuickIOTransferJobErrorEventArgs : QuickIOTransferJobEventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobErrorEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="e">Exception</param>
    public QuickIOTransferJobErrorEventArgs(IQuickIOTransferJob job, Exception e)
        : base(job)
    {
        Exception = e;
    }

    /// <summary>
    /// Error
    /// </summary>
    public Exception Exception { get; private set; }
}
