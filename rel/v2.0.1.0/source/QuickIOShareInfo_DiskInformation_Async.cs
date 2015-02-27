// <copyright file="QuickIOShareInfo_Metadata_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShareInfo_Metadata</summary>

#if NET40_OR_GREATER
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOShareInfo
    {
        /// <summary>
        /// Returns <see cref="QuickIODiskInformation"/> of this instance.
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>Only supported for <see cref="QuickIOShareType.Disk"/></remarks>
        /// <exception cref="UnsupportedShareType">Metadata not supported for this Sharetype. Only available for <see cref="QuickIOShareType.Disk"/></exception>
        public Task<QuickIODiskInformation> GetDiskInformationAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( GetDiskInformation );
        }
    }
}
#endif