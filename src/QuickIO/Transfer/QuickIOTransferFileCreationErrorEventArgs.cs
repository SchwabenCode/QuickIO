namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains further information when a file creation process fails
/// </summary>
public class QuickIOTransferFileCreationErrorEventArgs : QuickIOTransferJobWriteEventArgs
{
    /// <summary>
    /// Exception
    /// </summary>
    public Exception Exception { get; private set; }

    /// <summary>
    /// Creates new instance of <see cref="QuickIOTransferFileCreationErrorEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="targetPath">Target file path</param>
    /// <param name="e">Exception</param>
    public QuickIOTransferFileCreationErrorEventArgs(IQuickIOTransferJob job, string targetPath, Exception e)
        : base(job, targetPath)
    {
        Exception = e;
    }
}
