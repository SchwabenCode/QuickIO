using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIOShareInfo
{
    /// <summary>
    /// Returns <see cref="QuickIODiskInformation"/> of this instance.
    /// </summary>
    /// <returns><see cref="QuickIODiskInformation"/></returns>
    /// <remarks>Only supported for <see cref="QuickIOShareType.Disk"/></remarks>
    /// <exception cref="UnsupportedShareTypeException">Metadata not supported for this Sharetype. Only available for <see cref="QuickIOShareType.Disk"/></exception>
    public Task<QuickIODiskInformation> GetDiskInformationAsync()
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(GetDiskInformation);
    }
}
