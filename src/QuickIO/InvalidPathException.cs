using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Invalid Path Exception
/// </summary>
[Serializable]
public class InvalidPathException : QuickIOBaseException
{
    /// <summary>
    /// Invalid Path Exception
    /// </summary>
    /// <param name="path">Invalid Path</param>
    public InvalidPathException(string path)
        : base(Win32ErrorCodes.FormatMessage(Win32ErrorCodes.ERROR_INVALID_NAME), path)
    {
    }

    /// <summary>
    /// Invalid Path Exception
    /// </summary>
    /// <param name="message">Error Message</param>
    /// <param name="path">Invalid Path</param>
    public InvalidPathException(string message, string path)
        : base(message, path)
    {
    }
}
