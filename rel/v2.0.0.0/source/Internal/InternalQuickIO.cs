// <copyright file="InternalQuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/08/2014</date>
// <summary>Provides internal methods</summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Policy;
using Microsoft.Win32.SafeHandles;
using SchwabenCode.QuickIO.Win32API;
#if NET40_OR_GREATER
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;
#endif
namespace SchwabenCode.QuickIO.Internal
{
    /// <summary>
    /// Provides internal methods. All IO operations are called from here.
    /// </summary>
    [FileIOPermission( SecurityAction.Demand, AllFiles = FileIOPermissionAccess.AllAccess )]
    internal static class InternalQuickIO
    {
        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static void CreateFile( QuickIOPathInfo pathInfo, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0 )
        {
            using ( var fileHandle = Win32SafeNativeMethods.CreateFile( pathInfo.FullNameUnc, fileAccess, fileShare, IntPtr.Zero, fileMode, fileAttributes, IntPtr.Zero ) )
            {
                var win32Error = Marshal.GetLastWin32Error( );
                if ( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="path">Path to the file to remove</param>
        /// <exception cref="FileNotFoundException">This error is fired if the specified file to remove does not exist.</exception>
        public static void DeleteFile( String path )
        {
            var result = Win32SafeNativeMethods.DeleteFile( path );
            var win32Error = Marshal.GetLastWin32Error( );
            if ( !result )
            {
                InternalQuickIOCommon.NativeExceptionMapping( path, win32Error );
            }
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="pathInfo">PathInfo of the file to remove</param>
        /// <exception cref="FileNotFoundException">This error is fired if the specified file to remove does not exist.</exception>
        public static void DeleteFile( QuickIOPathInfo pathInfo )
        {
            RemoveAttribute( pathInfo, FileAttributes.ReadOnly );
            DeleteFile( pathInfo.FullNameUnc );
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="fileInfo">FileInfo of the file to remove</param>
        /// <exception cref="PathNotFoundException">This error will be fired if the specified path or a part of them does not exist.</exception>
        /// <exception cref="FileNotFoundException">This error will be fired when attempting a file to delete, which does not exist.</exception>
        public static void DeleteFile( QuickIOFileInfo fileInfo )
        {
            RemoveAttribute( fileInfo.PathInfo, FileAttributes.ReadOnly );
            DeleteFile( fileInfo.PathInfo );
        }

        /// <summary>
        /// Remove a file attribute
        /// </summary>
        /// <param name="pathInfo">Affected target</param>
        /// <param name="attribute">Attribute to remove</param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static Boolean RemoveAttribute( QuickIOPathInfo pathInfo, FileAttributes attribute )
        {
            if ( ( pathInfo.Attributes & attribute ) == attribute )
            {
                var attributes = pathInfo.Attributes;
                attributes &= ~attribute;
                SetAttributes( pathInfo, attributes );
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a file attribute
        /// </summary>
        /// <param name="pathInfo">Affected target</param>
        /// <param name="attribute">Attribute to add</param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static Boolean AddAttribute( QuickIOPathInfo pathInfo, FileAttributes attribute )
        {
            if ( ( pathInfo.Attributes & attribute ) != attribute )
            {
                var attributes = pathInfo.Attributes;
                attributes |= attribute;
                SetAttributes( pathInfo, attributes );
                return true;
            }

            return false;
        }


        /// <summary>
        /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exists.
        /// </summary>
        /// <param name="pathInfo"><see cref="QuickIOPathInfo"/></param>
        /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static void CreateDirectory( QuickIOPathInfo pathInfo, bool recursive = false )
        {
            if ( recursive )
            {
                var parent = pathInfo.Parent;
                if ( parent.IsRoot )
                {
                    // Root
                    if ( !parent.Exists )
                    {
                        throw new PathNotFoundException( "Root path does not exists. You cannot create a root this way.", parent.FullName );
                    }

                }
                else if ( !parent.Exists )
                {
                    CreateDirectory( parent, recursive );
                }
            }

            if ( pathInfo.Exists )
            {
                return;
            }

            var created = Win32SafeNativeMethods.CreateDirectory( pathInfo.FullNameUnc, IntPtr.Zero );
            var win32Error = Marshal.GetLastWin32Error( );
            if ( !created )
            {
                InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
            }
        }

        /// <summary>
        /// Deletes all files in the given directory.
        /// </summary>
        /// <param name="directoryPath">Path of directory to clear</param>
        /// <param name="recursive">If true all files in all all subfolders included</param>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        /// <exception cref="FileNotFoundException">This error will be fired when attempting a file to delete, which does not exist.</exception>
        public static void DeleteFiles( String directoryPath, bool recursive = false )
        {
            var allFilePaths = EnumerateFilePaths( directoryPath, QuickIOPatternConstants.All, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions.None );
            foreach ( var filePath in allFilePaths )
            {
                DeleteFile( filePath );
            }
        }

        /// <summary>
        /// Deletes all files in the given directory. On request  all contents, too.
        /// </summary>
        /// <param name="pathInfo">PathInfo of directory to clear</param>
        /// <param name="recursive">If <paramref name="recursive"/> is true then all subfolders are also deleted.</param>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        /// <remarks>Function loads every file and attribute. Alls read-only flags will be removed before removing.</remarks>
        public static void DeleteDirectory( QuickIOPathInfo pathInfo, bool recursive = false )
        {
            DeleteDirectory( new QuickIODirectoryInfo( pathInfo ), recursive );
        }

        /// <summary>
        /// Deletes all files in the given directory. On request  all contents, too.
        /// </summary>
        /// <param name="directoryInfo">Info of directory to clear</param>
        /// <param name="recursive">If <paramref name="recursive"/> is true then all subfolders are also deleted.</param>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        /// <remarks>Function loads every file and attribute. Alls read-only flags will be removed before removing.</remarks>
        public static void DeleteDirectory( QuickIODirectoryInfo directoryInfo, bool recursive = false )
        {
            // Contents
            if ( recursive )
            {
                // search all contents
                var subFiles = QuickIODirectory.EnumerateFilePaths( directoryInfo.FullNameUnc, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.UNC, QuickIOEnumerateOptions.None );
                #region delete all files
                foreach ( var item in subFiles )
                {
                    DeleteFile( item );
                }
                #endregion

                var subDirs = QuickIODirectory.EnumerateDirectories( directoryInfo, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions.None );

                foreach ( var subDir in subDirs )
                {
                    DeleteDirectory( subDir, recursive );
                }
            }

            // Remove specified
            var removed = Win32SafeNativeMethods.RemoveDirectory( directoryInfo.FullNameUnc );
            var win32Error = Marshal.GetLastWin32Error( );
            if ( !removed )
            {
                InternalQuickIOCommon.NativeExceptionMapping( directoryInfo.FullName, win32Error );
            }
        }

        #region FindData

        /// <summary>
        /// Gets the <see cref="Win32FindData"/> from the passed path.
        /// </summary>
        /// <param name="pathInfo">Path</param>
        /// <param name="pathFindData"><seealso cref="Win32FindData"/>. Will be null if path does not exist.</param>
        /// <returns>true if path is valid and <see cref="Win32FindData"/> is set</returns>
        /// <remarks>
        /// <see>
        ///     <cref>QuickIOCommon.NativeExceptionMapping</cref>
        /// </see> if invalid handle found.
        /// </remarks>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static bool TryGetFindDataFromPath( QuickIOPathInfo pathInfo, out Win32FindData pathFindData )
        {
            var win32FindData = new Win32FindData( );
            int win32Error;

            //var path = pathInfo.FullNameUnc;
            //if ( pathInfo.IsRoot )
            //{
            //    path = QuickIOPath.Combine( path, QuickIOPatternConstants.All );
            //}

            using ( var fileHandle = FindFirstSafeFileHandle( pathInfo.FullNameUnc, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }

                // Treffer auswerten
                // Ignore . and .. directories
                if ( !InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                {
                    pathFindData = win32FindData;
                    return true;
                }
            }

            pathFindData = null;
            return false;
        }


        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <param name="win32FindData"></param>
        /// <param name="win32Error">Last error code. 0 if no error occurs</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static Win32FileHandle FindFirstSafeFileHandle( string path, Win32FindData win32FindData, out Int32 win32Error )
        {
            var result = Win32SafeNativeMethods.FindFirstFile( path, win32FindData );
            win32Error = Marshal.GetLastWin32Error( );

            return result;
        }

        /// <summary>
        /// Reurns true if passed path exists
        /// </summary>
        /// <param name="pathInfo">Path to check</param>
        public static Boolean Exists( QuickIOPathInfo pathInfo )
        {
            return Exists( pathInfo.FullNameUnc );
        }

        /// <summary>
        /// Reurns true if passed path exists
        /// </summary>
        /// <param name="fullnameUnc">Path to check</param>
        public static Boolean Exists( String fullnameUnc )
        {
            uint attributes = Win32SafeNativeMethods.GetFileAttributes( fullnameUnc );
            return !Equals( attributes, 0xffffffff );
        }

        ///// <summary>
        ///// Returns the <see cref="Win32FindData"/> from specified <paramref name="fullUncPath"/>
        ///// </summary>
        ///// <param name="fullUncPath">Path to the file system entry</param>
        ///// <returns><see cref="Win32FindData"/></returns>
        ///// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        /// 
        /// <summary>
        /// Returns the <see cref="Win32FindData"/> from specified <paramref name="pathInfo"/>
        /// </summary>
        /// <param name="pathInfo">Path to the file system entry</param>
        /// <returns><see cref="Win32FindData"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static Win32FindData GetFindDataFromPath( QuickIOPathInfo pathInfo )
        {
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( pathInfo.FullNameUnc, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }

                // Treffer auswerten
                // Ignore . and .. directories
                if ( !InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                {
                    return win32FindData;
                }
            }

            throw new PathNotFoundException( pathInfo.FullName );
        }

        /// <summary>
        /// Gets the <see cref="Win32FindData"/> from the passed <see cref="QuickIOPathInfo"/>
        /// </summary>
        /// <param name="pathInfo">Path to the file system entry</param>
        /// <param name="estimatedFileSystemEntryType">Estimated Type (File or Directory)</param>
        /// <returns><seealso cref="Win32FindData"/></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder or vise versa.</exception>
        ///<exception cref="PathNotFoundException">No entry found for passed path</exception>  
        public static Win32FindData GetFindDataFromPath( QuickIOPathInfo pathInfo, QuickIOFileSystemEntryType? estimatedFileSystemEntryType )
        {
            return GetFindDataFromPath( pathInfo.FullNameUnc, estimatedFileSystemEntryType );
        }

        /// <summary>
        /// Gets the <see cref="Win32FindData"/> from the passed path.
        /// </summary>
        /// <param name="fullUncPath">Path to the file system entry</param>
        /// <param name="estimatedFileSystemEntryType">Estimated Type (File or Directory)</param>
        /// <returns><seealso cref="Win32FindData"/></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder or vise versa.</exception>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>        
        public static Win32FindData GetFindDataFromPath( String fullUncPath, QuickIOFileSystemEntryType? estimatedFileSystemEntryType )
        {
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( fullUncPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( fullUncPath, win32Error );
                }

                // Treffer auswerten
                // Ignore . and .. directories
                if ( !InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                {

                    // Check for correct type
                    switch ( estimatedFileSystemEntryType )
                    {
                        // Unimportant
                        case null:
                            {
                                return win32FindData;
                            }
                        case QuickIOFileSystemEntryType.Directory:
                            {
                                // Check for directory flag
                                if ( InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                                {
                                    return win32FindData;
                                }
                                throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.File, fullUncPath );
                            }
                        case QuickIOFileSystemEntryType.File:
                            {
                                // Check for directory flag
                                if ( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                                {
                                    return win32FindData;
                                }
                                throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, fullUncPath );
                            }
                    }
                    return win32FindData;

                }
            }
            throw new PathNotFoundException( fullUncPath );
        }
        #endregion

        #region FileHandle
        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="info">Path to the file system entry</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static SafeFileHandle CreateSafeFileHandle( QuickIOPathInfo info )
        {
            return CreateSafeFileHandle( info.FullNameUnc );
        }

        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static SafeFileHandle CreateSafeFileHandle( string path )
        {
            return Win32SafeNativeMethods.CreateFile( path, FileAccess.ReadWrite, FileShare.None, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero );
        }

        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static SafeFileHandle OpenReadWriteFileSystemEntryHandle( string path )
        {
            return Win32SafeNativeMethods.OpenReadWriteFileSystemEntryHandle( path, ( 0x40000000 | 0x80000000 ), FileShare.Read | FileShare.Write | FileShare.Delete, IntPtr.Zero, FileMode.Open, ( 0x02000000 ), IntPtr.Zero );
        }

        #endregion



        #region Enumerations
        #region Directories


        /// <summary>
        /// Determined metadata of directory
        /// </summary>
        /// <param name="pathInfo">Path of the directory</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryMetadata"/> started with the given directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static QuickIODirectoryMetadata EnumerateDirectoryMetadata( QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateDirectoryMetadata( pathInfo.FullNameUnc, pathInfo.FindData, enumerateOptions );
        }

        /// <summary>
        /// Determined metadata of directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="findData"><see cref="Win32FindData"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryMetadata"/> started with the given directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static QuickIODirectoryMetadata EnumerateDirectoryMetadata( String uncDirectoryPath, Win32FindData findData, QuickIOEnumerateOptions enumerateOptions )
        {
            // Results
            var subFiles = new List<QuickIOFileMetadata>( );
            var subDirs = new List<QuickIODirectoryMetadata>( );

            // Match for start of search
            var currentPath = QuickIOPath.Combine( uncDirectoryPath, QuickIOPatternConstants.All );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    if ( win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES )
                    {
                        InternalQuickIOCommon.NativeExceptionMapping( uncDirectoryPath, win32Error );
                    }

                    if ( EnumerationHandleInvalidFileHandle( uncDirectoryPath, enumerateOptions, win32Error ) )
                    {
                        return null;
                    }
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var uncResultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

                    #region File
                    // if it's a file, add to the collection
                    if ( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        var fileMetaData = new QuickIOFileMetadata( uncResultPath, win32FindData );
                        subFiles.Add( fileMetaData );
                    }
                    #endregion
                    #region Directory
                    else
                    {
                        var dir = EnumerateDirectoryMetadata( uncResultPath, win32FindData, enumerateOptions );
                        subDirs.Add( dir );
                    }
                    #endregion
                    // Create new FindData object for next result

                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }

            return new QuickIODirectoryMetadata( uncDirectoryPath, findData, subDirs, subFiles );
        }


        /// <summary>
        /// Determined all subfolders of a directory
        /// </summary>
        /// <param name="pathInfo">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryInfo"/> collection of subfolders</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            // Match for start of search
            var currentPath = QuickIOPath.Combine( pathInfo.FullNameUnc, pattern );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    if ( win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES )
                    {
                        InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                    }

                    if ( EnumerationHandleInvalidFileHandle( pathInfo.FullName, enumerateOptions, win32Error ) )
                    {
                        yield return null;

                    }
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( pathInfo.FullName, win32FindData.cFileName );

                    // Check for Directory
                    if ( InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        yield return new QuickIODirectoryInfo( resultPath, win32FindData );

                        // SubFolders?!
                        if ( searchOption == SearchOption.AllDirectories )
                        {
                            foreach ( var match in EnumerateDirectories( new QuickIOPathInfo( resultPath, win32FindData.cFileName ), pattern, searchOption, enumerateOptions ) )
                            {
                                yield return match;
                            }
                        }
                    }
                    // Create new FindData object for next result
                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }
        }

        /// <summary>
        /// Determined all sub system entries of a directory
        /// </summary>
        /// <param name="pathInfo">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateFileSystemEntries( pathInfo.FullNameUnc, pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Determined all sub system entries of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            // Match for start of search
            var currentPath = QuickIOPath.Combine( uncDirectoryPath, pattern );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    if ( win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES )
                    {
                        InternalQuickIOCommon.NativeExceptionMapping( uncDirectoryPath, win32Error );
                    }

                    if ( EnumerationHandleInvalidFileHandle( uncDirectoryPath, enumerateOptions, win32Error ) )
                    {
                        yield return new KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>( );
                    }
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

                    // Check for Directory
                    if ( InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        yield return new KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>( new QuickIOPathInfo( resultPath ) { FindData = win32FindData }, QuickIOFileSystemEntryType.Directory );

                        // SubFolders?!
                        if ( searchOption == SearchOption.AllDirectories )
                        {
                            foreach ( var match in EnumerateFileSystemEntries( new QuickIOPathInfo( resultPath, win32FindData.cFileName ), pattern, searchOption, enumerateOptions ) )
                            {
                                yield return match;
                            }
                        }
                    }
                    else
                    {
                        yield return new KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>( new QuickIOPathInfo( resultPath ) { FindData = win32FindData }, QuickIOFileSystemEntryType.File );

                    }
                    // Create new FindData object for next result
                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }
        }

        /// <summary>
        /// Determined all sub file system entries of a directory
        /// </summary>
        /// <param name="pathInfo">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<KeyValuePair<String, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            return EnumerateFileSystemEntryPaths( pathInfo.FullNameUnc, pattern, searchOption, enumerateOptions, pathFormatReturn );
        }

        /// <summary>
        /// Determined all sub file system entries of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static IEnumerable<KeyValuePair<String, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            // Match for start of search
            var currentPath = QuickIOPath.Combine( uncDirectoryPath, pattern );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    if ( win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES )
                    {
                        InternalQuickIOCommon.NativeExceptionMapping( uncDirectoryPath, win32Error );
                    }

                    if ( EnumerationHandleInvalidFileHandle( uncDirectoryPath, enumerateOptions, win32Error ) )
                    {
                        yield return new KeyValuePair<string, QuickIOFileSystemEntryType>( );
                    }
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

                    // Check for Directory
                    if ( InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        yield return new KeyValuePair<String, QuickIOFileSystemEntryType>( FormatPathByType( pathFormatReturn, resultPath ), QuickIOFileSystemEntryType.Directory );

                        // SubFolders?!
                        if ( searchOption == SearchOption.AllDirectories )
                        {
                            foreach ( var match in EnumerateFileSystemEntryPaths( resultPath, pattern, searchOption, enumerateOptions, pathFormatReturn ) )
                            {
                                yield return match;
                            }
                        }
                    }
                    else
                    {
                        yield return new KeyValuePair<String, QuickIOFileSystemEntryType>( FormatPathByType( pathFormatReturn, resultPath ), QuickIOFileSystemEntryType.File );

                    }
                    // Create new FindData object for next result
                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }
        }


        /// <summary>
        /// Determined all sub directory paths of a directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of directory paths</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<String> EnumerateDirectoryPaths( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            return FindPaths( path, pattern, searchOption, QuickIOFileSystemEntryType.Directory, enumerateOptions, pathFormatReturn );
        }
        #endregion

        #region Files

        /// <summary>
        /// Determined all files of a directory
        /// </summary>
        /// <param name="pathInfo">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>Collection of files</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIOFileInfo> EnumerateFiles( QuickIOPathInfo pathInfo, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return EnumerateFiles( pathInfo.FullNameUnc, pattern, searchOption, enumerateOptions );
        }

        /// <summary>
        /// Returns the handle by given path and finddata
        /// </summary>
        /// <param name="uncPath">Specified path</param>
        /// <param name="win32FindData">FindData to fill</param>
        /// <param name="win32Error">Win32Error Code. 0 on success</param>
        /// <returns><see cref="Win32FileHandle"/> of specified path</returns>
        private static Win32FileHandle FindFirstFileManaged( String uncPath, Win32FindData win32FindData, out Int32 win32Error )
        {
            var handle = Win32SafeNativeMethods.FindFirstFile( uncPath, win32FindData );
            win32Error = Marshal.GetLastWin32Error( );
            return handle;
        }

        /// <summary>
        /// Determined all files of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of files</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIOFileInfo> EnumerateFiles( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            // Match for start of search
            var currentPath = QuickIOPath.Combine( uncDirectoryPath, pattern );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstFileManaged( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid && EnumerationHandleInvalidFileHandle( uncDirectoryPath, enumerateOptions, win32Error ) )
                {
                    yield return null;
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

                    // Check for Directory
                    if ( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        yield return new QuickIOFileInfo( resultPath, win32FindData );
                    }
                    else
                    {
                        // SubFolders?!
                        if ( searchOption == SearchOption.AllDirectories )
                        {
                            foreach ( var match in EnumerateFiles( resultPath, pattern, searchOption, enumerateOptions ) )
                            {
                                yield return match;
                            }
                        }
                    }
                    // Create new FindData object for next result
                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }
        }

        /// <summary>
        /// Determined all files paths of a directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of file paths</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<String> EnumerateFilePaths( String path, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            return FindPaths( path, pattern, searchOption, QuickIOFileSystemEntryType.File, enumerateOptions, pathFormatReturn );
        }
        #endregion
        #endregion

        #region Private Enumerations > Logic


        /// <summary>
        /// Loads a file from specified path
        /// </summary>
        /// <param name="pathInfo">Full path</param>
        /// <returns><see cref="QuickIOFileInfo"/></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's not a file; it's a directory.</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static QuickIOFileInfo LoadFileFromPathInfo( QuickIOPathInfo pathInfo )
        {
            // Find First file
            Win32FindData findData;
            if ( TryGetFindDataFromPath( pathInfo, out findData ) )
            {
                // Entry found, check for file
                if ( InternalQuickIOCommon.DetermineFileSystemEntry( findData ) == QuickIOFileSystemEntryType.File )
                {
                    return new QuickIOFileInfo( pathInfo, findData );
                }
                throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, pathInfo.FullName );
            }

            // Nothing found
            throw new PathNotFoundException( pathInfo.FullName );
        }

        /// <summary>
        /// Loads a directory from specified path
        /// </summary>
        /// <param name="pathInfo">Full path</param>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's not a directory; it's a file.</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static QuickIODirectoryInfo LoadDirectoryFromPathInfo( QuickIOPathInfo pathInfo )
        {
            // Find First file
            Win32FindData findData;
            if ( TryGetFindDataFromPath( pathInfo, out findData ) )
            {
                // Entry found, check for file
                if ( InternalQuickIOCommon.DetermineFileSystemEntry( findData ) == QuickIOFileSystemEntryType.Directory )
                {
                    return new QuickIODirectoryInfo( pathInfo, findData );
                }
                throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, pathInfo.FullName );
            }

            // Nothing found
            throw new PathNotFoundException( pathInfo.FullName );
        }


        /// <summary>
        /// Search Exection
        /// </summary>
        /// <param name="uncDirectoryPath">Start directory path</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="filterType"><see cref="QuickIOFileSystemEntryType"/></param>
        /// <returns>Collection of path</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static IEnumerable<String> FindPaths( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOFileSystemEntryType? filterType = null, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            // Result Container
            var results = new List<String>( );

            // Match for start of search
            var currentPath = QuickIOPath.Combine( uncDirectoryPath, pattern );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid && EnumerationHandleInvalidFileHandle( uncDirectoryPath, enumerateOptions, win32Error ) )
                {
                    return new List<String>( );
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

                    // if it's a file, add to the collection
                    if ( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        if ( filterType != null && ( ( QuickIOFileSystemEntryType ) filterType == QuickIOFileSystemEntryType.File ) )
                        {
                            // It's a file
                            results.Add( FormatPathByType( pathFormatReturn, resultPath ) );
                        }
                    }
                    else
                    {
                        // It's a directory
                        // Check for search searchFocus directories
                        if ( filterType != null && ( ( QuickIOFileSystemEntryType ) filterType == QuickIOFileSystemEntryType.Directory ) )
                        {
                            results.Add( FormatPathByType( pathFormatReturn, resultPath ) );
                        }

                        // SubFolders?!
                        if ( searchOption == SearchOption.AllDirectories )
                        {
                            var r = new List<String>( FindPaths( resultPath, pattern, searchOption, filterType, enumerateOptions ) );
                            if ( r.Count > 0 )
                            {
                                results.AddRange( r );
                            }

                        }
                    }

                    // Create new FindData object for next result
                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }
            // Return result;
            return results;
        }

        /// <summary>
        /// Handles the options to the fired exception
        /// </summary>
        private static bool EnumerationHandleInvalidFileHandle( string path, QuickIOEnumerateOptions enumerateOptions, int win32Error )
        {
            try
            {
                InternalQuickIOCommon.NativeExceptionMapping( path, win32Error );
            }
            catch ( Exception )
            {
                if ( ( enumerateOptions & QuickIOEnumerateOptions.SuppressAllExceptions ) == QuickIOEnumerateOptions.SuppressAllExceptions )
                {
                    return true;
                }

                throw;
            }
            return false;
        }

        /// <summary>
        /// Formats a path 
        /// </summary>
        /// <param name="pathFormatReturn">Target format type</param>
        /// <param name="uncPath">Path to format</param>
        /// <returns>Formatted path</returns>
        private static string FormatPathByType( QuickIOPathType pathFormatReturn, string uncPath )
        {
            return pathFormatReturn == QuickIOPathType.Regular ? QuickIOPath.ToRegularPath( uncPath ) : uncPath;
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the file on the entry.
        /// </summary>
        /// <param name="pathInfo">The path to the entry. </param>
        /// <returns>The <see cref="FileAttributes"/> of the file on the entry.</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static FileAttributes GetAttributes( QuickIOPathInfo pathInfo )
        {
            return pathInfo.Attributes;
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the file on the entry.
        /// </summary>
        /// <param name="uncPath">The path to the entry. </param>
        /// <returns>The <see cref="FileAttributes"/> of the file on the entry.</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static FileAttributes GetAttributes( String uncPath )
        {
            int win32Error;
            var attrs = SafeGetAttributes( uncPath, out win32Error );
            InternalQuickIOCommon.NativeExceptionMapping( uncPath, win32Error );

            return ( FileAttributes ) attrs;
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the file on the entry.
        /// </summary>
        /// <param name="uncPath">The path to the entry. </param>
        /// <param name="win32Error">Win32 Error Code</param>
        /// <returns>The <see cref="FileAttributes"/> of the file on the entry.</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static uint SafeGetAttributes( String uncPath, out Int32 win32Error )
        {
            uint attributes = Win32SafeNativeMethods.GetFileAttributes( uncPath );
            win32Error = ( attributes ) == 0xffffffff ? Marshal.GetLastWin32Error( ) : 0;
            return attributes;
        }

        /// <summary>
        /// Sets the specified <see cref="FileAttributes"/> of the entry on the specified path.
        /// </summary>
        /// <param name="pathInfo">The path to the entry.</param>
        /// <param name="attributes">A bitwise combination of the enumeration values.</param>
        /// <exception cref="Win32Exception">Unmatched Exception</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static void SetAttributes( QuickIOPathInfo pathInfo, FileAttributes attributes )
        {
            if ( !Win32SafeNativeMethods.SetFileAttributes( pathInfo.FullNameUnc, ( uint ) attributes ) )
            {
                var win32Error = Marshal.GetLastWin32Error( );
                InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
            }
        }

#if NET40_OR_GREATER
        /// <summary>
        /// Sets the specified <see cref="FileAttributes"/> of the entry on the specified path.
        /// </summary>
        /// <param name="pathInfo">The path to the entry.</param>
        /// <param name="attributes">A bitwise combination of the enumeration values.</param>
        /// <exception cref="Win32Exception">Unmatched Exception</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static Task SetAttributesAsync( QuickIOPathInfo pathInfo, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => SetAttributes( pathInfo, attributes ) );
        }
#endif

        #endregion

        /// <summary>
        /// Copies a file and overwrite existing files if desired.
        /// </summary>
        /// <param name="sourceFilePath">Full source path</param>
        /// <param name="targetFilePath">Full target path</param>
        /// <param name="win32Error">Last error occured</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <returns>True if copy succeeded, false if not. Check last Win32 Error to get further information.</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static bool CopyFile( string sourceFilePath, string targetFilePath, out Int32 win32Error, bool overwrite = false )
        {
            var failOnExists = !overwrite;

            // Kopieren
            bool result = Win32SafeNativeMethods.CopyFile( sourceFilePath, targetFilePath, failOnExists );
            win32Error = !result ? Marshal.GetLastWin32Error( ) : 0;
            return result;
        }

        /// <summary>
        /// Determines the statistics of the given directory. This includes the number of files, folders and the total size in bytes.
        /// </summary>
        /// <param name="pathInfo">PathInfo of the directory to generate the statistics.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>Provides the statistics of the directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static QuickIOFolderStatisticResult GetDirectoryStatistics( QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return GetDirectoryStatistics( pathInfo.FullNameUnc, enumerateOptions );
        }

        /// <summary>
        /// Determines metadata of network shares
        /// </summary>
        /// <param name="rootPath">Share to check</param>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        public static QuickIODiskInformation GetDiskInformation( String rootPath )
        {
            UInt64 freeBytes;
            UInt64 totalBytes;
            UInt64 totalFreeBytes;

            /* PInvoke request */
            if ( !Win32SafeNativeMethods.GetDiskFreeSpaceEx( rootPath, out freeBytes, out totalBytes, out totalFreeBytes ) )
            {
                var win32Error = Marshal.GetLastWin32Error( );
                InternalQuickIOCommon.NativeExceptionMapping( rootPath, win32Error );
            }

            return new QuickIODiskInformation( freeBytes, totalBytes, totalFreeBytes );
        }

        /// <summary>
        /// Determines the statistics of the given directory. This includes the number of files, folders and the total size in bytes.        
        /// </summary>
        /// <param name="path">Path to the directory to generate the statistics.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>Provides the statistics of the directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static QuickIOFolderStatisticResult GetDirectoryStatistics( String path, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            UInt64 fileCount = 0;
            UInt64 folderCount = 0;
            UInt64 totalSize = 0;

            // Match for start of search
            var currentPath = QuickIOPath.Combine( path, QuickIOPatternConstants.All );

            // Find First file
            var win32FindData = new Win32FindData( );
            int win32Error;
            using ( var fileHandle = FindFirstSafeFileHandle( currentPath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if ( fileHandle.IsInvalid )
                {
                    if ( EnumerationHandleInvalidFileHandle( currentPath, enumerateOptions, win32Error ) )
                    {
                        return null;
                    }
                }

                // Treffer auswerten
                do
                {
                    // Ignore . and .. directories
                    if ( InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                    {
                        continue;
                    }

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( path, win32FindData.cFileName );

                    // if it's a file, add to the collection
                    if ( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                    {
                        fileCount++;
                        totalSize += win32FindData.CalculateBytes( ); win32FindData.CalculateBytes( );
                    }
                    else
                    {
                        folderCount++;
                        var result = GetDirectoryStatistics( resultPath, enumerateOptions );
                        {
                            folderCount += result.FolderCount;
                            fileCount += result.FileCount;
                            totalSize += result.TotalBytes;
                        }
                    }

                    // Create new FindData object for next result
                    win32FindData = new Win32FindData( );
                } // Search for next entry
                while ( Win32SafeNativeMethods.FindNextFile( fileHandle, win32FindData ) );
            }


            // Return result;
            return new QuickIOFolderStatisticResult( folderCount, fileCount, totalSize );
        }

        /// <summary>
        /// Moves a file
        /// </summary>
        /// <param name="sourceFileName">Full source path</param>
        /// <param name="destFileName">Full target path</param>
        public static void MoveFile( string sourceFileName, string destFileName )
        {
            if ( !Win32SafeNativeMethods.MoveFile( sourceFileName, destFileName ) )
            {
                var win32Error = Marshal.GetLastWin32Error( );
                InternalQuickIOCommon.NativeExceptionMapping( sourceFileName, win32Error );
            }
        }

        #region FileTimes

        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static void SetAllFileTimes( QuickIOPathInfo pathInfo, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            var longCreateTime = creationTimeUtc.ToFileTime( );
            var longAccessTime = lastAccessTimeUtc.ToFileTime( );
            var longWriteTime = lastWriteTimeUtc.ToFileTime( );

            using ( var fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if ( Win32SafeNativeMethods.SetAllFileTimes( fileHandle, ref longCreateTime, ref longAccessTime, ref longWriteTime ) == 0 )
                {
                    var win32Error = Marshal.GetLastWin32Error( );
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Sets the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="utcTime">The time that is to be used (UTC)</param>
        public static void SetCreationTimeUtc( QuickIOPathInfo pathInfo, DateTime utcTime )
        {
            var longTime = utcTime.ToFileTime( );
            using ( var fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if ( !Win32SafeNativeMethods.SetCreationFileTime( fileHandle, ref longTime, IntPtr.Zero, IntPtr.Zero ) )
                {
                    var win32Error = Marshal.GetLastWin32Error( );
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Sets the time at which the file or directory was last written to (UTC)
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="utcTime">The time that is to be used (UTC)</param>
        public static void SetLastWriteTimeUtc( QuickIOPathInfo pathInfo, DateTime utcTime )
        {
            var longTime = utcTime.ToFileTime( );
            using ( var fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if ( !Win32SafeNativeMethods.SetLastWriteFileTime( fileHandle, IntPtr.Zero, IntPtr.Zero, ref longTime ) )
                {
                    var win32Error = Marshal.GetLastWin32Error( );
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Sets the time at which the file or directory was last accessed to (UTC)
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="utcTime">The time that is to be used (UTC)</param>
        public static void SetLastAccessTimeUtc( QuickIOPathInfo pathInfo, DateTime utcTime )
        {
            var longTime = utcTime.ToFileTime( );
            using ( var fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if ( !Win32SafeNativeMethods.SetLastAccessFileTime( fileHandle, IntPtr.Zero, ref longTime, IntPtr.Zero ) )
                {
                    var win32Error = Marshal.GetLastWin32Error( );
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        #endregion


        #region Shares

        /// <summary>
        /// Gets Share Result
        /// </summary>
        /// <param name="machineName">Machine</param>
        /// <param name="level">API level</param>
        /// <param name="buffer">Buffer</param>
        /// <param name="entriesRead">Entries total read</param>
        /// <param name="totalEntries">Entries total</param>
        /// <param name="resumeHandle">Handle</param>
        /// <returns>Error Code</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/bb525387(v=vs.85).aspx</remarks>
        public static int GetShareEnumResult( string machineName, QuickIOShareApiReadLevel level, ref IntPtr buffer, ref int entriesRead, ref int totalEntries, ref int resumeHandle )
        {
            return Win32SafeNativeMethods.NetShareEnum( machineName, ( int ) level, out buffer, -1, out entriesRead, out totalEntries, ref  resumeHandle );
        }

        #endregion
    }
}