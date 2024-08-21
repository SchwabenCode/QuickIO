using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    /// <summary>
    /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exist.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/54a0at6s(v=vs.110).aspx</remarks>
    /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
    /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
    public static Task CreateAsync(string path, bool recursive = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Create(path, recursive));
    }

    /// <summary>
    /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exist.
    /// </summary>
    /// <param name="pathInfo">The directory.</param>
    /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/54a0at6s(v=vs.110).aspx</remarks>
    /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
    /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
    public static Task CreateAsync(QuickIOPathInfo pathInfo, bool recursive = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Create(pathInfo, recursive));
    }
}
