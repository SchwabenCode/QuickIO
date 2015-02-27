// <copyright file="QuickIOCommon.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/23/2014</date>
// <summary>Provides several methods for internal purposes.</summary>

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides several methods for internal purposes.
    /// </summary>
    internal static partial class QuickIOCommon
    {
        /// <summary>
        /// Common Constants
        /// </summary>
        public static class Constants
        {
            /// <summary>
            /// Represents return value of invalid request of get the file attributes of a system entry.
            /// Is equal to UInt32.MaxValue
            /// See http://msdn.microsoft.com/en-us/library/windows/desktop/aa364944(v=vs.85).aspx
            /// </summary>
            public const UInt32 INVALID_FILE_ATTRIBUTES = 0xffffffff;
        }

        /// <summary>
        /// Determines the type based on the attributes of the path
        /// </summary>
        /// <param name="pathInfo"><see cref="QuickIOPathInfo"/></param>
        /// <returns><see cref="QuickIOFileSystemEntryType"/></returns>
        internal static QuickIOFileSystemEntryType DetermineFileSystemEntry( QuickIOPathInfo pathInfo )
        {
            var findData = InternalQuickIO.GetFindDataFromPath( pathInfo.FullNameUnc );

            return !InternalHelpers.ContainsFileAttribute( findData.dwFileAttributes, FileAttributes.Directory ) ? QuickIOFileSystemEntryType.File : QuickIOFileSystemEntryType.Directory;
        }

        /// <summary>
        /// Determines the type based on the attributes of the handle
        /// </summary>
        /// <param name="findData"><see cref="Win32FindData"/></param>
        /// <returns><see cref="QuickIOFileSystemEntryType"/></returns>
        internal static QuickIOFileSystemEntryType DetermineFileSystemEntry( Win32FindData findData )
        {
            return !InternalHelpers.ContainsFileAttribute( findData.dwFileAttributes, FileAttributes.Directory ) ? QuickIOFileSystemEntryType.File : QuickIOFileSystemEntryType.Directory;
        }

        /// <summary>
        /// Reurns true if passed path exists
        /// </summary>
        /// <param name="path">Path to check</param>
        public static Boolean Exists( String path )
        {
            try
            {
                InternalQuickIO.GetFindDataFromPath( path );
            }
            catch ( PathNotFoundException )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the path with the expected system entry type exists
        /// </summary>
        /// <param name="path">Path to a file or a directory</param>
        /// <param name="systemEntryType"><see cref="QuickIOFileSystemEntryType"/> you are searching for</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's not the type you're searching for.</exception>
        public static Boolean Exists( String path, QuickIOFileSystemEntryType systemEntryType )
        {
            return Exists( new QuickIOPathInfo( path ), systemEntryType );
        }

        /// <summary>
        /// Checks whether the path with the expected system entry type exists
        /// </summary>
        /// <param name="pathInfo">A file or a directory</param>
        /// <param name="systemEntryType"><see cref="QuickIOFileSystemEntryType"/> you are searching for</param>
        /// <returns></returns>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's not the type you're searching for.</exception>
        public static Boolean Exists( QuickIOPathInfo pathInfo, QuickIOFileSystemEntryType systemEntryType )
        {
            switch ( systemEntryType )
            {
                case QuickIOFileSystemEntryType.Directory:
                    try
                    {
                        InternalQuickIO.LoadDirectoryFromPathInfo( pathInfo );
                        return true;
                    }
                    catch ( PathNotFoundException )
                    {
                        return false;
                    }

                case QuickIOFileSystemEntryType.File:
                    try
                    {
                        InternalQuickIO.LoadFileFromPathInfo( pathInfo );
                        return true;
                    }
                    catch ( PathNotFoundException )
                    {
                        return false;
                    }

                default:
                    throw new ArgumentException( "Unknown QuickIOFileSystemEntryType passed." );
            }
        }

        /// <summary>
        /// Exception Mapping
        /// </summary>
        /// <param name="path">Error path</param>
        public static void NativeExceptionMapping( String path )
        {
            // Get error (PInvoke Signature > SetLastError has to be true!
            NativeExceptionMapping( path, Marshal.GetLastWin32Error( ) );
        }

        /// <summary>
        /// Exception Mapping
        /// </summary>
        /// <param name="path"></param>
        /// <param name="errorCode">errorCode</param>
        public static void NativeExceptionMapping( String path, Int32 errorCode )
        {
            // http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx

            switch ( errorCode )
            {
                case Win32ErrorCodes.ERROR_SUCCESS:
                    return;

                case Win32ErrorCodes.ERROR_PATH_NOT_FOUND:
                case Win32ErrorCodes.ERROR_FILE_NOT_FOUND:
                    throw new PathNotFoundException( Win32ErrorCodes.FormatMessage( errorCode ), path );

                case Win32ErrorCodes.ERROR_ALREADY_EXISTS:
                    throw new PathAlreadyExistsException( Win32ErrorCodes.FormatMessage( errorCode ), path );

                case Win32ErrorCodes.ERROR_INVALID_NAME:
                case Win32ErrorCodes.ERROR_DIRECTORY:
                    throw new InvalidPathException( Win32ErrorCodes.FormatMessage( errorCode ), path );

                case Win32ErrorCodes.ERROR_DIR_NOT_EMPTY:
                    throw new DirectoryNotEmptyException( Win32ErrorCodes.FormatMessage( errorCode ), path );

                case Win32ErrorCodes.ERROR_ACCESS_DENIED:
                case Win32ErrorCodes.ERROR_NETWORK_ACCESS_DENIED:
                    throw new UnauthorizedAccessException( "File '" + path + "' not found.", new Win32Exception( errorCode ) );

                case Win32ErrorCodes.ERROR_REM_NOT_LIST:
                case Win32ErrorCodes.ERROR_CURRENT_DIRECTORY:
                case Win32ErrorCodes.ERROR_CANNOT_MAKE:
                    throw new Exception( Win32ErrorCodes.FormatMessage( errorCode ) + path + "'.", new Win32Exception( errorCode ) );

                default:
                    throw new Exception( "See InnerException for details.", new Win32Exception( errorCode ) );
            }
        }

    }
}
