// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Contains information when a new worker has been created
    /// </summary>
    public class QuickIOTransferWorkerCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferWorkerCreatedEventArgs"/>
        /// </summary>
        /// <param name="workerID">Affected Worker ID</param>
        public QuickIOTransferWorkerCreatedEventArgs( int workerID )
        {
            WorkerID = workerID;
        }

        /// <summary>
        /// Affected Worker ID
        /// </summary>
        public Int32 WorkerID { get; private set; }
    }
}