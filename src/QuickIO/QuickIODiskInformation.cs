namespace SchwabenCode.QuickIO;

/// <summary>
/// Disk metadata information
/// </summary>
public sealed partial class QuickIODiskInformation
{
    internal QuickIODiskInformation(ulong freeBytes, ulong totalBytes, ulong totalFreeBytes)
    {
        FreeBytes = freeBytes;
        TotalBytes = totalBytes;
        TotalFreeBytes = totalFreeBytes;
    }

    /// <summary>
    /// Total available number of bytes for the user who executed the API call.
    /// </summary>
    public ulong FreeBytes { get; private set; }

    /// <summary>
    /// Total bytes of share
    /// </summary>
    public ulong TotalBytes { get; private set; }

    /// <summary>
    /// Total free bytes for all users
    /// </summary>
    public ulong TotalFreeBytes { get; private set; }
}
