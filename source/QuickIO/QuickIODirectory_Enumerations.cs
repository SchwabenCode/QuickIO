// <copyright file="QuickIODirectory_Enumerations" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIODirectory</summary>

using System;
using System.Collections.Generic;
using System.IO;
using SchwabenCode.QuickIO.Compatibility;
using SchwabenCode.QuickIO.Internal;

#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        #region EnumerateDirectoryPaths
        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateDirectoryPaths( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectoryPaths( new QuickIOPathInfo( path ), searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path in async context.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( new QuickIOPathInfo( path ), searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateDirectoryPaths( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectoryPaths( directoryInfo.PathInfo, searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="directoryInfo">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( directoryInfo.PathInfo, searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateDirectoryPaths( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateDirectoryPaths( info.FullNameUnc, searchOption, enumerateOptions, pathFormatReturn );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( info, searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif
        #endregion

        #region EnumerateDirectories
        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        /// <example>
        /// <code>
        /// // Get subfolders
        /// IEnumerable&gt;QuickIODirectoryInfo&lt; allSubFolders = QuickIODirectory.EnumerateDirectories( @"C:\temp\QuickIO", SearchOption.AllDirectories );
        /// 
        /// foreach ( QuickIODirectoryInfo directoryInfo in allSubFolders )
        /// {
        ///     Console.WriteLine( "Directory found: {0} Readonly: {1}", directoryInfo.FullName, directoryInfo.IsReadOnly );
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectories( new QuickIOPathInfo( path ), searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directories in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( new QuickIOPathInfo( path ), searchOption, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectories( directoryInfo.PathInfo, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directories in a specified path in a seperate task created by the default <see cref="TaskScheduler"/> in async context.
        /// </summary>
        /// <param name="directoryInfo">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( directoryInfo.PathInfo, searchOption, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of directories names in a specified path.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateDirectories( info, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of directories names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( info, searchOption, enumerateOptions ) );
        }
#endif
        #endregion

        #region EnumerateFilePaths
        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateFilePaths( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateFilePaths( new QuickIOPathInfo( path ), searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( new QuickIOPathInfo( path ), searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateFilePaths( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateFilePaths( directoryInfo.PathInfo, searchOption, pathFormatReturn, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( directoryInfo.PathInfo, searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="info">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateFilePaths( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFilePaths( info.FullNameUnc, searchOption, enumerateOptions, pathFormatReturn );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="info">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => InternalQuickIO.EnumerateFilePaths( info.FullNameUnc, searchOption, enumerateOptions, pathFormatReturn ) );
        }
#endif

        #endregion

        #region EnumerateFiles

        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        /// <example>
        /// <code>
        /// // Get subfiles
        /// IEnumerable&lt;QuickIOFileInfo&gt; allSubFiles = QuickIODirectory.EnumerateFiles( @"C:\temp\QuickIO", SearchOption.AllDirectories );
        /// 
        /// foreach ( QuickIOFileInfo fileInfo in allSubFiles )
        /// {
        ///     Console.WriteLine( "File found: {0} Readonly: {1}", fileInfo.FullName, fileInfo.IsReadOnly );
        /// }
        ///</code>
        /// </example>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFiles( new QuickIOPathInfo( path ), searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( new QuickIOPathInfo( path ), searchOption, enumerateOptions ) );
        }
#endif


        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFiles( directoryInfo.PathInfo, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns> #
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( directoryInfo.PathInfo, searchOption, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="info">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFiles( info, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="info">The directory to search. </param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>     /// 
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( QuickIOPathInfo info, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( info, searchOption, enumerateOptions ) );
        }
#endif

        #endregion

        #region EnumerateFileSystemEntryPaths
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntryPaths( new QuickIOPathInfo( path ), searchOption, enumerateOptions, pathFormatReturn );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( new QuickIOPathInfo( path ), searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntryPaths( directoryInfo.PathInfo, searchOption, enumerateOptions, pathFormatReturn );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( directoryInfo.PathInfo, searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="pathInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( QuickIOPathInfo pathInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntryPaths( pathInfo, searchOption, enumerateOptions, pathFormatReturn );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pathInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( QuickIOPathInfo pathInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( pathInfo, searchOption, pathFormatReturn, enumerateOptions ) );
        }
#endif

        #endregion

        #region EnumerateFileSystemEntries
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        ///<example>
        /// <code>
        ///  // Get all with one call
        ///  IEnumerable&lt;KeyValuePair&lt;QuickIOPathInfo, QuickIOFileSystemEntryType&gt;gt; allSubEntries = QuickIODirectory.EnumerateFileSystemEntries( @"C:\temp\QuickIO", SearchOption.AllDirectories );
        ///  foreach ( KeyValuePair&lt;QuickIOPathInfo, QuickIOFileSystemEntryTypegt; subEntry in allSubEntries )
        ///  {
        ///      var pathInfo = subEntry.Key;
        ///      var type = subEntry.Value;
        /// 
        ///      Console.WriteLine( "Entry found: {0} Readonly: {1}", pathInfo.FullName, type );
        ///  }
        /// </code>
        /// </example>
        public static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntries( new QuickIOPathInfo( path ), searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( string path, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( new QuickIOPathInfo( path ), searchOption ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="pathInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( QuickIOPathInfo pathInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntries( pathInfo, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pathInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( QuickIOPathInfo pathInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( pathInfo, searchOption, enumerateOptions ) );
        }
#endif

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntries( directoryInfo.PathInfo, searchOption, enumerateOptions );
        }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public static Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( QuickIODirectoryInfo directoryInfo, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( directoryInfo.PathInfo, searchOption, enumerateOptions ) );
        }
#endif

        #endregion
    }
}
