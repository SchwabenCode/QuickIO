// <copyright file="QuickIOTransferFileCreationJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCreationJob</summary>

using System;
using System.IO;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// File Create job implementation
    /// </summary>
    /// <example>
    /// File Create job with observer
    /// <code>
    /// <![CDATA[
    /// public void CreateJobWithObserver( IQuickIOTransferObserver observer, String sourceFile, String targetDirectory )
    /// {
    ///     var createJob = new QuickIOTransferFileCreationJob( observer, sourceFile, targetDirectory, GenerateDummyContent( ) );
    /// 
    ///     createJob.CreationStarted += OnCreationStarted;
    ///     createJob.CreationProgress += OnCreationProgress;
    ///     createJob.CreationFinished += OnCreationFinished;
    /// 
    ///     createJob.Run( );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// File create job
    /// <code>
    /// <![CDATA[
    /// public void CreateJob( String sourceFile, String targetDirectory, Int32 maxBufferSize )
    /// {
    ///     var createJob = new QuickIOTransferFileCreationJob( sourceFile, targetDirectory, GenerateDummyContent( ) );
    /// 
    ///     createJob.CreationStarted += OnCreationStarted;
    ///     createJob.CreationProgress += OnCreationProgress;
    ///     createJob.CreationFinished += OnCreationFinished;
    /// 
    ///     createJob.Run( );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// Event definitions for this example
    /// <code>
    /// <![CDATA[
    /// private byte[ ] GenerateDummyContent()
    /// {
    ///     return System.Text.Encoding.UTF8.GetBytes( "Hello. THis is file creation" );
    /// }
    /// 
    /// private static void OnCreationFinished( object sender, QuickIOTransferFileCreationFinishedArgs e )
    /// {
    ///     Console.WriteLine( "TestFileCreationJob: Creation Finished." );
    /// }
    /// 
    /// private static void OnCreationProgress( object sender, QuickIOTransferFileCreationProgressArgs e )
    /// {
    ///     Console.WriteLine( "TestFileCreationJob: Creation progresss: " + e.Percentage.ToString( "0.00" ) );
    /// }
    /// 
    /// private static void OnCreationStarted( object sender, QuickIOTransferFileCreationStartedArgs e )
    /// {
    ///     Console.WriteLine( "TestFileCreationJob: Creation started." );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// </example>
    public class QuickIOTransferFileCreationJob : QuickIOTransferJobWriteJob
    {
        private volatile int _maxJobRetryAttempts;

        #region Properties
        /// <summary>
        /// JobType
        /// </summary>
        internal override QuickIOTransferJobType JobType
        {
            get
            {
                return QuickIOTransferJobType.FileCreation;
            }
        }

        /// <summary>
        /// Count of max retries per job
        /// </summary>
        public int MaxJobRetryAttempts
        {
            get { return _maxJobRetryAttempts; }
            set { _maxJobRetryAttempts = value; }
        }

        #endregion

        /// <summary>
        /// Starts the creation process
        /// </summary>
        protected override void Implementation( )
        {
            TransferStarted = DateTime.Now;

            var targetFullnameInfo = new QuickIOPathInfo( QuickIOPath.Combine( TargetDirectory, FileName ) );

            if ( targetFullnameInfo.Exists && !Overwrite )
            {
                CurrentRetryCount = MaxJobRetryAttempts; // no sense to requeue
                throw new FileAlreadyExistsException( targetFullnameInfo.FullName );
            }

            if ( !targetFullnameInfo.Parent.Exists )
            {
                OnDirectoryCreating( targetFullnameInfo.Parent.FullName );

                QuickIODirectory.Create( targetFullnameInfo.Parent, true );

                OnDirectoryCreated( targetFullnameInfo.Parent.FullName );
            }

            using ( var rs = new MemoryStream( Contents ) )
            using ( var ws = QuickIOFile.Open( targetFullnameInfo, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None ) )
            {
                var totalBytes = rs.Length;

                OnCreationStarted( totalBytes );

                // set target stream length
                ws.SetLength( totalBytes );

                int bytesRead;
                UInt64 bytesTransfered = 0;

                // check buffer for small files; will be faster
                var bytes = new byte[ Math.Min( totalBytes, MaxBufferSize ) ];

                // transfer chunks
                while ( ( bytesRead = rs.Read( bytes, 0, bytes.Length ) ) > 0 )
                {
                    // Write
                    ws.Write( bytes, 0, bytesRead );

                    // Calculation
                    bytesTransfered = ( bytesTransfered + ( UInt64 ) bytesRead );

                    OnCreationProgress( totalBytes, bytesTransfered );
                }
                OnCreationFinished( totalBytes );
            }
        }


        /// <summary>
        /// Creates a new instance if <see cref="QuickIOTransferFileCreationJob"/>
        /// </summary>
        /// <param name="contents">Contents to write</param>
        /// <param name="maxBufferSize">Set max buffer size for copy transfer</param>
        /// <param name="overwrite">true to overwrite existing elements</param>
        /// <param name="targetDirectory">Target directory fullname</param>
        /// <param name="fileName">Target filename</param>
        /// <param name="parentExistanceCheck">true to verify parent existance</param>
        /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
        public QuickIOTransferFileCreationJob( String targetDirectory, String fileName, Byte[ ] contents, Int32 maxBufferSize = 1024, bool overwrite = false, bool parentExistanceCheck = true, Int32 prorityLevel = 0 )
            : this( null, targetDirectory, fileName, contents, maxBufferSize, overwrite, parentExistanceCheck, prorityLevel )
        {
        }

        /// <summary>
        /// Creates a new instance if <see cref="QuickIOTransferFileCreationJob"/>
        /// </summary>
        /// <param name="contents">Contents to write</param>
        /// <param name="overwrite">true to overwrite existing elements</param>
        /// <param name="maxBufferSize">Set max buffer size for copy transfer</param>
        /// <param name="observer">Observer</param>
        /// <param name="targetDirectory">Target directory fullname</param>
        /// <param name="fileName">Target filename</param>
        /// <param name="parentExistanceCheck">true to verify parent existance</param>
        /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
        public QuickIOTransferFileCreationJob( IQuickIOTransferObserver observer, String targetDirectory, String fileName, Byte[ ] contents, Int32 maxBufferSize = 1024, bool overwrite = false, bool parentExistanceCheck = true, Int32 prorityLevel = 0 ) :
            base( observer, prorityLevel )
        {
            Invariant.NotEmpty( targetDirectory );
            Invariant.NotEmpty( fileName );

            // Parent
            Overwrite = overwrite;

            //Own
            MaxBufferSize = Math.Max( 1024, maxBufferSize );
            TargetDirectory = targetDirectory;
            FileName = fileName;
            Contents = contents;
            ParentExistanceCheck = parentExistanceCheck;

            TargetFullName = QuickIOPath.Combine( TargetDirectory, FileName );
        }

        /// <summary>
        /// Target directory
        /// </summary>
        public String TargetDirectory { get; private set; }

        /// <summary>
        /// Target directory
        /// </summary>
        public string TargetFullName { get; private set; }

        /// <summary>
        /// Filename with extension
        /// </summary>
        public String FileName { get; private set; }

        /// <summary>
        /// Contents to write
        /// </summary>
        public byte[ ] Contents { get; private set; }

        /// <summary>
        /// Transfer started
        /// </summary>
        public DateTime? TransferStarted { get; internal set; }


        #region Events
        /// <summary>
        /// This event is raised during a creation of a file. It provides current information such as progress, speed and estimated time.
        /// </summary>
        public event QuickIOTransferFileCreationProgressHandler Progress;

        /// <summary>
        /// This event is triggered at the beginning of the file creation operation.
        /// </summary>
        public event QuickIOTransferFileCreationStartedHandler Started;

        /// <summary>
        /// This event is raised at the end of the file creation operation.
        /// </summary>
        public event QuickIOTransferFileCreationFinishedHandler Finished;
        /// <summary>
        /// This event is raised if file creation fails
        /// </summary>
        public new event QuickIOTransferFileCreationErrorHandler Error;

        /// <summary>
        /// This event is raised before an upcoming directory creation operation is performed
        /// </summary>
        public event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;

        /// <summary>
        /// This event is raised when a directory was created
        /// </summary>
        public event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;

        /// <summary>
        /// Fires <see cref="Progress"/>
        /// </summary>
        private void OnCreationProgress( Int64 totalBytes, UInt64 bytesTransfered )
        {
            QuickIOTransferFileCreationProgressEventArgs args = null;
            if ( Progress != null )
            {
                args = new QuickIOTransferFileCreationProgressEventArgs( this, TargetFullName, totalBytes, bytesTransfered, ( DateTime ) TransferStarted );
                Progress( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCreationProgressEventArgs( this, TargetFullName, totalBytes, bytesTransfered, ( DateTime ) TransferStarted );
                }
                Observer.OnFileCreationProgress( args );
            }
        }
        /// <summary>
        /// Fires <see cref="Progress"/>
        /// </summary>
        private void OnCreationStarted( Int64 totalBytes )
        {
            QuickIOTransferFileCreationStartedEventArgs args = null;
            if ( Started != null )
            {
                args = new QuickIOTransferFileCreationStartedEventArgs( this, TargetFullName, totalBytes );
                Started( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCreationStartedEventArgs( this, TargetFullName, totalBytes );
                }
                Observer.OnFileCreationStarted( args );
            }
        }
        /// <summary>
        /// Fires <see cref="Finished"/>
        /// </summary>
        private void OnCreationFinished( Int64 totalBytes )
        {
            QuickIOTransferFileCreationFinishedEventArgs args = null;
            if ( Finished != null )
            {
                args = new QuickIOTransferFileCreationFinishedEventArgs( this, TargetFullName, totalBytes, ( DateTime ) TransferStarted );
                Finished( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCreationFinishedEventArgs( this, TargetFullName, totalBytes, ( DateTime ) TransferStarted );
                }
                Observer.OnFileCreationFinished( args );
            }
        }

        /// <summary>
        /// Fires <see cref="Error"/>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError( Exception e )
        {
            // base throw not important
            //base.OnError( e ); 

            QuickIOTransferFileCreationErrorEventArgs args = null;
            if ( Error != null )
            {
                args = new QuickIOTransferFileCreationErrorEventArgs( this, TargetFullName, e );
                Error( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCreationErrorEventArgs( this, TargetFullName, e );
                }
                Observer.OnFileCreationError( args );
            }
        }

        /// <summary>
        /// Fire <see cref="DirectoryCreating"/>
        /// </summary>
        private void OnDirectoryCreating( String directoryPath )
        {
            QuickIOTransferDirectoryCreatingEventArgs args = null;
            if ( DirectoryCreating != null )
            {
                args = new QuickIOTransferDirectoryCreatingEventArgs( this, directoryPath );
                DirectoryCreating( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferDirectoryCreatingEventArgs( this, directoryPath );
                }
                Observer.OnDirectoryCreating( args );
            }
        }


        /// <summary>
        /// Fires <see cref="DirectoryCreated"/>
        /// </summary>
        private void OnDirectoryCreated( String directoryPath )
        {
            QuickIOTransferDirectoryCreatedEventArgs args = null;
            if ( DirectoryCreated != null )
            {
                args = new QuickIOTransferDirectoryCreatedEventArgs( this, directoryPath );
                DirectoryCreated( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferDirectoryCreatedEventArgs( this, directoryPath );
                }
                Observer.OnDirectoryCreated( args );
            }
        }

        #endregion
    }
}