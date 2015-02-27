// <copyright file="QuickIOTransferServiceBase_Events.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferServiceBase</summary>

using System;
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    public partial class QuickIOTransferServiceBase
    {
        #region Service Events

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
        private void OnCompletedAddingRequested()
        {
            EventArgs args = null;
            if ( CompletedAddingRequested != null )
            {
                args = new EventArgs( );
                CompletedAddingRequested( this, args );
            }


            if ( args == null )
            {
                args = new EventArgs( );
            }
            Observer.OnCompletedAddingRequested( args );
        }
        /// <summary>
        /// Fire <see cref="CancellationRequested"/>
        /// </summary>
        private void OnCancellationRequested()
        {
            EventArgs args = null;
            if ( CancellationRequested != null )
            {
                args = new EventArgs( );
                CancellationRequested( this, args );
            }


            if ( args == null )
            {
                args = new EventArgs( );
            }
            Observer.OnCancellationRequested( args );
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
        /// <param name="threadId">affcted Worker Thread ID</param>
        private void OnWorkerWokeUp( int threadId )
        {
            QuickIOTransferWorkerWokeUpEventArgs args = null;
            if ( WorkerWokeUp != null )
            {
                args = new QuickIOTransferWorkerWokeUpEventArgs( threadId );
                WorkerWokeUp( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferWorkerWokeUpEventArgs( threadId );
            }
            Observer.OnWorkerWokeUp( args );
        }
        /// <summary>
        /// Fire <see cref="WorkerPickedJob"/>
        /// </summary>
        /// <param name="threadId">affcted Worker Thread ID</param>
        private void OnWorkerIsWaiting( int threadId )
        {
            QuickIOTransferWorkerIsSleepingEventArgs args = null;
            if ( WorkerIsWaiting != null )
            {
                args = new QuickIOTransferWorkerIsSleepingEventArgs( threadId );
                WorkerIsWaiting( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferWorkerIsSleepingEventArgs( threadId );
            }
            Observer.OnWorkerIsWaiting( args );
        }

        /// <summary>
        /// Fire <see cref="WorkerPickedJob"/>
        /// </summary>
        /// <param name="threadId">affcted Worker Thread ID</param>
        /// <param name="job">picked job</param>
        private void OnWorkerPickedJob( int threadId, IQuickIOTransferJob job )
        {
            QuickIOTransferWorkerPickedJobEventArgs args = null;
            if ( WorkerPickedJob != null )
            {
                args = new QuickIOTransferWorkerPickedJobEventArgs( threadId, job );
                WorkerPickedJob( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferWorkerPickedJobEventArgs( threadId, job );
            }
            Observer.OnWorkerPickedJob( args );
        }
        /// <summary>
        /// Fire <see cref="WorkerCreated"/>
        /// </summary>
        /// <param name="threadId">affcted Worker Thread ID</param>
        private void OnWorkerCreated( int threadId )
        {
            QuickIOTransferWorkerCreatedEventArgs args = null;
            if ( WorkerCreated != null )
            {
                args = new QuickIOTransferWorkerCreatedEventArgs( threadId );
                WorkerCreated( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferWorkerCreatedEventArgs( threadId );
            }
            Observer.OnWorkerCreated( args );
        }
        /// <summary>
        /// Fire <see cref="WorkerStarted"/>
        /// </summary>
        /// <param name="threadId">affcted Worker Thread ID</param>
        private void OnWorkerStarted( int threadId )
        {
            QuickIOTransferWorkerStartedEventArgs args = null;
            if ( WorkerStarted != null )
            {
                args = new QuickIOTransferWorkerStartedEventArgs( threadId );
                WorkerStarted( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferWorkerStartedEventArgs( threadId );
            }
            Observer.OnWorkerStarted( args );
        }
        /// <summary>
        /// Fire <see cref="WorkerShutdown"/>
        /// </summary>
        /// <param name="threadId">affcted Worker Thread ID</param>
        private void OnWorkerShutdown( int threadId )
        {
            QuickIOTransferWorkerShutdownEventArgs args = null;
            if ( WorkerShutdown != null )
            {
                args = new QuickIOTransferWorkerShutdownEventArgs( threadId );
                WorkerShutdown( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferWorkerShutdownEventArgs( threadId );
            }
            Observer.OnWorkerShutdown( args );
        }

        #endregion

        #region Jobs
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
        /// Fire <see cref="JobEnqueued"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        protected void OnJobEnqueued( IQuickIOTransferJob job )
        {
            QuickIOTransferJobEnqueuedEventArgs args = null;
            if ( JobEnqueued != null )
            {
                args = new QuickIOTransferJobEnqueuedEventArgs( job );
                JobEnqueued( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferJobEnqueuedEventArgs( job );
            }
            Observer.OnJobEnqueued( args );
        }

        /// <summary>
        /// Fire <see cref="JobDequeued"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        protected void OnJobDequeued( IQuickIOTransferJob job )
        {
            QuickIOTransferJobDequeuedEventArgs args = null;
            if ( JobDequeued != null )
            {
                args = new QuickIOTransferJobDequeuedEventArgs( job );
                JobDequeued( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferJobDequeuedEventArgs( job );
            }
            Observer.OnJobDequeued( args );
        }

        /// <summary>
        /// Fire <see cref="JobRequeued"/> for this service and specified observer
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="e">Caused exception</param>
        protected void OnJobRequeued( IQuickIOTransferJob job, Exception e )
        {
            QuickIOTransferJobRequeuedEventArgs args = null;
            if ( JobRequeued != null )
            {
                args = new QuickIOTransferJobRequeuedEventArgs( job, e );
                JobRequeued( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferJobRequeuedEventArgs( job, e );
            }
            Observer.OnJobRequeued( args );
        }

        /// <summary>
        /// Fire <see cref="JobRetryMaxReached"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="lastException">Last exception</param>
        protected void OnJobRetryMaxReached( IQuickIOTransferJob job, Exception lastException )
        {
            QuickIOTransferJobReatryMaxReachedEventArgs args = null;
            if ( JobRetryMaxReached != null )
            {
                args = new QuickIOTransferJobReatryMaxReachedEventArgs( job, lastException );
                JobRetryMaxReached( this, args );
            }

            if ( args == null )
            {
                args = new QuickIOTransferJobReatryMaxReachedEventArgs( job, lastException );
            }
            Observer.OnJobRetryMaxReached( args );
        }
        #endregion

    }
}
