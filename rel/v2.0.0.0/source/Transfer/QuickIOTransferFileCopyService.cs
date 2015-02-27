// <copyright file="QuickIOTransferFileCopyService.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCopyService</summary>

using System;
using System.Collections.Generic;
using SchwabenCode.QuickIO.Compatibility;

#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Copy directory with progress monitoring
    /// </summary>
    /// <example>
    /// Copy file
    /// 
    /// <code>
    /// <![CDATA[
    /// class Program
    /// {
    ///     static void Main( string[ ] args )
    ///     {
    ///         const string sourceDirectory = @"C:\transfer_test\source";
    ///         const string targetDirectory = @"C:\transfer_test\to";
    /// 
    ///         // search files
    ///         var files = QuickIODirectory.EnumerateFiles( sourceDirectory, SearchOption.TopDirectoryOnly )
    /// 
    ///         var observer = new QuickIOTransferObserver( );
    ///         var service = new QuickIOTransferFileCopyService( observer, files, targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );
    /// 
    ///         //  Progress information
    ///         service.Observer.FileCopyStarted += OnFileCopyStarted;
    ///         service.Observer.FileCopyProgress += OnFileCopyProgress;
    ///         service.Observer.FileCopyFinished += OnFileCopyFinished;
    ///         // Same as (observer events are called first!):
    ///         //service.FileCopyStarted += OnFileCopyStarted;
    ///         //service.FileCopyProgress += OnFileCopyProgress;
    ///         //service.FileCopyFinished += OnFileCopyFinished;
    /// 
    ///         // Start progress
    ///         service.Start( ); // Blocks thread until finished
    /// 
    ///         Console.WriteLine( "Finished" );
    ///         Console.ReadKey( );
    ///     }
    /// 
    ///     private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
    ///     {
    ///         Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
    ///     }
    /// 
    ///     private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
    ///     {
    ///         Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    ///     }
    /// 
    ///     private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
    ///     {
    ///         Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    ///     }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    ///<example>
    /// Copy collection of files
    /// <code>
    /// <![CDATA[
    /// class Program
    /// {
    ///     static void Main( string[ ] args )
    ///     {
    ///        const string sourceDirectory = @"C:\transfer_test\source";
    ///        const string targetDirectory = @"C:\transfer_test\to";
    /// 
    ///        // search files
    ///        var files = QuickIODirectory.EnumerateFiles( sourceDirectory, SearchOption.TopDirectoryOnly )
    /// 
    ///        var service = new QuickIOTransferFileCopyService( files, targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );
    ///        
    ///        //  Progress information
    ///        service.Observer.FileCopyStarted += OnFileCopyStarted;
    ///        service.Observer.FileCopyProgress += OnFileCopyProgress;
    ///        service.Observer.FileCopyFinished += OnFileCopyFinished;
    ///        service.Observer.FileCopyError += ObserverOnFileCopyError;
    ///        // Same as (observer events are called first!):
    ///        //service.FileCopyStarted += OnFileCopyStarted;
    ///        //service.FileCopyProgress += OnFileCopyProgress;
    ///        //service.FileCopyFinished += OnFileCopyFinished;
    ///        //service.FileCopyError += ObserverOnFileCopyError;
    ///        
    ///        // Start progress
    ///        service.Start( ); // Blocks thread until finished
    ///        
    ///        Console.WriteLine( "Finished" );
    ///        Console.ReadKey( );
    ///     }
    /// 
    ///     private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
    ///     {
    ///        Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
    ///     }
    /// 
    ///     private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
    ///     {
    ///        Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
    ///     }
    /// 
    ///     private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
    ///     {
    ///        Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    ///     }
    /// 
    ///     private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
    ///     {
    ///        Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    public partial class QuickIOTransferFileCopyService : QuickIOTransferServiceBase
    {
        /// <summary>
        /// Directory to copy
        /// </summary>
        public List<QuickIOFileInfo> SourceFileInfos { get; private set; }

        /// <summary>
        /// Target fullname
        /// </summary>
        public string TargetFullName { get; private set; }

        /// <summary>
        /// true to overwrite existing content
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferDirectoryCopyService"/>
        /// </summary>
        /// <param name="observer">Observer for monitoring</param>
        /// <param name="sourceFileInfo">File to copy</param>
        /// <param name="targetFullName">Target fullname</param>
        /// <param name="threadCount">Copy Worker Counts. Use 1 on local systems. Use >2 with SMB shares</param>
        /// <param name="retryCount">Count of retries before copy is broken</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <example>
        /// Copy file
        /// 
        /// <code>
        /// <![CDATA[
        /// class Program
        /// {
        ///     static void Main( string[ ] args )
        ///     {
        ///        const string sourceDirectory = @"C:\transfer_test\source";
        ///        const string targetDirectory = @"C:\transfer_test\to";
        /// 
        ///        // search files
        ///        var file = new QuickIOFileInfo( "file" );
        /// 
        ///        var observer = new QuickIOTransferObserver( );
        ///        var service = new QuickIOTransferFileCopyService(observer,  file, targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );
        ///        
        ///        //  Progress information
        ///        service.Observer.FileCopyStarted += OnFileCopyStarted;
        ///        service.Observer.FileCopyProgress += OnFileCopyProgress;
        ///        service.Observer.FileCopyFinished += OnFileCopyFinished;
        ///        service.Observer.FileCopyError += ObserverOnFileCopyError;
        ///        // Same as (observer events are called first!):
        ///        //service.FileCopyStarted += OnFileCopyStarted;
        ///        //service.FileCopyProgress += OnFileCopyProgress;
        ///        //service.FileCopyFinished += OnFileCopyFinished;
        ///        //service.FileCopyError += ObserverOnFileCopyError;
        ///        
        ///        // Start progress
        ///        service.Start( ); // Blocks thread until finished
        ///        
        ///        Console.WriteLine( "Finished" );
        ///        Console.ReadKey( );
        ///     }
        /// 
        ///     private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
        ///     {
        ///        Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
        ///     }
        /// 
        ///     private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
        ///     }
        /// 
        ///     private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// 
        ///     private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
        ///     {
        ///        Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        public QuickIOTransferFileCopyService( IQuickIOTransferObserver observer, QuickIOFileInfo sourceFileInfo, String targetFullName, Int32 threadCount = 1, Int32 retryCount = 3, Boolean overwrite = false )
            : this( observer, new List<QuickIOFileInfo> { sourceFileInfo }, targetFullName, threadCount, retryCount, overwrite )
        {

        }


        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferDirectoryCopyService"/>
        /// </summary>
        /// <param name="sourceFileInfo">File to copy</param>
        /// <param name="targetFullName">Target fullname</param>
        /// <param name="threadCount">Copy Worker Counts. Use 1 on local systems. Use >2 with SMB shares</param>
        /// <param name="retryCount">Count of retries before copy is broken</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <example>
        /// Copy file
        /// 
        /// <code>
        /// <![CDATA[
        /// class Program
        /// {
        ///     static void Main( string[ ] args )
        ///     {
        ///        const string sourceDirectory = @"C:\transfer_test\source";
        ///        const string targetDirectory = @"C:\transfer_test\to";
        /// 
        ///        // search file
        ///        var file = new QuickIOFileInfo( "file" );
        /// 
        ///        var service = new QuickIOTransferFileCopyService( file, targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );
        ///        
        ///        //  Progress information
        ///        service.Observer.FileCopyStarted += OnFileCopyStarted;
        ///        service.Observer.FileCopyProgress += OnFileCopyProgress;
        ///        service.Observer.FileCopyFinished += OnFileCopyFinished;
        ///        service.Observer.FileCopyError += ObserverOnFileCopyError;
        ///        // Same as (observer events are called first!):
        ///        //service.FileCopyStarted += OnFileCopyStarted;
        ///        //service.FileCopyProgress += OnFileCopyProgress;
        ///        //service.FileCopyFinished += OnFileCopyFinished;
        ///        //service.FileCopyError += ObserverOnFileCopyError;
        ///        
        ///        // Start progress
        ///        service.Start( ); // Blocks thread until finished
        ///        
        ///        Console.WriteLine( "Finished" );
        ///        Console.ReadKey( );
        ///     }
        /// 
        ///     private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
        ///     {
        ///        Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
        ///     }
        /// 
        ///     private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
        ///     }
        /// 
        ///     private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// 
        ///     private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
        ///     {
        ///        Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        public QuickIOTransferFileCopyService( QuickIOFileInfo sourceFileInfo, String targetFullName, Int32 threadCount = 1, Int32 retryCount = 3, Boolean overwrite = false )
            : this( null, new List<QuickIOFileInfo> { sourceFileInfo }, targetFullName, threadCount, retryCount, overwrite )
        {

        }

        ///  <summary>
        ///  Creates new instance of <see cref="QuickIOTransferDirectoryCopyService"/>
        ///  </summary>
        /// <param name="sourceFileInfos">Files to copy</param>
        ///  <param name="targetFullName">Target fullname</param>
        ///  <param name="threadCount">Copy Worker Counts. Use 1 on local systems. Use >2 with SMB shares</param>
        ///  <param name="retryCount">Count of retries before copy is broken</param>
        ///  <param name="overwrite">true to overwrite existing files</param>
        /// <example>
        ///  Copy collection of files
        ///  <code>
        ///  <![CDATA[
        /// class Program
        /// {
        ///     static void Main( string[ ] args )
        ///     {
        ///        const string sourceDirectory = @"C:\transfer_test\source";
        ///        const string targetDirectory = @"C:\transfer_test\to";
        /// 
        ///        // search files
        ///        var files = QuickIODirectory.EnumerateFiles( sourceDirectory, SearchOption.TopDirectoryOnly );
        /// 
        ///        var service = new QuickIOTransferFileCopyService( files, targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );
        ///        
        ///        //  Progress information
        ///        service.Observer.FileCopyStarted += OnFileCopyStarted;
        ///        service.Observer.FileCopyProgress += OnFileCopyProgress;
        ///        service.Observer.FileCopyFinished += OnFileCopyFinished;
        ///        service.Observer.FileCopyError += ObserverOnFileCopyError;
        ///        // Same as (observer events are called first!):
        ///        //service.FileCopyStarted += OnFileCopyStarted;
        ///        //service.FileCopyProgress += OnFileCopyProgress;
        ///        //service.FileCopyFinished += OnFileCopyFinished;
        ///        //service.FileCopyError += ObserverOnFileCopyError;
        ///        
        ///        // Start progress
        ///        service.Start( ); // Blocks thread until finished
        ///        
        ///        Console.WriteLine( "Finished" );
        ///        Console.ReadKey( );
        ///     }
        /// 
        ///     private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
        ///     {
        ///        Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
        ///     }
        /// 
        ///     private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
        ///     }
        /// 
        ///     private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// 
        ///     private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
        ///     {
        ///        Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// }
        ///  ]]></code>
        ///  </example>
        public QuickIOTransferFileCopyService( IEnumerable<QuickIOFileInfo> sourceFileInfos, String targetFullName, Int32 threadCount = 1, Int32 retryCount = 3, Boolean overwrite = false )
            : this( null, sourceFileInfos, targetFullName, threadCount, retryCount, overwrite )
        {
            ;
        }

        ///  <summary>
        ///  Creates new instance of <see cref="QuickIOTransferDirectoryCopyService"/>
        ///  </summary>
        /// <param name="observer">Observer for monitoring</param>
        /// <param name="sourceFileInfos">Files to copy</param>
        ///  <param name="targetFullName">Target fullname</param>
        ///  <param name="threadCount">Copy Worker Counts. Use 1 on local systems. Use >2 with SMB shares</param>
        ///  <param name="retryCount">Count of retries before copy is broken</param>
        ///  <param name="overwrite">true to overwrite existing files</param>
        /// <example>
        ///  Copy collection of files
        ///  <code>
        ///  <![CDATA[
        /// class Program
        /// {
        ///     static void Main( string[ ] args )
        ///     {
        ///        const string sourceDirectory = @"C:\transfer_test\source";
        ///        const string targetDirectory = @"C:\transfer_test\to";
        /// 
        ///        // search files
        ///        var files = QuickIODirectory.EnumerateFiles( sourceDirectory, SearchOption.TopDirectoryOnly );
        /// 
        ///        var observer = new QuickIOTransferObserver( );
        ///        var service = new QuickIOTransferFileCopyService( observer, files, targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );
        /// 
        ///        //  Progress information
        ///        service.Observer.FileCopyStarted += OnFileCopyStarted;
        ///        service.Observer.FileCopyProgress += OnFileCopyProgress;
        ///        service.Observer.FileCopyFinished += OnFileCopyFinished;
        ///        service.Observer.FileCopyError += ObserverOnFileCopyError;
        ///        // Same as (observer events are called first!):
        ///        //service.FileCopyStarted += OnFileCopyStarted;
        ///        //service.FileCopyProgress += OnFileCopyProgress;
        ///        //service.FileCopyFinished += OnFileCopyFinished;
        ///        //service.FileCopyError += ObserverOnFileCopyError;
        ///        
        ///        // Start progress
        ///        service.Start( ); // Blocks thread until finished
        ///        
        ///        Console.WriteLine( "Finished" );
        ///        Console.ReadKey( );
        ///     }
        /// 
        ///     private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
        ///     {
        ///        Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
        ///     }
        /// 
        ///     private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
        ///     }
        /// 
        ///     private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
        ///     {
        ///        Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// 
        ///     private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
        ///     {
        ///        Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        ///     }
        /// }
        ///  ]]></code>
        ///  </example>
        public QuickIOTransferFileCopyService( IQuickIOTransferObserver observer, IEnumerable<QuickIOFileInfo> sourceFileInfos, String targetFullName, Int32 threadCount = 1, Int32 retryCount = 3, Boolean overwrite = false )
            : base( observer, threadCount, retryCount )
        {
            SourceFileInfos = new List<QuickIOFileInfo>( sourceFileInfos );
            TargetFullName = targetFullName;
            Overwrite = overwrite;

            // Register Events
            RegisterInternalEventHandling( );
        }

        private ulong _totalBytes;
        private readonly object _totalBytesLock = new object( );
        private ulong _totalBytesTransfered;
        private readonly object _totalBytesTransferedLock = new object( );

        /// <summary>
        /// Total bytes to transfer
        /// </summary>
        public UInt64 TotalBytes
        {
            get
            {
                lock ( _totalBytesLock )
                {
                    return _totalBytes;
                }
            }
            private set
            {
                lock ( _totalBytesLock )
                {
                    _totalBytes = value;
                }
            }
        }

        /// <summary>
        /// Total bytes transfered
        /// </summary>
        public UInt64 TotalBytesTransfered
        {
            get
            {
                lock ( _totalBytesTransferedLock )
                {
                    return _totalBytesTransfered;
                }
            }
            private set
            {
                lock ( _totalBytesTransferedLock )
                {
                    _totalBytesTransfered = value;
                }
            }
        }

        /// <summary>
        /// Null if not started
        /// </summary>
        public DateTime? TransferStarted { get; private set; }

        /// <summary>
        /// Null if not finished
        /// </summary>
        public DateTime? TransferFinished { get; private set; }

        /// <summary>
        /// Total duration. If transfer is not finished the current timestamp is used for the calculation
        /// </summary>
        public TimeSpan? Duration
        {
            get
            {
                if ( TransferStarted == null )
                {
                    return null;
                }
                return ( ( TransferFinished ?? DateTime.Now ).Subtract( ( DateTime ) TransferStarted ) );
            }
        }

        /// <summary>
        /// Bytes per second
        /// </summary>
        public Double BytesPerSecond
        {
            get
            {
                var transfered = TotalBytesTransfered;

                var d = Duration;
                if ( d == null || transfered == 0 )
                {
                    return 0;
                }

                return transfered * 1.0 / ( ( TimeSpan ) d ).TotalSeconds;
            }
        }

        /// <summary>
        /// Bytes per second
        /// </summary>
        public Double Percentage
        {
            get
            {
                var total = TotalBytes;
                var transfered = TotalBytesTransfered;

                if ( total == 0 || transfered == 0 )
                {
                    return 0;
                }
                if ( total == transfered )
                {
                    return 100;
                }

                return ( transfered * 1.0 / total * 100.0 );
            }
        }

        /// <summary>
        /// Starts the copy process.
        /// First it determines all content information of source. Then the target directory structure will be created before transfer begins
        /// </summary>
        /// <exception cref="InvalidOperationException">Service is already running.</exception>
        /// <exception cref="ObjectDisposedException">Fired if you try to start a same service multiple times.</exception>
        public void Start()
        {
            try
            {
                if ( base.IsWorking )
                {
                    throw new InvalidOperationException( "Already running." );
                }

                if ( TransferFinished != null )
                {
                    throw new ObjectDisposedException( "Service already finished. Unable to start same service multiple times." );
                }

                TransferStarted = DateTime.Now;
                TransferFinished = null;

                var targetUnc = QuickIOPath.ToUncPath( TargetFullName );

                var fileTransferQueueItems = new List<QuickIOTransferJob>( );

                foreach ( var file in SourceFileInfos )
                {

                    var target = targetUnc + QuickIOPath.DirectorySeparatorChar + file.Name;
                    fileTransferQueueItems.Add( new QuickIOTransferFileCopyJob( file.FullNameUnc, target, MaxBufferSize, Overwrite, true ) );
                    TotalBytes += file.Bytes;
                }

                InternalAddRange( fileTransferQueueItems );

                base.StartWorking( );

                // No more will be added
                CompleteAdding( );

                // Wait for finish
                WaitForFinish( );
            }
            finally
            {
                TransferFinished = DateTime.Now;
            }
        }

#if NET40_OR_GREATER
        /// <summary>
        /// Starts the copy process as task.
        /// First it determines all content information of source. Then the target directory structure will be created before transfer begins
        /// </summary>
        public Task StartAsync()
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( Start );
        }
#endif
    }
}