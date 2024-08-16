using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Transfer.Contracts;

/// <summary>
/// Contract implementation
/// </summary>
[ContractClass(typeof(IQuickIOTransferObserver))]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class IQuickIOTransferObserverContract : IQuickIOTransferObserver
{
    public event QuickIOTransferDirectoryCreatingHandler? DirectoryCreating { add { } remove { } }
    public event QuickIOTransferDirectoryCreatedHandler? DirectoryCreated { add { } remove { } }
    public event QuickIOTransferDirectoryCreationErrorHandler? DirectoryCreationError { add { } remove { } }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnDirectoryCreating(QuickIOTransferDirectoryCreatingEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnDirectoryCreated(QuickIOTransferDirectoryCreatedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnDirectoryCreationError(QuickIOTransferDirectoryCreationErrorEventArgs args) { }

    public event QuickIOTransferFileCreationErrorHandler? FileCreationError { add { } remove { } }
    public event QuickIOTransferFileCreationStartedHandler? FileCreationStarted { add { } remove { } }
    public event QuickIOTransferFileCreationFinishedHandler? FileCreationFinished { add { } remove { } }
    public event QuickIOTransferFileCreationProgressHandler? FileCreationProgress { add { } remove { } }
    public void OnFileCreationError(QuickIOTransferFileCreationErrorEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnFileCreationProgress(QuickIOTransferFileCreationProgressEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnFileCreationStarted(QuickIOTransferFileCreationStartedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnFileCreationFinished(QuickIOTransferFileCreationFinishedEventArgs args) { }

    public event QuickIOTransferFileCopyErrorHandler? FileCopyError { add { } remove { } }
    public event QuickIOTransferFileCopyProgressHandler? FileCopyProgress { add { } remove { } }
    public event QuickIOTransferFileCopyStartedHandler? FileCopyStarted { add { } remove { } }
    public event QuickIOTransferFileCopyFinishedHandler? FileCopyFinished { add { } remove { } }
    public void OnFileCopyError(QuickIOTransferFileCopyErrorEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnFileCopyProgress(QuickIOTransferFileCopyProgressEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnFileCopyStarted(QuickIOTransferFileCopyStartedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnFileCopyFinished(QuickIOTransferFileCopyFinishedEventArgs args) { }

    public event QuickIOTransferCompletedAddingRequestedHandler? CompletedAddingRequested { add { } remove { } }
    public event QuickIOTransferCancellationRequestedHandler? CancellationRequested { add { } remove { } }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnCompletedAddingRequested(EventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnCancellationRequested(EventArgs args) { }

    public event QuickIOTransferWorkerIsWaitingHandler? WorkerIsWaiting { add { } remove { } }
    public event QuickIOTransferWorkerWokeUpHandler? WorkerWokeUp { add { } remove { } }
    public event QuickIOTransferWorkerPickedJobHandler? WorkerPickedJob { add { } remove { } }
    public event QuickIOTransferWorkerCreatedHandler? WorkerCreated { add { } remove { } }
    public event QuickIOTransferWorkerStartedHandler? WorkerStarted { add { } remove { } }
    public event QuickIOTransferWorkerShutdownHandler? WorkerShutdown { add { } remove { } }
    public void OnWorkerWokeUp(QuickIOTransferWorkerWokeUpEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnWorkerIsWaiting(QuickIOTransferWorkerIsSleepingEventArgs args) { }

    public void OnWorkerPickedJob(QuickIOTransferWorkerPickedJobEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnWorkerCreated(QuickIOTransferWorkerCreatedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnWorkerStarted(QuickIOTransferWorkerStartedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnWorkerShutdown(QuickIOTransferWorkerShutdownEventArgs args) { }

    public event QuickIOTransferJobRunHandler? JobRun { add { } remove { } }
    public event QuickIOTransferJobErrorHandler? JobError { add { } remove { } }
    public event QuickIOTransferJobEndHandler? JobEnd { add { } remove { } }
    public event QuickIOTransferJobEnqueuedHandler? JobEnqueued { add { } remove { } }
    public event QuickIOTransferJobDequeuedHandler? JobDequeued { add { } remove { } }
    public event QuickIOTransferJobRequeuedHandler? JobRequeued { add { } remove { } }
    public event QuickIOTransferJobRetryMaxReachedHandler? JobRetryMaxReached { add { } remove { } }
    public void OnJobRun(QuickIOTransferJobRunEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnJobError(QuickIOTransferJobErrorEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnJobEnd(QuickIOTransferJobEndEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnJobEnqueued(QuickIOTransferJobEnqueuedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnJobDequeued(QuickIOTransferJobDequeuedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnJobRequeued(QuickIOTransferJobRequeuedEventArgs args) { }

    /// <summary>
    /// Contract implementation
    /// </summary>
    /// <param name="args">Cannot be null</param>
    public void OnJobRetryMaxReached(QuickIOTransferJobReatryMaxReachedEventArgs args) { }
}
