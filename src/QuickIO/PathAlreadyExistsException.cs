using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Exception if path does not exist.
/// </summary>
[Serializable]
public class PathAlreadyExistsException : QuickIOBaseException
{
    /// <summary>
    /// Exception if path does not exist.
    /// </summary>
    public PathAlreadyExistsException(string message, string path)
        : base(message, path)
    {
        Contract.Requires(!string.IsNullOrWhiteSpace(message));
        Contract.Requires(!string.IsNullOrWhiteSpace(path));
    }
}
