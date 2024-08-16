
namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides Extensions
/// </summary>
public static class QuickIOExtensions
{

    /// <summary>
    /// Returns a <see cref="QuickIOFileInfo"/> of the current path
    /// </summary>
    /// <param name="source"><see cref="FileInfo"/></param>
    /// <returns><see cref="QuickIOFileInfo"/></returns>
    public static QuickIOFileInfo ToQuickIO(this FileInfo source)
    {
        return (QuickIOFileInfo)source;
    }

    /// <summary>
    /// Returns a <see cref="QuickIODirectoryInfo"/> of the current path
    /// </summary>
    /// <param name="source"><see cref="DirectoryInfo"/></param>
    /// <returns><see cref="QuickIODirectoryInfo"/></returns>
    public static QuickIODirectoryInfo ToQuickIO(this DirectoryInfo source)
    {
        return (QuickIODirectoryInfo)source;
    }


    /// <summary>
    /// Returns a <see cref="FileInfo"/> of the current path
    /// </summary>
    /// <param name="source"><see cref="QuickIOFileInfo"/></param>
    /// <returns><see cref="FileInfo"/></returns>
    public static FileInfo AsFileInfo(this QuickIOFileInfo source)
    {
        return new FileInfo(source.FullName);
    }

    /// <summary>
    /// Returns a <see cref="DirectoryInfo"/> of the current path
    /// </summary>
    /// <param name="source"><see cref="QuickIODirectoryInfo"/></param>
    /// <returns><see cref="DirectoryInfo"/></returns>
    public static DirectoryInfo AsDirectoryInfo(this QuickIODirectoryInfo source)
    {
        return new DirectoryInfo(source.FullName);
    }
}
