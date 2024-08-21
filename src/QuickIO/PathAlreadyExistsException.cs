
namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when an operation encounters an existing path
/// that was expected to be unique or non-existent.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios involving file or directory creation 
/// where a unique path is required. The exception provides detailed information about 
/// the conflicting path, allowing for better error handling and debugging.
/// </remarks>
[Serializable]
public class PathAlreadyExistsException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PathAlreadyExistsException"/> class 
    /// with a specified error message and the path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The path that already exists and caused the exception to be thrown.</param>
    public PathAlreadyExistsException(string message, string path)
        : base(message, path) { }
}
