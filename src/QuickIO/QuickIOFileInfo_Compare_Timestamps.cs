namespace SchwabenCode.QuickIO;

public partial class QuickIOFileInfo
{
    /// <summary>
    /// Returns the if all timestamps are equal
    /// </summary>
    /// <param name="file">File to compare with</param>
    /// <returns>Returns the if all timestamps are equal</returns>
    public bool IsEqualTimestamps(QuickIOFileInfo file)
    {
        return (InternalIsEqualTimestampCreated(file) && InternalIsEqualTimestampLastAccessed(file) && InternalIsEqualTimestampsLastWritten(file));
    }

    /// <summary>
    /// Checks all timestamps.
    /// </summary>
    /// <param name="file">File to compare with</param>
    /// <returns>If collection is empty, all timestamps are equal. Otherwise unequal timestamp is returned.</returns>
    public IEnumerable<QuickIOFileCompareCriteria> CompareTimestamps(QuickIOFileInfo file)
    {
        if (InternalIsEqualTimestampCreated(file))
        {
            yield return QuickIOFileCompareCriteria.TimestampCreated;
        }

        if (InternalIsEqualTimestampLastAccessed(file))
        {
            yield return QuickIOFileCompareCriteria.TimestampLastAccessed;
        }

        if (InternalIsEqualTimestampsLastWritten(file))
        {
            yield return QuickIOFileCompareCriteria.TimestampLastWritten;
        }
    }

    /// <summary>
    /// Returns the if timestamp 'created' is equal
    /// </summary>
    /// <param name="file">File to compare with</param>
    /// <returns>Returns the if timestamp 'created' is equal</returns>
    public bool IsEqualTimestampCreated(QuickIOFileInfo file)
    {
        return InternalIsEqualTimestampCreated(file);
    }
    /// <summary>
    /// Same as <see cref="IsEqualTimestampCreated"/> but does not check the param for null
    /// </summary>
    private bool InternalIsEqualTimestampCreated(QuickIOFileInfo file)
    {
        int result = ( CreationTimeUtc.CompareTo( file.CreationTimeUtc ) );
        return (result == 0); // result < 0: file1 is earlier, result > 0: file1 is later. 0 = equal 
    }

    /// <summary>
    /// Returns the if timestamp 'last accessed' is equal
    /// </summary>
    /// <param name="file">File to compare with</param>
    /// <returns>Returns the if timestamp 'last accessed' is equal</returns>
    public bool IsEqualTimestampLastAccessed(QuickIOFileInfo file)
    {
        return InternalIsEqualTimestampLastAccessed(file);
    }

    /// <summary>
    /// Same as <see cref="IsEqualTimestampLastAccessed"/> but does not check the param for null
    /// </summary>
    private bool InternalIsEqualTimestampLastAccessed(QuickIOFileInfo file)
    {
        int result = ( LastAccessTimeUtc.CompareTo( file.LastAccessTimeUtc ) );
        return (result == 0); // result < 0: file1 is earlier, result > 0: file1 is later. 0 = equal 
    }

    /// <summary>
    /// Returns the if timestamp 'last written to' is equal
    /// </summary>
    /// <param name="file">File to compare with</param>
    /// <returns>Returns the if timestamp 'last written to' is equal</returns>
    public bool IsEqualTimestampsLastWritten(QuickIOFileInfo file)
    {
        return InternalIsEqualTimestampsLastWritten(file);
    }

    /// <summary>
    /// Same as <see cref="IsEqualTimestampsLastWritten"/> but does not check the param for null
    /// </summary>
    private bool InternalIsEqualTimestampsLastWritten(QuickIOFileInfo file)
    {
        int result = ( LastWriteTimeUtc.CompareTo( file.LastWriteTimeUtc ) );
        return (result == 0); // result < 0: file1 is earlier, result > 0: file1 is later. 0 = equal 
    }
}
