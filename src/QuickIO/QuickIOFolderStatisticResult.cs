namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents the result of retrieving statistics for a directory, including counts of subdirectories and files, and the total size of files in bytes.
/// </summary>
/// <param name="FolderCount">The number of subdirectories within the directory.</param>
/// <param name="FileCount">The number of files within the directory.</param>
/// <param name="TotalBytes">The total size of all files within the directory, in bytes.</param>
/// <example>
/// <code>
/// QuickIOFolderStatisticResult stats = new QuickIOFolderStatisticResult(10, 150, 204800);
/// 
/// Console.WriteLine($"Folders: {stats.FolderCount}");
/// Console.WriteLine($"Files: {stats.FileCount}");
/// Console.WriteLine($"Total size: {stats.TotalBytes} bytes");
/// </code>
/// </example>
public record class QuickIOFolderStatisticResult(
    ulong FolderCount,
    ulong FileCount,
    ulong TotalBytes);

