// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Transfer
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
