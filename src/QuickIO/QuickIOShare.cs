using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides static methods to access network shares.
/// </summary>
public static partial class QuickIOShare
{
    /// <summary>
    /// Checks the given share for admin information
    /// </summary>
    /// <param name="serverName">Sharename</param>
    /// <param name="item">Share reference</param>
    /// <returns><see cref="QuickIOShareInfo"/></returns>
    internal static QuickIOShareInfo GetShareInfoWithAdminInformation(string serverName, IntPtr item)
    {
        Win32ApiShareInfoAdmin shareInfo = ( Win32ApiShareInfoAdmin ) Marshal.PtrToStructure( item, typeof( Win32ApiShareInfoAdmin ) )!;
        return new QuickIOShareInfo(serverName, shareInfo.ShareName, shareInfo.ShareType, shareInfo.Remark);
    }

    /// <summary>
    /// Checks the given share for normal user information
    /// </summary>
    /// <param name="serverName">Sharename</param>
    /// <param name="item">Share reference</param>
    /// <returns><see cref="QuickIOShareInfo"/></returns>
    internal static QuickIOShareInfo GetShareInfoWithNormalInformation(string serverName, IntPtr item)
    {
        Win32ApiShareInfoNormal shareInfo = ( Win32ApiShareInfoNormal ) Marshal.PtrToStructure( item, typeof( Win32ApiShareInfoNormal ) )!;
        return new QuickIOShareInfo(serverName, shareInfo.ShareName, shareInfo.ShareType, shareInfo.Remark);
    }
}
