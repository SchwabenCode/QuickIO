// <copyright file="Win32ApiFindData.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Class representing WIN32 Find Data</summary>

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
        private bool? _isDirectory = null;
        /// <summary>
        /// Returns true if entry is a directory
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public Boolean IsDirectory
        {
            get
            {
                if( _isDirectory == null )
                {
                    _isDirectory = ( dwFileAttributes & FileAttributes.Directory ) != 0;
                }
                return ( bool )_isDirectory;
            }
        }

        /// <summary>
        /// Returns true if entry is a file
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public Boolean IsFile
        {
            get
            {
                return !IsDirectory;
            }
        }

        private ulong? _bytes = null;
        /// <summary>
        /// Returns total size of entry in Bytes
        /// </summary>
        public ulong Bytes
        {
            get
            {
                if( _bytes == null )
                {
                    _bytes = CalculateBytes();
                }
                return ( ulong )_bytes;
            }
        }


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

         /// <summary>
        /// Returns type of entry
        /// </summary>
        public QuickIOFileSystemEntryType FileSystemEntryType
        {
            get { return IsDirectory ? QuickIOFileSystemEntryType.Directory : QuickIOFileSystemEntryType.File; }
        }

        /// <summary>
        /// Returns the total size in bytes
        /// </summary>
        /// <returns></returns>
        public ulong CalculateBytes()
        {

            return ( ( ulong )nFileSizeHigh << 32 | nFileSizeLow );
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
