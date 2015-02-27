// <copyright file="IQuickIOTransferJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>IQuickIOTransferJob</summary>

using System;
#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Interface for transfer jobs
    /// </summary>
    public interface IQuickIOTransferJob
    {
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
        void Run();

#if NET40_OR_GREATER
        /// <summary>
        /// Executes <see cref="Run"/> in Async context
        /// </summary>
        Task RunAsync();
#endif
    }
}