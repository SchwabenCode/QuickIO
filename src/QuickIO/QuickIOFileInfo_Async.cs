namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{

    /// <summary>
    /// Returns true if file exists. Uncached.
    /// </summary>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a directory.</exception>
    public override Task<bool> ExistsAsync
    {
        get
        {
            return QuickIOFile.ExistsAsync(this);
        }
    }

}
