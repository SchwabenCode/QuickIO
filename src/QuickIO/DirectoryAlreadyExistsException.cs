namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when an operation encounters an existing directory
/// that was expected to be unique or non-existent.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios involving directory creation where 
/// a unique directory path is required. It provides detailed information about the conflicting 
/// directory path, assisting in error handling and debugging.
/// </remarks>
[Serializable]
public class DirectoryAlreadyExistsException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectoryAlreadyExistsException"/> class 
    /// with a specified error message and the directory path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The directory path that already exists and caused the exception to be thrown.</param>
    public DirectoryAlreadyExistsException(string message, string path)
        : base(message, path) { }
}
