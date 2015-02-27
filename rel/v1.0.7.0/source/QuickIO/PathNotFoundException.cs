// <copyright file="PathNotFoundException.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>PathNotFoundException</summary>

using System;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Exception if path does not exist.
    /// </summary>
    [Serializable]
    public class PathNotFoundException : QuickIOBaseException
    {
        /// <summary>
        /// Exception if path does not exist.
        /// </summary>
        public PathNotFoundException( string path )
            : base( Win32ErrorCodes.FormatMessage( Win32ErrorCodes.ERROR_PATH_NOT_FOUND ), path )
        {
        }

        /// <summary>
        /// Exception if path does not exist.
        /// </summary>
        public PathNotFoundException( string message, string path )
            : base( message, path )
        {
        }
    }
}
