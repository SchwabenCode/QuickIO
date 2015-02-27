// <copyright file="QuickIOShare.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShare</summary>

using System;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides static methods to access network shares.
    /// </summary>
    public static partial class QuickIOShare
    {
        /// <summary>
        /// Checks the given share for admin information
        /// </summary>
        /// <param name="serverName">Sharename</param>
        /// <param name="item">Share reference</param>
        /// <returns><see cref="QuickIOShareInfo"/></returns>
        internal static QuickIOShareInfo GetShareInfoWithAdminInformation( String serverName, IntPtr item )
        {
            var shareInfo = ( Win32ApiShareInfoAdmin ) Marshal.PtrToStructure( item, typeof( Win32ApiShareInfoAdmin ) );
            return new QuickIOShareInfo( serverName, shareInfo.ShareName, shareInfo.ShareType, shareInfo.Remark );
        }

        /// <summary>
        /// Checks the given share for normal user information
        /// </summary>
        /// <param name="serverName">Sharename</param>
        /// <param name="item">Share reference</param>
        /// <returns><see cref="QuickIOShareInfo"/></returns>
        internal static QuickIOShareInfo GetShareInfoWithNormalInformation( String serverName, IntPtr item )
        {
            var shareInfo = ( Win32ApiShareInfoNormal ) Marshal.PtrToStructure( item, typeof( Win32ApiShareInfoNormal ) );
            return new QuickIOShareInfo( serverName, shareInfo.ShareName, shareInfo.ShareType, shareInfo.Remark );
        }
    }
}
