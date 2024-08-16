using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public sealed partial class QuickIODirectoryInfo
{
    /// <summary>
    /// Returns a <see cref="DirectoryInfo"/> of the current path of this folder
    /// </summary>
    /// <returns><see cref="DirectoryInfo"/></returns>
    public Task<DirectoryInfo> AsDirectoryInfoAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(AsDirectoryInfo);
    }
}
