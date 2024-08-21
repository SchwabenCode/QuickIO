namespace SchwabenCode.QuickIO.Internal;

/// <summary>
/// Provides static methods for validating invariants and conditions in code.
/// </summary>
internal static class Invariant
{
    /// <summary>
    /// Ensures that a given value is greater than a specified minimum value.
    /// </summary>
    /// <param name="count">The value to check.</param>
    /// <param name="min">The minimum acceptable value.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="count"/> is less than <paramref name="min"/>.
    /// </exception>
    public static void Greater(int count, int min)
    {
        if (count < min)
        {
            throw new ArgumentOutOfRangeException(nameof(count),
                "Value has to be greater than '" + min + "' but is '" + count + "'");
        }
    }
}
