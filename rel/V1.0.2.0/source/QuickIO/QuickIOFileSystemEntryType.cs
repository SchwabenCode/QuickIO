// <copyright file="QuickIOFileSystemEntryType.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/13/2014</date>
// <summary>Represents type of path or handle</summary>

using System.IO;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents type of path or handle
    /// </summary>
    public enum QuickIOFileSystemEntryType
    {
        /// <summary>
        /// Represents a file (<see cref="FileAttributes"/> does not contain directory flag)
        /// </summary>
        File = 0,

        /// <summary>
        /// Represents a directory (<see cref="FileAttributes"/>contains directory flag)
        /// </summary>
        Directory = 1
    }
}
