using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.Pinvoke;
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
        /// <param name="internalPath">Path</param>
        /// <param name="win32FindData"><seealso cref="Win32FindData"/>. Will be null if path does not exist.</param>
        /// <returns>true if path is valid and <see cref="Win32FindData"/> is set</returns>
        /// <remarks>
        /// <see>
        ///     <cref>QuickIOCommon.NativeExceptionMapping</cref>
        /// </see> if invalid handle found.
        /// </remarks>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static bool TryGetFindDataFromPath( InternalPath internalPath, out Win32FindData win32FindData )
        {
            Contract.Requires( internalPath != null );

            win32FindData = GetFindDataFromPath( internalPath );
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
            Contract.Requires( win32FindData != null );

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
        /// Returns the <see cref="Win32FindData"/> from specified <paramref name="path"/>
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <returns><see cref="Win32FindData"/></returns>
        public static Win32FindData SafeGetFindDataFromPath( InternalPath internalPath )
        {
            Contract.Requires( internalPath != null );

            Win32FindData win32FindData = new Win32FindData();
            int win32Error;
            using( var fileHandle = FindFirstSafeFileHandle( internalPath.Path, win32FindData, out win32Error ) )
            {
                // Take care of invalid handles
                if( fileHandle.IsInvalid )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( internalPath.Path, win32Error );
                }

                // Treffer auswerten
                // Ignore . and .. directories
                if( !InternalRawDataHelpers.IsSystemDirectoryEntry( win32FindData ) )
                {
                    return win32FindData;
                }
            }

            return null;
        }

        public static Win32FindData GetFindDataFromPath( InternalPath internalPath, QuickIOFileSystemEntryType? estimatedFileSystemEntryType = null )
        {
            Contract.Requires( internalPath != null );
            Contract.Ensures( Contract.Result<Win32FindData>() != null );

            Win32FindData win32FindData = SafeGetFindDataFromPath( internalPath );

            if( win32FindData == null )
            {
                throw new PathNotFoundException( internalPath.Path );
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
                        throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.File, internalPath.Path );
                    }
                case QuickIOFileSystemEntryType.File:
                    {
                        // Check for directory flag
                        if( !InternalHelpers.ContainsFileAttribute( win32FindData.dwFileAttributes, FileAttributes.Directory ) )
                        {
                            return win32FindData;
                        }
                        throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, internalPath.Path );
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
