using System.Text;

namespace SchwabenCode.QuickIO;

/// <summary>
/// This class is used for hash calculations.
/// Use <see>
///         <cref>Format</cref>
///     </see>
///     for human readable output.
/// </summary>
/// <example>
/// <code>
/// // Show human readable hash
/// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
/// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
/// </code>
/// </example>
public class QuickIOHashResult
{
    /// <summary>
    /// The bytes that represents the calculation result
    /// </summary>
    public byte[] HashBytes { get; private set; }

    /// <summary>
    /// Creates an instance of <see cref="QuickIOHashResult"/>
    /// </summary>
    /// <param name="hashBytes"></param>
    internal QuickIOHashResult(byte[] hashBytes)
    {
        HashBytes = hashBytes;
    }

    /// <summary>
    /// Formats the <see cref="HashBytes"/> as a hexadecimal string using UTF8 encoding.
    /// </summary>
    /// <returns>Formated string</returns>
    /// <example>
    /// <code>
    /// // Show human readable hash
    /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
    /// Console.WriteLine("Hash: {0}", hashResult.Format( );
    /// </code>
    /// </example>
    public string Format()
    {
        return Format(Encoding.UTF8);
    }

    /// <summary>
    /// Formats the <see cref="HashBytes"/> as a hexadecimal string using specified encoding.
    /// </summary>
    /// <param name="encoding">Encoding for formatting</param>
    /// <returns>Formated string</returns>
    /// <example>
    /// <code>
    /// // Show human readable hash
    /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
    /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8 );
    /// </code>
    /// </example>
    public string Format(Encoding encoding)
    {
        return Format(encoding, "x2");
    }

    /// <summary>
    /// Formats the <see cref="HashBytes"/> using specified encoding and format.
    /// </summary>
    /// <param name="encoding">Encoding for formatting</param>
    /// <param name="format">Pattern for formatting. Use x2 for hexadecimal output.</param>
    /// <returns>Formated string</returns>
    /// <example>
    /// <code>
    /// // Show human readable hash
    /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
    /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
    /// </code>
    /// </example>
    public string Format(Encoding encoding, string format
, CancellationToken cancellationToken = default
)
    {
        StringBuilder sb = new( );
        for (int index = 0; index < HashBytes.Length; index++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _ = sb.Append(HashBytes[index].ToString(format));
        }

        return sb.ToString();
    }
}
