// <copyright file="QuickIOTransferObserver.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferObserver</summary>

using System;
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    ///  A QuickIO observer is a central contact point and allows the condition monitoring of QuickIO services and QuickIO jobs.<br />
    ///  It is possible to create an own observer by inherit from IQuickIOTransferObserver and QuickIOTransferObserver to monitor your own services and jobs at a central point and gather all information.
    /// 
    /// If you define your own jobs you can create your own observer class that derives from <see cref="IQuickIOTransferJob"/>, too.
    /// 
    /// <example>
    /// Own observer example
    /// <code>
    /// <![CDATA[
    /// /// <summary>
    /// /// My observer interface
    /// /// </summary>
    /// public interface IMyExampleObserver : IQuickIOTransferObserver
    /// {
    ///     /// <summary>
    ///     /// Description of MyEvent
    ///     /// </summary>
    ///     event MyExampleObserver.MyCustomEventHandler MyEvent;
    /// 
    ///     /// <summary>
    ///     /// Fire <see cref="MyExampleObserver.MyEvent"/>
    ///     /// </summary>
    ///     void OnMyEvent( );
    /// }
    /// 
    /// /// <summary>
    /// /// my observer implementation
    /// /// </summary>
    /// public class MyExampleObserver : QuickIOTransferObserver, IMyExampleObserver
    /// {
    ///     /// <summary>
    ///     /// Delegate for <see cref="MyEvent"/>
    ///     /// </summary>
    ///     public delegate void MyCustomEventHandler( object sender, EventArgs e );
    /// 
    ///     /// <summary>
    ///     /// Description of MyEvent
    ///     /// </summary>
    ///     public event MyCustomEventHandler MyEvent;
    /// 
    ///     /// <summary>
    ///     /// Fire <see cref="MyEvent"/>
    ///     /// </summary>
    ///     public virtual void OnMyEvent( )
    ///     {
    ///         if ( MyEvent != null )
    ///         {
    ///             MyEvent( this, EventArgs.Empty );
    ///         }
    ///     }
    /// 
    ///     /// <summary>
    ///     /// For example we want to log each worker creation, but  the keep the default behavior
    ///     /// </summary>
    ///     public override void OnWorkerCreated( QuickIOTransferWorkerCreatedEventArgs args )
    ///     {
    ///         base.OnWorkerCreated( args );
    /// 
    ///         QuickIOFile.AppendAllText( "Log_WorkerCreation.log", String.Format( "[{0}] NEW WORKER: {1} ", DateTime.Now, args.WorkerID ) );
    ///     }
    /// }
    /// 
    /// /// <summary>
    /// /// Example usage of own observer
    /// /// </summary>
    /// public class Program
    /// {
    ///     /// <summary>
    ///     /// Program implementation
    ///     /// </summary>
    ///     public static void OwnObserverExample( )
    ///     {
    ///         var myObserver = new MyExampleObserver( );
    /// 
    ///         var service1 = new QuickIOTransferBackgroundService( myObserver, workerCount: 1 );
    ///         var service2 = new QuickIOTransferBackgroundService( myObserver, workerCount: 4 );
    ///         var directoryCopyService = new QuickIOTransferDirectoryCopyService( myObserver, new QuickIODirectoryInfo( @"C:\temp" ), @"C:\temp_testtarget" );
    /// 
    ///         // service usage here
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    /// </summary>
    public class QuickIOTransferObserver : IQuickIOTransferObserver
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferObserver"/>
        /// </summary>
        public QuickIOTransferObserver( )
        {

        }

        #region Directory Create

        /// <summary>
        /// This event is raised if directory creation operation fails
        /// </summary>
        public event QuickIOTransferDirectoryCreationErrorHandler DirectoryCreationError;

        /// <summary>
        /// This event is raised before an upcoming directory creation operation is performed
        /// </summary>
        public event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;

        /// <summary>
        /// This event is raised when a directory was created
        /// </summary>
        public event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;

        /// <summary>
        /// Fire <see cref="DirectoryCreationError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnDirectoryCreationError( QuickIOTransferDirectoryCreationErrorEventArgs args )
        {
            if ( DirectoryCreationError != null )
            {
                DirectoryCreationError( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="DirectoryCreating"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnDirectoryCreating( QuickIOTransferDirectoryCreatingEventArgs args )
        {
            if ( DirectoryCreating != null )
            {
                DirectoryCreating( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="DirectoryCreated"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnDirectoryCreated( QuickIOTransferDirectoryCreatedEventArgs args )
        {
            if ( DirectoryCreated != null )
            {
                DirectoryCreated( this, args );
            }
        }
        #endregion

        #region File Creation
        /// <summary>
        /// This event is raised if file creation fails
        /// </summary>
        public event QuickIOTransferFileCreationErrorHandler FileCreationError;
        /// <summary>
        /// This event is raised during a creation of a file. It provides current information such as progress, speed and estimated time.
        /// </summary>
        public event QuickIOTransferFileCreationProgressHandler FileCreationProgress;

        /// <summary>
        /// This event is triggered at the beginning of the file creation operation.
        /// </summary>
        public event QuickIOTransferFileCreationStartedHandler FileCreationStarted;

        /// <summary>
        /// This event is raised at the end of the file creation operation.
        /// </summary>
        public event QuickIOTransferFileCreationFinishedHandler FileCreationFinished;

        /// <summary>
        /// Fire <see cref="FileCreationError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCreationError( QuickIOTransferFileCreationErrorEventArgs args )
        {
            if ( FileCreationError != null )
            {
                FileCreationError( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCreationProgress"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCreationProgress( QuickIOTransferFileCreationProgressEventArgs args )
        {
            if ( FileCreationProgress != null )
            {
                FileCreationProgress( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCreationStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCreationStarted( QuickIOTransferFileCreationStartedEventArgs args )
        {
            if ( FileCreationStarted != null )
            {
                FileCreationStarted( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyFinished"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCreationFinished( QuickIOTransferFileCreationFinishedEventArgs args )
        {
            if ( FileCreationFinished != null )
            {
                FileCreationFinished( this, args );
            }
        }
        #endregion

        #region File Copy

        /// <summary>
        /// This event is raised if file copy operation fails
        /// </summary>
        public event QuickIOTransferFileCopyErrorHandler FileCopyError;

        /// <summary>
        /// This event is raised during a copy of a file. It provides current information such as progress, speed and estimated time.
        /// </summary>
        public event QuickIOTransferFileCopyProgressHandler FileCopyProgress;

        /// <summary>
        /// This event is triggered at the beginning of the file copy operation.
        /// </summary>
        public event QuickIOTransferFileCopyStartedHandler FileCopyStarted;

        /// <summary>
        /// This event is raised at the end of the file copy operation.
        /// </summary>
        public event QuickIOTransferFileCopyFinishedHandler FileCopyFinished;

        /// <summary>
        /// Fire <see cref="FileCopyError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyError( QuickIOTransferFileCopyErrorEventArgs args )
        {
            if ( FileCopyError != null )
            {
                FileCopyError( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyProgress"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyProgress( QuickIOTransferFileCopyProgressEventArgs args )
        {
            if ( FileCopyProgress != null )
            {
                FileCopyProgress( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyStarted( QuickIOTransferFileCopyStartedEventArgs args )
        {
            if ( FileCopyStarted != null )
            {
                FileCopyStarted( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyFinished"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyFinished( QuickIOTransferFileCopyFinishedEventArgs args )
        {
            if ( FileCopyFinished != null )
            {
                FileCopyFinished( this, args );
            }
        }
        #endregion

        #region Service
        /// <summary>
        /// This event is raised if the service has been made known that no new elements will be added.
        /// </summary>
        public event QuickIOTransferCompletedAddingRequestedHandler CompletedAddingRequested;


        /// <summary>
        /// This event is raised if the service has been made known that he should cancel the processing
        /// </summary>
        public event QuickIOTransferCancellationRequestedHandler CancellationRequested;

        /// <summary>
        /// Fire <see cref="CompletedAddingRequested"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnCompletedAddingRequested( EventArgs args )
        {
            if ( CompletedAddingRequested != null )
            {
                CompletedAddingRequested( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="CancellationRequested"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnCancellationRequested( EventArgs args )
        {
            if ( CancellationRequested != null )
            {
                CancellationRequested( this, args );
            }
        }
        #endregion


        #region Worker Events

        /// <summary>
        /// This event is raised when a processing thread is waiting for new items
        /// </summary>
        public event QuickIOTransferWorkerIsWaitingHandler WorkerIsWaiting;

        /// <summary>
        /// This event is raised when a processing thread, which so far has been waiting for, was notified of a new item in the queue.
        /// It may be that he gets no element from the queue, because another thread was faster. He would sleep lie down again, if no more items available.
        /// </summary>
        public event QuickIOTransferWorkerWokeUpHandler WorkerWokeUp;

        /// <summary>
        /// This event is raised when a processing thread has taken a new item from the queue 
        /// </summary>
        public event QuickIOTransferWorkerPickedJobHandler WorkerPickedJob;

        /// <summary>
        /// This event is raised when a new processing thread was created
        /// </summary>
        public event QuickIOTransferWorkerCreatedHandler WorkerCreated;

        /// <summary>
        /// This event is raised when a processing thread started
        /// </summary>
        public event QuickIOTransferWorkerStartedHandler WorkerStarted;

        /// <summary>
        /// This event is raised when a processing thread was shutdown
        /// </summary>
        public event QuickIOTransferWorkerShutdownHandler WorkerShutdown;

        /// <summary>
        /// Fire <see cref="WorkerWokeUp"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnWorkerWokeUp( QuickIOTransferWorkerWokeUpEventArgs args )
        {
            if ( WorkerWokeUp != null )
            {
                WorkerWokeUp( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="WorkerPickedJob"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnWorkerIsWaiting( QuickIOTransferWorkerIsSleepingEventArgs args )
        {
            if ( WorkerIsWaiting != null )
            {
                WorkerIsWaiting( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="WorkerPickedJob"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnWorkerPickedJob( QuickIOTransferWorkerPickedJobEventArgs args )
        {
            if ( WorkerPickedJob != null )
            {
                WorkerPickedJob( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="WorkerCreated"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnWorkerCreated( QuickIOTransferWorkerCreatedEventArgs args )
        {
            if ( WorkerCreated != null )
            {
                WorkerCreated( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="WorkerStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnWorkerStarted( QuickIOTransferWorkerStartedEventArgs args )
        {
            if ( WorkerStarted != null )
            {
                WorkerStarted( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="WorkerShutdown"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnWorkerShutdown( QuickIOTransferWorkerShutdownEventArgs args )
        {
            if ( WorkerShutdown != null )
            {
                WorkerShutdown( this, args );
            }
        }

        #endregion

        #region Jobs

        /// <summary>
        /// This event is raised when <see cref="QuickIOTransferJob.Run"/> is called
        /// </summary>
        public event QuickIOTransferJobRunHandler JobRun;

        /// <summary>
        /// This event is triggered if <see cref="QuickIOTransferJob.Run"/> has an error
        /// </summary>
        public event QuickIOTransferJobErrorHandler JobError;

        /// <summary>
        /// This event is raised at the end <see cref="QuickIOTransferJob.Run"/>
        /// </summary>
        public event QuickIOTransferJobEndHandler JobEnd;

        /// <summary>
        /// This event is raised if the job of a queue has been added.
        /// </summary>
        public event QuickIOTransferJobEnqueuedHandler JobEnqueued;

        /// <summary>
        /// This event is raised if the job was taken from of a queue.
        /// </summary>
        public event QuickIOTransferJobDequeuedHandler JobDequeued;

        /// <summary>
        /// This event is raised if the job was re-added to a queue.
        /// </summary>
        public event QuickIOTransferJobRequeuedHandler JobRequeued;

        /// <summary>
        /// This event is raised if the max retry count is reached.
        /// </summary>
        public event QuickIOTransferJobRetryMaxReachedHandler JobRetryMaxReached;


        /// <summary>
        /// Fire <see cref="JobRun"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobRun( QuickIOTransferJobRunEventArgs args )
        {
            if ( JobRun != null )
            {
                JobRun( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="JobError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobError( QuickIOTransferJobErrorEventArgs args )
        {
            if ( JobError != null )
            {
                JobError( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="JobEnd"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobEnd( QuickIOTransferJobEndEventArgs args )
        {
            if ( JobEnd != null )
            {
                JobEnd( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="JobEnqueued"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobEnqueued( QuickIOTransferJobEnqueuedEventArgs args )
        {
            if ( JobEnqueued != null )
            {
                JobEnqueued( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="JobDequeued"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobDequeued( QuickIOTransferJobDequeuedEventArgs args )
        {
            if ( JobDequeued != null )
            {
                JobDequeued( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="JobRequeued"/>
        /// </summary>      
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobRequeued( QuickIOTransferJobRequeuedEventArgs args )
        {
            if ( JobRequeued != null )
            {
                JobRequeued( this, args );
            }
        }

        /// <summary>
        /// Fire <see cref="JobRetryMaxReached"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnJobRetryMaxReached( QuickIOTransferJobReatryMaxReachedEventArgs args )
        {
            if ( JobRetryMaxReached != null )
            {
                JobRetryMaxReached( this, args );
            }
        }
        #endregion
    }
}
