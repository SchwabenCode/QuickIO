namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Abstract base class for job event arguments
/// </summary>
public abstract class QuickIOTransferJobEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="QuickIOTransferJobEventArgs"/>
    /// </summary>
    /// <param name="job">Affected job</param>
    protected QuickIOTransferJobEventArgs(IQuickIOTransferJob job)
    {
        Job = job;
    }


    /// <summary>
    /// Target file path
    /// </summary>
    public IQuickIOTransferJob Job { get; private set; }
}
