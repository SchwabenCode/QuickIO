using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// Receives <see cref="QuickIOFileMetadata"/> of current file
    /// </summary>
    /// <returns><see cref="QuickIOFileMetadata"/></returns>
    public Task<QuickIOFileMetadata?> GetMetadataAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(GetMetadata);
    }
}
