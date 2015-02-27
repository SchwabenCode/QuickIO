
using System.Collections.Generic;
using System.IO;

using SchwabenCode.QuickIO.Compatibility;

#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryInfo
    {
        #region EnumerateDirectoryPaths

        /// <summary>
        /// Returns an enumerable collection of directory names.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public IEnumerable<string> EnumerateDirectoryPaths( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateDirectoryPaths( PathInfo, searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directory names in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param> 
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( searchOption, pathFormatReturn, enumerateOptions ) );
        }

#endif
        #endregion

        #region EnumerateDirectories

        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateDirectories( PathInfo, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directories in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( searchOption, enumerateOptions ) );
        }
#endif
        #endregion

        #region EnumerateFilePaths

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public IEnumerable<string> EnumerateFilePaths( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFilePaths( PathInfo, searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<string>> EnumerateFilePathsAsync( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif
        #endregion

        #region EnumerateFiles
        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public IEnumerable<QuickIOFileInfo> EnumerateFiles( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFiles( PathInfo, searchOption );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( searchOption, enumerateOptions ) );
        }
#endif
        #endregion

        #region EnumerateFileSystemEntryPaths
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFileSystemEntryPaths( PathInfo, searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif
        #endregion

        #region EnumerateFileSystemEntries
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        public IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFileSystemEntries( PathInfo, searchOption );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( searchOption ) );
        }
#endif
        #endregion
    }
}
