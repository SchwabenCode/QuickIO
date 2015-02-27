// <copyright file="QuickIOTransferServiceBase_Executions.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferServiceBase</summary>


using System;

namespace SchwabenCode.QuickIO.Transfer
{
    public partial class QuickIOTransferServiceBase
    {
        /// <summary>
        /// Element consuming. Breaks if element is null.
        /// </summary>
        private void StartConsuming( object threadId )
        {
            var tID = ( Int32 ) threadId;

            while ( true )
            {
                // while one thread is waiting for a new item
                // all other thrads are waiting at this lock point
                lock ( _jobQueueLock )
                {
                    // Check for canceleation
                    if ( CancelRequested )
                    {
                        RemoveThread( tID );
                        return;
                    }

                    // Remove?
                    lock ( _workerCountRemoveRequestedLock )
                    {
                        if ( _workerCountRemoveRequested > 0 )
                        {
                            _workerCountRemoveRequested--;
                            RemoveThread( tID );
                            return;
                        }
                    }

                    // block while no new entry is in queue
                    if ( _jobQueue.Count == 0 )
                    {
                        if ( AddingCompleted )
                        {
                            RemoveThread( tID );
                            return;
                        }

                        OnWorkerIsWaiting( tID );

                        // one thread is waiting here for new items!
                        InternalWaitForNewQueueItems( );

                        OnWorkerWokeUp( tID );
                    }

                    // we have to check the count here again, cause the wakeup
                    // can be caused by remove thread!
                    if ( _jobQueue.Count > 0 )
                    {
                        // Get first item in queue
                        var job = _jobQueue[ 0 ];
                        _jobQueue.RemoveAt( 0 );

                        OnWorkerPickedJob( tID, job );
                        JobExecuteSwitch( job );
                    }
                }
            }
        }

        /// <summary>
        /// Consuming - transfer file
        /// </summary>
        /// <param name="job">Queue Item</param>
        private void JobExecuteSwitch( IQuickIOTransferJob job )
        {
            OnJobDequeued( job );

            job.CurrentRetryCount++;

            try
            {
                job.Run( );
            }
            catch ( Exception e )
            {
                // Retry count reached?!
                if ( job.CurrentRetryCount >= _maxJobRetryAttempts )
                {
                    OnJobRetryMaxReached( job, e );
                    return;
                }

                // Increase retry count and re-add to the queue
                job.CurrentRetryCount++;
                lock ( _jobQueueLock )
                {
                    // on empty queue just add
                    if ( _jobQueue.Count == 0 )
                    {
                        _jobQueue.Add( job );
                    }

                        // Check for cancellation token 'null'
                    else if ( _jobQueue.Contains( null ) )
                    {
                        // Queue has cancellation token at last position
                        _jobQueue.Insert( _jobQueue.Count - 2, job );
                    }
                    else
                    {
                        _jobQueue.Insert( _jobQueue.Count - 1, job );
                    }

                    InternalReSortLockedQueue( ); // resort queue
                }

                OnJobRequeued( job, e );
            }

        }
    }
}
