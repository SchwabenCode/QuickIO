// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Contract implementation
    /// </summary>
    [ContractClass( typeof( IQuickIOTransferObserver ) )]
    [Browsable( false )]
    [EditorBrowsable( EditorBrowsableState.Never )]
    public abstract class IQuickIOTransferObserverContract : IQuickIOTransferObserver
    {
        public event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;
        public event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;
        public event QuickIOTransferDirectoryCreationErrorHandler DirectoryCreationError;

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnDirectoryCreating( QuickIOTransferDirectoryCreatingEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnDirectoryCreated( QuickIOTransferDirectoryCreatedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnDirectoryCreationError( QuickIOTransferDirectoryCreationErrorEventArgs args )
        {
            Contract.Requires( args != null );
        }

        public event QuickIOTransferFileCreationErrorHandler FileCreationError;
        public event QuickIOTransferFileCreationStartedHandler FileCreationStarted;
        public event QuickIOTransferFileCreationFinishedHandler FileCreationFinished;
        public event QuickIOTransferFileCreationProgressHandler FileCreationProgress;
        public void OnFileCreationError( QuickIOTransferFileCreationErrorEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnFileCreationProgress( QuickIOTransferFileCreationProgressEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnFileCreationStarted( QuickIOTransferFileCreationStartedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnFileCreationFinished( QuickIOTransferFileCreationFinishedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        public event QuickIOTransferFileCopyErrorHandler FileCopyError;
        public event QuickIOTransferFileCopyProgressHandler FileCopyProgress;
        public event QuickIOTransferFileCopyStartedHandler FileCopyStarted;
        public event QuickIOTransferFileCopyFinishedHandler FileCopyFinished;
        public void OnFileCopyError( QuickIOTransferFileCopyErrorEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnFileCopyProgress( QuickIOTransferFileCopyProgressEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnFileCopyStarted( QuickIOTransferFileCopyStartedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnFileCopyFinished( QuickIOTransferFileCopyFinishedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        public event QuickIOTransferCompletedAddingRequestedHandler CompletedAddingRequested;
        public event QuickIOTransferCancellationRequestedHandler CancellationRequested;

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnCompletedAddingRequested( EventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnCancellationRequested( EventArgs args )
        {
            Contract.Requires( args != null );
        }

        public event QuickIOTransferWorkerIsWaitingHandler WorkerIsWaiting;
        public event QuickIOTransferWorkerWokeUpHandler WorkerWokeUp;
        public event QuickIOTransferWorkerPickedJobHandler WorkerPickedJob;
        public event QuickIOTransferWorkerCreatedHandler WorkerCreated;
        public event QuickIOTransferWorkerStartedHandler WorkerStarted;
        public event QuickIOTransferWorkerShutdownHandler WorkerShutdown;
        public void OnWorkerWokeUp( QuickIOTransferWorkerWokeUpEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnWorkerIsWaiting( QuickIOTransferWorkerIsSleepingEventArgs args )
        {
            Contract.Requires( args != null );
        }

        public void OnWorkerPickedJob( QuickIOTransferWorkerPickedJobEventArgs args )
        {
            Contract.Requires( args != null );
        }
        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnWorkerCreated( QuickIOTransferWorkerCreatedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnWorkerStarted( QuickIOTransferWorkerStartedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnWorkerShutdown( QuickIOTransferWorkerShutdownEventArgs args )
        {
            Contract.Requires( args != null );
        }

        public event QuickIOTransferJobRunHandler JobRun;
        public event QuickIOTransferJobErrorHandler JobError;
        public event QuickIOTransferJobEndHandler JobEnd;
        public event QuickIOTransferJobEnqueuedHandler JobEnqueued;
        public event QuickIOTransferJobDequeuedHandler JobDequeued;
        public event QuickIOTransferJobRequeuedHandler JobRequeued;
        public event QuickIOTransferJobRetryMaxReachedHandler JobRetryMaxReached;
        public void OnJobRun( QuickIOTransferJobRunEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnJobError( QuickIOTransferJobErrorEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnJobEnd( QuickIOTransferJobEndEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnJobEnqueued( QuickIOTransferJobEnqueuedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnJobDequeued( QuickIOTransferJobDequeuedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnJobRequeued( QuickIOTransferJobRequeuedEventArgs args )
        {
            Contract.Requires( args != null );
        }

        /// <summary>
        /// Contract implementation
        /// </summary>
        /// <param name="args">Cannot be null</param>
        public void OnJobRetryMaxReached( QuickIOTransferJobReatryMaxReachedEventArgs args )
        {
            Contract.Requires( args != null );
        }
    }

}