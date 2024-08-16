using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public static partial class QuickIOShare
{
    /// <summary>
    /// Receives <see cref="QuickIODiskInformation"/> of specifies share path
    /// </summary>
    /// <returns><see cref="QuickIODiskInformation"/></returns>
    /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
    public static Task<QuickIODiskInformation> GetMetadataAsync(string sharePath)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetDiskInformation(sharePath));
    }
}
