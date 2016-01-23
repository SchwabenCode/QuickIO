// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Win32
{
    public interface IWin32ApiShareInfo
    {
        /// <summary>
        /// Returns the share name
        /// </summary>
        String GetShareName();

        /// <summary>
        /// Returns the share name
        /// </summary>
        QuickIOShareType GetShareType();

        /// <summary>
        /// Returns the remark
        /// </summary>
        String GetRemark();
    }
}
