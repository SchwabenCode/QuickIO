using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public sealed partial class QuickIODirectoryMetadata
{
    /// <summary>
    /// Returns a new instance of <see cref="QuickIODirectoryInfo"/> of the current directory
    /// </summary>
    /// <returns><see cref="QuickIODirectoryInfo"/></returns>
    public Task<QuickIODirectoryInfo> ToDirectoryInfoAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(ToDirectoryInfo);
    }
}
