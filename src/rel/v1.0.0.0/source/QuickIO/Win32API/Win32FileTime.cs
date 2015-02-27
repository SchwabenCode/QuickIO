// <copyright file="Win32FileTime.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/03/2014</date>
// <summary>Win32FileTime</summary>

using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// See http://www.pinvoke.net/default.aspx/Structures/FILETIME.html?diff=y
    /// Represents Win32 LongFileTime
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    internal struct Win32FileTime
    {
        public uint DateTimeLow;
        public uint DateTimeHigh;
    }
}