// <copyright file="QuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides static methods for files and directories</summary>


using System.Collections.Generic;
using System.IO;
using SchwabenCode.QuickIO.Internal;
#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;


namespace SchwabenCode.QuickIO
{
    public static partial class QuickIO
    {
        /// <summary>
        /// Checks whether a file exists
        /// </summary>
        /// <param name="path">File path to check</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static Task<bool> FileExistsAsync( String path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => FileExists( path ) );
        }

        /// <summary>
        /// Checks whether a file exists
        /// </summary>
        /// <param name="pathInfo">File path to check</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static Task<bool> FileExistsAsync( QuickIOPathInfo pathInfo )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => FileExists( pathInfo ) );
        }

        /// <summary>
        /// Checks whether a directory exists
        /// </summary>
        /// <param name="path">Directory path to verify</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for directory but found file.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static Task<bool> DirectoryExistsAsync( String path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => DirectoryExists( path ) );
        }

        /// <summary>
        /// Checks whether a directory exists
        /// </summary>
        /// <param name="pathInfo">Directory path to verify</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for directory but found file.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static Task<bool> DirectoryExistsAsync( QuickIOPathInfo pathInfo )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => DirectoryExists( pathInfo ) );
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
        public static Task CreateFileAsync( String fullName, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0 )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => CreateFile( fullName, fileAccess, fileShare, fileMode, fileAttributes ) );
        }

        /// <summary>
        /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exist.
        /// </summary>
        /// <param name="fullName">The path to the directory.</param>
        /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
        /// <exception cref="PathAlreadyExistsException">Path already exists.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static Task CreateDirectoryAsync( String fullName, bool recursive = false )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => CreateDirectory( fullName, recursive ) );
        }


        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="fullName">The path to the file. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static Task DeleteFileAsync( String fullName )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => DeleteFile( fullName ) );
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static Task DeleteFileAsync( QuickIOPathInfo pathInfo )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => DeleteFile( pathInfo ) );
        }


        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="file">The  file. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static Task DeleteFileAsync( QuickIOFileInfo file )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => DeleteFile( file ) );
        }

        /// <summary>
        /// Removes a directory. 
        /// </summary>
        /// <param name="fullName">The path to the directory. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static Task DeleteDirectoryAsync( String fullName )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => DeleteFile( fullName ) );
        }

        /// <summary>
        /// Removes a directory. 
        /// </summary>
        /// <param name="pathInfo">The path of the directory. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static Task DeleteDirectoryAsync( QuickIOPathInfo pathInfo )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => DeleteFile( pathInfo ) );
        }

        /// <summary>
        /// Removes a directory. 
        /// </summary>
        /// <param name="directoryInfo">The directory. </param>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static Task DeleteDirectoryAsync( QuickIODirectoryInfo directoryInfo )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => DeleteDirectory( directoryInfo ) );
        }

        #region EnumerateFiles
        /// <summary>
        /// Returns a file list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file list from the current directory</returns>
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( path, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a file list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="pathInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file list from the current directory</returns>
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( pathInfo, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a file list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file list from the current directory</returns>
        public static Task<IEnumerable<QuickIOFileInfo>> EnumerateFilesAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFiles( directoryInfo, pattern, searchOption ) );
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
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( path, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a file path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file path list from the current directory</returns>
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( QuickIOPathInfo path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( path, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a file path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a file path list from the current directory</returns>
        public static Task<IEnumerable<string>> EnumerateFilePathsAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateFilePaths( directoryInfo, pattern, searchOption ) );
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
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( path, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a directory list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="pathInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory list from the current directory</returns>
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( pathInfo, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a directory list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory list from the current directory</returns>
        public static Task<IEnumerable<QuickIODirectoryInfo>> EnumerateDirectoriesAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectories( directoryInfo, pattern, searchOption ) );
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
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( path, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a directory path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="pathInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory path list from the current directory</returns>
        public static Task<IEnumerable<string>> EnumerateDirectoryPathsAsync( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( pathInfo, pattern, searchOption ) );
        }

        /// <summary>
        /// Returns a directory path list from the current directory using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="directoryInfo">Rootpath</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.</param>
        /// <returns>Returns a directory path list from the current directory</returns>
        public static Task<IEnumerable<String>> EnumerateDirectoryPathsAsync( QuickIODirectoryInfo directoryInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateDirectoryPaths( directoryInfo, pattern, searchOption ) );
        }
        #endregion

        /// <summary>
        /// Receives <see cref="QuickIODiskInformation"/> of specifies path
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
        public static Task<QuickIODiskInformation> GetDiskInformationAsync( String path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetDiskInformation( path ) );
        }

    }
}
#endif
