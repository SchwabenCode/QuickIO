﻿using System.Text;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public sealed partial class QuickIOFileInfo
{
    /// <summary>
    /// Reads the contents of the file into a byte collection.
    /// </summary>
    /// <returns>A byte collection containing the contents.</returns>
    public Task<byte[]> ReadAllBytesAsync(int readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => ReadAllBytes(readBuffer));
    }

    /// <summary>
    /// Reads all lines.
    /// </summary>
    /// <returns>A string collection containing all lines.</returns>
    public Task<IEnumerable<string>> ReadAllLinesAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(ReadAllLines);
    }

    /// <summary>
    /// Reads all lines with the specified encoding
    /// </summary>
    /// <param name="encoding">The encoding applied to the contents. </param>
    /// <returns>A string collection containing all lines.</returns>
    public Task<IEnumerable<string>> ReadAllLinesAsync(Encoding encoding)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => ReadAllLines(encoding));
    }

    /// <summary>
    /// Reads all text.
    /// </summary>
    /// <returns>A string represents the content.</returns>
    public Task<string> ReadAllTextAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(ReadAllText);
    }

    /// <summary>
    /// Reads all text with the specified encoding.
    /// </summary>
    /// <param name="encoding">The encoding applied to the content. </param>
    /// <returns>A string represents the content.</returns>
    public Task<string> ReadAllTextAsync(Encoding encoding)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => ReadAllText(encoding));
    }
}
