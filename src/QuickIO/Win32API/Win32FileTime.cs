using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// See http://www.pinvoke.net/default.aspx/Structures/FILETIME.html?diff=y
/// Represents Win32 LongFileTime
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct Win32FileTime
{
    public uint DateTimeLow;
    public uint DateTimeHigh;
}
