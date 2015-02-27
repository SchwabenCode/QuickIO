// <copyright file="InternalHelpers.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides several helper methods for internal usage only</summary>

using System;
using System.IO;

namespace SchwabenCode.QuickIO
{
    internal static class InternalHelpers
    {
        /// <summary>
        /// Adds another <see cref="FileAttributes"/> <paramref name="attr"/> to the existing collection <paramref name="source"/>
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to add or remove</param>
        /// <param name="existance">true to add, false to remove</param>
        /// <returns><see cref="FileAttributes"/></returns>
        public static FileAttributes ForceFileAttributesExistance( FileAttributes source, FileAttributes attr, bool existance )
        {
            return existance ? AddFileAttrribute( source, attr ) : RemoveFileAttribute( source, attr );
        }

        /// <summary>
        /// Checks whether an attribute is already in the collection; If not, it will be added.
        /// Returns true on add. False if the collection already contains that attribute.
        /// </summary>
        /// <param name="source"><see cref="FileAttributes"/> collection</param>
        /// <param name="attr">Attribute to add or remove</param>
        /// <param name="existance">true to add, false to remove</param>
        /// <param name="updatedSource">FileAttributes after update</param>
        /// <returns>True if the collection <paramref name="source"/> has been updated <paramref name="updatedSource"/>.</returns>
        public static Boolean TryForceFileAttributesExistance( FileAttributes source, FileAttributes attr, bool existance, out FileAttributes updatedSource )
        {
            return existance ? TryAddFileAttrribute( source, attr, out updatedSource ) : TryRemoveFileAttrribute( source, attr, out updatedSource );
        }

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
            if (ContainsFileAttribute(source, attr))
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
            source &= attr;
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
