using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// Returns a <see cref="FileInfo"/> of the current path of this file
    /// </summary>
    /// <returns><see cref="DirectoryInfo"/></returns>
    public Task<FileInfo> AsFileInfoAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(AsFileInfo);
    }
}
