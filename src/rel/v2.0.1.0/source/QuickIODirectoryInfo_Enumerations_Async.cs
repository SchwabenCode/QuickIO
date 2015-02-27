// <copyright file="QuickIODirectoryInfo_Enumerations_Async.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectoryInfo_Enumerations</summary>

using System;
#if NET40_OR_GREATER
using System.Collections.Generic;
using System.IO;

using SchwabenCode.QuickIO.Compatibility;


using System.Threading.Tasks;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryInfo
    {
        /// <summary>
        /// Returns an enumerable collection of directory names in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param> 
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( pattern,searchOption, pathFormatReturn, enumerateOptions ) );
        }

        /// <summary>
        /// Returns an enumerable collection of directories in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories(pattern, searchOption, enumerateOptions ) );
        }

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<string>> EnumerateFilePathsAsync( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths(pattern, searchOption, pathFormatReturn, enumerateOptions ) );
        }

        /// <summary>
        /// Returns an enumerable collection of files in a specified path in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( pattern, searchOption, enumerateOptions ) );
        }

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntryPathsAsync( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntryPaths( pattern, searchOption, pathFormatReturn, enumerateOptions ) );
        }

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories in a seperate task created by the default <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public Task<IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>>> EnumerateFileSystemEntriesAsync( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFileSystemEntries( pattern, searchOption, enumerateOptions ) );
        }
    }
}
#endif