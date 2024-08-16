namespace SchwabenCode.QuickIO;

/// <summary>
/// Various default and recommended values for different operations, connections and API calls
/// </summary>
public static class QuickIORecommendedValues
{
    /// <summary>
    /// Recommended buffer byte size for default read operations
    /// </summary>
    public const int DefaultReadBufferBytes = 4096;

    /// <summary>
    /// Recommended size of Byte packages for TCP connections
    /// </summary>
    public const int TCPMaxPackageBytes = 65535;

    /// <summary>
    /// Recommended size of Byte packages for local ethernet connections
    /// </summary>
    public const int MTUMaxPackageBytes = 1500;

    /// <summary>
    /// Recommended size of Byte packages for SMB connections
    /// </summary>
    /// <remarks>See http://support.microsoft.com/kb/223140</remarks>
    public const int SMBMaxPackageBytes = 60 * 1024;
}
