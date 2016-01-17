// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using SchwabenCode.QuickIO.PInvoke;
using System.IO;

namespace SchwabenCode.QuickIO.Internal
{
    /// <summary>
    /// Provides internal methods. PathMatchAll IO operations are called from here.
    /// </summary>
    [FileIOPermission( SecurityAction.Demand, AllFiles = FileIOPermissionAccess.AllAccess, AllLocalFiles = FileIOPermissionAccess.AllAccess )]
    internal static partial class InternalQuickIO
    {
        /// <summary>
        /// Determines the statistics of the given directory. This includes the number of files, folders and the total size in bytes.
        /// </summary>
        /// <param name="pathInfo">PathInfo of the directory to generate the statistics.</param>
        /// <param name="enumerateOptions">Options <see cref="QuickIOEnumerateOptions"/></param>
        /// <returns>Provides the statistics of the directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static QuickIOFolderStatisticResult GetDirectoryStatistics( QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines metadata of network shares
        /// </summary>
        /// <param name="rootPath">Share to check</param>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        public static QuickIODiskInformation GetDiskInformation( String rootPath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( rootPath ) );
            Contract.Ensures( Contract.Result<QuickIODiskInformation>() != null );

            UInt64 freeBytes;
            UInt64 totalBytes;
            UInt64 totalFreeBytes;

            /* PInvoke request */
            if( !Win32SafeNativeMethods.GetDiskFreeSpaceEx( rootPath, out freeBytes, out totalBytes, out totalFreeBytes ) )
            {
                InternalQuickIOCommon.NativeExceptionMapping( rootPath, Marshal.GetLastWin32Error() );
            }

            return new QuickIODiskInformation( freeBytes, totalBytes, totalFreeBytes );
        }

        /// <summary>
        /// Moves a file
        /// </summary>
        /// <param name="sourceFileName">Full source path</param>
        /// <param name="destFileName">Full target path</param>
        public static void MoveFile( string sourceFileName, string destFileName )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( sourceFileName ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( destFileName ) );

            if( !Win32SafeNativeMethods.MoveFile( sourceFileName, destFileName ) )
            {
                InternalQuickIOCommon.NativeExceptionMapping( sourceFileName, Marshal.GetLastWin32Error() );
            }
        }


        #region Internal Directory
        public static bool FileExists( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            int win32Error;
            var attrs = InternalQuickIO.SafeGetAttributes( path, out win32Error );

            if( Equals( attrs, 0xffffffff ) )
            {
                return false;
            }

            if( !InternalHelpers.ContainsFileAttribute( FileAttributes.Directory, ( FileAttributes )attrs ) )
            {
                return true;
            }

            throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, path );
        }
        #endregion
    }
}