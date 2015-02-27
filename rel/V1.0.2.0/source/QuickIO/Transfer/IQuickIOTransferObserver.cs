// <copyright file="IQuickIOTransferObserver.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>IQuickIOTransferObserver</summary>

using System;
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Implementation requirements for central observer.
    /// </summary>
    /// <remarks>See <see cref="QuickIOTransferObserver"/> for custom observer implementation example.</remarks>
    public interface IQuickIOTransferObserver
    {
        /// <summary>
        /// This event is raised before an upcoming directory creation operation is performed
        /// </summary>
        event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;

        /// <summary>
        /// This event is raised when a directory was created
        /// </summary>
        event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;

        /// <summary>
        /// This event is raised if directory creation operation fails
        /// </summary>
         event QuickIOTransferDirectoryCreationErrorHandler DirectoryCreationError;

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.DirectoryCreating"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnDirectoryCreating( QuickIOTransferDirectoryCreatingEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.DirectoryCreated"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnDirectoryCreated( QuickIOTransferDirectoryCreatedEventArgs args );

        /// <summary>
        /// Fire <see cref="DirectoryCreationError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnDirectoryCreationError(QuickIOTransferDirectoryCreationErrorEventArgs args);

        #region File Creation
        /// <summary>
        /// This event is raised if file creation fails
        /// </summary>
        event QuickIOTransferFileCreationErrorHandler FileCreationError;

        /// <summary>
        /// This event is triggered at the beginning of the file copy operation.
        /// </summary>
        event QuickIOTransferFileCreationStartedHandler FileCreationStarted;

        /// <summary>
        /// This event is raised at the end of the file copy operation.
        /// </summary>
        event QuickIOTransferFileCreationFinishedHandler FileCreationFinished;

        /// <summary>
        /// This event is raised at the end of the file copy operation.
        /// </summary>
        event QuickIOTransferFileCreationProgressHandler FileCreationProgress;

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCreationError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCreationError( QuickIOTransferFileCreationErrorEventArgs args );
        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCreationProgress"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCreationProgress( QuickIOTransferFileCreationProgressEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCreationStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCreationStarted( QuickIOTransferFileCreationStartedEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCreationFinished"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCreationFinished( QuickIOTransferFileCreationFinishedEventArgs args );
        #endregion

        #region File Copy
        /// <summary>
        /// This event is raised if file copy operation fails
        /// </summary>
        event QuickIOTransferFileCopyErrorHandler FileCopyError;

        /// <summary>
        /// This event is raised during a copy of a file. It provides current information such as progress, speed and estimated time.
        /// </summary>
        event QuickIOTransferFileCopyProgressHandler FileCopyProgress;

        /// <summary>
        /// This event is triggered at the beginning of the file copy operation.
        /// </summary>
        event QuickIOTransferFileCopyStartedHandler FileCopyStarted;

        /// <summary>
        /// This event is raised at the end of the file copy operation.
        /// </summary>
        event QuickIOTransferFileCopyFinishedHandler FileCopyFinished;

        /// <summary>
        /// Fire <see cref="FileCopyError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCopyError( QuickIOTransferFileCopyErrorEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCopyProgress"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCopyProgress( QuickIOTransferFileCopyProgressEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCopyStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCopyStarted( QuickIOTransferFileCopyStartedEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.FileCopyFinished"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnFileCopyFinished( QuickIOTransferFileCopyFinishedEventArgs args );
        #endregion
        /// <summary>
        /// This event is raised if the service has been made known that no new elements will be added.
        /// </summary>
        event QuickIOTransferCompletedAddingRequestedHandler CompletedAddingRequested;

        /// <summary>
        /// This event is raised if the service has been made known that he should cancel the processing
        /// </summary>
        event QuickIOTransferCancellationRequestedHandler CancellationRequested;

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.CompletedAddingRequested"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnCompletedAddingRequested( EventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.CancellationRequested"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnCancellationRequested( EventArgs args );

        /// <summary>
        /// This event is raised when a processing thread is waiting for new items
        /// </summary>
        event QuickIOTransferWorkerIsWaitingHandler WorkerIsWaiting;

        /// <summary>
        /// This event is raised when a processing thread, which so far has been waiting for, was notified of a new item in the queue.
        /// It may be that he gets no element from the queue, because another thread was faster. He would sleep lie down again, if no more items available.
        /// </summary>
        event QuickIOTransferWorkerWokeUpHandler WorkerWokeUp;

        /// <summary>
        /// This event is raised when a processing thread has taken a new item from the queue 
        /// </summary>
        event QuickIOTransferWorkerPickedJobHandler WorkerPickedJob;

        /// <summary>
        /// This event is raised when a new processing thread was created
        /// </summary>
        event QuickIOTransferWorkerCreatedHandler WorkerCreated;

        /// <summary>
        /// This event is raised when a processing thread started
        /// </summary>
        event QuickIOTransferWorkerStartedHandler WorkerStarted;

        /// <summary>
        /// This event is raised when a processing thread was shutdown
        /// </summary>
        event QuickIOTransferWorkerShutdownHandler WorkerShutdown;

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.WorkerWokeUp"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnWorkerWokeUp( QuickIOTransferWorkerWokeUpEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.WorkerPickedJob"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnWorkerIsWaiting( QuickIOTransferWorkerIsSleepingEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.WorkerPickedJob"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnWorkerPickedJob( QuickIOTransferWorkerPickedJobEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.WorkerCreated"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnWorkerCreated( QuickIOTransferWorkerCreatedEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.WorkerStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnWorkerStarted( QuickIOTransferWorkerStartedEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.WorkerShutdown"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnWorkerShutdown( QuickIOTransferWorkerShutdownEventArgs args );

        /// <summary>
        /// This event is raised when <see cref="QuickIOTransferJob.Run"/> is called
        /// </summary>
        event QuickIOTransferJobRunHandler JobRun;

        /// <summary>
        /// This event is triggered if <see cref="QuickIOTransferJob.Run"/> has an error
        /// </summary>
        event QuickIOTransferJobErrorHandler JobError;

        /// <summary>
        /// This event is raised at the end <see cref="QuickIOTransferJob.Run"/>
        /// </summary>
        event QuickIOTransferJobEndHandler JobEnd;

        /// <summary>
        /// This event is raised if the job of a queue has been added.
        /// </summary>
        event QuickIOTransferJobEnqueuedHandler JobEnqueued;

        /// <summary>
        /// This event is raised if the job was taken from of a queue.
        /// </summary>
        event QuickIOTransferJobDequeuedHandler JobDequeued;

        /// <summary>
        /// This event is raised if the job was re-added to a queue.
        /// </summary>
        event QuickIOTransferJobRequeuedHandler JobRequeued;

        /// <summary>
        /// This event is raised if the max retry count is reached.
        /// </summary>
        event QuickIOTransferJobRetryMaxReachedHandler JobRetryMaxReached;

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.JobRun"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnJobRun( QuickIOTransferJobRunEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.JobError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnJobError( QuickIOTransferJobErrorEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.JobEnd"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnJobEnd( QuickIOTransferJobEndEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.JobEnqueued"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnJobEnqueued( QuickIOTransferJobEnqueuedEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.JobDequeued"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnJobDequeued( QuickIOTransferJobDequeuedEventArgs args );

        /// <summary>
        /// Fire <see cref="JobRequeued"/>
        /// </summary>      
        /// <param name="args">Holds further event information</param>
        void OnJobRequeued( QuickIOTransferJobRequeuedEventArgs args );

        /// <summary>
        /// Fire <see cref="QuickIOTransferObserver.JobRetryMaxReached"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        void OnJobRetryMaxReached( QuickIOTransferJobReatryMaxReachedEventArgs args );
    }

}