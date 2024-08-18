namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Specifies the type of security information to be applied to or retrieved from a file system entry.
/// This enumeration supports a bitwise combination of its member values.
/// </summary>
[Flags]
internal enum Win32FileSystemEntrySecurityInformation : uint
{
    /// <summary>
    /// Indicates the owner security information.
    /// </summary>
    OwnerSecurityInformation = 1,

    /// <summary>
    /// Indicates the group security information.
    /// </summary>
    GroupSecurityInformation = 2,

    /// <summary>
    /// Indicates the Discretionary Access Control List (DACL) security information.
    /// </summary>
    DaclSecurityInformation = 4,

    /// <summary>
    /// Indicates the System Access Control List (SACL) security information.
    /// </summary>
    SaclSecurityInformation = 8,

    /// <summary>
    /// Indicates that the SACL is unprotected.
    /// </summary>
    UnprotectedSaclSecurityInformation = 0x10000000,

    /// <summary>
    /// Indicates that the DACL is unprotected.
    /// </summary>
    UnprotectedDaclSecurityInformation = 0x20000000,

    /// <summary>
    /// Indicates that the SACL is protected.
    /// </summary>
    ProtectedSaclSecurityInformation = 0x40000000,

    /// <summary>
    /// Indicates that the DACL is protected.
    /// </summary>
    ProtectedDaclSecurityInformation = 0x80000000
}
