using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    #region Job Delegates
    /// <summary>
    /// This event is raised when a job runs
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobRunEventArgs"/></param>
    public delegate void QuickIOTransferJobRunHandler( object sender, QuickIOTransferJobRunEventArgs e );
    /// <summary>
    /// This event is raised when a job got an error
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobRunEventArgs"/></param>
    public delegate void QuickIOTransferJobErrorHandler( object sender, QuickIOTransferJobErrorEventArgs e );
    /// <summary>
    /// This event is raised when a job ends
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobRunEventArgs"/></param>
    public delegate void QuickIOTransferJobEndHandler( object sender, QuickIOTransferJobEndEventArgs e );

    /// <summary>
    /// This event is raised when a new job to the queue is added to
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobEnqueuedEventArgs"/></param>
    public delegate void QuickIOTransferJobEnqueuedHandler( object sender, QuickIOTransferJobEnqueuedEventArgs e );

    /// <summary>
    /// This event is raised when a job was taken from the queue
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobDequeuedEventArgs"/></param>
    public delegate void QuickIOTransferJobDequeuedHandler( object sender, QuickIOTransferJobDequeuedEventArgs e );


    /// <summary>
    /// This event is raised when a job was taken from the queue, whose type is unknown. This job can not be processed and will be discarded.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobEnqueuedEventArgs"/></param>
    public delegate void QuickIOTransferUnknownJobHandler( object sender, QuickIOTransferJobEnqueuedEventArgs e );


    /// <summary>
    /// This event is raised when a job triggered an error during processing. It will be re-added to the queue.
    /// It will be re-added to the queue if the maximum number of attempts <see>
    ///         <cref>MaxJobRetryAttempts</cref>
    ///     </see>
    ///     is not reached.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobRequeuedEventArgs"/></param>
    public delegate void QuickIOTransferJobRequeuedHandler( object sender, QuickIOTransferJobRequeuedEventArgs e );


    /// <summary>
    /// Max <see>
    ///         <cref>MaxJobRetryAttempts</cref>
    ///     </see>
    ///     of a job reached
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferJobReatryMaxReachedEventArgs"/></param>
    public delegate void QuickIOTransferJobRetryMaxReachedHandler( object sender, QuickIOTransferJobReatryMaxReachedEventArgs e );
    #endregion

    #region FileCreation Delegates

    /// <summary>
    /// This event is raised during a Creation of a file. It provides current information such as progress, speed and estimated time.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCreationProgressEventArgs"/></param>
    public delegate void QuickIOTransferFileCreationProgressHandler( object sender, QuickIOTransferFileCreationProgressEventArgs e );
    /// <summary>
    /// This event is raised if a file creation fails
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCreationErrorEventArgs"/></param>
    public delegate void QuickIOTransferFileCreationErrorHandler( object sender, QuickIOTransferFileCreationErrorEventArgs e );
    /// <summary>
    /// This event is triggered at the beginning of the file Creation operation.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCreationStartedEventArgs"/></param>
    public delegate void QuickIOTransferFileCreationStartedHandler( object sender, QuickIOTransferFileCreationStartedEventArgs e );
    /// <summary>
    /// This event is raised at the end of the file Creation operation.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCreationFinishedEventArgs"/></param>
    public delegate void QuickIOTransferFileCreationFinishedHandler( object sender, QuickIOTransferFileCreationFinishedEventArgs e );

    #endregion

    #region File Copy

    /// <summary>
    /// This event is raised during a copy of a file. It provides current information such as progress, speed and estimated time.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCopyProgressEventArgs"/></param>
    public delegate void QuickIOTransferFileCopyProgressHandler( object sender, QuickIOTransferFileCopyProgressEventArgs e );
    /// <summary>
    /// This event is raised if a file copy fails
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCreationErrorEventArgs"/></param>
    public delegate void QuickIOTransferFileCopyErrorHandler( object sender, QuickIOTransferFileCopyErrorEventArgs e );
    /// <summary>
    /// This event is triggered at the beginning of the file copy operation.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCopyStartedEventArgs"/></param>
    public delegate void QuickIOTransferFileCopyStartedHandler( object sender, QuickIOTransferFileCopyStartedEventArgs e );
    /// <summary>
    /// This event is raised at the end of the file copy operation.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferFileCopyFinishedEventArgs"/></param>
    public delegate void QuickIOTransferFileCopyFinishedHandler( object sender, QuickIOTransferFileCopyFinishedEventArgs e );
    #endregion

    #region Directory
    /// <summary>
    /// This event is raised if a directoy creation fails
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferDirectoryCreationErrorEventArgs"/></param>
    public delegate void QuickIOTransferDirectoryCreationErrorHandler( object sender, QuickIOTransferDirectoryCreationErrorEventArgs e );
    /// <summary>
    /// This event is raised before an upcoming directory creation operation is performed
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferDirectoryCreatingEventArgs"/></param>
    public delegate void QuickIOTransferDirectoryCreatingHandler( object sender, QuickIOTransferDirectoryCreatingEventArgs e );
    /// <summary>
    /// This event is raised when a directory was created
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferDirectoryCreatedEventArgs"/></param>
    public delegate void QuickIOTransferDirectoryCreatedHandler( object sender, QuickIOTransferDirectoryCreatedEventArgs e );
    #endregion

    #region Service
    /// <summary>
    /// This event is raised if the service has been made known that no new elements will be added.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="EventArgs"/></param>
    public delegate void QuickIOTransferCompletedAddingRequestedHandler( object sender, EventArgs e );
    /// <summary>
    /// This event is raised if the service has been made known that he should cancel the processing
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="EventArgs"/></param>
    public delegate void QuickIOTransferCancellationRequestedHandler( object sender, EventArgs e );
    #endregion

    #region Workers
    /// <summary>
    /// This event is raised when a processing thread is waiting for new items
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferWorkerIsSleepingEventArgs"/></param>
    public delegate void QuickIOTransferWorkerIsWaitingHandler( object sender, QuickIOTransferWorkerIsSleepingEventArgs e );
    /// <summary>
    /// This event is raised when a processing thread, which so far has been waiting for, was notified of a new item in the queue.
    /// It may be that he gets no element from the queue, because another thread was faster. He would sleep lie down again, if no more items available.
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferWorkerWokeUpEventArgs"/></param>
    public delegate void QuickIOTransferWorkerWokeUpHandler( object sender, QuickIOTransferWorkerWokeUpEventArgs e );
    /// <summary>
    /// This event is raised when a processing thread has taken a new item from the queue 
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferWorkerPickedJobEventArgs"/></param>
    public delegate void QuickIOTransferWorkerPickedJobHandler( object sender, QuickIOTransferWorkerPickedJobEventArgs e );
    /// <summary>
    /// This event is raised when a new processing thread was created
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferWorkerCreatedEventArgs"/></param>
    public delegate void QuickIOTransferWorkerCreatedHandler( object sender, QuickIOTransferWorkerCreatedEventArgs e );
    /// <summary>
    /// This event is raised when a processing thread started
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferWorkerStartedEventArgs"/></param>
    public delegate void QuickIOTransferWorkerStartedHandler( object sender, QuickIOTransferWorkerStartedEventArgs e );
    /// <summary>
    /// This event is raised when a processing thread was shutdown
    /// </summary>
    /// <param name="sender">Transfer Service or Job</param>
    /// <param name="e">Provides further event information. <see cref="QuickIOTransferWorkerShutdownEventArgs"/></param>
    public delegate void QuickIOTransferWorkerShutdownHandler( object sender, QuickIOTransferWorkerShutdownEventArgs e );
    #endregion
}
