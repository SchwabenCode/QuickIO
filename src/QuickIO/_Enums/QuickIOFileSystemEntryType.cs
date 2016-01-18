// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents type of path or handle
    /// </summary>
    public enum QuickIOFileSystemEntryType
    {
        /// <summary>
        /// Represents a file (<see cref="System.IO.FileAttributes"/> does not contain directory flag)
        /// </summary>
        File = 0,

        /// <summary>
        /// Represents a directory (<see cref="System.IO.FileAttributes"/>contains directory flag)
        /// </summary>
        Directory = 1
    }
}
