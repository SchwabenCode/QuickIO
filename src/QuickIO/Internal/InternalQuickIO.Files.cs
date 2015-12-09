// <copyright file="InternalQuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/08/2014</date>
// <summary>Provides internal methods</summary>

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.Pinvoke;
using System.Collections.Generic;
using System.Linq;

namespace SchwabenCode.QuickIO.Internal
{
    internal static partial class InternalQuickIO
    {
        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static void CreateFile( String path, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0 )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            using( var fileHandle = Win32SafeNativeMethods.CreateFile( path, fileAccess, fileShare, IntPtr.Zero, fileMode, fileAttributes, IntPtr.Zero ) )
            {
                var win32Error = Marshal.GetLastWin32Error();
                if( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( path, win32Error );
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
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Remove all attributes
            RemoveAllFileAttributes( path );

            if( !Win32SafeNativeMethods.DeleteFile( path ) )
            {
                InternalQuickIOCommon.NativeExceptionMapping( path, Marshal.GetLastWin32Error() );
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
            Contract.Requires( !String.IsNullOrWhiteSpace( directoryPath ) );

            IEnumerable<string> allFilePaths = EnumerateFilePaths( directoryPath, QuickIOPatterns.PathMatchAll, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions.None );
            foreach( var filePath in allFilePaths )
            {
                DeleteFile( filePath );
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
        internal static IEnumerable<String> EnumerateFilePaths( String path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<IEnumerable<String>>() != null );

            throw new NotImplementedException();
            //return EnumerateSystemPaths( path, pattern, searchOption, QuickIOFileSystemEntryType.File, enumerateOptions, pathFormatReturn );
        }

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
            Contract.Requires( !String.IsNullOrWhiteSpace( sourceFilePath ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( targetFilePath ) );

            if( !Win32SafeNativeMethods.CopyFile( sourceFilePath, targetFilePath, !overwrite ) )
            {
                win32Error = Marshal.GetLastWin32Error();
                return false;
            }

            win32Error = 0;
            return true;
        }
    }
}