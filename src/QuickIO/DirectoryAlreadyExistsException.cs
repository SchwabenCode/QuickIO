namespace SchwabenCode.QuickIO;

/// <summary>
/// This error is raised if you want to create for example a folder which already exists.
/// </summary>
[Serializable]
public class DirectoryAlreadyExistsException : QuickIOBaseException
{
    /// <summary>
    /// Creates an instance of <see cref="DirectoryAlreadyExistsException"/>
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="path">Affected directory path</param>
    public DirectoryAlreadyExistsException(string message, string path)
        : base(message, path) { }
}
