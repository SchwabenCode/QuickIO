// <copyright file="QuickIODirectoryInfo_Operators_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for directories</summary>
#if NET40_OR_GREATER

using System.IO;
using SchwabenCode.QuickIO.Compatibility;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryInfo
    {
        /// <summary>
        /// Returns a <see cref="DirectoryInfo"/> of the current path of this folder
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/></returns>
        public Task<DirectoryInfo> AsDirectoryInfoAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( AsDirectoryInfo );
        }
    }
}
#endif