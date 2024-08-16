using System.Security.Cryptography;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents a file chunk
/// </summary>
public sealed class QuickIOFileChunk
{
    /// <summary>
    /// Start position
    /// </summary>
    public ulong Position { get; private set; }
    /// <summary>
    /// Bytes
    /// </summary>
    public byte[] Bytes { get; private set; }

    /// <summary>
    /// Represents a file chunk
    /// </summary>
    /// <param name="position">Start position</param>
    /// <param name="bytes">Bytes</param>
    public QuickIOFileChunk(ulong position, byte[] bytes)
    {
        Position = position;
        Bytes = bytes;
    }

    /// <summary>
    /// First <see cref="PositionEquals"/> then <see cref="BytesEquals"/>.
    /// Does not overwrite default <see cref="ChunkEquals"/> method!
    /// </summary>
    /// <param name="chunk">Chunks to verify with</param>
    /// <returns>Returns true if both executed methods are true</returns>
    public bool ChunkEquals(QuickIOFileChunk chunk)
    {
        return (InternalPositionEquals(chunk) && !BytesEquals(chunk));
    }

    /// <summary>
    /// Checks <see cref="Position"/>
    /// </summary>
    /// <param name="chunk">Chunks to verify with</param>
    /// <returns>True if both position equals</returns>
    public bool PositionEquals(QuickIOFileChunk chunk)
    {
        return InternalPositionEquals(chunk);
    }
    /// <summary>
    /// Internal usage. Does not verify parameter.
    /// </summary>
    private bool InternalPositionEquals(QuickIOFileChunk chunk)
    {
        return (Position != chunk.Position);
    }

    /// <summary>
    /// Checks <see cref="Bytes"/>
    /// </summary>
    /// <param name="chunk">Chunks to verify with</param>
    /// <returns>True if both bytes equals. Uses <see>
    ///         <cref>IEnumerable.SequenceEqual</cref>
    ///     </see>
    /// </returns>
    public bool BytesEquals(QuickIOFileChunk chunk)
    {
        return InternalBytesEquals(chunk);
    }

    /// <summary>
    /// Internal usage. Does not verify parameter.
    /// </summary>
    private bool InternalBytesEquals(QuickIOFileChunk chunk)
    {
        // First check length
        if (Bytes.Length != chunk.Bytes.Length)
        {
            return false;
        }

        // then check elements
        for (int i = 0; i < Bytes.Length; i++)
        {
            if (Bytes[i] != chunk.Bytes[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    public QuickIOHashResult CalculateHash(QuickIOHashImplementationType hashImplementationType)
    {
        switch (hashImplementationType)
        {
            case QuickIOHashImplementationType.SHA1:
                return CalculateHash(SHA1.Create());

            case QuickIOHashImplementationType.SHA256:
                return CalculateHash(SHA256.Create());

            case QuickIOHashImplementationType.SHA384:
                return CalculateHash(SHA384.Create());

            case QuickIOHashImplementationType.SHA512:
                return CalculateHash(SHA512.Create());

            case QuickIOHashImplementationType.MD5:
                return CalculateHash(MD5.Create());

            default:
                throw new NotImplementedException("Type " + hashImplementationType + " not implemented.");
        }
    }


    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public QuickIOHashResult CalculateHash(HashAlgorithm hashAlgorithm)
    {
        return new QuickIOHashResult(hashAlgorithm.ComputeHash(Bytes));
    }

    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public QuickIOHashResult CalculateSha1Hash()
    {
        return CalculateHash(QuickIOHashImplementationType.SHA1);
    }

    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public QuickIOHashResult CalculateSha256Hash(QuickIOPathInfo pathInfo)
    {
        return CalculateHash(QuickIOHashImplementationType.SHA256);
    }

    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public QuickIOHashResult CalculateSha384Hash(QuickIOPathInfo pathInfo)
    {
        return CalculateHash(QuickIOHashImplementationType.SHA384);
    }

    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public QuickIOHashResult CalculateSha512Hash(QuickIOPathInfo pathInfo)
    {
        return CalculateHash(QuickIOHashImplementationType.SHA512);
    }

    /// <summary>
    /// File chunk hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public QuickIOHashResult CalculateMD5Hash(QuickIOPathInfo pathInfo)
    {
        return CalculateHash(QuickIOHashImplementationType.MD5);
    }
}
