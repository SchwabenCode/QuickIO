namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// Receives <see cref="QuickIOFileMetadata"/> of current file
    /// </summary>
    /// <returns><see cref="QuickIOFileMetadata"/></returns>
    public QuickIOFileMetadata? GetMetadata()
    {
        if (FindData is null)
        {
            return null;
        }

        return new QuickIOFileMetadata(FullNameUnc, FindData);
    }
}
