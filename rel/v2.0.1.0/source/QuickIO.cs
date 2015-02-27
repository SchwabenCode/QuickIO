// <copyright file="QuickIO.cs" company="Benjamin Abt (  ttp://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides static methods for files and directories</summary>

using System;
using System.Collections.Generic;
using System.IO;
using SchwabenCode.QuickIO.Internal;


namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides static methods for files and directories.
    /// </summary>
    [Obsolete( "It's recommended to use the QuickIOFile, QuickIODirectory classes" )]
    public static partial class QuickIO
    {
        /// <summary>
        /// Checks whether a file exists
        /// </summary>
        /// <param name="path">File path to check</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool FileExists( String path )
        {
            return QuickIOFile.Exists( path );
        }

        /// <summary>
        /// Checks whether a file exists
        /// </summary>
        /// <param name="pathInfo">File path to check</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool FileExists( QuickIOPathInfo pathInfo )
        {
            return QuickIOFile.Exists( pathInfo );
        }

        /// <summary>
        /// Checks whether a directory exists
        /// </summary>
        /// <param name="path">Directory path to verify</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for directory but found file.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool DirectoryExists( String path )
        {
            return QuickIODirectory.Exists( path );
        }

        /// <summary>
        /// Checks whether a directory exists
        /// </summary>
        /// <param name="pathInfo">Directory path to verify</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for directory but found file.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool DirectoryExists( QuickIOPathInfo pathInfo )
        {
            return QuickIODirectory.Exists( pathInfo );
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="fullName">The path to the file.</param>
        /// <param name="fileAccess"><see cref="FileAccess"/> - default <see cref="FileAccess.Write"/></param>
        /// <param name="fileShare"><see cref="FileShare "/> - default <see cref="FileShare.None"/></param>
        /// <param name="fileMode"><see cref="FileMode"/> - default <see cref="FileMode.Create"/></param>
        /// <param name="fileAttributes"><see cref="FileAttributes"/> - default 0 (none)</param>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        public static void CreateFile( String fullName, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0 )
        {
            QuickIOFile.Create( new QuickIOPathInfo( fullName ), fileAccess, fileShare, fileMode, fileAttributes );
        }

        /// <summary>
        /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exist.
        /// </summary>
        /// <param name="fullName">The path to the directory.</param>
        /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
        /// <exception cref="PathAlreadyExistsException">Path already exists.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static void CreateDirectory( String fullName, bool recursive = false )
        {
            QuickIODirectory.Create( new QuickIOPathInfo( fullName ), recursive );
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="fullName">The path to the file. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static void DeleteFile( String fullName )
        {
            InternalQuickIO.DeleteFile( new QuickIOPathInfo( fullName ) );
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static void DeleteFile( QuickIOPathInfo pathInfo )
        {
            InternalQuickIO.DeleteFile( pathInfo );
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="file">The  file. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static void DeleteFile( QuickIOFileInfo file )
        {
            InternalQuickIO.DeleteFile( file );
        }

        /// <summary>
        /// Removes a directory. 
        /// </summary>
        /// <param name="fullName">The path to the directory. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static void DeleteDirectory( String fullName )
        {
            DeleteDirectory( new QuickIOPathInfo( fullName ) );
        }

        /// <summary>
        /// Removes a directory. 
        /// </summary>
        /// <param name="pathInfo">The path of the directory. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static void DeleteDirectory( QuickIOPathInfo pathInfo )
        {
            InternalQuickIO.DeleteDirectory( pathInfo );
        }

        /// <summary>
        /// Removes a directory. 
        /// </summary>
        /// <param name="directoryInfo">The directory. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static void DeleteDirectory( QuickIODirectoryInfo directoryInfo )
        {
            DeleteDirectory( directoryInfo.PathInfo );
        }

        #region EnumerateFiles


        /// <summary>
        /// Returns a file list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file list from the current directory</returns>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateFiles( new QuickIOPathInfo( path ), pattern, searchOption );
        }

        /// <summary>
        /// Returns a file list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="pathInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file list from the current directory</returns>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateFiles( pathInfo, pattern, searchOption );
        }

        /// <summary>
        /// Returns a file list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file list from the current directory</returns>
        public static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateFiles( directoryInfo, pattern, searchOption );
        }
        #endregion

        #region EnumerateFilePaths
        /// <summary>
        /// Returns a file path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file path list from the current directory</returns>
        public static IEnumerable<String> EnumerateFilePaths( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateFilePaths( path, pattern, searchOption );
        }

        /// <summary>
        /// Returns a file path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file path list from the current directory</returns>
        public static IEnumerable<String> EnumerateFilePaths( QuickIOPathInfo path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateFilePaths( path, pattern, searchOption );
        }

        /// <summary>
        /// Returns a file path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file path list from the current directory</returns>
        public static IEnumerable<String> EnumerateFilePaths( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateFilePaths( directoryInfo, pattern, searchOption );
        }
        #endregion

        #region EnumerateDirectories
        /// <summary>
        /// Returns a directory list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory list from the current directory</returns>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateDirectories( new QuickIOPathInfo( path ), pattern, searchOption );
        }

        /// <summary>
        /// Returns a directory list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="pathInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory list from the current directory</returns>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateDirectories( pathInfo, pattern, searchOption );
        }

        /// <summary>
        /// Returns a directory list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory list from the current directory</returns>
        public static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateDirectories( directoryInfo, pattern, searchOption );
        }
        #endregion

        #region EnumerateDirectoryPaths
        /// <summary>
        /// Returns a directory path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory path list from the current directory</returns>
        public static IEnumerable<String> EnumerateDirectoryPaths( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateDirectoryPaths( path, pattern, searchOption );
        }

        /// <summary>
        /// Returns a directory path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="pathInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory path list from the current directory</returns>
        public static IEnumerable<String> EnumerateDirectoryPaths( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateDirectoryPaths( pathInfo, pattern, searchOption );
        }

        /// <summary>
        /// Returns a directory path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory path list from the current directory</returns>
        public static IEnumerable<String> EnumerateDirectoryPaths( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return QuickIODirectory.EnumerateDirectoryPaths( directoryInfo, pattern, searchOption );
        }
        #endregion

        /// <summary>
        /// Receives <see cref="QuickIODiskInformation"/> of specifies path
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
        public static QuickIODiskInformation GetDiskInformation( String path )
        {
            return InternalQuickIO.GetDiskInformation( path );
        }
    }
}
