// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

namespace SchwabenCode.QuickIO.Win32
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
