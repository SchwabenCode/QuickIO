// <copyright file="QuickIOTransferFileCreationProgressEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCreationProgressEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Live progress information during file transfer.
    /// </summary>
    public class QuickIOTransferFileCreationProgressEventArgs : QuickIOTransferJobWriteEventArgs
    {
        /// <summary>
        /// Total bytes of file transfered
        /// </summary>
        public ulong BytesTransfered { get; private set; }

        /// <summary>
        /// Time the progress event was fired
        /// </summary>
        public DateTime ProgressTimestamp { get; private set; }

        private DateTime? _estimatedFinishTimestamp;

        /// <summary>
        /// Estimated Timestamp when transfer is finished
        /// </summary>
        public DateTime EstimatedFinishTimestamp
        {
            get
            {
                return ( DateTime ) ( _estimatedFinishTimestamp ?? ( _estimatedFinishTimestamp = TransferStartedTimestamp.Add( EstimatedDuration ) ) );
            }
        }

        private TimeSpan? _estimatedDuration;
        /// <summary>
        /// Estimated Duration
        /// </summary>
        public TimeSpan EstimatedDuration
        {
            get
            {
                return ( TimeSpan ) ( _estimatedDuration ?? ( _estimatedDuration = TimeSpan.FromSeconds( ( TotalBytes / BytesPerSecond ) ) ) );
            }
        }

        private double? _percentage;

        /// <summary>
        /// Total percentage
        /// </summary>
        public Double Percentage
        {
            get
            {
                if ( _percentage == null )
                {
                    if ( BytesTransfered == 0 )
                    {
                        _percentage = 0;
                    }
                    else if ( BytesTransfered == TotalBytes )
                    {
                        return 100;
                    }
                    else
                    {
                        _percentage = BytesTransfered * 1.0 / TotalBytes * 100.0;
                    }
                }

                return ( Double ) _percentage;
            }
        }

        private TimeSpan? _duration;

        /// <summary>
        /// Live transfer duration
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return ( TimeSpan ) ( _duration ?? ( _duration = ProgressTimestamp.Subtract( TransferStartedTimestamp ) ) );
            }
        }


        private double? _bytesPerSecond;

        /// <summary>
        /// Live bytes per second
        /// </summary>
        public Double BytesPerSecond
        {
            get
            {
                return ( Double ) ( _bytesPerSecond ?? ( _bytesPerSecond = ( BytesTransfered / Duration.TotalSeconds ) ) );
            }
        }

        /// <summary>
        /// Total bytes of file
        /// </summary>
        public UInt64 TotalBytes { get; private set; }


        /// <summary>
        /// Time transfer of file started
        /// </summary>
        public DateTime TransferStartedTimestamp { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferFileCreationProgressEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Target file path</param>
        /// <param name="totalBytes">Total bytes to transfer</param>
        /// <param name="bytesTransfered">Total bytes transfered</param>
        /// <param name="transferStarted"></param>
        public QuickIOTransferFileCreationProgressEventArgs( IQuickIOTransferJob job, string targetPath, Int64 totalBytes, UInt64 bytesTransfered, DateTime transferStarted )
            : base( job, targetPath )
        {
            TotalBytes = ( UInt64 ) totalBytes;
            BytesTransfered = bytesTransfered;
            TransferStartedTimestamp = transferStarted;
            ProgressTimestamp = DateTime.Now;
        }
    }

}