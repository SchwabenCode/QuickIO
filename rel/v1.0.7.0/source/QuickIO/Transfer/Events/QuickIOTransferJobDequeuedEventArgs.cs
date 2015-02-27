// <copyright file="QuickIOTransferJobDequeuedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferJobDequeuedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information of a dequeued job
    /// </summary>
    public class QuickIOTransferJobDequeuedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobDequeuedEventArgs"/>
        /// </summary>
        /// <param name="job">Enqueued Job</param>
        public QuickIOTransferJobDequeuedEventArgs( IQuickIOTransferJob job )
        {
            Job = job;
        }

        /// <summary>
        /// Dequeued Job
        /// </summary>
        public IQuickIOTransferJob Job { get; private set; }
    }
}
