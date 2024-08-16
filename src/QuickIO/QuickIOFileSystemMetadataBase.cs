using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Abstract class for file system entries such as files and directory.
/// Just for meta data reprentation
/// </summary>
public abstract class QuickIOFileSystemMetadataBase
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="uncResultPath"></param>
    internal QuickIOFileSystemMetadataBase(string uncResultPath, Win32FindData win32FindData)
    {
        FullNameUnc = uncResultPath;

        LastWriteTimeUtc = win32FindData.GetLastWriteTimeUtc();
        LastAccessTimeUtc = win32FindData.GetLastAccessTimeUtc();
        CreationTimeUtc = win32FindData.GetCreationTimeUtc();

        Name = win32FindData.cFileName;

        Attributes = win32FindData.dwFileAttributes;
    }

    /// <summary>
    /// Path to file or directory (regular format)
    /// </summary>
    public string FullName
    {
        get
        {
            return _fullName ??= QuickIOPath.ToRegularPath(FullNameUnc);
        }
    }
    private string? _fullName;

    /// <summary>
    /// Name of file or directory
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Path to file or directory (unc format)
    /// </summary>
    public string FullNameUnc { get; private set; }

    /// <summary>
    /// Gets the creation time (UTC)
    /// </summary>
    public DateTime CreationTimeUtc { get; private set; }
    /// <summary>
    /// Gets the creation time
    /// </summary>
    public DateTime CreationTime => LastWriteTimeUtc.ToLocalTime();

    /// <summary>
    /// Gets the time (UTC) of last access. 
    /// </summary>
    public DateTime LastAccessTimeUtc { get; private set; }
    /// <summary>
    /// Gets the time that the  file was last accessed
    /// </summary>
    public DateTime LastAccessTime => LastAccessTimeUtc.ToLocalTime();

    /// <summary>
    /// Gets the time (UTC) was last written to
    /// </summary>
    public DateTime LastWriteTimeUtc { get; private set; }
    /// <summary>
    /// Gets the time the file was last written to.
    /// </summary>
    public DateTime LastWriteTime => LastWriteTimeUtc.ToLocalTime();

    /// <summary>
    /// File Attributes
    /// </summary>
    public FileAttributes Attributes { get; internal set; }

    /// <summary>
    /// Returns a new instance of <see cref="QuickIOPathInfo"/> of the current path
    /// </summary>
    /// <returns><see cref="QuickIOPathInfo"/></returns>
    public QuickIOPathInfo ToPathInfo() => new(FullNameUnc);
}
