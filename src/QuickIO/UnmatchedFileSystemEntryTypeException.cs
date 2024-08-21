namespace SchwabenCode.QuickIO;

/// <summary>
/// Exception if path returns another type as excepted
/// </summary>
[Serializable]
public sealed class UnmatchedFileSystemEntryTypeException : Exception
{
    /// <summary>
    /// Estimated Type
    /// </summary>
    public QuickIOFileSystemEntryType Estimated { get; private set; }

    /// <summary>
    /// Type found
    /// </summary>
    public QuickIOFileSystemEntryType Found { get; private set; }

    /// <summary>
    /// Affected full path
    /// </summary>
    public string FullName { get; private set; }

    /// <summary>
    /// Exception if path returns another type as excepted
    /// </summary>
    public UnmatchedFileSystemEntryTypeException(QuickIOFileSystemEntryType estimated, QuickIOFileSystemEntryType found, string path)
        : base("FileSystemEntryType not matched!")
    {
        Estimated = estimated;
        Found = found;
        FullName = path;
    }
}
