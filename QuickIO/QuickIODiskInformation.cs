// <copyright file="QuickIODiskInformation.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/04/2014</date>
// <summary>QuickIODiskInformation</summary>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Disk metadata information
    /// </summary>
    public sealed partial class QuickIODiskInformation
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
        public UInt64 FreeBytes { get; private set; }

        /// <summary>
        /// Total bytes of share
        /// </summary>
        public UInt64 TotalBytes { get; private set; }

        /// <summary>
        /// Total free bytes for all users
        /// </summary>
        public UInt64 TotalFreeBytes { get; private set; }
    }
}