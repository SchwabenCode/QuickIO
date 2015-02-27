// <copyright file="QuickIOShare_DiskInformation.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShare_DiskInformation</summary>

using System;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOShare
    {
        /// <summary>
        /// Receives <see cref="QuickIODiskInformation"/> of specifies share path
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
        public static QuickIODiskInformation GetDiskInformation( String sharePath )
        {
            return InternalQuickIO.GetDiskInformation( sharePath );
        }
    }
}
