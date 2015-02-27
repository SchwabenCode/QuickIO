// <copyright file="QuickIODirectoryInfo_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>Provides properties and instance methods for directories</summary>

#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;


namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides properties and instance methods for directories
    /// </summary>
    public sealed partial class QuickIODirectoryInfo
    {

        /// <summary>
        /// Returns true if directory exists. Result starts a file system call and is not cached.
        /// </summary>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a file..</exception>
        public override Task<Boolean> ExistsAsync
        {
            get
            {
                return QuickIODirectory.ExistsAsync( this );
            }
        }
    }
}
#endif