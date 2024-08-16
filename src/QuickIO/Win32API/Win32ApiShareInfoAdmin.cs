
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Gets the complete share information. Requires admin priviles.
/// </summary>
/// <remarks>See http://msdn.microsoft.com/en-us/library/windows/desktop/bb525408(v=vs.85).aspx</remarks>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct Win32ApiShareInfoAdmin
{
    [MarshalAs( UnmanagedType.LPWStr )]
    public string ShareName;
    public QuickIOShareType ShareType;
    [MarshalAs( UnmanagedType.LPWStr )]
    public string Remark;
    public int Permissions;
    public int MaxUsers;
    public int CurrentUsers;
    [MarshalAs( UnmanagedType.LPWStr )]
    public string Path;
    [MarshalAs( UnmanagedType.LPWStr )]
    public string Password;
}
