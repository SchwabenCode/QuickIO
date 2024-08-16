namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Win32 Security Information
/// </summary>
[Flags]
internal enum Win32FileSystemEntrySecurityInformation : uint
{
    OwnerSecurityInformation = 1,
    GroupSecurityInformation = 2,

    DaclSecurityInformation = 4,
    SaclSecurityInformation = 8,

    UnprotectedSaclSecurityInformation = 0x10000000,
    UnprotectedDaclSecurityInformation = 0x20000000,

    ProtectedSaclSecurityInformation = 0x40000000,
    ProtectedDaclSecurityInformation = 0x80000000
}
