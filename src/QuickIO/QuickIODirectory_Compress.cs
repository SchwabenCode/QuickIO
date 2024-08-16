using System.IO.Compression;
using SchwabenCode.QuickIO.Internal;

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
    public static void Compress(String directoryFullPath, String zipFullPath, bool overWriteExistingZip = false, CompressionLevel compressionLevel = CompressionLevel.Fastest, bool includeBaseDirectory = false)
    {
        Invariant.NotEmpty(directoryFullPath);
        Invariant.NotEmpty(zipFullPath);

        if (!Exists(directoryFullPath))
        {
            throw new DirectoryNotFoundException("Directory to zip '" + directoryFullPath + "' does not exist.");
        }

        if (!overWriteExistingZip && (QuickIOFile.Exists(zipFullPath)))
        {
            throw new FileAlreadyExistsException("The target zipFile name '" + zipFullPath + "' already exists.", zipFullPath);
        }

        ZipFile.CreateFromDirectory(directoryFullPath, zipFullPath, compressionLevel, includeBaseDirectory);
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
    public static void Compress(QuickIODirectoryInfo directory, String zipFullPath, bool overWriteExistingZip = false, CompressionLevel compressionLevel = CompressionLevel.Fastest, bool includeBaseDirectory = false)
    {
        Invariant.NotEmpty(zipFullPath);

        Compress(directory.FullName, zipFullPath, overWriteExistingZip, compressionLevel, includeBaseDirectory);
    }
}
