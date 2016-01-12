// <copyright file="QuickIOShare_Enumerate.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/04/2014</date>
// <summary>QuickIOShare</summary>

using System;
using System.Collections.Generic;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOShare
    {
        /// <summary>
        /// Enumerate shares of specific machine. If no machine is specified, local machine is used
        /// </summary>
        /// <returns>Collection of <see cref="QuickIOShareInfo"/></returns>
        public static IEnumerable<QuickIOShareInfo> EnumerateShares( String machineName = null, QuickIOShareApiReadLevel level = QuickIOShareApiReadLevel.Admin )
        {
            Contract.Ensures( Contract.Result<IEnumerable<QuickIOShareInfo>>() != null );

            Type shareType = ( level == QuickIOShareApiReadLevel.Admin ) ? typeof( Win32ApiShareInfoAdmin ) : typeof( Win32ApiShareInfoNormal );
            switch( level )
            {
                case QuickIOShareApiReadLevel.Admin:
                    return InternalQuickIO.EnumerateShares<Win32ApiShareInfoAdmin>( QuickIOShareApiReadLevel.Admin, machineName );
                case QuickIOShareApiReadLevel.Normal:
                    return InternalQuickIO.EnumerateShares<Win32ApiShareInfoNormal>( QuickIOShareApiReadLevel.Normal, machineName );
                default:
                    throw new NotSupportedException( $"Unsupported level '{level}'" );
            }
        }
    }
}
