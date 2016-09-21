// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System.Runtime.InteropServices;

namespace SchwabenCode.QuickIO.Win32
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