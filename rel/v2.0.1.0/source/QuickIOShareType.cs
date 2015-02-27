// <copyright file="QuickIOShareType.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/15/2014</date>
// <summary>QuickIOShareType</summary>

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Enum collection of available shares types
    /// </summary>
    public enum QuickIOShareType : uint
    {
        /// <summary>
        /// Disk or network share share
        /// </summary>
        Disk = 0,

        /// <summary>
        /// Printer share
        /// </summary>
        Printer = 1,

        /// <summary>
        /// Device share
        /// </summary>
        Device = 2,

        /// <summary>
        /// IPC share</summary>
        IPC = 2147483651,

        /// <summary>
        /// Special share
        /// </summary>
        Special = 2147483648
    }
}