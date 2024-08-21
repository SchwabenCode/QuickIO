namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when a file system operation fails because the target file or directory is currently in use or locked by another process.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios where operations like deleting, moving, or modifying files and directories cannot be completed
/// because they are being accessed by other processes. It provides detailed information about the busy path, aiding in error handling and debugging.
/// </remarks>
[Serializable]
public class FileSystemIsBusyException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileSystemIsBusyException"/> class
    /// with a specified error message and the path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The file or directory path that is currently in use and caused the exception to be thrown.</param>
    public FileSystemIsBusyException(string message, string path)
        : base(message, path)
    {
    }
}
