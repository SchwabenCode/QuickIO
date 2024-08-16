using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIODirectory
{
    /// <summary>
    /// Moves a directory
    /// </summary>
    /// <param name="from">Fullname to move</param>
    /// <param name="to">Full targetname</param>
    /// <param name="overwrite">true to overwrite target</param>
    /// <exception cref="DirectoryAlreadyExistsException">Target exists</exception>
    public static Task MoveAsync(string from, string to, bool overwrite = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Move(from, to, overwrite));
    }
}
