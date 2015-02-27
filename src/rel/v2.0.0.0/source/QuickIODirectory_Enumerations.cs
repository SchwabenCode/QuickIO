// <copyright file="QuickIODirectory_Enumerations" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIODirectory</summary>

using System;
using System.Collections.Generic;
using System.IO;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        #region EnumerateDirectoryPaths

        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateDirectoryPaths( string path,String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectoryPaths( new QuickIOPathInfo( path ), pattern, searchOption, pathFormatReturn, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateDirectoryPaths( QuickIODirectoryInfo directoryInfo,String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectoryPaths( directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateDirectoryPaths( QuickIOPathInfo info,String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateDirectoryPaths( info.FullNameUnc, pattern, searchOption, enumerateOptions, pathFormatReturn );
        }
        #endregion

        #region EnumerateDirectories
        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
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
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectories( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectories( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of directories names in a specified path.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateDirectories( info, pattern, searchOption, enumerateOptions );
        }
        #endregion

        #region EnumerateFilePaths
        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateFilePaths( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateFilePaths( new QuickIOPathInfo( path ), pattern, searchOption, pathFormatReturn, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateFilePaths( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateFilePaths( directoryInfo.PathInfo, pattern, searchOption, pathFormatReturn, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="info">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<string> EnumerateFilePaths( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFilePaths( info.FullNameUnc, pattern, searchOption, enumerateOptions, pathFormatReturn );
        }
        #endregion

        #region EnumerateFiles

        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
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
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFiles( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions );
        }


        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383458(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFiles( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of files in a specified path.
        /// </summary>
        /// <param name="info">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path.</returns>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIOPathInfo info, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFiles( info, pattern, searchOption, enumerateOptions );
        }

        #endregion

        #region EnumerateFileSystemEntryPaths
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntryPaths( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions, pathFormatReturn );
        }

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntryPaths( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions, pathFormatReturn );
        }

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="pathInfo">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntryPaths( pathInfo, pattern, searchOption, enumerateOptions, pathFormatReturn );
        }

        #endregion

        #region EnumerateFileSystemEntries
        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
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
        public static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( string path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntries( new QuickIOPathInfo( path ), pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="pathInfo">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntries( pathInfo, pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="directoryInfo">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateFileSystemEntries( directoryInfo.PathInfo, pattern, searchOption, enumerateOptions );
        }

        #endregion
    }
}
