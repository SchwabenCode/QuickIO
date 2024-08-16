using System.Collections.ObjectModel;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Directory metadata information
/// </summary>
public sealed partial class QuickIODirectoryMetadata : QuickIOFileSystemMetadataBase
{
    /// <summary>
    /// Creates instance of <see cref="QuickIODirectoryMetadata"/>
    /// </summary>
    /// <param name="win32FindData">Win32FindData of current directory</param>
    /// <param name="subDirs">Directories in current directory</param>
    /// <param name="subFiles">Files in current directory</param>
    /// <param name="uncFullname">UNC Path of current directory</param>
    internal QuickIODirectoryMetadata(string uncFullname, Win32FindData win32FindData, IList<QuickIODirectoryMetadata> subDirs, IList<QuickIOFileMetadata> subFiles)
        : base(uncFullname, win32FindData)
    {
        Directories = new ReadOnlyCollection<QuickIODirectoryMetadata>(subDirs);
        Files = new ReadOnlyCollection<QuickIOFileMetadata>(subFiles);
    }

    /// <summary>
    /// Directories in current directory
    /// </summary>
    public ReadOnlyCollection<QuickIODirectoryMetadata> Directories { get; internal set; }

    /// <summary>
    /// Files in current directory
    /// </summary>
    public ReadOnlyCollection<QuickIOFileMetadata> Files { get; internal set; }

    private ulong? _bytes;
    /// <summary>
    /// Size of the file. 
    /// </summary>
    public ulong Bytes
    {
        get
        {
            if (_bytes == null)
            {
                ulong bytes = 0;

                #region Dirs

                {
                    for (int i = 0; i < Directories.Count; i++)
                    {
                        bytes += +Directories[i].Bytes;
                    }
                }

                #endregion

                #region Files
                {
                    for (int i = 0; i < Files.Count; i++)
                    {
                        bytes += +Files[i].Bytes;
                    }
                }
                #endregion

                _bytes = bytes;
            }
            return (ulong)_bytes;
        }
    }

    /// <summary>
    /// Returns a new instance of <see cref="QuickIODirectoryInfo"/> of the current directory
    /// </summary>
    /// <returns><see cref="QuickIODirectoryInfo"/></returns>
    public QuickIODirectoryInfo ToDirectoryInfo()
    {
        return new QuickIODirectoryInfo(ToPathInfo());
    }
}
