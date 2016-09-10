// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents a file system entry type
    /// </summary>
    public class QuickIOFileSystemEntry
    {
        /// <summary>
        /// Creates an instance of <see cref = "QuickIOFileSystemEntry"/>
        /// </summary>
        internal QuickIOFileSystemEntry( string path, QuickIOFileSystemEntryType type, FileAttributes  attributes, ulong bytes)
        {
            Contract.Requires( !string.IsNullOrWhiteSpace( path ) );
            Path = path;
            Type = type;
            Attributes = attributes;
            Bytes = bytes;
        }

        /// <summary>
        /// Entry's fullname
        /// </summary>
        public String Path { get; }

        /// <summary>
        /// Returns <see cref="Path"/> in unc.
        /// </summary>
        /// <returns></returns>
        public String GetPathUnc()
        {
            return QuickIOPath.ToPathUnc(Path);
        }

        /// <summary>
        /// Returns <see cref="Path"/> in regular.
        /// </summary>
        /// <returns></returns>
        public String GetPathRegular()
        {
            return QuickIOPath.ToPathRegular( Path );
        }

        /// <summary>
        /// Entry type
        /// </summary>
        public QuickIOFileSystemEntryType Type { get; }

        /// <summary>
        /// Entry type
        /// </summary>
        public FileAttributes Attributes { get; }        /// <summary>
                                                         /// Entry type
                                                         /// </summary>
        public ulong Bytes { get; }
    }
}