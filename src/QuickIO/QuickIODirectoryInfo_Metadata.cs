using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO;

public partial class QuickIODirectoryInfo
{
    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current file
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public QuickIODirectoryMetadata? GetMetadata(QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        if (FindData is null)
        {
            return null;
        }
        return InternalQuickIO.EnumerateDirectoryMetadata(FullNameUnc, FindData, enumerateOptions);
    }
}
