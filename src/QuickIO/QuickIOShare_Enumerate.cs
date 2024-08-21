using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

public static partial class QuickIOShare
{

    /// <summary>
    /// Enumerate shares of specific machine. If no machine is specified, local machine is used
    /// </summary>
    /// <returns>Collection of <see cref="QuickIOShareInfo"/></returns>
    public static IEnumerable<QuickIOShareInfo> EnumerateShares(string? machineName = null, QuickIOShareApiReadLevel level = QuickIOShareApiReadLevel.Admin)
    {
        // Specify 
        string targetName = string.IsNullOrEmpty( machineName ) ? Environment.MachineName : machineName;

        int resumeHandle = 0;
        nint buffer = IntPtr.Zero;

        try
        {
            int entriesRead = 0;
            int totalEntries = 0;

            int returnCode = InternalQuickIO.GetShareEnumResult( targetName, level, ref buffer, ref entriesRead, ref totalEntries, ref resumeHandle );

            // Available return codes: http://msdn.microsoft.com/en-us/library/windows/desktop/bb525387(v=vs.85).aspx

            if (returnCode == Win32ErrorCodes.ERROR_ACCESS_DENIED) // Access Denied
            {
                // Admin required, but not granted? try with normal usr
                level = QuickIOShareApiReadLevel.Normal;
                returnCode = InternalQuickIO.GetShareEnumResult(targetName, level, ref buffer, ref entriesRead, ref totalEntries, ref resumeHandle);
            }

            if (returnCode != 0) // we only handle return 0 here
            {
                yield break;

            }
            // Ignore no entries
            if (entriesRead <= 0)
            {
                yield break;
            }

            Type shareType = ( level == QuickIOShareApiReadLevel.Admin ) ? typeof( Win32ApiShareInfoAdmin ) : typeof( Win32ApiShareInfoNormal );
            int dataOffset = Marshal.SizeOf( shareType );

            for (int i = 0, currentDataItem = buffer.ToInt32(); i < entriesRead; i++, currentDataItem += dataOffset)
            {

                if (level == QuickIOShareApiReadLevel.Normal)
                {
                    yield return GetShareInfoWithNormalInformation(targetName, new IntPtr(currentDataItem));

                }
                else
                {
                    yield return GetShareInfoWithAdminInformation(targetName, new IntPtr(currentDataItem));

                }
            }
        }
        finally
        {
            // Clean up buffer allocated by system
            if (buffer != IntPtr.Zero)
            {
                _ = Win32SafeNativeMethods.NetApiBufferFree(buffer);
            }
        }
    }
}
