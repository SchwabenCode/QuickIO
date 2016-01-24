// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.IO;

namespace SchwabenCode.QuickIO
{
    internal static class InternalHelpers
    {
        /// <summary>
        /// Adds a <see cref="FileAttributes"/> <paramref name="attr"/> to the existing collection <paramref name="source"/>.
        /// Returns true on add. False if the collection already contains that attribute.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to add</param>
        /// <param name="updatedSource">FileAttributes after update</param>
        /// <returns>True if attributes updated</returns>
        public static Boolean TryAddFileAttrribute( FileAttributes source, FileAttributes attr, out FileAttributes updatedSource )
        {
            if (ContainsFileAttribute(source, attr))
            {
                updatedSource = source;
                return false;
            }

            updatedSource = AddFileAttrribute( source, attr );
            return true;
        }

        /// <summary>
        /// Adds a <see cref="FileAttributes"/> <paramref name="attr"/> to the existing collection <paramref name="source"/>.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to add</param>
        /// <returns><see cref="FileAttributes"/></returns>
        public static FileAttributes AddFileAttrribute( FileAttributes source, FileAttributes attr )
        {
            source |= attr;
            return source;
        }

        /// <summary>
        /// Removes a <see cref="FileAttributes"/> <paramref name="attr"/> to the existing collection <paramref name="source"/>.
        /// Returns true on remove. False if the collection does not contain that attribute.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to remove</param>
        /// <param name="updatedSource">FileAttributes after update</param>
        /// <returns>True if attributes updated</returns>
        public static Boolean TryRemoveFileAttrribute( FileAttributes source, FileAttributes attr, out FileAttributes updatedSource )
        {
            if (!ContainsFileAttribute(source, attr))
            {
                updatedSource = source;
                return false;
            }

            updatedSource = RemoveFileAttribute( source, attr );
            return true;
        }

        /// <summary>
        /// Removes a <see cref="FileAttributes"/> <paramref name="attr"/> to the existing collection <paramref name="source"/>.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to remove</param>
        /// <returns><see cref="FileAttributes"/></returns>
        public static FileAttributes RemoveFileAttribute( FileAttributes source, FileAttributes attr )
        {
            source &= ~attr;
            return source;
        }

        /// <summary>
        /// Checks whether the given attribute in the collection is included.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to check</param>
        /// <returns>True if exists, false if not</returns>
        public static Boolean ContainsFileAttribute( FileAttributes source, FileAttributes attr )
        {
            return ( source & attr ) != 0;
        }
    }
}
