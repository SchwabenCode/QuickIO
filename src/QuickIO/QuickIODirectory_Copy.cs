using SchwabenCode.QuickIO.Internal;
namespace SchwabenCode.QuickIO;

public static partial class QuickIODirectory
{
    /// <summary>
    /// Copies a directory and all contents
    /// </summary>
    /// <param name="source">Source directory</param>
    /// <param name="target">Target directory</param>
    /// <param name="overwrite">true to overwrite existing files</param>
    /// <param name="cancellationToken">Cancallation Token</param>
    public static void Copy(string source, string target, bool overwrite = false, CancellationToken cancellationToken = default)
    {
        Copy(new QuickIODirectoryInfo(source), new QuickIOPathInfo(target), overwrite, cancellationToken);
    }

    /// <summary>
    /// Copies a directory and all contents
    /// </summary>
    /// <param name="source">Source directory</param>
    /// <param name="target">Target directory</param>
    /// <param name="overwrite">true to overwrite existing files</param>
    /// <param name="cancellationToken">Cancallation Token</param>
    public static void Copy(QuickIODirectoryInfo source, QuickIOPathInfo target, bool overwrite = false, CancellationToken cancellationToken = default)
    {
        IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> allContentUncPaths = EnumerateFileSystemEntryPaths( source, QuickIOPatternConstants.All, SearchOption.AllDirectories, QuickIOPathType.UNC );
        foreach (KeyValuePair<string, QuickIOFileSystemEntryType> entry in allContentUncPaths)
        {
            cancellationToken.ThrowIfCancellationRequested();
            string sourcePathUnc = entry.Key;
            string targetFullnameUnc = target.FullNameUnc + sourcePathUnc.Substring( source.FullNameUnc.Length );

            if (!QuickIODirectory.Exists(targetFullnameUnc))
            {

            }

            switch (entry.Value)
            {
                case QuickIOFileSystemEntryType.Directory:
                {
                    QuickIODirectory.Create(targetFullnameUnc, true);
                }
                break;

                case QuickIOFileSystemEntryType.File:
                {
                    QuickIOFile.Copy(sourcePathUnc, targetFullnameUnc, overwrite);
                }
                break;
            }
        }
    }


    /// <summary>
    /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
    /// </summary>
    /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
    public static Task<QuickIODirectoryMetadata?> GetMetadastaAsync(string directoryPath)
    {
        return Compatibility.NETCompatibility.AsyncExtensions
            .GetAsyncResult(() => InternalQuickIO.EnumerateDirectoryMetadata(new QuickIOPathInfo(directoryPath)));
    }
}
