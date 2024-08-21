using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Represents the data returned by the FindFirstFile, FindNextFile, and related functions of the Windows API.
/// This class is used to store file or directory attributes and timestamps, as well as the file size and names.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
[BestFitMapping(false)]
internal class Win32FindData
{
    /// <summary>
    /// The file attributes of the file or directory.
    /// </summary>
    public FileAttributes dwFileAttributes;

    /// <summary>
    /// The low-order part of the creation time of the file or directory.
    /// </summary>
    public uint ftCreationTime_dwLowDateTime;

    /// <summary>
    /// The high-order part of the creation time of the file or directory.
    /// </summary>
    public uint ftCreationTime_dwHighDateTime;

    /// <summary>
    /// The low-order part of the last access time of the file or directory.
    /// </summary>
    public uint ftLastAccessTime_dwLowDateTime;

    /// <summary>
    /// The high-order part of the last access time of the file or directory.
    /// </summary>
    public uint ftLastAccessTime_dwHighDateTime;

    /// <summary>
    /// The low-order part of the last write time of the file or directory.
    /// </summary>
    public uint ftLastWriteTime_dwLowDateTime;

    /// <summary>
    /// The high-order part of the last write time of the file or directory.
    /// </summary>
    public uint ftLastWriteTime_dwHighDateTime;

    /// <summary>
    /// The high-order part of the file size.
    /// </summary>
    public uint nFileSizeHigh;

    /// <summary>
    /// The low-order part of the file size.
    /// </summary>
    public uint nFileSizeLow;

    /// <summary>
    /// Reserved for future use by the operating system.
    /// </summary>
    public int dwReserved0;

    /// <summary>
    /// Reserved for future use by the operating system.
    /// </summary>
    public int dwReserved1;

    /// <summary>
    /// The name of the file or directory.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string cFileName = null!;

    /// <summary>
    /// An alternative name for the file in the 8.3 format (short file name).
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
    public string cAlternateFileName = null!;
}
