// <copyright file="Win32ApiShareInfoAdmin.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/15/2014</date>
// <summary>Win32ApiShareInfoAdmin</summary>

using System;
using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Gets the complete share information. Requires admin priviles.
    /// </summary>
    /// <remarks>See http://msdn.microsoft.com/en-us/library/windows/desktop/bb525408(v=vs.85).aspx</remarks>
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
    internal struct Win32ApiShareInfoAdmin
    {
        [MarshalAs( UnmanagedType.LPWStr )]
        public String ShareName;
        public QuickIOShareType ShareType;
        [MarshalAs( UnmanagedType.LPWStr )]
        public String Remark;
        public Int32 Permissions;
        public Int32 MaxUsers;
        public Int32 CurrentUsers;
        [MarshalAs( UnmanagedType.LPWStr )]
        public String Path;
        [MarshalAs( UnmanagedType.LPWStr )]
        public String Password;
    }
}