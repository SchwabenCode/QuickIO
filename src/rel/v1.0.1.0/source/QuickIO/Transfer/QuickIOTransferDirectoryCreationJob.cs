// <copyright file="QuickIOTransferDirectoryCreationJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferDirectoryCreationJob</summary>

using System;
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Job for creating directories
    /// </summary>
    /// <example>
    /// Directory Creation job with observer
    /// <code>
    /// <![CDATA[
    /// public void CreateJobWithObserver( IQuickIOTransferObserver observer, String path)
    /// {
    ///     var createJob = new QuickIOTransferDirectoryCreationJob( observer, path );
    /// 
    ///     createJob.DirectoryCreating += OnDirectoryCreating;
    ///     createJob.DirectoryCreated += OnDirectoryCreated;
    /// 
    ///     createJob.Run( );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// Directory Creation job
    /// <code>
    /// <![CDATA[
    /// public void CreateJob( String path )
    /// {
    ///     var createJob = new QuickIOTransferDirectoryCreationJob( path );
    /// 
    ///     createJob.DirectoryCreating += OnDirectoryCreating;
    ///     createJob.DirectoryCreated += OnDirectoryCreated;
    /// 
    ///     createJob.Run( );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// Event definitions for this example
    /// <code>
    /// <![CDATA[
    /// private static void OnDirectoryCreating( object sender, QuickIOTransferDirectoryCreatingArgs e )
    /// {
    ///     Console.WriteLine( "TestDirectoryCreationJob: Creation started." );
    /// }
    /// 
    /// 
    /// private static void OnDirectoryCreated( object sender, QuickIOTransferDirectoryCreatedArgs e )
    /// {
    ///     Console.WriteLine( "TestDirectoryCreationJob: Creation finished." );
    /// }
    /// ]]>
    /// </code>
    /// 
    /// </example>
    public class QuickIOTransferDirectoryCreationJob : QuickIOTransferJob
    {
        // Job Type
        internal override QuickIOTransferJobType JobType
        {
            get
            {
                return QuickIOTransferJobType.DirectoryCreation;
            }
        }

        /// <summary>
        /// Creates the directory
        /// </summary>
protected override void Implementation( )
{
    OnDirectoryCreating( );

    if ( !QuickIODirectory.Exists( DirectoryToCreatePath ) )
    {
        QuickIODirectory.Create( DirectoryToCreatePath, true );
    }

    OnDirectoryCreated( );
}

        /// <summary>
        /// Directory fullname to create
        /// </summary>
        public string DirectoryToCreatePath { get; private set; }

        /// <summary>
        /// Job for creating directories with default observer
        /// </summary>
        /// <param name="directoryToCreatePath">Directory fullname to create</param>
        /// <param name="overwrite">true to overwrite</param>
        /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
        public QuickIOTransferDirectoryCreationJob( String directoryToCreatePath, bool overwrite = true, Int32 prorityLevel = 1 )
            : this( null, directoryToCreatePath, overwrite, prorityLevel )
        {
        }

        /// <summary>
        /// Job for creating directories with default observer
        /// </summary>
        /// <param name="observer">Observer</param>
        /// <param name="directoryToCreatePath">Directory fullname to create</param>
        /// <param name="overwrite">true to overwrite</param>
        /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
        public QuickIOTransferDirectoryCreationJob( IQuickIOTransferObserver observer, String directoryToCreatePath, bool overwrite = true, Int32 prorityLevel = 1 )
            : base( observer, prorityLevel )
        {
            DirectoryToCreatePath = directoryToCreatePath;
        }

        #region Events
        /// <summary>
        /// This event is raised if directory creation operation fails
        /// </summary>
        public new event QuickIOTransferDirectoryCreationErrorHandler Error;

        /// <summary>
        /// This event is raised before an upcoming directory creation operation is performed
        /// </summary>
        public event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;

        /// <summary>
        /// This event is raised when a directory was created
        /// </summary>
        public event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;

        /// <summary>
        /// Fire <see cref="DirectoryCreating"/>
        /// </summary>
        private void OnDirectoryCreating( )
        {
            OnDirectoryCreating( DirectoryToCreatePath );
        }
        /// <summary>
        /// Fires <see cref="DirectoryCreated"/>
        /// </summary>
        private void OnDirectoryCreated( )
        {
            OnDirectoryCreated( DirectoryToCreatePath );
        }


        /// <summary>
        /// Fires <see cref="Error"/>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError( Exception e )
        {
            // base throw not important
            //base.OnError( e ); 

            QuickIOTransferDirectoryCreationErrorEventArgs args = null;
            if ( Error != null )
            {
                args = new QuickIOTransferDirectoryCreationErrorEventArgs( this, DirectoryToCreatePath, e );
                Error( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferDirectoryCreationErrorEventArgs( this, DirectoryToCreatePath, e );
                }
                Observer.OnDirectoryCreationError( args );
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