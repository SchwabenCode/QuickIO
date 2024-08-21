using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when a provided file or directory path is invalid.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios where a path does not conform to the expected format, 
/// such as containing illegal characters or being otherwise malformed. It provides detailed information 
/// about the invalid path, assisting in error handling and debugging.
/// </remarks>
[Serializable]
public class InvalidPathException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPathException"/> class 
    /// with the path that caused the exception. The error message is automatically generated 
    /// based on the Win32 error code for "invalid name."
    /// </summary>
    /// <param name="path">The file or directory path that is invalid and caused the exception to be thrown.</param>
    public InvalidPathException(string path)
        : base(Win32ErrorCodes.FormatMessage(Win32ErrorCodes.ERROR_INVALID_NAME), path)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPathException"/> class 
    /// with a specified error message and the path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The file or directory path that is invalid and caused the exception to be thrown.</param>
    public InvalidPathException(string message, string path)
        : base(message, path)
    {
    }
}
