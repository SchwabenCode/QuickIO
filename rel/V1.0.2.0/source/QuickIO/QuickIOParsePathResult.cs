// <copyright file="QuickIOParsePathResult.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOParsePathResult</summary>
using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Result of parsing path
    /// </summary>
    public class QuickIOParsePathResult
    {
        /// <summary>
        /// Full root path
        /// </summary>
        /// <example><b>C:\folder\parent\file.txt</b> returns <b>C:\</b></example>
        /// <remarks>Returns null if source path is Root</remarks>
        public String RootPath { get; internal set; }

        /// <summary>
        /// Full parent path
        /// </summary>
        /// <example><b>C:\folder\parent\file.txt</b> returns <b>C:\folder\parent</b></example>
        /// <remarks>Returns null if source path is Root</remarks>
        public String ParentPath { get; internal set; }

        /// <summary>
        /// Name of file oder directory
        /// </summary>
        /// <example><b>C:\folder\parent\file.txt</b> returns <b>file.txt</b></example>
        /// <example><b>C:\folder\parent</b> returns <b>parent</b></example>
        /// <remarks>Returns null if source path is Root</remarks>
        public String Name { get; internal set; }

        /// <summary>
        /// True if source path is root
        /// </summary>
        public Boolean IsRoot { get; internal set; }

        /// <summary>
        /// Full path without trailing directory separtor char
        /// </summary>
        public String FullName { get; internal set; }

        /// <summary>
        /// Full UNC path without trailing directory separtor char
        /// </summary>
        public string FullNameUnc { get; internal set; }

        /// <summary>
        /// <see cref="QuickIOPathType"/>
        /// </summary>
        public QuickIOPathType PathType { get; internal set; }

        /// <summary>
        /// <see cref="QuickIOPathLocation"/>
        /// </summary>
        public QuickIOPathLocation PathLocation { get; internal set; }

    }
}