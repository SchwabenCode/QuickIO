using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIOShareInfo
{
    /// <summary>
    /// Returns a <see cref="QuickIODirectoryInfo"/> of the current path of this file
    /// </summary>
    /// <returns><see cref="QuickIODirectoryInfo"/></returns>
    public Task<QuickIODirectoryInfo> AsDirectoryInfoAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(AsDirectoryInfo);
    }
}
