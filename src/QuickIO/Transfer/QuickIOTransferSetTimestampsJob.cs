namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Job to set timestamps
/// </summary>
internal class QuickIOTransferSetTimestampsJob : QuickIOTransferJob
{
    /// <summary>
    ///  Implementation of this job
    /// </summary>
    protected override void Implementation()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Targetpath
    /// </summary>
    public string TargetPath { get; private set; }

    #region Time Properties
    #region UNC Times
    /// <summary>
    /// Gets the creation time (UTC)
    /// </summary>
    public DateTime CreationTimeUtc { get; private set; }

    /// <summary>
    /// Gets the time (UTC) of last access. 
    /// </summary>
    public DateTime LastAccessTimeUtc { get; private set; }

    /// <summary>
    /// Gets the time (UTC) was last written to
    /// </summary>
    public DateTime LastWriteTimeUtc { get; private set; }
    #endregion

    #region LocalTime
    /// <summary>
    /// Gets the creation time
    /// </summary>
    public DateTime CreationTime { get { return CreationTimeUtc.ToLocalTime(); } }

    /// <summary>
    /// Gets the time that the  file was last accessed
    /// </summary>
    public DateTime LastAccessTime { get { return LastAccessTimeUtc.ToLocalTime(); } }

    /// <summary>
    /// Gets the time the file was last written to.
    /// </summary>
    public DateTime LastWriteTime { get { return LastWriteTimeUtc.ToLocalTime(); } }
    #endregion
    #endregion

    /// <summary>
    /// Job for creating directory paths
    /// </summary>
    /// <param name="targetPath">Affected fullname to set attributes</param>
    /// <param name="lastWriteTime">The time the file was last written to.</param>
    /// <param name="prorityLevel">Priority level of directory creation should be higher than file creation without parent check</param>
    /// <param name="creationTime">The creation time</param>
    /// <param name="lastAccessTime">The time that the  file was last accessed</param>
    public QuickIOTransferSetTimestampsJob(string targetPath, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime, int prorityLevel = -1)
        : base(prorityLevel)
    {
        TargetPath = targetPath;
        CreationTimeUtc = creationTime.ToUniversalTime();
        LastAccessTimeUtc = lastAccessTime.ToUniversalTime();
        LastWriteTimeUtc = lastWriteTime.ToUniversalTime();
    }
}
