﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO.Internal
{
    /// <summary>
    /// Provides several methods for internal purposes.
    /// </summary>
    internal static class InternalQuickIOCommon
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
            public const UInt32 InvalidFileAttributes = 0xffffffff;
        }

        /// <summary>
        /// Determines the type based on the attributes of the path
        /// </summary>
        /// <param name="internalPath"><see cref="InternalPath"/></param>
        /// <returns><see cref="QuickIOFileSystemEntryType"/></returns>
        internal static QuickIOFileSystemEntryType DetermineFileSystemEntry( InternalPath internalPath )
        {
            Contract.Requires( internalPath != null );

            Win32FindData findData = InternalQuickIO.GetFindDataFromPath( internalPath );

            return !InternalHelpers.ContainsFileAttribute( findData.dwFileAttributes, FileAttributes.Directory ) ? QuickIOFileSystemEntryType.File : QuickIOFileSystemEntryType.Directory;
        }

        /// <summary>
        /// Determines the type based on the attributes of the handle
        /// </summary>
        /// <param name="findData"><see cref="Win32FindData"/></param>
        /// <returns><see cref="QuickIOFileSystemEntryType"/></returns>
        internal static QuickIOFileSystemEntryType DetermineFileSystemEntry( Win32FindData findData )
        {
            Contract.Requires( findData != null );

            return !InternalHelpers.ContainsFileAttribute( findData.dwFileAttributes, FileAttributes.Directory ) ? QuickIOFileSystemEntryType.File : QuickIOFileSystemEntryType.Directory;
        }


        /// <summary>
        /// Exception Mapping
        /// </summary>
        /// <param name="path"></param>
        /// <param name="errorCode">errorCode</param>
        public static void NativeExceptionMapping( String path, Int32 errorCode )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            if( errorCode == Win32ErrorCodes.ERROR_SUCCESS )
            {
                return;
            }

            var affectedPath = QuickIOPath.ToPathRegular( path );

            // http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx

            switch( errorCode )
            {
                case Win32ErrorCodes.ERROR_PATH_NOT_FOUND:
                case Win32ErrorCodes.ERROR_FILE_NOT_FOUND:
                    throw new PathNotFoundException( Win32ErrorCodes.FormatMessage( errorCode ), affectedPath );

                case Win32ErrorCodes.ERROR_ALREADY_EXISTS:
                    throw new PathAlreadyExistsException( Win32ErrorCodes.FormatMessage( errorCode ), affectedPath );

                case Win32ErrorCodes.ERROR_INVALID_NAME:
                case Win32ErrorCodes.ERROR_DIRECTORY:
                    throw new InvalidPathException( Win32ErrorCodes.FormatMessage( errorCode ), affectedPath );

                case Win32ErrorCodes.ERROR_REM_NOT_LIST:
                case Win32ErrorCodes.ERROR_NETWORK_BUSY:
                case Win32ErrorCodes.ERROR_BUSY:
                case Win32ErrorCodes.ERROR_PATH_BUSY:
                    throw new FileSystemIsBusyException( Win32ErrorCodes.FormatMessage( errorCode ), affectedPath );

                case Win32ErrorCodes.ERROR_DIR_NOT_EMPTY:
                    throw new DirectoryNotEmptyException( Win32ErrorCodes.FormatMessage( errorCode ), affectedPath );

                case Win32ErrorCodes.ERROR_ACCESS_DENIED:
                case Win32ErrorCodes.ERROR_NETWORK_ACCESS_DENIED:
                    throw new UnauthorizedAccessException( "Access to '" + affectedPath + "' denied.", new Win32Exception( errorCode ) );

                case Win32ErrorCodes.ERROR_CURRENT_DIRECTORY:
                case Win32ErrorCodes.ERROR_CANNOT_MAKE:
                    throw new Exception( Win32ErrorCodes.FormatMessage( errorCode ) + affectedPath + "'.", new Win32Exception( errorCode ) );

                default:
                    throw new Exception( "Error on '" + affectedPath + "': See InnerException for details.", new Win32Exception( errorCode ) );
            }
        }
    }
}
