
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Represents information about a shared resource in the Win32 API.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct Win32ApiShareInfoNormal
{
    /// <summary>
    /// The name of the shared resource.
    /// </summary>
    [MarshalAs(UnmanagedType.LPWStr)]
    public string ShareName;

    /// <summary>
    /// The type of the shared resource.
    /// </summary>
    public QuickIOShareType ShareType;

    /// <summary>
    /// A comment or description associated with the shared resource.
    /// </summary>
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Remark;
}
