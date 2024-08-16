namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Abstract class for other event argument implementaions
/// </summary>
public abstract class QuickIOTransferJobWriteWithSourceEventArgs : QuickIOTransferJobWriteEventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobWriteWithSourceEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="sourcePath">Source path</param>
    /// <param name="targetPath">target path</param>
    protected QuickIOTransferJobWriteWithSourceEventArgs(IQuickIOTransferJob job, string sourcePath, string targetPath)
        : base(job, targetPath)
    {
        SourcePath = sourcePath;
    }

    /// <summary>
    /// Source file path
    /// </summary>
    public string SourcePath { get; private set; }
}
