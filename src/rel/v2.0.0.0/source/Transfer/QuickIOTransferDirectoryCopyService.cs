// <copyright file="QuickIOTransferDirectoryCopyService.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferDirectoryCopyService</summary>

using System;
using System.Collections.Generic;
using System.IO;
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
        public QuickIODirectoryInfo SourceDirectoryInfo { get; private set; }

        /// <summary>
        /// Target fullname
        /// </summary>
        public string TargetFullName { get; private set; }

        /// <summary>
        /// Deepth to copy
        /// </summary>
        public SearchOption SearchOption { get; set; }

        /// <summary>
        /// true to overwrite existing content
        /// </summary>
        public bool Overwrite { get; set; }

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
            : this( null, sourceDirectoryInfo, targetFullName, threadCount, retryCount, searchOption, overwrite )
        {
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
            : base( observer, threadCount, retryCount )
        {
            SourceDirectoryInfo = sourceDirectoryInfo;
            TargetFullName = targetFullName;
            SearchOption = searchOption;
            Overwrite = overwrite;

            // Register Events
            RegisterInternalEventHandling( );

            StartWorking( );
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
        public void Start()
        {
            try
            {
                if ( IsRunning )
                {
                    throw new Exception( "Already running." );
                }

                // Load prefences
                var preferences = DetermineDirectoryTransferPrefences( SourceDirectoryInfo, TargetFullName, SearchOption, Overwrite );

                InternalAddRange( preferences.CreateDirectoryJobs );
                InternalAddRange( preferences.FileTransferQueueItems );

                // No more will be added
                CompleteAdding( );

                // Wait for finish
                WaitForFinish( );
            }
            finally
            {
                IsRunning = false;
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

        private class InternalDirectoryTransferPrefences
        {
            public List<QuickIOTransferJob> CreateDirectoryJobs { get; set; }
            public List<QuickIOTransferJob> FileTransferQueueItems { get; set; }
        }

        private InternalDirectoryTransferPrefences DetermineDirectoryTransferPrefences( QuickIODirectoryInfo sourceDirectoryInfo, String targetFullName, SearchOption searchOption, Boolean overwrite )
        {
            var prefences = new InternalDirectoryTransferPrefences( );

            IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> allContentUncPaths = QuickIODirectory.EnumerateFileSystemEntryPaths( sourceDirectoryInfo, QuickIOPatternConstants.All, searchOption, QuickIOPathType.UNC );

            var targetPathInfo = new QuickIOPathInfo( targetFullName );

            prefences.CreateDirectoryJobs = new List<QuickIOTransferJob>( );
            prefences.FileTransferQueueItems = new List<QuickIOTransferJob>( );
            foreach ( var entry in allContentUncPaths )
            {
                var target = targetPathInfo.FullNameUnc + entry.Key.Substring( sourceDirectoryInfo.FullNameUnc.Length );

                switch ( entry.Value )
                {
                    case QuickIOFileSystemEntryType.Directory:
                        {
                            prefences.CreateDirectoryJobs.Add( new QuickIOTransferDirectoryCreationJob( target ) );
                        }
                        break;

                    case QuickIOFileSystemEntryType.File:
                        {
                            prefences.FileTransferQueueItems.Add( new QuickIOTransferFileCopyJob( entry.Key, target, MaxBufferSize, overwrite, false ) );
                        }
                        break;
                }
            }

            return prefences;
        }
    }
}