using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when an operation encounters an existing file 
/// that was expected to be unique or non-existent.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios involving file creation where a unique 
/// file path is required. It provides detailed information about the conflicting file path, 
/// assisting in error handling and debugging.
/// </remarks>
[Serializable]
public class FileAlreadyExistsException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileAlreadyExistsException"/> class 
    /// with the file path that caused the exception. The error message is automatically 
    /// generated based on the Win32 error code for "file already exists."
    /// </summary>
    /// <param name="path">The file path that already exists and caused the exception to be thrown.</param>
    public FileAlreadyExistsException(string path)
        : base(Win32ErrorCodes.FormatMessage(Win32ErrorCodes.ERROR_ALREADY_EXISTS), path)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileAlreadyExistsException"/> class 
    /// with a specified error message and the file path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The file path that already exists and caused the exception to be thrown.</param>
    public FileAlreadyExistsException(string message, string path)
        : base(message, path)
    { }
}
