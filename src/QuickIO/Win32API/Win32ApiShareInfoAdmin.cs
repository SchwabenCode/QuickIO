
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Represents detailed information about an administrative shared resource in the Win32 API.
/// </summary>
/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/lmshare/ns-lmshare-share_info_2</remarks>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct Win32ApiShareInfoAdmin
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

    /// <summary>
    /// The permissions set for the shared resource.
    /// </summary>
    public int Permissions;

    /// <summary>
    /// The maximum number of users that can simultaneously access the shared resource.
    /// </summary>
    public int MaxUsers;

    /// <summary>
    /// The current number of users accessing the shared resource.
    /// </summary>
    public int CurrentUsers;

    /// <summary>
    /// The local path of the shared resource.
    /// </summary>
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Path;

    /// <summary>
    /// The password required to access the shared resource, if any.
    /// </summary>
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Password;
}

