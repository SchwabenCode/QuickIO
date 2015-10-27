// <copyright file="QuickIODirectoryInfo_Metadata.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectoryInfo_EnumerationsQuickIODirectoryInfo_Metadata</summary>
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectoryInfo
    {        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current file
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public QuickIODirectoryMetadata GetMetadata( QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            return InternalQuickIO.EnumerateDirectoryMetadata( FullNameUnc, FindData, enumerateOptions );
        }
    }
}
