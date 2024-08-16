using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Structure of File Data given by Win32 API
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
[BestFitMapping(false)]
internal class Win32FindData
{
    /// <summary>
    /// File Attributes
    /// </summary>
    public FileAttributes dwFileAttributes;

    /// <summary>
    /// Last Creation Time (Low DateTime)
    /// </summary>
    public uint ftCreationTime_dwLowDateTime;

    /// <summary>
    /// Last Creation Time (High DateTime)
    /// </summary>
    public uint ftCreationTime_dwHighDateTime;

    /// <summary>
    /// Last Access Time (Low DateTime)
    /// </summary>
    public uint ftLastAccessTime_dwLowDateTime;

    /// <summary>
    /// Last Access Time (High DateTime)
    /// </summary>
    public uint ftLastAccessTime_dwHighDateTime;

    /// <summary>
    /// Last Write Time (Low DateTime)
    /// </summary>
    public uint ftLastWriteTime_dwLowDateTime;

    /// <summary>
    /// Last Write Time (High DateTime)
    /// </summary>
    public uint ftLastWriteTime_dwHighDateTime;

    /// <summary>
    /// File Size High
    /// </summary>
    public uint nFileSizeHigh;

    /// <summary>
    /// File Size Low
    /// </summary>
    public uint nFileSizeLow;

    /// <summary>
    /// Reserved
    /// </summary>
    public int dwReserved0;

    /// <summary>
    /// Reserved
    /// </summary>
    public int dwReserved1;

    /// <summary>
    /// File name
    /// </summary>
    [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 260 )]
    public string cFileName = null!;

    /// <summary>
    /// Alternate File Name
    /// </summary>
    [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 14 )]
    public string cAlternateFileName = null!;

    /// <summary>
    /// Creates a new Instance
    /// </summary>
    public static Win32FindData New => new();

    /// <summary>
    /// Returns the total size in bytes
    /// </summary>
    /// <returns></returns>
    public ulong CalculateBytes()
        => (ulong)nFileSizeHigh << 32 | nFileSizeLow;

    /// <summary>
    /// Gets last write time based on UTC
    /// </summary>
    /// <returns></returns>
    public DateTime GetLastWriteTimeUtc()
        => InternalRawDataHelpers.ConvertDateTime(ftLastWriteTime_dwHighDateTime, ftLastWriteTime_dwLowDateTime);

    /// <summary>
    /// Gets last access time based on UTC
    /// </summary>
    /// <returns></returns>
    public DateTime GetLastAccessTimeUtc()
        => InternalRawDataHelpers.ConvertDateTime(ftLastAccessTime_dwHighDateTime, ftLastAccessTime_dwLowDateTime);

    /// <summary>
    /// Gets the creation time based on UTC
    /// </summary>
    /// <returns></returns>
    public DateTime GetCreationTimeUtc()
        => InternalRawDataHelpers.ConvertDateTime(ftCreationTime_dwHighDateTime, ftCreationTime_dwLowDateTime);
}
