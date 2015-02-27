// <copyright file="QuickIODirectoryInfo_Enumerations.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectoryInfo_Enumerations</summary>

using System;
using System.Collections.Generic;
using System.IO;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryInfo
    {
        #region EnumerateDirectoryPaths

        /// <summary>
        /// Returns an enumerable collection of directory names.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public IEnumerable<string> EnumerateDirectoryPaths( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateDirectoryPaths( PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions );
        }

        #endregion

        #region EnumerateDirectories

        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        public IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateDirectories( PathInfo, pattern, searchOption, enumerateOptions );
        }
        #endregion

        #region EnumerateFilePaths

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options</param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public IEnumerable<string> EnumerateFilePaths( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFilePaths( PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions );
        }

        #endregion

        #region EnumerateFiles
        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public IEnumerable<QuickIOFileInfo> EnumerateFiles( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFiles( PathInfo, pattern, searchOption );
        }

        #endregion

        #region EnumerateFileSystemEntryPaths
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">Specifiy depth with <see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="pathFormatReturn">Type of return</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks><b>Requires .NET 4.0 or higher</b><br /><u>Warning:</u> parallel file system browsing on the same hard disk (HDD/SSD) will decrease performance. Use this only on stripped RAIDs or with network shares.</remarks>
        public IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFileSystemEntryPaths( PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions );
        }
        #endregion

        #region EnumerateFileSystemEntries
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        public IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return QuickIODirectory.EnumerateFileSystemEntries( PathInfo, pattern, searchOption );
        }
        #endregion
    }
}
