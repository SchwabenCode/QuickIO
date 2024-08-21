using SchwabenCode.QuickIO.Compatibility;
namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    /// <summary>
    /// Copies a directory and all contents
    /// </summary>
    /// <param name="source">Source directory</param>
    /// <param name="target">Target directory</param>
    /// <param name="overwrite">true to overwrite existing files</param>
    public static Task CopyAsync(string source, string target, bool overwrite = false
, CancellationToken cancellationToken = default
)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Copy(source, target, overwrite
, cancellationToken
));
    }

    /// <summary>
    /// Copies a directory and all contents
    /// </summary>
    /// <param name="source">Source directory</param>
    /// <param name="target">Target directory</param>
    /// <param name="overwrite">true to overwrite existing files</param>
    public static Task CopyAsync(QuickIODirectoryInfo source, QuickIOPathInfo target, bool overwrite = false
, CancellationToken cancellationToken = default
        )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Copy(source, target, overwrite
, cancellationToken
            ));
    }

}
