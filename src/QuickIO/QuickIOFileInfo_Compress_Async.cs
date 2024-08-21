using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIOFileInfo
{
    /// <summary>
    /// Compress all data of file and returns filled <see cref="MemoryStream"/>
    /// </summary>
    public Task<MemoryStream> GetCompressStreamAsync(int readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetCompressStream(readBuffer));
    }

    /// <summary>
    /// Decompress all data of file and returns filled <see cref="MemoryStream"/>
    /// </summary>
    public Task<MemoryStream> GetDecompressStreamAsync(int readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetDecompressStream(readBuffer));
    }

    /// <summary>
    /// Returns all bytes of <see cref="GetCompressStream"/>
    /// </summary>
    public Task<byte[]> CompressDataAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(CompressData);
    }

    /// <summary>
    /// Returns all bytes of <see cref="GetDecompressStream"/>
    /// </summary>
    public Task<byte[]> DecompressDataAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(DecompressData);
    }
}
