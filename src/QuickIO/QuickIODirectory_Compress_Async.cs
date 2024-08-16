using System.IO.Compression;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIODirectory
{
    /// <summary>
    /// Compresses a directory by using <see>
    ///         <cref>ZipFile.CreateFromDirectory</cref>
    ///     </see>
    /// </summary>
    /// <param name="directoryFullPath">Directory fullname to zip</param>
    /// <param name="zipFullPath">Zipfile fullname to save</param>
    /// <param name="overWriteExistingZip">true to overwrite existing zipfile</param>
    /// <param name="compressionLevel"><see cref="CompressionLevel"/></param>
    /// <param name="includeBaseDirectory">True to include basedirectory</param>
    public static Task CompressAsync(String directoryFullPath, String zipFullPath, bool overWriteExistingZip = false, CompressionLevel compressionLevel = CompressionLevel.Fastest, bool includeBaseDirectory = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Compress(directoryFullPath, zipFullPath, overWriteExistingZip, compressionLevel, includeBaseDirectory));
    }

    /// <summary>
    /// Compresses a directory by using <see>
    ///         <cref>ZipFile.CreateFromDirectory</cref>
    ///     </see>
    /// </summary>
    /// <param name="directory">Directory to zip</param>
    /// <param name="zipFullPath">Zipfile fullname to save</param>
    /// <param name="overWriteExistingZip">true to overwrite existing zipfile</param>
    /// <param name="compressionLevel"><see cref="CompressionLevel"/></param>
    /// <param name="includeBaseDirectory">True to include basedirectory</param>
    public static Task CompressAsync(QuickIODirectoryInfo directory, String zipFullPath, bool overWriteExistingZip = false, CompressionLevel compressionLevel = CompressionLevel.Fastest, bool includeBaseDirectory = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Compress(directory, zipFullPath, overWriteExistingZip, compressionLevel, includeBaseDirectory));
    }
}
