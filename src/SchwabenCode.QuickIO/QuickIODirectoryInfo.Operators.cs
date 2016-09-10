// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System.IO;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryInfo
    {
        /// <summary>
        /// Returns a <see cref="DirectoryInfo"/> of the current path of this folder
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/></returns>
        public DirectoryInfo AsDirectoryInfo()
        {
            return new DirectoryInfo( base.FullName );
        }

        /// <summary>
        /// Explizit Cast
        /// </summary>
        /// <param name="directoryInfo"><see cref="DirectoryInfo"/></param>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public static explicit operator QuickIODirectoryInfo( DirectoryInfo directoryInfo )
        {
            return new QuickIODirectoryInfo( directoryInfo.FullName );
        }
    }
}
