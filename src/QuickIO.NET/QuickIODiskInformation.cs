// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Disk metadata information
    /// </summary>
    public sealed class QuickIODiskInformation
    {
        internal QuickIODiskInformation( UInt64 freeBytes, UInt64 totalBytes, UInt64 totalFreeBytes )
        {
            FreeBytes = freeBytes;
            TotalBytes = totalBytes;
            TotalFreeBytes = totalFreeBytes;
        }

        /// <summary>
        /// Total available number of bytes for the user who executed the API call.
        /// </summary>
        public UInt64 FreeBytes { get;}

        /// <summary>
        /// Total bytes of share
        /// </summary>
        public UInt64 TotalBytes { get; }

        /// <summary>
        /// Total free bytes for all users
        /// </summary>
        public UInt64 TotalFreeBytes { get;  }
    }
}