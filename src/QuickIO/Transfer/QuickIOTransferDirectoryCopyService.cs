// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Copy directory with progress monitoring
    /// </summary>
    /// <example>
    /// Copy complete directory
    /// <code>
    /// <![CDATA[
    /// static void Main( string[ ] args )
    /// {
    ///     const string sourceDirectory = @"C:\transfer_test\source";
    ///     const string targetDirectory = @"C:\transfer_test\to";
    /// 
    /// 
    ///     // With observer
    ///     IQuickIOTransferObserver observer = new QuickIOTransferObserver( );
    ///     var service = new QuickIOTransferDirectoryCopyService( observer, new QuickIODirectoryInfo( sourceDirectory ), targetDirectory, threadCount: 1, retryCount: 3, searchOption: SearchOption.AllDirectories, overwrite: true );
    ///     // or without overload, to use default internal observer
    ///     // var service = new QuickIOTransferDirectoryCopyService( new QuickIODirectoryInfo( sourceDirectory ), targetDirectory, threadCount: 1, retryCount: 3, searchOption: SearchOption.AllDirectories, overwrite: true );
    /// 
    ///     //  Progress information
    ///     service.Observer.DirectoryCreationError += ObserverOnDirectoryCreationError;
    ///     service.Observer.FileCopyStarted += OnFileCopyStarted;
    ///     service.Observer.FileCopyProgress += OnFileCopyProgress;
    ///     service.Observer.FileCopyFinished += OnFileCopyFinished;
    ///     service.Observer.FileCopyError += ObserverOnFileCopyError;
    ///     // Same as (observer events are called first!):
    ///     service.FileCopyStarted += OnFileCopyStarted;
    ///     service.FileCopyProgress += OnFileCopyProgress;
    ///     service.FileCopyFinished += OnFileCopyFinished;
    ///     service.FileCopyError += ObserverOnFileCopyError;
    /// 
    ///     // Start progress
    ///     service.Start( ); // Blocks thread until finished
    /// 
    ///     Console.WriteLine( "Finished" );
    ///     Console.ReadKey( );
    /// }
    /// 
    /// private static void ObserverOnDirectoryCreationError( object sender, QuickIOTransferDirectoryCreationErrorEventArgs e )
    /// {
    ///     Console.WriteLine( "Error: Dir create '" + e.TargetPath + "' failed: " + e.Exception.Message );
    /// }
    /// 
    /// private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
    /// {
    ///     Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
    /// }
    /// 
    /// private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
    /// {
    ///     Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
    /// }
    /// 
    /// private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
    /// {
    ///     Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    /// }
    /// 
    /// private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
    /// {
    ///     Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public partial class QuickIOTransferDirectoryCopyService : QuickIOTransferServiceBase
    {
        /// <summary>
        /// Directory to copy
        /// </summary>
        public QuickIODirectoryInfo SourceDirectoryInfo { get; }

        /// <summary>
        /// Target fullname
        /// </summary>
        public string TargetFullName { get; }

        /// <summary>
        /// Deepth to copy
        /// </summary>
        public SearchOption SearchOption { get; }

        /// <summary>
        /// true to overwrite existing content
        /// </summary>
        public bool Overwrite { get; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferDirectoryCopyService"/> with default observer
        /// </summary>
        /// <param name="sourceDirectoryInfo">Directory to copy</param>
        /// <param name="targetFullName">Target fullname</param>
        /// <param name="threadCount">Copy Worker Counts. Use 1 on local systems. Use >2 with SMB shares</param>
        /// <param name="retryCount">Count of retries before copy is broken</param>
        /// <param name="searchOption"><see cref="SearchOption"/>of deepth to copy</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <example>
        /// Copy complete directory
        /// <code>
        /// <![CDATA[
        /// static void Main( string[ ] args )
        /// {
        ///     const string sourceDirectory = @"C:\transfer_test\source";
        ///     const string targetDirectory = @"C:\transfer_test\to";
        /// 
        /// 
        ///     // With observer
        ///     IQuickIOTransferObserver observer = new QuickIOTransferObserver( );
        ///     var service = new QuickIOTransferDirectoryCopyService( observer, new QuickIODirectoryInfo( sourceDirectory ), targetDirectory, threadCount: 1, retryCount: 3, searchOption: SearchOption.AllDirectories, overwrite: true );
        ///     // or without overload, to use default internal observer
        ///     // var service = new QuickIOTransferDirectoryCopyService( new QuickIODirectoryInfo( sourceDirectory ), targetDirectory, threadCount: 1, retryCount: 3, searchOption: SearchOption.AllDirectories, overwrite: true );
        /// 
        ///     //  Progress information
        ///     service.Observer.DirectoryCreationError += ObserverOnDirectoryCreationError;
        ///     service.Observer.FileCopyStarted += OnFileCopyStarted;
        ///     service.Observer.FileCopyProgress += OnFileCopyProgress;
        ///     service.Observer.FileCopyFinished += OnFileCopyFinished;
        ///     service.Observer.FileCopyError += ObserverOnFileCopyError;
        ///     // Same as (observer events are called first!):
        ///     service.FileCopyStarted += OnFileCopyStarted;
        ///     service.FileCopyProgress += OnFileCopyProgress;
        ///     service.FileCopyFinished += OnFileCopyFinished;
        ///     service.FileCopyError += ObserverOnFileCopyError;
        /// 
        ///     // Start progress
        ///     service.Start( ); // Blocks thread until finished
        /// 
        ///     Console.WriteLine( "Finished" );
        ///     Console.ReadKey( );
        /// }
        /// 
        /// private static void ObserverOnDirectoryCreationError( object sender, QuickIOTransferDirectoryCreationErrorEventArgs e )
        /// {
        ///     Console.WriteLine( "Error: Dir create '" + e.TargetPath + "' failed: " + e.Exception.Message );
        /// }
        /// 
        /// private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
        /// {
        ///     Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
        /// }
        /// 
        /// private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
        /// {
        ///     Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
        /// }
        /// 
        /// private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
        /// {
        ///     Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        /// }
        /// 
        /// private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
        /// {
        ///     Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        /// }
        /// ]]>
        /// </code>
        /// </example>
        public QuickIOTransferDirectoryCopyService( QuickIODirectoryInfo sourceDirectoryInfo, String targetFullName, Int32 threadCount = 1, Int32 retryCount = 3, SearchOption searchOption = SearchOption.TopDirectoryOnly, Boolean overwrite = false )
            : this( null, sourceDirectoryInfo, targetFullName, Math.Max( threadCount, 1 ), Math.Max( retryCount, 0 ), searchOption, overwrite )
        {
            Contract.Requires( sourceDirectoryInfo != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( targetFullName ) );
            Contract.Requires( threadCount >= 1 );
            Contract.Requires( retryCount >= 0 );
        }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferDirectoryCopyService"/> with specified observer
        /// </summary>
        /// <param name="observer">Observer</param>
        /// <param name="sourceDirectoryInfo">Directory to copy</param>
        /// <param name="targetFullName">Target fullname</param>
        /// <param name="threadCount">Copy Worker Counts. Use 1 on local systems. Use >2 with SMB shares</param>
        /// <param name="retryCount">Count of retries before copy is broken</param>
        /// <param name="searchOption"><see cref="SearchOption"/>of deepth to copy</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <example>
        /// Copy complete directory
        /// <code>
        /// <![CDATA[
        /// static void Main( string[ ] args )
        /// {
        ///     const string sourceDirectory = @"C:\transfer_test\source";
        ///     const string targetDirectory = @"C:\transfer_test\to";
        /// 
        /// 
        ///     // With observer
        ///     IQuickIOTransferObserver observer = new QuickIOTransferObserver( );
        ///     var service = new QuickIOTransferDirectoryCopyService( observer, new QuickIODirectoryInfo( sourceDirectory ), targetDirectory, threadCount: 1, retryCount: 3, searchOption: SearchOption.AllDirectories, overwrite: true );
        ///     // or without overload, to use default internal observer
        ///     // var service = new QuickIOTransferDirectoryCopyService( new QuickIODirectoryInfo( sourceDirectory ), targetDirectory, threadCount: 1, retryCount: 3, searchOption: SearchOption.AllDirectories, overwrite: true );
        /// 
        ///     //  Progress information
        ///     service.Observer.DirectoryCreationError += ObserverOnDirectoryCreationError;
        ///     service.Observer.FileCopyStarted += OnFileCopyStarted;
        ///     service.Observer.FileCopyProgress += OnFileCopyProgress;
        ///     service.Observer.FileCopyFinished += OnFileCopyFinished;
        ///     service.Observer.FileCopyError += ObserverOnFileCopyError;
        ///     // Same as (observer events are called first!):
        ///     service.FileCopyStarted += OnFileCopyStarted;
        ///     service.FileCopyProgress += OnFileCopyProgress;
        ///     service.FileCopyFinished += OnFileCopyFinished;
        ///     service.FileCopyError += ObserverOnFileCopyError;
        /// 
        ///     // Start progress
        ///     service.Start( ); // Blocks thread until finished
        /// 
        ///     Console.WriteLine( "Finished" );
        ///     Console.ReadKey( );
        /// }
        /// 
        /// private static void ObserverOnDirectoryCreationError( object sender, QuickIOTransferDirectoryCreationErrorEventArgs e )
        /// {
        ///     Console.WriteLine( "Error: Dir create '" + e.TargetPath + "' failed: " + e.Exception.Message );
        /// }
        /// 
        /// private static void ObserverOnFileCopyError( object sender, QuickIOTransferFileCopyErrorEventArgs e )
        /// {
        ///     Console.WriteLine( "Error: " + e.SourcePath + " to " + e.TargetPath + ": " + e.Exception.Message );
        /// }
        /// 
        /// private static void OnFileCopyStarted( object sender, QuickIOTransferFileCopyStartedEventArgs e )
        /// {
        ///     Console.WriteLine( "Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")" );
        /// }
        /// 
        /// private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedEventArgs e )
        /// {
        ///     Console.WriteLine( "Finished: " + e.SourcePath + " - MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        /// }
        /// 
        /// private static void OnFileCopyProgress( object sender, QuickIOTransferFileCopyProgressEventArgs e )
        /// {
        ///     Console.WriteLine( "Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + ( e.BytesPerSecond / 1024.0 / 1024.0 ).ToString( "0.0" ) );
        /// }
        /// ]]>
        /// </code>
        /// </example>
        public QuickIOTransferDirectoryCopyService( IQuickIOTransferObserver observer, QuickIODirectoryInfo sourceDirectoryInfo, String targetFullName, Int32 threadCount = 1, Int32 retryCount = 3, SearchOption searchOption = SearchOption.TopDirectoryOnly, Boolean overwrite = false )
            : base( observer, Math.Max( threadCount, 1 ), Math.Max( retryCount, 0 ) )
        {
            Contract.Requires( sourceDirectoryInfo != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( targetFullName ) );
            Contract.Requires( threadCount >= 1 );
            Contract.Requires( retryCount >= 0 );

            SourceDirectoryInfo = sourceDirectoryInfo;
            TargetFullName = targetFullName;
            SearchOption = searchOption;
            Overwrite = overwrite;

            // Register Events
            RegisterInternalEventHandling();

            StartWorking();
        }

        /// <summary>
        /// thread safe indicator if copy is running
        /// </summary>
        private volatile bool _running;

        /// <summary>
        /// true if copy process is running
        /// </summary>
        public Boolean IsRunning
        {
            get { return _running; }
            protected set { _running = value; }
        }

        /// <summary>
        /// Starts the copy process.
        /// First it determines all content information of source. Then the target directory structure will be created before transfer begins
        /// </summary>
        /// <exception cref="QuickIOTransferAlreadyRunningException">If already running.</exception>
        public void Start()
        {
            try
            {
                if( IsRunning )
                {
                    throw new QuickIOTransferAlreadyRunningException( "Already running." );
                }

                // load jobs
                IList<QuickIOTransferDirectoryCreationJob> dirCreateJobs = null;
                IList<QuickIOTransferFileCopyJob> fileCreateJobs = null;

                LoadAllJobs( out dirCreateJobs, out fileCreateJobs );

                // first add dir jobs
                InternalAdd( dirCreateJobs );
                InternalAdd( fileCreateJobs );

                // No more will be added
                CompleteAdding();

                // Wait for finish
                WaitForFinish();
            }
            finally
            {
                IsRunning = false;
            }
        }


        private void LoadAllJobs( out IList<QuickIOTransferDirectoryCreationJob> dirCreateJobs, out IList<QuickIOTransferFileCopyJob> fileCreateJobs )
        {
            Contract.Ensures( dirCreateJobs != null );
            Contract.Ensures( fileCreateJobs != null );

            IEnumerable<QuickIOFileSystemEntry> allContentUncPaths = InternalEnumerateFileSystem.EnumerateFileSystemEntries( SourceDirectoryInfo.FullNameUnc, QuickIOPatterns.PathMatchAll, SearchOption );

            string targetPathUnc = QuickIOPath.ToPathUnc( TargetFullName );

            dirCreateJobs = new List<QuickIOTransferDirectoryCreationJob>();
            fileCreateJobs = new List<QuickIOTransferFileCopyJob>();

            foreach( QuickIOFileSystemEntry entry in allContentUncPaths )
            {
                string newSourcePathUnc = entry.GetPathUnc();
                string newTargetPathUnc = targetPathUnc + newSourcePathUnc.Substring( SourceDirectoryInfo.FullNameUnc.Length );

                switch( entry.Type )
                {
                    case QuickIOFileSystemEntryType.Directory:
                        {
                            dirCreateJobs.Add( new QuickIOTransferDirectoryCreationJob( newTargetPathUnc ) );
                        }
                        break;

                    case QuickIOFileSystemEntryType.File:
                        {
                            fileCreateJobs.Add( new QuickIOTransferFileCopyJob( newSourcePathUnc, newTargetPathUnc, MaxBufferSize, Overwrite, false ) );
                        }
                        break;
                    default:
                        throw new NotSupportedException( $"Unknown type '{entry.Type}'" );
                }
            }
        }
    }
}