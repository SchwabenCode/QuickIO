// <copyright file="QuickIOTransferWorkerPickedJobEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferWorkerPickedJobEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information when a worker picked up a new job from the queue
    /// </summary>
    public class QuickIOTransferWorkerPickedJobEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferWorkerWokeUpEventArgs"/>
        /// </summary>
        /// <param name="workerID">Affected Worker ID</param>
        /// <param name="job">Picked job</param>
        public QuickIOTransferWorkerPickedJobEventArgs( int workerID, IQuickIOTransferJob job )
        {
            WorkerID = workerID;
            Job = job;
        }

        /// <summary>
        /// Affected Worker ID
        /// </summary>
        public Int32 WorkerID { get; private set; }


        /// <summary>
        /// Picked Job
        /// </summary>
        public IQuickIOTransferJob Job { get; private set; }
    }
}