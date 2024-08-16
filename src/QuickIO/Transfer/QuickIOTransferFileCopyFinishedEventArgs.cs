namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information when a file copy operation has been finished successfully
/// </summary>
public class QuickIOTransferFileCopyFinishedEventArgs : QuickIOTransferJobWriteWithSourceEventArgs
{
    /// <summary>
    /// Estimated Timestamp when transfer is finished
    /// </summary>
    public DateTime TransferFinished { get; private set; }


    private TimeSpan? _duration;

    /// <summary>
    /// Live transfer duration
    /// </summary>
    public TimeSpan Duration
    {
        get
        {
            return (TimeSpan)((TimeSpan?)(_duration ??= TransferFinished.Subtract(TransferStarted)));
        }
    }

    private double? _bytesPerSecond;

    /// <summary>
    /// Live bytes per second
    /// </summary>
    public double BytesPerSecond
    {
        get
        {
            return (double)((double?)(_bytesPerSecond ??= (TotalBytes / Duration.TotalSeconds)));
        }
    }

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
    /// <param name="job">Affected job</param>
    /// <param name="sourcePath">Source file path</param>
    /// <param name="targetPath">Target file path</param>
    /// <param name="totalBytes">Total bytes to transfer</param>
    /// <param name="transferStarted"></param>
    public QuickIOTransferFileCopyFinishedEventArgs(IQuickIOTransferJob job, string sourcePath, string targetPath, long totalBytes, DateTime transferStarted)
        : base(job, sourcePath, targetPath)
    {
        TotalBytes = (ulong)totalBytes;
        TransferStarted = transferStarted;
        TransferFinished = DateTime.Now;
    }
}
