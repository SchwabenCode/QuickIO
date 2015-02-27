// <copyright file="Win32ApiFindData.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Class representing WIN32 Find Data</summary>

using System;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Structure of File Data given by Win32 API
    /// </summary>
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Auto )]
    [BestFitMapping( false )]
    internal class Win32FindData
    {
        /// <summary>
        /// File Attributes
        /// </summary>
        public System.IO.FileAttributes dwFileAttributes;

        /// <summary>
        /// Last Creation Time (Low DateTime)
        /// </summary>
        public UInt32 ftCreationTime_dwLowDateTime;

        /// <summary>
        /// Last Creation Time (High DateTime)
        /// </summary>
        public UInt32 ftCreationTime_dwHighDateTime;

        /// <summary>
        /// Last Access Time (Low DateTime)
        /// </summary>
        public UInt32 ftLastAccessTime_dwLowDateTime;

        /// <summary>
        /// Last Access Time (High DateTime)
        /// </summary>
        public UInt32 ftLastAccessTime_dwHighDateTime;

        /// <summary>
        /// Last Write Time (Low DateTime)
        /// </summary>
        public UInt32 ftLastWriteTime_dwLowDateTime;

        /// <summary>
        /// Last Write Time (High DateTime)
        /// </summary>
        public UInt32 ftLastWriteTime_dwHighDateTime;

        /// <summary>
        /// File Size High
        /// </summary>
        public UInt32 nFileSizeHigh;

        /// <summary>
        /// File Size Low
        /// </summary>
        public UInt32 nFileSizeLow;

        /// <summary>
        /// Reserved
        /// </summary>
        public Int32 dwReserved0;

        /// <summary>
        /// Reserved
        /// </summary>
        public int dwReserved1;

        /// <summary>
        /// File name
        /// </summary>
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 260 )]
        public string cFileName;

        /// <summary>
        /// Alternate File Name
        /// </summary>
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 14 )]
        public string cAlternateFileName;

        /// <summary>
        /// Creates a new Instance
        /// </summary>
        public static Win32FindData New
        {
            get
            {
                return new Win32FindData();
            }
        }

        /// <summary>
        /// Returns the total size in bytes
        /// </summary>
        /// <returns></returns>
        public UInt64 CalculateBytes()
        {
            return ( ( UInt64 ) nFileSizeHigh << 32 | nFileSizeLow );
        }

        /// <summary>
        /// Gets last write time based on UTC
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastWriteTimeUtc()
        {
            return InternalRawDataHelpers.ConvertDateTime( ftLastWriteTime_dwHighDateTime, ftLastWriteTime_dwLowDateTime );
        }

        /// <summary>
        /// Gets last access time based on UTC
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastAccessTimeUtc()
        {
            return InternalRawDataHelpers.ConvertDateTime( ftLastAccessTime_dwHighDateTime, ftLastAccessTime_dwLowDateTime );
        }

        /// <summary>
        /// Gets the creation time based on UTC
        /// </summary>
        /// <returns></returns>
        public DateTime GetCreationTimeUtc()
        {
            return InternalRawDataHelpers.ConvertDateTime( ftCreationTime_dwHighDateTime, ftCreationTime_dwLowDateTime );
        }


    }
}
