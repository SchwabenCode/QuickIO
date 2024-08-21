using SchwabenCode.QuickIO.Internal;
namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    #region Exist
    /// <summary>
    /// Checks whether the given directory exists.
    /// </summary>
    /// <param name="path">The path to test. </param>
    /// <returns>true if exists; otherwise, false.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static bool Exists(string path)
    {
        QuickIOParsePathResult result = QuickIOPath.ParsePath( path );

        return InternalDirectoryExists(path, result.IsRoot);
    }

    /// <summary>
    /// Checks whether the given directory exists.
    /// </summary>
    /// <param name="pathInfo">The path to test. </param>
    /// <returns>true if exists; otherwise, false.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static bool Exists(QuickIOPathInfo pathInfo)
    {
        return InternalDirectoryExists(pathInfo.FullNameUnc, pathInfo.IsRoot);
    }

    /// <summary>
    /// Checks whether the given directory exists.
    /// </summary>
    /// <param name="directoryInfo">The path to test. </param>
    /// <returns>true if exists; otherwise, false.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static bool Exists(QuickIODirectoryInfo directoryInfo)
    {
        return InternalDirectoryExists(directoryInfo.FullNameUnc, directoryInfo.IsRoot);
    }

    #endregion

    #region Internal Directory
    private static bool InternalDirectoryExists(string uncPath, bool isRoot)
    {
        uint attrs = InternalQuickIO.SafeGetAttributes( uncPath, out _ );

        if (Equals(attrs, 0xffffffff))
        {
            return false;
        }

        if (isRoot)
        {
            return true;
        }

        if (InternalHelpers.ContainsFileAttribute(FileAttributes.Directory, (FileAttributes)attrs))
        {
            return true;
        }

        throw new UnmatchedFileSystemEntryTypeException(QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.File, uncPath);
    }
    #endregion
}
