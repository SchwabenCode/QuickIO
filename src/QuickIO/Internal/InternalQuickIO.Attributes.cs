namespace SchwabenCode.QuickIO.Internal;

/// <summary>
/// Provides internal helper methods for managing and manipulating <see cref="FileAttributes"/> in file operations.
/// </summary>
internal static partial class InternalQuickIO
{
    /// <summary>
    /// Adds or removes a specified <see cref="FileAttributes"/> from the source based on the existence flag.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to modify.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to add or remove.</param>
    /// <param name="existance">If true, the attribute will be added; if false, it will be removed.</param>
    /// <returns>The updated <see cref="FileAttributes"/> after modification.</returns>
    public static FileAttributes ForceFileAttributesExistance(FileAttributes source, FileAttributes attr, bool existance)
    {
        return existance ? AddFileAttrribute(source, attr) : RemoveFileAttribute(source, attr);
    }

    /// <summary>
    /// Tries to add or remove a specified <see cref="FileAttributes"/> from the source based on the existence flag.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to modify.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to add or remove.</param>
    /// <param name="existance">If true, the attribute will be added; if false, it will be removed.</param>
    /// <param name="updatedSource">The updated <see cref="FileAttributes"/> after modification.</param>
    /// <returns>True if the attributes were modified, false if no change was necessary.</returns>
    public static bool TryForceFileAttributesExistance(FileAttributes source, FileAttributes attr, bool existance, out FileAttributes updatedSource)
    {
        return existance ? TryAddFileAttrribute(source, attr, out updatedSource) : TryRemoveFileAttrribute(source, attr, out updatedSource);
    }

    /// <summary>
    /// Tries to add a specified <see cref="FileAttributes"/> to the source if it is not already present.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to modify.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to add.</param>
    /// <param name="updatedSource">The updated <see cref="FileAttributes"/> after modification.</param>
    /// <returns>True if the attribute was added, false if it was already present.</returns>
    public static bool TryAddFileAttrribute(FileAttributes source, FileAttributes attr, out FileAttributes updatedSource)
    {
        if (ContainsFileAttribute(source, attr))
        {
            updatedSource = source;
            return false;
        }

        updatedSource = AddFileAttrribute(source, attr);
        return true;
    }

    /// <summary>
    /// Adds a specified <see cref="FileAttributes"/> to the source.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to modify.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to add.</param>
    /// <returns>The updated <see cref="FileAttributes"/> after modification.</returns>
    public static FileAttributes AddFileAttrribute(FileAttributes source, FileAttributes attr)
    {
        source |= attr;
        return source;
    }

    /// <summary>
    /// Tries to remove a specified <see cref="FileAttributes"/> from the source if it is present.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to modify.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to remove.</param>
    /// <param name="updatedSource">The updated <see cref="FileAttributes"/> after modification.</param>
    /// <returns>True if the attribute was removed, false if it was not present.</returns>
    public static bool TryRemoveFileAttrribute(FileAttributes source, FileAttributes attr, out FileAttributes updatedSource)
    {
        if (!ContainsFileAttribute(source, attr))
        {
            updatedSource = source;
            return false;
        }

        updatedSource = RemoveFileAttribute(source, attr);
        return true;
    }

    /// <summary>
    /// Removes a specified <see cref="FileAttributes"/> from the source.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to modify.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to remove.</param>
    /// <returns>The updated <see cref="FileAttributes"/> after modification.</returns>
    public static FileAttributes RemoveFileAttribute(FileAttributes source, FileAttributes attr)
    {
        source &= ~attr;
        return source;
    }

    /// <summary>
    /// Determines whether the source contains a specified <see cref="FileAttributes"/>.
    /// </summary>
    /// <param name="source">The source <see cref="FileAttributes"/> to check.</param>
    /// <param name="attr">The <see cref="FileAttributes"/> to look for.</param>
    /// <returns>True if the source contains the specified attribute, false otherwise.</returns>
    public static bool ContainsFileAttribute(FileAttributes source, FileAttributes attr)
    {
        return (source & attr) != 0;
    }
}
