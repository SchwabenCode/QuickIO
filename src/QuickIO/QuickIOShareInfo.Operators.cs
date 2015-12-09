// <copyright file="QuickIOShareInfo_Operators.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShareInfo</summary>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOShareInfo
    {
        /// <summary>
        /// Returns a <see cref="QuickIODirectoryInfo"/> of the current path of this file
        /// </summary>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public QuickIODirectoryInfo AsDirectoryInfo()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( FullName ) );
            Contract.Ensures( Contract.Result<QuickIODirectoryInfo>() != null );

            return new QuickIODirectoryInfo( FullName );
        }
    }
}