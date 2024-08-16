namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides properties and instance methods for directories
/// </summary>
public sealed partial class QuickIODirectoryInfo
{

    /// <summary>
    /// Returns true if directory exists. Result starts a file system call and is not cached.
    /// </summary>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a file..</exception>
    public override Task<bool> ExistsAsync
    {
        get
        {
            return QuickIODirectory.ExistsAsync(this);
        }
    }
}
