namespace SchwabenCode.QuickIO.Internal;

/// <summary>
/// Several check methods to verify method parameters
/// </summary>
internal static class Invariant
{
    /// <summary>
    /// <paramref name="count"/> has to be greater than <paramref name="min"/>
    /// </summary>
    /// <param name="count">Count to check</param>
    /// <param name="min">Reference value</param>
    public static void Greater(int count, int min)
    {
        if (count < min)
        {
            throw new ArgumentOutOfRangeException(nameof(count),
                "Value has to be greather than '" + min + "' but is '" + count + "'");
        }
    }
}
