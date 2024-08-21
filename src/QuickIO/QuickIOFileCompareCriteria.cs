namespace SchwabenCode.QuickIO;

/// <summary>
/// Options for file compare. You can select multiple flags or use <see cref="All"/> for all options
/// </summary>
[Flags]
public enum QuickIOFileCompareCriteria
{
    /// <summary>
    /// All options will be verified
    /// </summary>
    All = 0,

    /// <summary>
    /// Compares all timestamps
    /// </summary>
    TimestampsAll,

    /// <summary>
    /// Compares timestamp of file creation
    /// </summary>
    TimestampCreated,

    /// <summary>
    /// Compares timestamp of file last written to
    /// </summary>
    TimestampLastWritten,

    /// <summary>
    /// Compares timestamp of file last accessed to
    /// </summary>
    TimestampLastAccessed,

    /// <summary>
    /// Compares length of file (without checking the content!)
    /// </summary>
    ByteLength,

    /// <summary>
    /// Compares the contents. Requires read access.
    /// </summary>
    Content
}
