// <copyright file="QuickIODirectoryMetadata_Async.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectoryMetadata</summary>
#if NET40_OR_GREATER

using System.IO;
using SchwabenCode.QuickIO.Compatibility;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryMetadata
    {
        /// <summary>
        /// Returns a new instance of <see cref="QuickIODirectoryInfo"/> of the current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public Task<QuickIODirectoryInfo> ToDirectoryInfoAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ToDirectoryInfo );
        }
    }
}
#endif