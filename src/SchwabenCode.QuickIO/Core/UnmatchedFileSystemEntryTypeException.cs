// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Core
{
    /// <summary>
    /// Exception if path returns another type as excepted
    /// </summary>
    public sealed class UnmatchedFileSystemEntryTypeException : Exception
    {
        /// <summary>
        /// Expected Type
        /// </summary>
        public QuickIOFileSystemEntryType Expected { get; private set; }

        /// <summary>
        /// Type found
        /// </summary>
        public QuickIOFileSystemEntryType Found { get; private set; }

        /// <summary>
        /// Affected full path
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Exception if path returns another type as excepted
        /// </summary>
        public UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType expected, QuickIOFileSystemEntryType found, string path )
            : base( "FileSystemEntryType not matched!" )
        {
            Expected = expected;
            Found = found;
            Path = path;
        }
    }
}
