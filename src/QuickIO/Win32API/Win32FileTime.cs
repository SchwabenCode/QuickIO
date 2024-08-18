using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Represents a 64-bit value that records the number of 100-nanosecond intervals since January 1, 1601 (UTC).
/// Used to specify file times in Windows API.
/// </summary>
/// <remarks>http://www.pinvoke.net/default.aspx/Structures/FILETIME.html?diff=y</remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct Win32FileTime
{
    /// <summary>
    /// The low-order part of the file time.
    /// </summary>
    public uint DateTimeLow;

    /// <summary>
    /// The high-order part of the file time.
    /// </summary>
    public uint DateTimeHigh;
}
