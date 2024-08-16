using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO;

public static partial class QuickIOShare
{
    /// <summary>
    /// Receives <see cref="QuickIODiskInformation"/> of specifies share path
    /// </summary>
    /// <returns><see cref="QuickIODiskInformation"/></returns>
    /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
    public static QuickIODiskInformation GetDiskInformation(string sharePath)
    {
        return InternalQuickIO.GetDiskInformation(sharePath);
    }
}
