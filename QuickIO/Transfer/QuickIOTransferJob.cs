// <copyright file="QuickIOTransferJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferJob</summary>

using System;
using SchwabenCode.QuickIO.Compatibility;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// A job is a defined task  is performed by the method <see cref="Run"/>
    /// Here, you can define the content of the task itself.
    /// </summary>
    public abstract class QuickIOTransferJob : IQuickIOTransferJob
    {

        /// <summary>
        /// Cancellation Token
        /// </summary>
        public System.Threading.CancellationToken Token { get; private set; }

        /// <summary>
        /// Checks state of <see cref="Token.IsCancellationRequested"/>
        /// </summary>
        public void ThrowIfCancellationRequested()
        {
            Token.ThrowIfCancellationRequested( );
        }

        /// <summary>
        /// Central observer
        /// </summary>
        public IQuickIOTransferObserver Observer { get; internal set; }

        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJob"/>
        /// </summary>
        /// <param name="observer">Observer for file monitoring by service</param>
        /// <param name="priorityLevel">Default priority</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <remarks>Thread-safe</remarks>
        protected QuickIOTransferJob( IQuickIOTransferObserver observer, Int32 priorityLevel = 0
, System.Threading.CancellationToken cancellationToken = default (System.Threading.CancellationToken )
 )
        {
            Observer = observer;
            CurrentRetryCount = priorityLevel;

            this.Token = cancellationToken;
        }

        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJob"/>
        /// </summary>
        /// <param name="priorityLevel">Default priority</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <remarks>Thread-safe</remarks>
        protected QuickIOTransferJob( Int32 priorityLevel = 0
, System.Threading.CancellationToken cancellationToken = default (System.Threading.CancellationToken )
 )
            : this( null, priorityLevel
, cancellationToken
 )
        {
        }

        /// <summary>
        /// Retry count before firing broken exception
        /// </summary>
        /// <remarks>Thread-safe</remarks>
        public Int32 CurrentRetryCount { get; set; }

        /// <summary>
        /// Prority level. Higher priority = higher value. 0 = default
        /// </summary>
        /// <remarks>Thread-safe</remarks>
        public Int32 PriorityLevel { get; set; }

        /// <summary>
        /// Implementation. <br/>
        /// It is executed by default without a background thread.
        /// The method can block.
        /// </summary>
        protected abstract void Implementation();

        /// <summary>
        /// Executes <see cref="Implementation"/>
        /// </summary>
        /// <example>
        /// Contains following content
        /// 
        /// <code>
        /// <![CDATA[
        /// public void Run( )
        /// {
        ///     var started = DateTime.Now;
        ///     OnRun( started );
        ///     try
        ///     {
        ///         Implementation( );
        ///     }
        ///     catch ( Exception e )
        ///     {
        ///         OnError( e );
        ///         throw;
        ///     }
        ///     OnEnd( started, DateTime.Now );
        /// }
        /// ]]>
        /// </code>
        /// </example>
        public void Run()
        {
            var started = DateTime.Now;
            OnRun( started );

            try
            {
                Implementation( );
            }
            catch ( Exception e )
            {
                OnError( e );
                throw;
            }

            OnEnd( started, DateTime.Now );
        }

        /// <summary>
        /// Executes <see cref="Run"/> in Async context
        /// </summary>
        public Task RunAsync()
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( Run );
        }

        #region Events
        /// <summary>
        /// This event is raised when <see cref="Run"/> is called
        /// </summary>
        public event QuickIOTransferJobRunHandler RunRaised;

        /// <summary>
        /// This event is triggered if <see cref="Run"/> has an error
        /// </summary>
        public event QuickIOTransferJobErrorHandler Error;

        /// <summary>
        /// This event is raised at the end <see cref="Run"/>
        /// </summary>
        public event QuickIOTransferJobEndHandler End;

        /// <summary>
        /// Fires <see cref="RunRaised"/>
        /// </summary>
        protected virtual void OnRun( DateTime started )
        {
            QuickIOTransferJobRunEventArgs args = null;
            if ( RunRaised != null )
            {
                args = new QuickIOTransferJobRunEventArgs( this, started );
                RunRaised( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferJobRunEventArgs( this, started );
                }
                Observer.OnJobRun( args );
            }
        }

        /// <summary>
        /// Fires <see cref="Error"/>
        /// </summary>
        protected virtual void OnError( Exception e )
        {
            QuickIOTransferJobErrorEventArgs args = null;
            if ( Error != null )
            {
                args = new QuickIOTransferJobErrorEventArgs( this, e );
                Error( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferJobErrorEventArgs( this, e );
                }
                Observer.OnJobError( args );
            }
        }

        /// <summary>
        /// Fires <see cref="RunRaised"/>
        /// </summary>
        protected virtual void OnEnd( DateTime started, DateTime finished )
        {
            QuickIOTransferJobEndEventArgs args = null;
            if ( End != null )
            {
                args = new QuickIOTransferJobEndEventArgs( this, started, finished );
                End( this, args );
            }

            if ( Observer != null )
            {
                if ( args == null )
                {
                    args = new QuickIOTransferJobEndEventArgs( this, started, finished );
                }
                Observer.OnJobEnd( args );
            }
        }

        #endregion
    }
}