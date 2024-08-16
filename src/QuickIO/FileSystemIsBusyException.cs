namespace SchwabenCode.QuickIO;

/// <summary>
/// This error is raised if file system is busy and further operations are not able to execute
/// </summary>
[Serializable]
public class FileSystemIsBusyException : QuickIOBaseException
{
    /// <summary>
    /// Creates an instance of <see cref="FileSystemIsBusyException"/>
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="path">Affected directory path</param>
    public FileSystemIsBusyException(string message, string path)
        : base(message, path)
    {
    }
}
