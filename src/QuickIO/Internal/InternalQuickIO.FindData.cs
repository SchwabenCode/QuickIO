// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.PInvoke;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Internal
{
    internal static partial class InternalQuickIO
    {
 

        /// <summary>
        /// Gets the <see cref="Win32FindData"/> from the passed path.
        /// </summary>
        /// <param name="fullpath">Path</param>
        /// <param name="win32FindData"><seealso cref="Win32FindData"/>. Will be null if path does not exist.</param>
        /// <returns>true if path is valid and <see cref="Win32FindData"/> is set</returns>
        /// <remarks>
        /// <see>
        ///     <cref>QuickIOCommon.NativeExceptionMapping</cref>
        /// </see> if invalid handle found.
        /// </remarks>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static bool TryGetFindDataFromPath( string fullpath, out Win32FindData win32FindData )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( fullpath ) );

            win32FindData = GetFindDataFromPath( fullpath );
            return ( win32FindData != null );
        }


        /// <summary>
        /// Returns the <see cref="Win32FileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <param name="win32FindData"></param>
        /// <param name="win32Error">Last error code. 0 if no error occurs</param>
        /// <returns><see cref="Win32FileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static Win32FileHandle FindFirstSafeFileHandle( string path, Win32FindData win32FindData, out Int32 win32Error )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            Contract.Ensures( Contract.Result<Win32FileHandle>() != null );

            var result = Win32SafeNativeMethods.FindFirstFile( path, win32FindData );
            win32Error = Marshal.GetLastWin32Error();

            return result;
        }

        /// <summary>
        /// Reurns true if passed path exists
        /// </summary>
        /// <param name="path">Path to check</param>
        public static Boolean Exists( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            uint attributes = Win32SafeNativeMethods.GetFileAttributes( path );
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
        /// Returns the <see cref="Win32FindData"/> from specified <paramref name="fullpath"/>
        /// </summary>
        /// <param name="fullpath">Path to the file system entry</param>
        /// <returns><see cref="Win32FindData"/></returns>
        public static Win32FindData SafeGetFindDataFromPath( string fullpath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( fullpath ) );

            Win32FindData win32FindData = new Win32FindData();
            int win32Error;
            using( Win32FileHandle fileHandle = FindFirstSafeFileHandle( fullpath, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( fullpath, win32Error );
                }

                // Treffer auswerten
                // Ignore . and .. directories
                if( !win32FindData.IsSystemDirectoryEntry( ) )
                {
                    return win32FindData;
                }
            }

            return null;
        }

        public static Win32FindData GetFindDataFromPath( string fullpath, QuickIOFileSystemEntryType? estimatedFileSystemEntryType = null )
        {
            Contract.Requires( fullpath != null );
            Contract.Ensures( Contract.Result<Win32FindData>() != null );

            Win32FindData win32FindData = SafeGetFindDataFromPath( fullpath );

            if( win32FindData == null )
            {
                throw new PathNotFoundException( fullpath );
            }

            // Check for correct type
            switch( estimatedFileSystemEntryType )
            {
                case QuickIOFileSystemEntryType.Directory:
                    {
                        // Check for directory flag
                        if( InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                        {
                            return win32FindData;
                        }
                        throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.File, fullpath );
                    }
                case QuickIOFileSystemEntryType.File:
                    {
                        // Check for directory flag
                        if( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                        {
                            return win32FindData;
                        }
                        throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, fullpath );
                    }
                case null:
                default:
                    {
                        return win32FindData;
                    }
            }
        }
    }
}
