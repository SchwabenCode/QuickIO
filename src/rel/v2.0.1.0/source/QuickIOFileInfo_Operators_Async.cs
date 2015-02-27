// <copyright file="QuickIOFileInfo_Operators_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

#if NET40_OR_GREATER
using System.IO;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Returns a <see cref="FileInfo"/> of the current path of this file
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/></returns>
        public Task<FileInfo> AsFileInfoAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( AsFileInfo );
        }
    }
}
#endif