using SchwabenCode.QuickIO.Compatibility;

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
    public static Task<bool> ExistsAsync(string path)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => Exists(path));
    }

    /// <summary>
    /// Checks whether the given directory exists.
    /// </summary>
    /// <param name="pathInfo">The path to test. </param>
    /// <returns>true if exists; otherwise, false.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static Task<bool> ExistsAsync(QuickIOPathInfo pathInfo)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => Exists(pathInfo));
    }

    /// <summary>
    /// Checks whether the given directory exists.
    /// </summary>
    /// <param name="directoryInfo">The path to test. </param>
    /// <returns>true if exists; otherwise, false.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static Task<bool> ExistsAsync(QuickIODirectoryInfo directoryInfo)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => Exists(directoryInfo));
    }

    #endregion
}
