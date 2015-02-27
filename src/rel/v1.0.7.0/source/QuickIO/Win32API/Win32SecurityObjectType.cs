// <copyright file="Win32SecurityObjectType.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Win32SecurityObjectType</summary>

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Win32 Security Object Type
    /// </summary>
    internal enum Win32SecurityObjectType
    {
        SeUnknownObjectType = 0x0,
        SeFileObject = 0x1,
        SeService = 0x2,
        SePrinter = 0x3,
        SeRegistryKey = 0x4,
        SeLmshare = 0x5,
        SeKernelObject = 0x6,
        SeWindowObject = 0x7,
        SeDsObject = 0x8,
        SeDsObjectAll = 0x9,
        SeProviderDefinedObject = 0xa,
        SeWmiguidObject = 0xb,
        SeRegistryWow6432Key = 0xc
    }
}
