// <copyright file="QuickIOTransferFileCreationFinishedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCreationFinishedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information when a file creation operation has been finished successfully
    /// </summary>
    public class QuickIOTransferFileCreationFinishedEventArgs : QuickIOTransferJobWriteEventArgs
    {
        /// <summary>
        /// Estimated Timestamp when transfer is finished
        /// </summary>
        public DateTime TransferFinished { get; private set; }


        private TimeSpan? _duration;

        /// <summary>
        /// Live transfer duration
        /// </summary>
        public TimeSpan Duration => ( TimeSpan ) ( _duration ?? ( _duration = TransferFinished.Subtract( TransferStarted ) ) );

        private double? _bytesPerSecond;

        /// <summary>
        /// Live bytes per second
        /// </summary>
        public Double BytesPerSecond => ( Double ) ( _bytesPerSecond ?? ( _bytesPerSecond = ( TotalBytes / Duration.TotalSeconds ) ) );

        /// <summary>
        /// Total bytes of file
        /// </summary>
        public long TotalBytes { get; }


        /// <summary>
        /// Time transfer of file started
        /// </summary>
        public DateTime TransferStarted { get; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferFileCreationFinishedEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Target file path</param>
        /// <param name="totalBytes">Total bytes to transfer</param>
        /// <param name="transferStarted"></param>
        public QuickIOTransferFileCreationFinishedEventArgs( IQuickIOTransferJob job, string targetPath, long totalBytes, DateTime transferStarted )
            : base( job, targetPath )
        {
            TotalBytes = totalBytes;
            TransferStarted = transferStarted;
            TransferFinished = DateTime.Now;
        }
    }
}