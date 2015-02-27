// <copyright file="QuickIOTransferFileCopyStartedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCopyStartedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information when a file copy process has been started
    /// </summary>
    public class QuickIOTransferFileCopyStartedEventArgs : QuickIOTransferJobWriteWithSourceEventArgs
    {
        /// <summary>
        /// Total bytes of file
        /// </summary>
        public UInt64 TotalBytes { get; private set; }

        /// <summary>
        /// Time transfer of file started
        /// </summary>
        public DateTime TransferStarted { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferFileCopyProgressEventArgs"/>
        /// </summary>
        /// <param name="sourcePath">Affected job</param>
        /// <param name="targetPath">Source file path</param>
        /// <param name="job">Affected job</param>
        /// <param name="totalBytes">Total bytes to transfer</param>
        public QuickIOTransferFileCopyStartedEventArgs( IQuickIOTransferJob job, string sourcePath, string targetPath, Int64 totalBytes )
            : base( job, sourcePath, targetPath )
        {
            TotalBytes = ( UInt64 ) totalBytes;
            TransferStarted = DateTime.Now;
        }
    }
}