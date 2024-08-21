namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains further information when a directory creation process fails
/// </summary>
public class QuickIOTransferDirectoryCreationErrorEventArgs : QuickIOTransferJobWriteEventArgs
{
    /// <summary>
    /// Exception
    /// </summary>
    public Exception Exception { get; private set; }

    /// <summary>
    /// Creates new instance of <see cref="QuickIOTransferFileCopyErrorEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="target">Target path</param>
    /// <param name="e">Exception</param>
    public QuickIOTransferDirectoryCreationErrorEventArgs(IQuickIOTransferJob job, string target, Exception e)
        : base(job, target)
    {
        Exception = e;
    }
}
