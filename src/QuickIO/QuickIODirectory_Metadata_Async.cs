using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static Task<QuickIODirectoryMetadata?> GetMetadataAsync(string directoryPath, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetMetadata(directoryPath, enumerateOptions));
    }

    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static Task<QuickIODirectoryMetadata?> GetMetadataAsync(QuickIODirectoryInfo directoryInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetMetadata(directoryInfo, enumerateOptions));
    }

    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static Task<QuickIODirectoryMetadata?> GetMetadataAsync(QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetMetadata(pathInfo, enumerateOptions));
    }
}
