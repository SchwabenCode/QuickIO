using System.IO.Compression;

namespace SchwabenCode.QuickIO;

public partial class QuickIOFileInfo
{
    /// <summary>
    /// Compress all data of file and returns filled <see cref="MemoryStream"/>
    /// </summary>
    public MemoryStream GetCompressStream(int readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes)
    {
        return InternalGetGZipStream(readBuffer, CompressionMode.Compress);
    }

    /// <summary>
    /// Decompress all data of file and returns filled <see cref="MemoryStream"/>
    /// </summary>
    public MemoryStream GetDecompressStream(int readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes)
    {
        return InternalGetGZipStream(readBuffer, CompressionMode.Decompress);
    }

    /// <summary>
    /// Internal Usage only
    /// </summary>
    private MemoryStream InternalGetGZipStream(int readBuffer, CompressionMode mode)
    {
        MemoryStream ms = new( );

        using (GZipStream gZipStream = new(ms, mode, true))
        {
            using FileStream readStream = OpenRead();
            byte[] buffer = new byte[ readBuffer ];
            int read;
            while ((read = readStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                gZipStream.Write(buffer, 0, read);
            }
        }
        return ms;
    }

    /// <summary>
    /// Returns all bytes of <see cref="GetCompressStream"/>
    /// </summary>
    public byte[] CompressData()
    {
        using MemoryStream s = GetCompressStream();
        return s.ToArray();
    }

    /// <summary>
    /// Returns all bytes of <see cref="GetDecompressStream"/>
    /// </summary>
    public byte[] DecompressData()
    {
        using MemoryStream s = GetDecompressStream();
        return s.ToArray();
    }
}
