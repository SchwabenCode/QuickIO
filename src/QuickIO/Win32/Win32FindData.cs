// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using System.IO;

namespace SchwabenCode.QuickIO.Win32
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
        public uint ftCreationTime_dwLowDateTime;

        /// <summary>
        /// Last Creation Time (High DateTime)
        /// </summary>
        public uint ftCreationTime_dwHighDateTime;

        /// <summary>
        /// Last Access Time (Low DateTime)
        /// </summary>
        public uint ftLastAccessTime_dwLowDateTime;

        /// <summary>
        /// Last Access Time (High DateTime)
        /// </summary>
        public uint ftLastAccessTime_dwHighDateTime;

        /// <summary>
        /// Last Write Time (Low DateTime)
        /// </summary>
        public uint ftLastWriteTime_dwLowDateTime;

        /// <summary>
        /// Last Write Time (High DateTime)
        /// </summary>
        public uint ftLastWriteTime_dwHighDateTime;

        /// <summary>
        /// File Size High
        /// </summary>
        public uint nFileSizeHigh;

        /// <summary>
        /// File Size Low
        /// </summary>
        public uint nFileSizeLow;

        /// <summary>
        /// Reserved
        /// </summary>
        public uint dwReserved0;

        /// <summary>
        /// Reserved
        /// </summary>
        public uint dwReserved1;

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
    }
}
