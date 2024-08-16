namespace SchwabenCode.QuickIO;

/// <summary>
/// Enum collection of available shares types
/// </summary>
public enum QuickIOShareType : uint
{
    /// <summary>
    /// Disk or network share share
    /// </summary>
    Disk = 0,

    /// <summary>
    /// Printer share
    /// </summary>
    Printer = 1,

    /// <summary>
    /// Device share
    /// </summary>
    Device = 2,

    /// <summary>
    /// IPC share</summary>
    IPC = 2147483651,

    /// <summary>
    /// Special share
    /// </summary>
    Special = 2147483648
}
