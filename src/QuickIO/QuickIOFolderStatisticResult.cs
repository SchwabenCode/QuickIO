// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Folder Statistics
    /// </summary>
    public class QuickIOFolderStatisticResult
    {
        /// <summary>
        /// Folder Count
        /// </summary>
        public ulong FolderCount { get; private set; }

        /// <summary>
        /// File Count
        /// </summary>
        public ulong FileCount { get; private set; }

        /// <summary>
        /// Total TotalBytes
        /// </summary>
        public ulong TotalBytes { get; private set; }

        /// <summary>
        /// Creates new Instance of <see cref="QuickIOFolderStatisticResult"/> - internal access only
        /// </summary>
        /// <param name="folderCount">Folder Count</param>
        /// <param name="fileCount">File Count</param>
        /// <param name="size"> Total TotalBytes</param>
        internal QuickIOFolderStatisticResult( UInt64 folderCount, UInt64 fileCount, UInt64 size )
        {
            FolderCount = folderCount;
            FileCount = fileCount;
            TotalBytes = size;
        }
    }
}