namespace SchwabenCode.QuickIO;

/// <summary>
/// Folder Statistics
/// </summary>
public class QuickIOFolderStatisticResult
{
    /// <summary>
    /// Folder Count
    /// </summary>
    public ulong FolderCount { get; private set; }

    /// <summary>
    /// File Count
    /// </summary>
    public ulong FileCount { get; private set; }

    /// <summary>
    /// Total TotalBytes
    /// </summary>
    public ulong TotalBytes { get; private set; }

    /// <summary>
    /// Creates new Instance of <see cref="QuickIOFolderStatisticResult"/> - internal access only
    /// </summary>
    /// <param name="folderCount">Folder Count</param>
    /// <param name="fileCount">File Count</param>
    /// <param name="size"> Total TotalBytes</param>
    internal QuickIOFolderStatisticResult(ulong folderCount, ulong fileCount, ulong size)
    {
        FolderCount = folderCount;
        FileCount = fileCount;
        TotalBytes = size;
    }
}
