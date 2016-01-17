// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO.Internal
{
    /// <summary>
    /// Various internal methods for the treatment of raw data
    /// </summary>
    internal static class InternalRawDataHelpers
    {
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
            return ( ( ( Int64 ) high ) << 0x20 ) | low;
        }

        /// <summary>
        /// Checks whether a directory supplied by PINvoke is relevant
        /// </summary>
        /// <param name="win32FindData"><see cref="Win32FindData"/></param>
        /// <returns>true if is relevant; otherwise false</returns>
        public static Boolean IsSystemDirectoryEntry( Win32FindData win32FindData )
        {
            Contract.Requires( win32FindData != null );

            if ( win32FindData.cFileName.Length >= 3 )
            {
                return false;
            }

            return ( win32FindData.cFileName == "." || win32FindData.cFileName == ".." );
        }

        /// <summary>
        /// Converts DateTime to Win32 FileTime format
        /// </summary>
        public static Win32FileTime DateTimeToFiletime( DateTime time )
        {
            Win32FileTime ft;
            var fileTime = time.ToFileTimeUtc( );
            ft.DateTimeLow = ( uint ) ( fileTime & 0xFFFFFFFF );
            ft.DateTimeHigh = ( uint ) ( fileTime >> 32 );
            return ft;
        }
    }
}
