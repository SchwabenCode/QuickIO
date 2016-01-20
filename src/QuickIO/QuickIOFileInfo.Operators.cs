﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System.IO;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Returns a <see cref="FileInfo"/> of the current path of this file
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/></returns>
        public FileInfo AsFileInfo()
        {
            return new FileInfo( base.FullName );
        }

        /// <summary>
        /// Explizit Cast
        /// </summary>
        /// <param name="fileInfo"><see cref="QuickIOFileInfo"/></param>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public static explicit operator QuickIOFileInfo( FileInfo fileInfo )
        {
            return new QuickIOFileInfo( fileInfo );
        }
    }
}
