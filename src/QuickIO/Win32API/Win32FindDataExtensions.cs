namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Provides extension methods for the <see cref="Win32FindData"/> structure.
/// </summary>
internal static class Win32FindDataExtensions
{
    /// <summary>
    /// Calculates the file size in bytes from the high and low parts of the file size.
    /// </summary>
    /// <param name="source">The <see cref="Win32FindData"/> structure.</param>
    /// <returns>The file size in bytes.</returns>
    public static ulong CalculateBytes(this Win32FindData source)
        => (ulong)source.nFileSizeHigh << 32 | source.nFileSizeLow;

    /// <summary>
    /// Gets the last write time in UTC from the <see cref="Win32FindData"/> structure.
    /// </summary>
    /// <param name="source">The <see cref="Win32FindData"/> structure.</param>
    /// <returns>The last write time in UTC.</returns>
    public static DateTime GetLastWriteTimeUtc(this Win32FindData source)
        => Win32Data.ConvertDateTime(source.ftLastWriteTime_dwHighDateTime, source.ftLastWriteTime_dwLowDateTime);

    /// <summary>
    /// Gets the last access time in UTC from the <see cref="Win32FindData"/> structure.
    /// </summary>
    /// <param name="source">The <see cref="Win32FindData"/> structure.</param>
    /// <returns>The last access time in UTC.</returns>
    public static DateTime GetLastAccessTimeUtc(this Win32FindData source)
        => Win32Data.ConvertDateTime(source.ftLastAccessTime_dwHighDateTime, source.ftLastAccessTime_dwLowDateTime);

    /// <summary>
    /// Gets the creation time in UTC from the <see cref="Win32FindData"/> structure.
    /// </summary>
    /// <param name="source">The <see cref="Win32FindData"/> structure.</param>
    /// <returns>The creation time in UTC.</returns>
    public static DateTime GetCreationTimeUtc(this Win32FindData source)
        => Win32Data.ConvertDateTime(source.ftCreationTime_dwHighDateTime, source.ftCreationTime_dwLowDateTime);
}

