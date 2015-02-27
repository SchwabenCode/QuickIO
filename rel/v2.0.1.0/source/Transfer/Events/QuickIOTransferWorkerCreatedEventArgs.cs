// <copyright file="QuickIOTransferWorkerCreatedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferWorkerCreatedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
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