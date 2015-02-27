// <copyright file="QuickIOTransferBackgroundService.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferBackgroundService</summary>

using System;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Instance for the continuous transfer of files; for example as a service.
    /// </summary>
    /// <example>
    /// Sort incoming files by an always watching file service
    /// 
    /// <code>
    /// <![CDATA[
    /// class Program
    /// {
    ///     const string dropDirectory = @"C:\transfer_test\dropfolder";
    ///     const string pictureFolder = @"C:\transfer_test\pictures";
    ///     const string movieFolder = @"C:\transfer_test\movies";
    /// 
    /// 
    ///     protected static QuickIOTransferBackgroundService TransferBackgroundService = new QuickIOTransferBackgroundService( workerCount: 2, maxFileRetry: 5 );
    ///     protected static FileSystemWatcher PictureWatcher = new FileSystemWatcher( dropDirectory, "*.png" );
    ///     protected static FileSystemWatcher MovieWatcher = new FileSystemWatcher( dropDirectory, "*.mp4" );
    /// 
    ///     static void Main( string[ ] args )
    ///     {
    ///         PictureWatcher.Created += OnCreated_Picture;
    ///         MovieWatcher.Created += OnCreated_MovieFile;
    /// 
    ///         TransferBackgroundService.Enqueued += OnJobEnqueued;
    ///         TransferBackgroundService.Dequeued += OnJobDequeued;
    ///         TransferBackgroundService.Requeued += JobRequeued;
    ///         TransferBackgroundService.WorkerPickedJob += OnServiceWorkerPickedJob;
    /// 
    ///         TransferBackgroundService.WorkerCreated += OnServiceWorkerCreated;
    ///         TransferBackgroundService.WorkerStarted += OnServiceWorkerStarted;
    ///         TransferBackgroundService.WorkerPickedJob += OnServiceWorkerPickedJob;
    /// 
    ///         TransferBackgroundService.Started += OnFileCopyStarted;
    ///         TransferBackgroundService.Progress += OnFileCopyProgress;
    ///         TransferBackgroundService.Finished += OnFileCopyFinished;
    /// 
    ///         TransferBackgroundService.StartWorking( );
    /// 
    ///         Console.WriteLine( "Service is running." );
    ///         Console.ReadKey( );
    /// 
    ///         // Ends on key input
    ///     }
    /// 
    ///     /// <summary>
    ///     /// worker started
    ///     /// </summary>
    ///     private static void OnServiceWorkerStarted( object sender, QuickIOTransferWorkerStartedEventArgs e )
    ///     {
    ///         Console.WriteLine( "[!] Worker Started. ID: " + e.WorkerID );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// new worker
    ///     /// </summary>
    ///     static void OnServiceWorkerCreated( object sender, QuickIOTransferWorkerCreatedEventArgs e )
    ///     {
    ///         Console.WriteLine( "[!] New Worker. ID: " + e.WorkerID );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// worker catched a job
    ///     /// </summary>
    ///     static void OnServiceWorkerPickedJob( object sender, QuickIOTransferWorkerPickedJobEventArgs e )
    ///     {
    ///         Console.WriteLine( "[!] Worker ID# " + e.WorkerID + " picked job: " + e.GetType( ) );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// job was broken by an exception, but requred
    ///     /// </summary>
    ///     static void JobRequeued( object sender, QuickIOTransferJobRequeuedArgs e )
    ///     {
    ///         Console.WriteLine( "[JOB REQUEUED] Try: #" + e.Job.CurrentRetryCount + " - " + e.Job.GetType( ) + " failed: " + e.Exception.Message );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// Report of job was taken from queue
    ///     /// </summary>
    ///     static void OnJobDequeued( object sender, QuickIOTransferJobDequeuedArgs e )
    ///     {
    ///         Console.WriteLine( "[JOB DEQUEUED] " + e.Job.GetType( ) );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// Report for new jobs
    ///     /// </summary>
    ///     static void OnJobEnqueued( object sender, QuickIOTransferJobEnqueuedArgs e )
    ///     {
    ///         Console.WriteLine( "[NEW JOB] " + e.Job.GetType( ) );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// Progress Report
    ///     /// </summary>
    ///     static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedArgs args )
    ///     {
    ///         Console.WriteLine( ">>>>>> STARTED " + args.SourcePath + " to " + args.TargetPath );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// Progress Report
    ///     /// </summary>
    ///     static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedArgs args )
    ///     {
    ///         Console.WriteLine( ">>>>>> FINISHED " + args.SourcePath + " to " + args.TargetPath + " - MB/s: " + ( args.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    ///     }
    ///     /// <summary>
    ///     /// Progress Report
    ///     /// </summary>
    ///     static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressArgs args )
    ///     {
    ///         Console.WriteLine( "Transfering " + args.SourcePath + " to " + args.TargetPath + " - %: " + args.Percentage + " MB/s: " + ( args.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// Copy movie file from drop folder to internal movie folder
    ///     /// </summary>
    ///     static void OnCreated_MovieFile( object sender, FileSystemEventArgs e )
    ///     {
    ///         var queueItem = new QuickIOTransferFileCopyJob( e.FullPath, movieFolder, overwrite: true );
    ///         TransferBackgroundService.Add( queueItem );
    ///     }
    /// 
    ///     /// <summary>
    ///     /// Copy picture file from drop folder to internal picture folder
    ///     /// </summary>
    ///     static void OnCreated_Picture( object sender, FileSystemEventArgs e )
    ///     {
    ///         var queueItem = new QuickIOTransferFileCopyJob( e.FullPath, pictureFolder, overwrite: true, parentExistanceCheck: false );
    ///         TransferBackgroundService.Add( queueItem );
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    public class QuickIOTransferBackgroundService : QuickIOTransferServiceBase
    {
        /// <summary>
        /// Creates an instance for <see cref="QuickIOTransferBackgroundService"/> with default observer
        /// </summary>
        /// <param name="workerCount"></param>
        /// <param name="maxFileRetry"></param>
        /// <param name="autostart">true to auto start. false to start service by using <see cref="QuickIOTransferServiceBase.StartWorking"/></param>
        public QuickIOTransferBackgroundService( int workerCount, int maxFileRetry = 3, bool autostart = true )
            : this( null, workerCount, maxFileRetry )
        {
            if ( autostart )
            {
                Start( );
            }
        }

        /// <summary>
        /// Creates an instance for <see cref="QuickIOTransferBackgroundService"/> with specified observer
        /// </summary>
        /// <param name="observer">Observer for monitoring</param>
        /// <param name="workerCount"></param>
        /// <param name="maxFileRetry"></param>
        /// <param name="autostart">true to auto start. false to start service by using <see cref="QuickIOTransferServiceBase.StartWorking"/></param>
        public QuickIOTransferBackgroundService( IQuickIOTransferObserver observer, int workerCount, int maxFileRetry = 3, bool autostart = true )
            : base( observer, workerCount, maxFileRetry )
        {
            if ( autostart )
            {
                Start( );
            }
        }

        /// <summary>
        /// Starts the service if not started yet
        /// </summary>
        public Boolean Start()
        {
            return StartWorking( );
        }

        /// <summary>
        /// Adds an item to the queue. null will not be insered and returns false.
        /// If <see cref="QuickIOTransferServiceBase.CompleteAdding"/> is called the return value is false, too
        /// </summary>
        /// <param name="queueItem">Item to add</param>
        /// <returns>true on add; false if not</returns>
        public void Add( QuickIOTransferFileCopyJob queueItem )
        {
            Invariant.NotNull( queueItem );

            if ( CancelRequested )
            {
                throw new Exception( "Queue is cancelled." );
            }

            if ( AddingCompleted )
            {
                throw new Exception( "Adding is completed." );
            }

            InternalAdd( queueItem );
        }

        /// <summary>
        /// Adds a new worker to the service. Worker will be created and started instantly.
        /// </summary>
        /// <param name="count">Must be 1 or greater</param>
        /// <remarks>It's not recommended to use more workers than the count of useable CPU cores.</remarks>
        public new void AddWorker( Int32 count = 1 )
        {
            base.AddWorker( count );
        }

        /// <summary>
        /// Remove workers from the service.
        /// </summary>
        /// <param name="count">Must be 1 or greater</param>
        public new void RemoveWorker( Int32 count = 1 )
        {
            base.RemoveWorker( count );
        }

        /// <summary>
        /// Joins all threads and blocks until all threads and queue items are completed.
        /// Queue has to be completed.
        /// </summary>
        public new void WaitForFinish()
        {
            base.WaitForFinish( );
        }
    }
}