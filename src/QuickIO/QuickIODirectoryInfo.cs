using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides properties and instance methods for directories
/// </summary>
public sealed partial class QuickIODirectoryInfo : QuickIOFileSystemEntryBase
{
    /// <summary>
    /// Create new instance of <see cref="QuickIODirectoryInfo"/>
    /// </summary>
    public QuickIODirectoryInfo(string path)
        : this(new QuickIOPathInfo(path)) { }

    /// <summary>
    /// Create new instance of <see cref="QuickIODirectoryInfo"/>
    /// </summary>
    public QuickIODirectoryInfo(DirectoryInfo directoryInfo)
        : this(new QuickIOPathInfo(directoryInfo.FullName)) { }

    /// <summary>
    /// Create new instance of <see cref="QuickIODirectoryInfo"/>
    /// </summary>
    public QuickIODirectoryInfo(QuickIOPathInfo pathInfo)
        : this(pathInfo, pathInfo.IsRoot ? null : InternalQuickIO.GetFindDataFromPath(pathInfo))
    {
    }

    /// <summary>
    /// Creates the folder information on the basis of the path and the handles
    /// </summary>
    /// <param name="pathInfo"><see cref="QuickIOPathInfo"/></param>
    /// <param name="win32FindData"><see cref="Win32FindData"/></param>
    internal QuickIODirectoryInfo(QuickIOPathInfo pathInfo, Win32FindData? win32FindData)
        : base(pathInfo, win32FindData)
    {
        if (win32FindData is not null)
        {
            LastWriteTimeUtc = win32FindData.GetLastWriteTimeUtc();
            LastAccessTimeUtc = win32FindData.GetLastAccessTimeUtc();
            CreationTimeUtc = win32FindData.GetCreationTimeUtc();
        }
    }

    /// <summary>
    /// Creates the folder information on the basis of the path and the handles
    /// </summary>
    /// <param name="fullname">Full path to the directory</param>
    /// <param name="win32FindData"><see cref="Win32FindData"/></param>
    internal QuickIODirectoryInfo(string fullname, Win32FindData? win32FindData)
        : this(new QuickIOPathInfo(fullname), win32FindData) { }

    /// <summary>
    /// Returns true if current path is root
    /// </summary>
    public bool IsRoot { get { return PathInfo.IsRoot; } }

    /// <summary>
    /// Returns true if directory exists. Result starts a file system call and is not cached.
    /// </summary>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a file..</exception>
    public override bool Exists
    {
        get
        {
            return QuickIODirectory.Exists(this);
        }
    }
}
