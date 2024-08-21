namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents an exception for unsuuported drive types
/// </summary>
public class UnsupportedShareTypeException : QuickIOBaseException
{
    /// <summary>
    /// Creates an instance of <see cref="UnsupportedShareTypeException"/>
    /// </summary>
    /// <param name="path">Unsupported drive</param>
    /// <param name="message">Error</param>
    public UnsupportedShareTypeException(string path, string message)
        : base(message, path)
    {
    }
}
