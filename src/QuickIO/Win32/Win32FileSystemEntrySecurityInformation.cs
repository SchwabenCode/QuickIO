// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>


using System;

namespace SchwabenCode.QuickIO.Win32
{
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
}
