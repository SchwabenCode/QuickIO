namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Provides helper methods for handling Win32 API data conversions and operations.
/// </summary>
internal static class Win32Data
{
    /// <summary>
    /// Converts a high and low part of a Win32 file time to a <see cref="DateTime"/> in UTC.
    /// </summary>
    /// <param name="high">The high 32 bits of the file time.</param>
    /// <param name="low">The low 32 bits of the file time.</param>
    /// <returns>A <see cref="DateTime"/> representing the combined file time in UTC.</returns>
    internal static DateTime ConvertDateTime(uint high, uint low)
        => DateTime.FromFileTimeUtc(CombineHighLowInts(high, low));

    /// <summary>
    /// Combines the high and low 32-bit parts into a single 64-bit integer.
    /// </summary>
    /// <param name="high">The high 32 bits.</param>
    /// <param name="low">The low 32 bits.</param>
    /// <returns>A 64-bit integer formed by combining the high and low parts.</returns>
    internal static long CombineHighLowInts(uint high, uint low)
    {
        return (long)high << 0x20 | low;
    }

    /// <summary>
    /// Determines whether the given <see cref="Win32FindData"/> represents a system directory entry (e.g., "." or "..").
    /// </summary>
    /// <param name="win32FindData">The <see cref="Win32FindData"/> structure to evaluate.</param>
    /// <returns><see langword="true"/> if the entry is a system directory (e.g., "." or ".."); otherwise, <see langword="false"/>.</returns>
    public static bool IsSystemDirectoryEntry(Win32FindData win32FindData)
        => win32FindData.cFileName is "." or "..";

    /// <summary>
    /// Converts a <see cref="DateTime"/> to a Win32 file time.
    /// </summary>
    /// <param name="time">The <see cref="DateTime"/> to convert.</param>
    /// <returns>A <see cref="Win32FileTime"/> structure representing the file time.</returns>
    public static Win32FileTime DateTimeToFiletime(DateTime time)
    {
        Win32FileTime ft;
        long fileTime = time.ToFileTimeUtc();
        ft.DateTimeLow = (uint)(fileTime & 0xFFFFFFFF);
        ft.DateTimeHigh = (uint)(fileTime >> 32);
        return ft;
    }
}
