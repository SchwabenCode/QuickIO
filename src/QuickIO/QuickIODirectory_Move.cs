using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

public partial class QuickIODirectory
{
    /// <summary>
    /// Moves a directory
    /// </summary>
    /// <param name="from">Fullname to move</param>
    /// <param name="to">Full targetname</param>
    /// <param name="overwrite">true to overwrite target</param>
    /// <exception cref="DirectoryAlreadyExistsException">Target exists</exception>
    public static void Move(string from, string to, bool overwrite = false)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(from);
        ArgumentNullException.ThrowIfNullOrEmpty(to);

        if (!overwrite && Exists(to))
        {
            throw new DirectoryAlreadyExistsException("Target directory already exists.", to);
        }

        if (!Win32SafeNativeMethods.MoveFile(from, to))
        {
            int win32Error = Marshal.GetLastWin32Error( );
            InternalQuickIOCommon.NativeExceptionMapping(from, win32Error);
        }
    }
}
