using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static QuickIODirectoryMetadata? GetMetadata(string directoryPath,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(directoryPath);
        return InternalQuickIO.EnumerateDirectoryMetadata(new QuickIOPathInfo(directoryPath), enumerateOptions);
    }

    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static QuickIODirectoryMetadata? GetMetadata(QuickIODirectoryInfo directoryInfo,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return InternalQuickIO.EnumerateDirectoryMetadata(directoryInfo.PathInfo, enumerateOptions);
    }

    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static QuickIODirectoryMetadata? GetMetadata(QuickIOPathInfo pathInfo,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return InternalQuickIO.EnumerateDirectoryMetadata(pathInfo, enumerateOptions);
    }

}
