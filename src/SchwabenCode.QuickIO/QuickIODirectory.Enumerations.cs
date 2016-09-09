// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using SchwabenCode.QuickIO.Core;
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
        public static IEnumerable<string> EnumerateDirectoryPaths( string path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( pattern ) );

            return InternalEnumerateFileSystem.EnumerateSystemPaths( path, pattern, searchOption, enumerateOptions, pathFormatReturn, QuickIOFileSystemEntryType.Directory );
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
        public static IEnumerable<string> EnumerateDirectoryPaths( QuickIODirectoryInfo info, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( info != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( pattern ) );

            return EnumerateDirectoryPaths( info.FullNameUnc, pattern, searchOption, pathFormatReturn, enumerateOptions );
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
        ///     Console.WriteLine( "Directory found: {0} Readonly: {1}", directoryInfo.Path, directoryInfo.IsReadOnly );
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( string path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalEnumerateFileSystem.EnumerateDirectories( path, pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns an enumerable collection of directories in a specified path.
        /// </summary>
        /// <param name="info">The directory to search.</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>An enumerable collection of the full names (including paths) for the directories in the directory specified by path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383304(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIODirectoryInfo info, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectories( info.FullNameUnc, pattern, searchOption, enumerateOptions );
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
        public static IEnumerable<string> EnumerateFilePaths( string path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalEnumerateFileSystem.EnumerateSystemPaths( path, pattern, searchOption, enumerateOptions, pathFormatReturn, QuickIOFileSystemEntryType.File );
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
        public static IEnumerable<string> EnumerateFilePaths( QuickIODirectoryInfo info, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( info != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( pattern ) );

            return EnumerateFilePaths( info.FullNameUnc, pattern, searchOption, pathFormatReturn, enumerateOptions );
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
        ///     Console.WriteLine( "File found: {0} Readonly: {1}", fileInfo.Path, fileInfo.IsReadOnly );
        /// }
        ///</code>
        /// </example>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( string path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( pattern ) );

            return InternalEnumerateFileSystem.EnumerateFiles( path, pattern, searchOption, enumerateOptions );
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
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles(QuickIODirectoryInfo directoryInfo,
            String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly,
            QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
        {
            Contract.Requires(directoryInfo != null);
            Contract.Requires(!String.IsNullOrWhiteSpace(pattern));

            return EnumerateFiles(directoryInfo.FullNameUnc, pattern, searchOption, enumerateOptions);
        }

        #endregion

        /// <summary>
        /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The directory to search. </param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.The default value is TopDirectoryOnly.</param>
        /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383459(v=vs.110).aspx</remarks>
        public static IEnumerable<QuickIOFileSystemEntry> EnumerateFileSystemEntries( string path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( pattern ) );

            return InternalEnumerateFileSystem.EnumerateFileSystemEntries( path, pattern, searchOption, enumerateOptions );
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
        public static IEnumerable<QuickIOFileSystemEntry> EnumerateFileSystemEntries( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( directoryInfo != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( pattern ) );

            return EnumerateFileSystemEntries( directoryInfo.FullNameUnc, pattern, searchOption, enumerateOptions );
        }

    }
}
