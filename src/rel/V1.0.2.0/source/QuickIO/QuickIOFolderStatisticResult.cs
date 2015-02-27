// <copyright file="QuickIOFolderStatisticResult.cs" company="Benjamin Abt (http://www.quickIO.NET)">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/13/2014</date>
// <summary>QuickIOFolderStatisticResult</summary>

using System;

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