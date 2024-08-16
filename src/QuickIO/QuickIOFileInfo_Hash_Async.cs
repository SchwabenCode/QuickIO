using System.Security.Cryptography;
using SchwabenCode.QuickIO.Compatibility;


namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// File content hash calculation
    /// </summary>
    public Task<QuickIOHashResult> CalculateHashAsync(QuickIOHashImplementationType hashImplementationType)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => CalculateHash(hashImplementationType));
    }

    /// <summary>
    /// File content hash calculation
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public Task<QuickIOHashResult> CalculateHashAsync(HashAlgorithm hashAlgorithm)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => CalculateHash(hashAlgorithm));
    }

    /// <summary>
    /// File content hash calculation using SHA1
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public Task<QuickIOHashResult> CalculateSha1HashAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(CalculateSha1Hash);
    }

    /// <summary>
    /// File content hash calculation using SHA256
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public Task<QuickIOHashResult> CalculateSha256HashAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(CalculateSha256Hash);
    }

    /// <summary>
    /// File content hash calculation using SHA384
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public Task<QuickIOHashResult> CalculateSha384HashAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(CalculateSha384Hash);
    }

    /// <summary>
    /// File content hash calculation using SHA512
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public Task<QuickIOHashResult> CalculateSha512HashAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(CalculateSha512Hash);
    }

    /// <summary>
    /// File content hash calculation using MD5
    /// </summary>
    /// <returns><see cref="QuickIOHashResult"/></returns>
    public Task<QuickIOHashResult> CalculateMD5HashAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(CalculateMD5Hash);
    }
}
