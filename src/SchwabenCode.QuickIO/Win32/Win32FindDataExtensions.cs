// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace SchwabenCode.QuickIO.Win32
{
    public static class Win32FindDataExtensions
    {
        /// <summary>
        /// Returns true if entry is a directory
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public static Boolean IsDirectory( this Win32FindData source )
        {
            return ( source.dwFileAttributes & FileAttributes.Directory ) != 0;
        }

        /// <summary>
        /// Returns true if entry is a file
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public static Boolean IsFile( this Win32FindData source )
        {
            return !IsDirectory( source );
        }
        /// <summary>
        /// Returns total size of entry in Bytes
        /// </summary>
        public static ulong GetBytes( this Win32FindData source )
        {
            return ( ( ulong )source.nFileSizeHigh << 32 | source.nFileSizeLow );
        }

        /// <summary>
        /// Returns type of entry
        /// </summary>
        public static QuickIOFileSystemEntryType GetFileSystemEntryType( this Win32FindData source )
        {
            return ( IsDirectory( source ) ? QuickIOFileSystemEntryType.Directory : QuickIOFileSystemEntryType.File );
        }

        /// <summary>
        /// Gets last write time based on UTC
        /// </summary>
        /// <returns></returns>
        public static DateTime GetLastWriteTimeUtc( this Win32FindData source )
        {
            return ConvertDateTime( source.ftLastWriteTime_dwHighDateTime, source.ftLastWriteTime_dwLowDateTime );
        }

        /// <summary>
        /// Gets last access time based on UTC
        /// </summary>
        /// <returns></returns>
        public static DateTime GetLastAccessTimeUtc( this Win32FindData source )
        {
            return ConvertDateTime( source.ftLastAccessTime_dwHighDateTime, source.ftLastAccessTime_dwLowDateTime );
        }

        /// <summary>
        /// Gets the creation time based on UTC
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCreationTimeUtc( this Win32FindData source )
        {
            return ConvertDateTime( source.ftCreationTime_dwHighDateTime, source.ftCreationTime_dwLowDateTime );
        }

        /// <summary>
        /// Converts the PInvoke information into <see cref="DateTime"/>
        /// </summary>
        /// <param name="high"><see cref="Win32FindData.ftLastWriteTime_dwHighDateTime"/> of <see cref="Win32FindData"/></param>
        /// <param name="low"><see cref="Win32FindData.ftLastWriteTime_dwLowDateTime"/> of <see cref="Win32FindData"/></param>
        /// <returns><see cref="DateTime"/></returns>
        internal static DateTime ConvertDateTime( UInt32 high, UInt32 low )
        {
            return DateTime.FromFileTimeUtc( CombineHighLowInts( high, low ) );
        }

        /// <summary>
        /// Merges the PInvoke information
        /// </summary>
        /// <param name="high"><see cref="Win32FindData.ftLastWriteTime_dwHighDateTime"/> of <see cref="Win32FindData"/></param>
        /// <param name="low"><see cref="Win32FindData.ftLastWriteTime_dwLowDateTime"/> of <see cref="Win32FindData"/></param>
        internal static Int64 CombineHighLowInts( UInt32 high, UInt32 low )
        {
            return ( ( ( Int64 )high ) << 0x20 ) | low;
        }



        /// <summary>
        /// Converts DateTime to Win32 FileTime format
        /// </summary>
        public static Win32FileTime DateTimeToFiletime( DateTime time )
        {
            Win32FileTime ft;
            var fileTime = time.ToFileTimeUtc();
            ft.DateTimeLow = ( uint )( fileTime & 0xFFFFFFFF );
            ft.DateTimeHigh = ( uint )( fileTime >> 32 );
            return ft;
        }

        /// <summary>
        /// Checks whether a directory supplied by PINvoke is relevant
        /// </summary>
        /// <param name="win32FindData"><see cref="Win32FindData"/></param>
        /// <returns>true if is relevant; otherwise false</returns>
        public static Boolean IsSystemDirectoryEntry( this Win32FindData win32FindData )
        {
            Contract.Requires( win32FindData != null );

            return ( win32FindData.cFileName == "." || win32FindData.cFileName == ".." );
        }
    }
}
