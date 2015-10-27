// <copyright file="IQuickIOTransferJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>IQuickIOTransferJob</summary>

using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Interface for transfer jobs
    /// </summary>
    [ContractClass( typeof( IQuickIOTransferJobContract ) )]
    public interface IQuickIOTransferJob
    {
        /// <summary>
        /// Cancellation Token
        /// </summary>
        System.Threading.CancellationToken Token { get; }

        /// <summary>
        /// Observer for Condition Monitoring
        /// </summary>
        IQuickIOTransferObserver Observer { get; }

        /// <summary>
        /// Retry count before firing broken exception
        /// </summary>
        Int32 CurrentRetryCount { get; set; }

        /// <summary>
        /// Prority level. Higher priority = higher value. 0 = default
        /// </summary>
        Int32 PriorityLevel { get; set; }

        /// <summary>
        /// Run implementation
        /// </summary>
        void Run( );

        /// <summary>
        /// Executes <see cref="Run"/> in Async context
        /// </summary>
        Task RunAsync( );
    }
}