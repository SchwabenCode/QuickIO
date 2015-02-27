// <copyright file="QuickIOShareInfo_Operators_async.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShareInfo</summary>

#if NET40_OR_GREATER
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOShareInfo
    {
        /// <summary>
        /// Returns a <see cref="QuickIODirectoryInfo"/> of the current path of this file
        /// </summary>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public Task<QuickIODirectoryInfo> AsDirectoryInfoAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( AsDirectoryInfo );
        }
    }
}
#endif