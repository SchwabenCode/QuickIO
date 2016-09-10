using System;
using System.IO;

namespace SchwabenCode.QuickIO
{
    public static class FileAttributesExtensions
    {

        /// <summary>
        /// Removes a <see cref="FileAttributes"/> <paramref name="attrToRemove"/> to the existing collection <paramref name="source"/>.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attrToRemove">Attribute to remove</param>
        /// <returns><see cref="FileAttributes"/></returns>
        public static FileAttributes Remove(this FileAttributes source, FileAttributes attrToRemove)
        {
            FileAttributes updated = source &= ~attrToRemove;

            return updated;
        }

        /// <summary>
        /// Checks whether the given attribute in the collection is included.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to check</param>
        /// <returns>True if exists, false if not</returns>
        public static bool Contains(this FileAttributes source, FileAttributes attr)
        {
            return (source & attr) != 0;
        }

        /// <summary>
        /// Adds another <see cref="FileAttributes"/> <paramref name="attr"/> to the existing collection <paramref name="source"/>
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to add or remove</param>
        /// <param name="existance">true to add, false to remove</param>
        /// <returns><see cref="FileAttributes"/></returns>
        public static FileAttributes Force(this FileAttributes source, FileAttributes attr, bool existance)
        {
            return existance ? Add(source, attr) : Remove(source, attr);
        }

        /// <summary>
        /// Adds a <see cref="FileAttributes"/> <paramref name="attrToAdd"/> to the existing collection <paramref name="source"/>.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attrToAdd">Attribute to add</param>
        /// <returns><see cref="FileAttributes"/></returns>
        public static FileAttributes Add(this FileAttributes source, FileAttributes attrToAdd)
        {
            source |= attrToAdd;
            return source;
        }
    }
}
