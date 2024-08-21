using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// File metadata information
/// </summary>
public sealed class QuickIOFileMetadata : QuickIOFileSystemMetadataBase
{
    /// <summary>
    /// Creates instance of <see cref="QuickIOFileMetadata"/>
    /// </summary>
    /// <param name="uncResultPath">UNC Path of current file</param>
    /// <param name="win32FindData">Win32FindData of current file</param>
    internal QuickIOFileMetadata(string uncResultPath, Win32FindData win32FindData)
        : base(uncResultPath, win32FindData)
    {
        Bytes = win32FindData.CalculateBytes();
    }

    /// <summary>
    /// Size of the file. 
    /// </summary>
    public ulong Bytes { get; private set; }


    /// <summary>
    /// Returns a new instance of <see cref="QuickIOFileInfo"/> of the current file
    /// </summary>
    /// <returns><see cref="QuickIOFileInfo"/></returns>
    public QuickIOFileInfo QuickIOFileInfo()
    {
        return new QuickIOFileInfo(ToPathInfo());
    }
}
