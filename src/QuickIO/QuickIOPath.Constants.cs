// <copyright file="QuickIOPath.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Performs operations for files or directories and path information</summary>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Performs operations for files or directories and path information. 
    /// </summary>
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Maximum allowed length of a regular path
        /// </summary>
        public const Int32 MaxRegularPathLength = 260;

        /// <summary>
        /// Max allowed path element name like folder names or file names
        /// </summary>
        public const int MaxPathElementLength = 255;

        /// <summary>
        /// Max allowed length of folder name
        /// </summary>
        public const int MaxFolderNameLength = MaxPathElementLength;
        /// <summary>
        /// Max allowed length of file name
        /// </summary>
        public const int MaxFileNameLength = MaxPathElementLength;

        /// <summary>
        /// Maximum allowed length of a regular folder path
        /// </summary>
        public const Int32 MaxSimpleDirectoryPathLength = 247;

        /// <summary>
        /// Maximum allowed length of an UNC Path
        /// </summary>
        public const Int32 MaxUncPathLength = 32767;

        /// <summary>
        /// Regular local path prefix
        /// </summary>
        public const String RegularLocalPathPrefix = @"";

        /// <summary>
        /// Path prefix for shares
        /// </summary>
        public const String RegularSharePathPrefix = @"\\";

        /// <summary>
        /// Length of Path prefix for shares
        /// </summary>
        public static readonly Int32 RegularSharePathPrefixLength = RegularSharePathPrefix.Length;

        /// <summary>
        /// UNC prefix for regular paths
        /// </summary>
        public const String UncLocalPathPrefix = @"\\?\";

        /// <summary>
        /// UNC prefix for shares
        /// </summary>
        public const String UncSharePathPrefix = @"\\?\UNC\";

        /// <summary>
        /// Directory Separator Char
        /// </summary>
        public static char DirectorySeparatorChar = System.IO.Path.DirectorySeparatorChar;
        /// <summary>
        /// WhiteSpace = ' '
        /// </summary>
        public static char WhiteSpace = ' ';
    }
}
