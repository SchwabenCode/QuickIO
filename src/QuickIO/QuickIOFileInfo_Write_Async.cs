using System.Text;
using SchwabenCode.QuickIO.Compatibility;


namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// Writes the specified byte array.
    /// </summary>
    /// <param name="bytes">The bytes to write. </param>
    public Task WriteAllBytesAsync(IEnumerable<byte> bytes)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => WriteAllBytes(bytes));
    }

    /// <summary>
    /// Writes the specified byte array.
    /// </summary>
    /// <param name="bytes">The bytes to write. </param>
    public Task WriteAllBytesAsync(byte[] bytes)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => WriteAllBytes(bytes));
    }

    /// <summary>
    /// Writes a collection of strings.
    /// Uses UTF-8 without Emitted UTF-8 identifier.
    /// </summary>
    /// <param name="contents">The lines write to.</param>
    public Task WriteAllLinesAsync(IEnumerable<string> contents)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => WriteAllLines(contents));
    }

    /// <summary>
    /// Writes a collection of strings.
    /// </summary>
    /// <param name="contents">The lines write to.</param>
    /// <param name="encoding">The character encoding to use.</param>
    public Task WriteAllLinesAsync(IEnumerable<string> contents, Encoding encoding)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => WriteAllLines(contents, encoding));
    }

    /// <summary>
    /// Writes the specified string.
    /// </summary>
    /// <param name="contents">The string to write to. </param>
    /// <param name="encoding">The encoding to apply to the string.</param>
    public Task WriteAllTextAsync(string contents, Encoding encoding)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => WriteAllText(contents, encoding));
    }

    /// <summary>
    /// Writes the specified string.
    /// </summary>
    /// <param name="contents">The string to write to. </param>
    public Task WriteAllTextAsync(string contents)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => WriteAllText(contents));
    }
}
