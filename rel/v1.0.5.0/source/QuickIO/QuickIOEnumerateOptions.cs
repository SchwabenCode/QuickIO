// <copyright file="QuickIOEnumerateOptions.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>04/10/2014</date>
// <summary>Provides properties and instance methods for directories</summary>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Options for enumerations
    /// </summary>
    [Flags]
    public enum QuickIOEnumerateOptions
    {
        /// <summary>
        /// No options
        /// </summary>
        None,
        /// <summary>
        /// Suppresses all exceptions
        /// </summary>
        SuppressAllExceptions
        
    }
}