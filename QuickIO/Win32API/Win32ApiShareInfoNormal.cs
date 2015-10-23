// <copyright file="Win32ApiShareInfoNormal.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/15/2014</date>
// <summary>Win32ApiShareInfoNormal</summary>

using System;
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Use this Info bag if call with admin privilegs fails (fallback)
    /// </summary>
    /// <remarks>See http://msdn.microsoft.com/en-us/library/windows/desktop/bb525407(v=vs.85).aspx</remarks>
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
    internal struct Win32ApiShareInfoNormal
    {
        [MarshalAs( UnmanagedType.LPWStr )]
        public String ShareName;
        public QuickIOShareType ShareType;
        [MarshalAs( UnmanagedType.LPWStr )]
        public String Remark;
    }
}