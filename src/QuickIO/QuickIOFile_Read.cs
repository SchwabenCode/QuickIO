using System.Text;

namespace SchwabenCode.QuickIO;

public static partial class QuickIOFile
{
    /// <summary>
    /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading. </param>
    /// <returns>A byte array containing the contents of the file.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.readallbytes(v=vs.110).aspx</remarks>
    public static byte[] ReadAllBytes(string path)
        => ReadAllBytes(new QuickIOPathInfo(path));

    /// <summary>
    /// Reads the contents of the file into a byte collection.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="readBuffer">Read buffer byte size</param>
    /// <returns>A byte collection containing the contents.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.readallbytes(v=vs.110).aspx</remarks>
    public static byte[] ReadAllBytes(QuickIOPathInfo pathInfo, int readBuffer = 1024)
    {
        using FileStream readStream = OpenRead(pathInfo);
        byte[] buffer = new byte[ readBuffer ];

        using MemoryStream ms = new();
        int read;

        while ((read = readStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
        }

        return ms.ToArray();
    }

    /// <summary>
    /// Reads all lines.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <returns>A string collection containing all lines.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/s2tte0y1(v=vs.110).aspx</remarks>
    public static IEnumerable<string> ReadAllLines(string path)
        => ReadAllLines(path, Encoding.UTF8);

    /// <summary>
    /// Reads all lines.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <returns>A string collection containing all lines.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/s2tte0y1(v=vs.110).aspx</remarks>
    public static IEnumerable<string> ReadAllLines(QuickIOPathInfo pathInfo)
        => ReadAllLines(pathInfo, Encoding.UTF8);

    /// <summary>
    /// Reads all lines with the specified encoding
    /// </summary>
    /// <param name="path">The file. </param>
    /// <param name="encoding">The encoding applied to the contents. </param>
    /// <returns>A string collection containing all lines.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/bsy4fhsa(v=vs.110).aspx</remarks>
    public static IEnumerable<string> ReadAllLines(string path, Encoding encoding)
        => ReadAllLines(new QuickIOPathInfo(path), encoding);

    /// <summary>
    /// Reads all lines with the specified encoding
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="encoding">The encoding applied to the contents. </param>
    /// <returns>A string collection containing all lines.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/bsy4fhsa(v=vs.110).aspx</remarks>
    public static IEnumerable<string> ReadAllLines(QuickIOPathInfo pathInfo, Encoding encoding)
    {
        using StreamReader streamReader = new(OpenRead(pathInfo.FullNameUnc), encoding);
        while (streamReader.Peek() >= 0)
        {
            string? line = streamReader.ReadLine();
            if (line is not null)
            {
                yield return line;
            }
        }
    }

    /// <summary>
    /// Reads all text.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <returns>A string represents the content.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/s2tte0y1(v=vs.110).aspx</remarks>
    public static string ReadAllText(string path)
        => ReadAllText(new QuickIOPathInfo(path));

    /// <summary>
    /// Reads all text.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <returns>A string represents the content.</returns>
    public static string ReadAllText(QuickIOPathInfo pathInfo)
        => ReadAllText(pathInfo, Encoding.UTF8);

    /// <summary>
    /// Reads all text with the specified encoding.
    /// </summary>
    /// <param name="path">The file. </param>
    /// <param name="encoding">The encoding applied to the content. </param>
    /// <returns>A string represents the content.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143369(v=vs.110).aspx</remarks>
    public static string ReadAllText(string path, Encoding encoding)
        => ReadAllText(new QuickIOPathInfo(path), encoding);

    /// <summary>
    /// Reads all text with the specified encoding.
    /// </summary>
    /// <param name="pathInfo">The file. </param>
    /// <param name="encoding">The encoding applied to the content. </param>
    /// <returns>A string represents the content.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms143369(v=vs.110).aspx</remarks>
    public static string ReadAllText(QuickIOPathInfo pathInfo, Encoding encoding)
    {
        using StreamReader streamReader = new(OpenRead(pathInfo.FullNameUnc), encoding);
        return streamReader.ReadToEnd();
    }
}
