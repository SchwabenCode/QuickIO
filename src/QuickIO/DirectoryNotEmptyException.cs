namespace SchwabenCode.QuickIO;

/// <summary>
/// This error is raised if a folder that is not empty should be deleted.
/// </summary>
[Serializable]
public class DirectoryNotEmptyException : QuickIOBaseException
{
    /// <summary>
    /// Creates an instance of <see cref="DirectoryNotEmptyException"/>
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="path">Affected directory path</param>
    public DirectoryNotEmptyException(string message, string path)
        : base(message, path)
    {
    }
}
