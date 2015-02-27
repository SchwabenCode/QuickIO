// <copyright file="QuickIOShare_Enumerate_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/04/2014</date>
// <summary>QuickIOShare</summary>

#if NET40_OR_GREATER
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOShare
    {
        /// <summary>
        /// Enumerate shares of specific machine. If no machine is specified, local machine is used
        /// </summary>
        /// <returns>Collection of <see cref="QuickIOShareInfo"/></returns>
        public static Task<IEnumerable<QuickIOShareInfo>> EnumerateSharesAsync( String machineName = null, QuickIOShareApiReadLevel level = QuickIOShareApiReadLevel.Admin )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => EnumerateShares( machineName, level ) );
        }
    }
}
#endif