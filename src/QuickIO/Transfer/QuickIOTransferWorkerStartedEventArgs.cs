// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Contains information when a worker started
    /// </summary>
    public class QuickIOTransferWorkerStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferWorkerStartedEventArgs"/>
        /// </summary>
        /// <param name="workerID">Affected Worker ID</param>
        public QuickIOTransferWorkerStartedEventArgs( int workerID )
        {
            WorkerID = workerID;
        }

        /// <summary>
        /// Affected Worker ID
        /// </summary>
        public Int32 WorkerID { get; private set; }
    }
}