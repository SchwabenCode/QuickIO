namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Specifies the types of security objects in the Windows API that can have security descriptors associated with them.
/// </summary>
internal enum Win32SecurityObjectType
{
    /// <summary>
    /// Unknown object type.
    /// </summary>
    SeUnknownObjectType = 0x0,

    /// <summary>
    /// A file or directory.
    /// </summary>
    SeFileObject = 0x1,

    /// <summary>
    /// A service.
    /// </summary>
    SeService = 0x2,

    /// <summary>
    /// A printer.
    /// </summary>
    SePrinter = 0x3,

    /// <summary>
    /// A registry key.
    /// </summary>
    SeRegistryKey = 0x4,

    /// <summary>
    /// A network share.
    /// </summary>
    SeLmshare = 0x5,

    /// <summary>
    /// A kernel object.
    /// </summary>
    SeKernelObject = 0x6,

    /// <summary>
    /// A window station or desktop object.
    /// </summary>
    SeWindowObject = 0x7,

    /// <summary>
    /// A directory service object.
    /// </summary>
    SeDsObject = 0x8,

    /// <summary>
    /// All directory service objects.
    /// </summary>
    SeDsObjectAll = 0x9,

    /// <summary>
    /// A provider-defined object.
    /// </summary>
    SeProviderDefinedObject = 0xa,

    /// <summary>
    /// A Windows Management Instrumentation (WMI) object.
    /// </summary>
    SeWmiguidObject = 0xb,

    /// <summary>
    /// A registry key for 32-bit applications on 64-bit Windows.
    /// </summary>
    SeRegistryWow6432Key = 0xc
}
