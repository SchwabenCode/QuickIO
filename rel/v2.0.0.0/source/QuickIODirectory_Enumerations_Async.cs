// <copyright file="QuickIODirectory_Enumerations_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory</summary>
#if NET40_OR_GREATER
using System;
using System.Collections.Generic;
using System.IO;
using SchwabenCode.QuickIO.Compatibility;
using SchwabenCode.QuickIO.Internal;

using System.Threading.Tasks;


namespace SchwabenCode.QuickIO
{
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
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( new QuickIOPathInfo( path ), pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( info, pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( info, pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( new QuickIOPathInfo( path ), pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => InternalQuickIO.EnumerateFilePaths( info.FullNameUnc, pattern, searchOption, enumerateOptions, pathFormatReturn ) );
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
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( info, pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( new QuickIOPathInfo( path ), pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( pathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions ) );
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
        public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( pathInfo, pattern, searchOption, enumerateOptions ) );
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
        public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions ) );
        }
        #endregion
    }
}
#endif