namespace SchwabenCode.QuickIO.Internal;

/// <summary>
/// Several check methods to verify method parameters
/// </summary>
internal static class Invariant
{
    /// <summary>
    /// Returns the given name
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="item">Property Name</param>
    /// <returns>Property Name</returns>
    public static string GetName<T>(T item) where T : class
    {
        return typeof(T).GetProperties()[0].Name;
    }

    /// <summary>
    /// Checks if specified string element is null or emoty
    /// </summary>
    /// <param name="item">Element to check</param>
    /// <exception cref="ArgumentNullException"> if <paramref name="item"/>is null or empty</exception>
    public static void NotEmpty(string item)
    {
        if (string.IsNullOrEmpty(item))
        {
            throw new ArgumentNullException(typeof(string).GetProperties()[0].Name);
        }
    }

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
