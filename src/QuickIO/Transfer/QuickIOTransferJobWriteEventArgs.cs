namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Abstract base class for file transfer event arguments
/// </summary>
public abstract class QuickIOTransferJobWriteEventArgs : QuickIOTransferJobEventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobWriteEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="targetPath">Target file path</param>
    protected QuickIOTransferJobWriteEventArgs(IQuickIOTransferJob job, string targetPath)
        : base(job)
    {
        TargetPath = targetPath;
    }

    /// <summary>
    /// Target file path
    /// </summary>
    public string TargetPath { get; private set; }
}
