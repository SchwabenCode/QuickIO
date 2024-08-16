using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Exception if path does not exist.
/// </summary>
[Serializable]
public class PathNotFoundException : QuickIOBaseException
{
    /// <summary>
    /// Exception if path does not exist.
    /// </summary>
    public PathNotFoundException(string path)
        : base(Win32ErrorCodes.FormatMessage(Win32ErrorCodes.ERROR_PATH_NOT_FOUND), path)
    {
    }

    /// <summary>
    /// Exception if path does not exist.
    /// </summary>
    public PathNotFoundException(string message, string path)
        : base(message, path)
    {
    }
}
