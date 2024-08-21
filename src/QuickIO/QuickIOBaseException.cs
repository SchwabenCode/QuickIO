using System.ComponentModel;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Abstract base class for exceptions
/// </summary>
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class QuickIOBaseException : Exception
{
    /// <summary>
    /// Affected Path
    /// </summary>
    public string Path { get; private set; }

    /// <summary>
    /// Abstract base class for exceptions
    /// </summary>
    protected QuickIOBaseException(string message, string path)
        : base(message)
    {
        Path = path;
    }

    /// <summary>
    /// Abstract base class for exceptions
    /// </summary>
    protected QuickIOBaseException(string message, string path, Exception innerException)
        : base(message, innerException)
    {
        Path = path;
    }
}
