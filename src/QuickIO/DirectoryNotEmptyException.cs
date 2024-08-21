namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when an operation fails because a directory 
/// that was expected to be empty is not.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios where a directory must be empty 
/// for a specific operation to proceed, such as deletion or renaming. It provides detailed 
/// information about the non-empty directory path, aiding in error handling and debugging.
/// </remarks>
[Serializable]
public class DirectoryNotEmptyException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectoryNotEmptyException"/> class 
    /// with a specified error message and the directory path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The directory path that is not empty and caused the exception to be thrown.</param>
    public DirectoryNotEmptyException(string message, string path)
        : base(message, path)
    {
    }
}
