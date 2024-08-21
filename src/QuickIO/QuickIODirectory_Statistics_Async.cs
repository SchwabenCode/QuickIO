using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides static methods to access folders. For example creating, deleting and retrieving content and security information such as the owner.
/// </summary>
public static partial class QuickIODirectory
{
    /// <summary>
    /// Gets the directory statistics: total files, folders and bytes
    /// </summary>
    /// <param name="path"></param>
    /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
    public static Task<QuickIOFolderStatisticResult?> GetStatisticsAsync(string path)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetStatistics(path));
    }

    /// <summary>
    /// Gets the directory statistics: total files, folders and bytes
    /// </summary>
    /// <param name="pathInfo"></param>
    /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
    public static Task<QuickIOFolderStatisticResult?> GetStatisticsAsync(QuickIOPathInfo pathInfo)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetStatistics(pathInfo));
    }

    /// <summary>
    /// Gets the directory statistics: total files, folders and bytes
    /// </summary>
    /// <param name="directoryInfo"></param>
    /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
    public static Task<QuickIOFolderStatisticResult?> GetStatisticsAsync(QuickIODirectoryInfo directoryInfo)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetStatistics(directoryInfo));
    }
}
