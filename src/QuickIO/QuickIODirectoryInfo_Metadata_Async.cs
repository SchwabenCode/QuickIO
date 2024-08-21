using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIODirectoryInfo
{
    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current file
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public Task<QuickIODirectoryMetadata?> GetMetadataAsync(QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
        => NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetMetadata(enumerateOptions));
}
