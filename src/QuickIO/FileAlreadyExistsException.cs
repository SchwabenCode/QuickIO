using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// This error is raised if a file should be created that already exists.
/// </summary>   
[Serializable]
public class FileAlreadyExistsException : QuickIOBaseException
{
    /// <summary>
    /// Creates an instance of <see cref="FileAlreadyExistsException"/>
    /// </summary>
    /// <param name="path">Affected file path</param>
    public FileAlreadyExistsException(string path)
        : base(Win32ErrorCodes.FormatMessage(Win32ErrorCodes.ERROR_ALREADY_EXISTS), path)
    {
    }

    /// <summary>
    /// Creates an instance of <see cref="FileAlreadyExistsException"/>
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="path">Affected file path</param>
    public FileAlreadyExistsException(string message, string path)
        : base(message, path)
    {
    }
}

