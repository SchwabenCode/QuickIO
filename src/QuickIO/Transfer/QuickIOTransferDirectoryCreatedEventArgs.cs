namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information after a directory create operation was performed
/// </summary>
public class QuickIOTransferDirectoryCreatedEventArgs : QuickIOTransferJobEventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferDirectoryCreatedEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="targetPath">Directory fullname that was created</param>
    public QuickIOTransferDirectoryCreatedEventArgs(IQuickIOTransferJob job, string targetPath)
        : base(job)
    {
        TargetPath = targetPath;
    }

    /// <summary>
    /// Target path
    /// </summary>
    public string TargetPath { get; private set; }
}
