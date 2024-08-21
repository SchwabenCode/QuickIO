using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public static partial class QuickIOShare
{
    /// <summary>
    /// Enumerate shares of specific machine. If no machine is specified, local machine is used
    /// </summary>
    /// <returns>Collection of <see cref="QuickIOShareInfo"/></returns>
    public static Task<IEnumerable<QuickIOShareInfo>> EnumerateSharesAsync(string? machineName = null,
        QuickIOShareApiReadLevel level = QuickIOShareApiReadLevel.Admin)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => EnumerateShares(machineName, level));
    }
}
