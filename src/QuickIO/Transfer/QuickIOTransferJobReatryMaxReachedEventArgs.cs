﻿namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Contains information if the max retry amount of a job has been reached
/// </summary>
public class QuickIOTransferJobReatryMaxReachedEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobReatryMaxReachedEventArgs"/>
    /// </summary>
    /// <param name="job">Enqueued Job</param>
    /// <param name="lastException">Last Exception occured</param>
    public QuickIOTransferJobReatryMaxReachedEventArgs(IQuickIOTransferJob job, Exception lastException)
    {
        Job = job;
        LastException = lastException;
    }

    /// <summary>
    /// Requeued Job
    /// </summary>
    public IQuickIOTransferJob Job { get; private set; }

    /// <summary>
    /// Raised exception caused the requeue
    /// </summary>
    public Exception LastException { get; private set; }
}
