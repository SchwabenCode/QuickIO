// <copyright file="QuickIOTransferFileCreationStartedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCreationStartedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information when a file creation process has been started
    /// </summary>
    public class QuickIOTransferFileCreationStartedEventArgs : QuickIOTransferJobWriteEventArgs
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
        /// Creates new instance of <see cref="QuickIOTransferFileCreationStartedEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Target file path</param>
        /// <param name="totalBytes">Total bytes to transfer</param>
        public QuickIOTransferFileCreationStartedEventArgs( IQuickIOTransferJob job, string targetPath, Int64 totalBytes )
            : base( job, targetPath )
        {
            TotalBytes = ( UInt64 ) totalBytes;
            TransferStarted = DateTime.Now;
        }
    }
}