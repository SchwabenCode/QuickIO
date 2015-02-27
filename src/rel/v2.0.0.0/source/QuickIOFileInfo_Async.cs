// <copyright file="QuickIOFileInfo_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>
#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {

        /// <summary>
        /// Returns true if file exists. Uncached.
        /// </summary>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a directory.</exception>
        public override Task<Boolean> ExistsAsync
        {
            get
            {
                return QuickIOFile.ExistsAsync( this );
            }
        }

    }
}
#endif