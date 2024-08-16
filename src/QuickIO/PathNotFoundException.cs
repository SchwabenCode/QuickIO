using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception that is thrown when an operation fails due to a specified 
/// path not being found.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios involving file or directory access where 
/// the specified path does not exist. It provides detailed information about the missing 
/// path, aiding in error handling and debugging.
/// </remarks>
[Serializable]
public class PathNotFoundException : QuickIOBaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PathNotFoundException"/> class 
    /// with a specified path that caused the exception. The error message is automatically 
    /// generated based on the Win32 error code for "path not found."
    /// </summary>
    /// <param name="path">The path that was not found and caused the exception to be thrown.</param>
    public PathNotFoundException(string path)
        : base(Win32ErrorCodes.FormatMessage(Win32ErrorCodes.ERROR_PATH_NOT_FOUND), path) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PathNotFoundException"/> class 
    /// with a specified error message and the path that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The path that was not found and caused the exception to be thrown.</param>
    public PathNotFoundException(string message, string path)
        : base(message, path) { }
}
