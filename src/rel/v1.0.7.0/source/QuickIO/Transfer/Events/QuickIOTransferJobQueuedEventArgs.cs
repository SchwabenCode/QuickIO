// <copyright file="QuickIOTransferJobQueuedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferJobQueuedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information of an queued job
    /// </summary>
    public class QuickIOTransferJobQueuedEventArgs : QuickIOTransferJobWriteWithSourceEventArgs
    {
        /// <summary>
        /// Timestamp when the item has been added to the queue
        /// </summary>
        public DateTime AddedToQueue { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobQueuedEventArgs"/>. Sets <see cref="AddedToQueue"/> to DateTime.Now
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="sourcePath">Source file path</param>
        /// <param name="targetPath">Target file path</param>
        public QuickIOTransferJobQueuedEventArgs( IQuickIOTransferJob job, string sourcePath, string targetPath )
            : base( job, sourcePath, targetPath )
        {
            AddedToQueue = DateTime.Now;
        }
    }
}