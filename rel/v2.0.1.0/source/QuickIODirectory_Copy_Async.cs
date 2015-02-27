// <copyright file="QuickIODirectory_Copy.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>Provides properties and instance methods for copy</summary>

#if NET40_OR_GREATER
using SchwabenCode.QuickIO.Internal;

using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;
namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        public static Task CopyAsync( String source, String target, bool overwrite = false )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => Copy( source, target, overwrite ) );
        }

        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        public static Task CopyAsync( QuickIODirectoryInfo source, QuickIOPathInfo target, bool overwrite = false )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => Copy( source, target, overwrite ) );
        }

    }
}
#endif