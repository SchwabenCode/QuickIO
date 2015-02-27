// <copyright file="QuickIOTransferFileCopyJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCopyJob</summary>

using System;
using System.IO;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// File Copy job implementation
    /// </summary>
    /// <example>
    /// File Copy job with observer
    /// <code>
    /// <![CDATA[
    /// public void CopyJobWithObserver( IQuickIOTransferObserver observer, String sourceFile, String targetDirectory, Int32 maxBufferSize )
    /// {
    ///     var copyJob = new QuickIOTransferFileCopyJob( observer, sourceFile, targetDirectory, maxBufferSize, overwrite: true, parentExistanceCheck: true );
    /// 
    ///     copyJob.CopyStarted += OnCopyStarted;
    ///     copyJob.CopyProgress += OnCopyProgress;
    ///     copyJob.CopyFinished += OnFileCopyFinished;
    /// 
    ///     copyJob.Run( );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// File copy job
    /// <code>
    /// <![CDATA[
    /// public void CopyJob( String sourceFile, String targetDirectory, Int32 maxBufferSize )
    /// {
    ///     var copyJob = new QuickIOTransferFileCopyJob( sourceFile, targetDirectory, maxBufferSize, overwrite: true, parentExistanceCheck: true );
    /// 
    ///     copyJob.CopyStarted += OnCopyStarted;
    ///     copyJob.CopyProgress += OnCopyProgress;
    ///     copyJob.CopyFinished += OnFileCopyFinished;
    /// 
    ///     copyJob.Run( );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// Event definitions for this example
    /// <code>
    /// <![CDATA[
    /// private static void OnFileCopyFinished( object sender, QuickIOTransferFileCopyFinishedArgs e )
    /// {
    ///     Console.WriteLine( "TestFileCopyJob: Copy Finished." );
    /// }
    /// 
    /// private static void OnCopyProgress( object sender, QuickIOTransferFileCopyProgressArgs e )
    /// {
    ///     Console.WriteLine( "TestFileCopyJob: Copy progresss: " + e.Percentage.ToString( "0.00" ) );
    /// }
    /// 
    /// private static void OnCopyStarted( object sender, QuickIOTransferFileCopyStartedArgs e )
    /// {
    ///     Console.WriteLine( "TestFileCopyJob: Copy started." );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// </example>
    public class QuickIOTransferFileCopyJob : QuickIOTransferJobWriteJob
    {
        private volatile bool _copyTimestamps;
        private DateTime? _transferStarted;
        private readonly Object _transferStartedLock = new object( );


        /// <summary>
        /// JobType
        /// </summary>
        internal override QuickIOTransferJobType JobType
        {
            get
            {
                return QuickIOTransferJobType.FileCopy;
            }
        }

        /// <summary>
        /// Executes the Copy process
        /// </summary>
        protected override void Implementation( )
        {
            TransferStarted = DateTime.Now;

            var sourceInfo = new QuickIOFileInfo( Source );
            var targetFilePathInfo = new QuickIOPathInfo( Target );

            if ( targetFilePathInfo.Exists && !Overwrite )
            {
                throw new FileAlreadyExistsException( Target );
            }

            if ( ParentExistanceCheck )
            {
                OnDirectoryCreating( targetFilePathInfo.Parent.FullName );

                QuickIODirectory.Create( targetFilePathInfo.Parent, true );

                OnDirectoryCreated( targetFilePathInfo.Parent.FullName );
            }

            long totalBytes;
            using ( var rs = sourceInfo.OpenRead( ) )
            using ( var ws = QuickIOFile.Open( targetFilePathInfo, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None ) )
            {
                totalBytes = rs.Length;

                OnCopyStarted( totalBytes );

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


                    OnCopyProgress( totalBytes, bytesTransfered );
                }
            }

            // Copy Timestamps
            if ( CopyTimestamps )
            {
                QuickIOFile.SetAllFileTimes( targetFilePathInfo, sourceInfo.CreationTime, sourceInfo.LastAccessTime, sourceInfo.LastWriteTime );
            }

            // Copy Attributes
            if ( CopyAttributes )
            {
                QuickIOFile.SetAttributes( targetFilePathInfo, sourceInfo.Attributes );
            }

            OnCopyFinished( totalBytes );
        }

        /// <summary>
        /// Fullname source
        /// </summary>
        public String Source { get; private set; }

        /// <summary>
        /// Fullname target
        /// </summary>
        public String Target { get; private set; }


        /// <summary>
        /// Creates a new queue item
        /// </summary>
        /// <param name="source">Fullname source</param>
        /// <param name="target">Fullname target</param>
        /// <param name="maxBufferSize">Set max buffer size for copy transfer</param>
        /// <param name="overwrite">true overwrites existing files</param>
        /// <param name="parentExistanceCheck">true to verify parent existance</param>
        /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
        public QuickIOTransferFileCopyJob( string source, string target, Int32 maxBufferSize = 1024, bool overwrite = false, bool parentExistanceCheck = true, Int32 prorityLevel = 0 ) :
            this( null, source, target, maxBufferSize, overwrite, parentExistanceCheck, prorityLevel )
        {
        }

        /// <summary>
        /// Creates a new queue item
        /// </summary>
        /// <param name="observer">Observer</param>
        /// <param name="source">Fullname source</param>
        /// <param name="target">Fullname target</param>
        /// <param name="maxBufferSize">Set max buffer size for copy transfer</param>
        /// <param name="overwrite">true overwrites existing files</param>
        /// <param name="parentExistanceCheck">true to verify parent existance</param>
        /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
        public QuickIOTransferFileCopyJob( IQuickIOTransferObserver observer, string source, string target, Int32 maxBufferSize = 1024, bool overwrite = false, bool parentExistanceCheck = true, Int32 prorityLevel = 0 ) :
            base( observer, prorityLevel )
        {
            Invariant.NotEmpty( source );
            Invariant.NotEmpty( target );

            // Parent
            Overwrite = overwrite;

            // Own
            MaxBufferSize = Math.Max( 1024, maxBufferSize );
            Source = source;
            Target = target;
            ParentExistanceCheck = parentExistanceCheck;
        }

        /// <summary>
        /// Transfer started
        /// </summary>
        public DateTime? TransferStarted
        {
            get
            {
                lock ( _transferStartedLock )
                {
                    return _transferStarted;
                }
            }
            internal set
            {
                lock ( _transferStartedLock )
                {
                    _transferStarted = value;
                }
            }
        }

        /// <summary>
        /// true to copy all datetime information such as CreationTime, LastAccessTime and LastWriteTime.<br/>
        /// Default: false
        /// </summary>
        /// <remarks>Will reduce the processing speed, because a single physical access is required for each setting.</remarks>
        public Boolean CopyTimestamps
        {
            get { return _copyTimestamps; }
            set { _copyTimestamps = value; }
        }

        /// <summary>
        /// true to copy attribute information.<br/>
        /// Default: false
        /// </summary>
        /// <remarks>Will reduce the processing speed, because a single physical access is required for each setting.</remarks>
        public Boolean CopyAttributes
        {
            get { return _copyTimestamps; }
            set { _copyTimestamps = value; }
        }


        #region Events
        /// <summary>
        /// This event is raised during a copy of a file. It provides current information such as progress, speed and estimated time.
        /// </summary>
        public event QuickIOTransferFileCopyProgressHandler Progress;

        /// <summary>
        /// This event is triggered at the beginning of the file copy operation.
        /// </summary>
        public event QuickIOTransferFileCopyStartedHandler Started;

        /// <summary>
        /// This event is raised if file copy operation fails
        /// </summary>
        public new event QuickIOTransferFileCopyErrorHandler Error;

        /// <summary>
        /// This event is raised at the end of the file copy operation.
        /// </summary>
        public event QuickIOTransferFileCopyFinishedHandler Finished;

        /// <summary>
        /// This event is raised before an upcoming directory creation operation is performed
        /// </summary>
        public event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;

        /// <summary>
        /// This event is raised when a directory was created
        /// </summary>
        public event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;

        /// <summary>
        /// Fire <see cref="Progress"/>
        /// </summary>
        private void OnCopyProgress( Int64 totalBytes, UInt64 bytesTransfered )
        {
            QuickIOTransferFileCopyProgressEventArgs args = null;
            if ( Progress != null )
            {
                args = new QuickIOTransferFileCopyProgressEventArgs( this, Source, Target, totalBytes, bytesTransfered, ( DateTime ) TransferStarted );
                Progress( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCopyProgressEventArgs( this, Source, Target, totalBytes, bytesTransfered, ( DateTime ) TransferStarted );
                }
                Observer.OnFileCopyProgress( args );
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

            QuickIOTransferFileCopyErrorEventArgs args = null;
            if ( Error != null )
            {
                args = new QuickIOTransferFileCopyErrorEventArgs( this, Source, Target, e );
                Error( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCopyErrorEventArgs( this, Source, Target, e );
                }
                Observer.OnFileCopyError( args );
            }
        }

        /// <summary>
        /// Fire <see cref="Started"/>
        /// </summary>
        private void OnCopyStarted( Int64 totalBytes )
        {
            QuickIOTransferFileCopyStartedEventArgs args = null;
            if ( Started != null )
            {
                args = new QuickIOTransferFileCopyStartedEventArgs( this, Source, Target, totalBytes );
                Started( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCopyStartedEventArgs( this, Source, Target, totalBytes );
                }
                Observer.OnFileCopyStarted( args );
            }
        }
        /// <summary>
        /// Fire <see cref="Finished"/>
        /// </summary>
        private void OnCopyFinished( Int64 totalBytes )
        {
            QuickIOTransferFileCopyFinishedEventArgs args = null;
            if ( Finished != null )
            {
                args = new QuickIOTransferFileCopyFinishedEventArgs( this, Source, Target, totalBytes, ( DateTime ) TransferStarted );
                Finished( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferFileCopyFinishedEventArgs( this, Source, Target, totalBytes, ( DateTime ) TransferStarted );
                }
                Observer.OnFileCopyFinished( args );
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
        /// Fire <see cref="DirectoryCreated"/>
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