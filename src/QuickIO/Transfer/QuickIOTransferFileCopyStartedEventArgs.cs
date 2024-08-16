namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when a file copy process has been started
/// </summary>
public class QuickIOTransferFileCopyStartedEventArgs : QuickIOTransferJobWriteWithSourceEventArgs
{
    /// <summary>
    /// Total bytes of file
    /// </summary>
    public ulong TotalBytes { get; private set; }

    /// <summary>
    /// Time transfer of file started
    /// </summary>
    public DateTime TransferStarted { get; private set; }

    /// <summary>
    /// Creates new instance of <see cref="QuickIOTransferFileCopyProgressEventArgs"/>
    /// </summary>
    /// <param name="sourcePath">Affected job</param>
    /// <param name="targetPath">Source file path</param>
    /// <param name="job">Affected job</param>
    /// <param name="totalBytes">Total bytes to transfer</param>
    public QuickIOTransferFileCopyStartedEventArgs(IQuickIOTransferJob job, string sourcePath, string targetPath, long totalBytes)
        : base(job, sourcePath, targetPath)
    {
        TotalBytes = (ulong)totalBytes;
        TransferStarted = DateTime.Now;
    }
}
