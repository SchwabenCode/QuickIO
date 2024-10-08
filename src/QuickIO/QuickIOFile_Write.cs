﻿using System.Text;

namespace SchwabenCode.QuickIO;

public static partial class QuickIOFile
{

    /// <summary>
    /// Writes the specified byte array.
    /// If the file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <param name="bytes">The bytes to write. </param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.writeallbytes(v=vs.110).aspx</remarks>
    public static void WriteAllBytes(string path, IEnumerable<byte> bytes)
    {
        WriteAllBytes(new QuickIOPathInfo(path), bytes);
    }

    /// <summary>
    /// Writes the specified byte array.
    /// If the file already exists, it is overwritten.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="bytes">The bytes to write. </param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.writeallbytes(v=vs.110).aspx</remarks>
    public static void WriteAllBytes(QuickIOPathInfo pathInfo, IEnumerable<byte> bytes)
    {
        WriteAllBytes(pathInfo, bytes.ToArray());
    }


    /// <summary>
    /// Writes the specified byte array.
    /// If the file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <param name="bytes">The bytes to write. </param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.writeallbytes(v=vs.110).aspx</remarks>
    public static void WriteAllBytes(string path, byte[] bytes)
    {
        WriteAllBytes(new QuickIOPathInfo(path), bytes);
    }

    /// <summary>
    /// Writes the specified byte array.
    /// If the file already exists, it is overwritten.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="bytes">The bytes to write. </param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.writeallbytes(v=vs.110).aspx</remarks>
    public static void WriteAllBytes(QuickIOPathInfo pathInfo, byte[] bytes)
    {
        using FileStream fileStream = OpenFileStream(pathInfo, FileAccess.ReadWrite, FileMode.Create, FileShare.None);
        _ = fileStream.Seek(0, SeekOrigin.Begin);
        fileStream.Write(bytes, 0, bytes.Length);
    }

    /// <summary>
    /// Writes a collection of strings.
    /// Uses UTF-8 without Emitted UTF-8 identifier.
    /// </summary>
    /// <param name="path">The file.</param>
    /// <param name="contents">The lines write to.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/dd383693(v=vs.110).aspx</remarks>
    public static void WriteAllLines(string path, IEnumerable<string> contents)
    {
        WriteAllLines(new QuickIOPathInfo(path), contents, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
    }

    /// <summary>
    /// Writes a collection of strings.
    /// Uses UTF-8 without Emitted UTF-8 identifier.
    /// </summary>
    /// <param name="pathInfo">The file.</param>
    /// <param name="contents">The lines write to.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/dd383693(v=vs.110).aspx</remarks>
    public static void WriteAllLines(QuickIOPathInfo pathInfo, IEnumerable<string> contents)
    {
        WriteAllLines(pathInfo, contents, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
    }


    /// <summary>
    /// Writes a collection of strings.
    /// </summary>
    /// <param name="path">The file.</param>
    /// <param name="contents">The lines write to.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/dd383463(v=vs.110).aspx</remarks>
    public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
    {
        WriteAllLines(new QuickIOPathInfo(path), contents, encoding);
    }

    /// <summary>
    /// Writes a collection of strings.
    /// </summary>
    /// <param name="pathInfo">The file.</param>
    /// <param name="contents">The lines write to.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/dd383463(v=vs.110).aspx</remarks>
    public static void WriteAllLines(QuickIOPathInfo pathInfo, IEnumerable<string> contents, Encoding encoding)
    {
        FileStream fileStream = OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.Create, FileShare.None );
        using StreamWriter streamWriter = new(fileStream, encoding);
        foreach (string entry in contents)
        {
            streamWriter.WriteLine(entry);
        }
    }

    /// <summary>
    /// Writes the specified string.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <param name="contents">The string to write to. </param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143375(v=vs.110).aspx</remarks>
    public static void WriteAllText(string path, string contents)
    {
        WriteAllText(new QuickIOPathInfo(path), contents);
    }

    /// <summary>
    /// Writes the specified string.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="contents">The string to write to. </param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143375(v=vs.110).aspx</remarks>
    public static void WriteAllText(QuickIOPathInfo pathInfo, string contents)
    {
        WriteAllText(pathInfo, contents, QuickIOSystemRules.UTF8EncodingNoEmit);
    }

    /// <summary>
    /// Writes the specified string.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <param name="contents">The string to write to. </param>
    /// <param name="encoding">The encoding to apply to the string.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143376(v=vs.110).aspx</remarks>
    public static void WriteAllText(string path, string contents, Encoding encoding)
    {
        WriteAllText(new QuickIOPathInfo(path), contents, encoding);
    }

    /// <summary>
    /// Writes the specified string.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="contents">The string to write to. </param>
    /// <param name="encoding">The encoding to apply to the string.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143376(v=vs.110).aspx</remarks>
    public static void WriteAllText(QuickIOPathInfo pathInfo, string contents, Encoding encoding)
    {
        FileStream fileStream = OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.Create, FileShare.None );
        using StreamWriter streamWriter = new(fileStream, encoding);
        streamWriter.Write(contents);
    }
}
