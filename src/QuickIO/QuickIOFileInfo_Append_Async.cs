using System.Text;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// Appends lines to a file.
    /// Uses UTF-8 Encoding.
    /// </summary>
    /// <param name="contents">The lines to append.</param>
    public Task AppendAllLinesAsync(IEnumerable<string> contents)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => AppendAllLines(contents));
    }

    /// <summary>
    /// Appends lines by using the specified encoding.
    /// If the file does not exist, it creates the file.
    /// </summary>
    /// <param name="contents">The lines to append.</param>
    /// <param name="encoding">The character encoding.</param>
    public Task AppendAllLinesAsync(IEnumerable<string> contents, Encoding encoding)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => AppendAllLines(contents, encoding));
    }

    /// <summary>
    /// Appends the specified string.
    /// If the file does not exist, it creates the file.
    /// Uses UTF-8 Encoding.
    /// </summary>
    /// <param name="contents">The string to append to the file.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
    public Task AppendAllTextAsync(string contents)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => AppendAllText(contents));
    }

    /// <summary>
    /// Appends the specified string.
    /// If the file does not exist, it creates the file.
    /// </summary>
    /// <param name="contents">The string to append to the file.</param>
    /// <param name="encoding">The character encoding.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
    public Task AppendAllTextAsync(string contents, Encoding encoding)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => AppendAllText(contents, encoding));
    }

}
