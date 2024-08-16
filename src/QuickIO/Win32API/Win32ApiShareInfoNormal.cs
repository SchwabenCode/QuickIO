
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Use this Info bag if call with admin privilegs fails (fallback)
/// </summary>
/// <remarks>See http://msdn.microsoft.com/en-us/library/windows/desktop/bb525407(v=vs.85).aspx</remarks>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct Win32ApiShareInfoNormal
{
    [MarshalAs( UnmanagedType.LPWStr )]
    public string ShareName;
    public QuickIOShareType ShareType;
    [MarshalAs( UnmanagedType.LPWStr )]
    public string Remark;
}
