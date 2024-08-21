using SchwabenCode.QuickIO.Compatibility;
using SchwabenCode.QuickIO.Internal;


namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    #region EnumerateDirectoryPaths

    /// <summary>
    /// Returns an enumerable collection of directory names in a specified path in async context.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
    public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateDirectoryPaths(new QuickIOPathInfo(path), pattern, searchOption, pathFormatReturn, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of directory names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="directoryInfo">The directory to search.</param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
    public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync(QuickIODirectoryInfo directoryInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateDirectoryPaths(directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of directory names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="info">The directory to search.</param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
    public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync(QuickIOPathInfo info, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateDirectoryPaths(info, pattern, searchOption, pathFormatReturn, enumerateOptions));
    }
    #endregion

    #region EnumerateDirectories

    /// <summary>
    /// Returns an enumerable collection of directories in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateDirectories(new QuickIOPathInfo(path), pattern, searchOption, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of directories in a specified path in a seperate task created by the default <see cref="TaskScheduler"/> in async context.
    /// </summary>
    /// <param name="directoryInfo">The directory to search.</param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync(QuickIODirectoryInfo directoryInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateDirectories(directoryInfo.PathInfo, pattern, searchOption, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of directories names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="info">The directory to search.</param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync(QuickIOPathInfo info, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateDirectories(info, pattern, searchOption, enumerateOptions));
    }
    #endregion

    #region EnumerateFilePaths

    /// <summary>
    /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="path">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<string>> EnumerateFilePathsAsync(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFilePaths(new QuickIOPathInfo(path), pattern, searchOption, pathFormatReturn, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="directoryInfo">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<string>> EnumerateFilePathsAsync(QuickIODirectoryInfo directoryInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFilePaths(directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="info">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<string>> EnumerateFilePathsAsync(QuickIOPathInfo info, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => InternalQuickIO.EnumerateFilePaths(info.FullNameUnc, pattern, searchOption, enumerateOptions, pathFormatReturn));
    }
    #endregion

    #region EnumerateFiles

    /// <summary>
    /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="path">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFiles(new QuickIOPathInfo(path), pattern, searchOption, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="directoryInfo">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns> #
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync(QuickIODirectoryInfo directoryInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFiles(directoryInfo.PathInfo, pattern, searchOption, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="info">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption"><see cref="SearchOption"/></param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>     /// 
    public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync(QuickIOPathInfo info, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFiles(info, pattern, searchOption, enumerateOptions));
    }
    #endregion

    #region EnumerateFileSystemEntryPaths
    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="path">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFileSystemEntryPaths(new QuickIOPathInfo(path), pattern, searchOption, pathFormatReturn, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="directoryInfo">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync(QuickIODirectoryInfo directoryInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFileSystemEntryPaths(directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="pathInfo">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
    /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync(QuickIOPathInfo pathInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFileSystemEntryPaths(pathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions));
    }
    #endregion

    #region EnumerateFileSystemEntries
    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="path">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFileSystemEntries(new QuickIOPathInfo(path), pattern, searchOption, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="pathInfo">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync(QuickIOPathInfo pathInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFileSystemEntries(pathInfo, pattern, searchOption, enumerateOptions));
    }

    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
    /// </summary>
    /// <param name="directoryInfo">The directory to search. </param>
    /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
    /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
    /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
    public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync(QuickIODirectoryInfo directoryInfo, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateFileSystemEntries(directoryInfo.PathInfo, pattern, searchOption, enumerateOptions));
    }
    #endregion
}
