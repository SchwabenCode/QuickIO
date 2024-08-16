using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO;

public partial class QuickIOShareInfo
{
    /// <summary>
    /// Returns <see cref="QuickIODiskInformation"/> of this instance.
    /// </summary>
    /// <returns><see cref="QuickIODiskInformation"/></returns>
    /// <remarks>Only supported for <see cref="QuickIOShareType.Disk"/></remarks>
    /// <exception cref="UnsupportedShareTypeException">Metadata not supported for this Sharetype. Only available for <see cref="QuickIOShareType.Disk"/></exception>
    public QuickIODiskInformation GetDiskInformation()
    {
        if (ShareType != QuickIOShareType.Disk)
        {
            throw new UnsupportedShareTypeException(FullName, "Metadata not supported for this Sharetype");
        }

        return InternalQuickIO.GetDiskInformation(FullName);
    }
}
