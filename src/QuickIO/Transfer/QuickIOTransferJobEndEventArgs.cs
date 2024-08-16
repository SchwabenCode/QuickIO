namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// provides information for job run
/// </summary>
public class QuickIOTransferJobEndEventArgs : QuickIOTransferJobEventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobEndEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    /// <param name="jobStart">Time of job start</param>
    /// <param name="jobEnd">Time of job end</param>
    public QuickIOTransferJobEndEventArgs(IQuickIOTransferJob job, DateTime jobStart, DateTime jobEnd)
        : base(job)
    {
        StartTime = jobStart;
        EndTime = jobEnd;
    }

    /// <summary>
    /// Time of job start
    /// </summary>
    public DateTime StartTime { get; private set; }

    /// <summary>
    /// Time of job end
    /// </summary>
    public DateTime EndTime { get; private set; }
}
