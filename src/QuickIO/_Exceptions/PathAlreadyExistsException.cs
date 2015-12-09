// <copyright file="PathAlreadyExistsException.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>PathAlreadyExistsException</summary>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Exception if path does not exist.
    /// </summary>
    [Serializable]
    public class PathAlreadyExistsException : QuickIOBaseException
    {
        /// <summary>
        /// Exception if path does not exist.
        /// </summary>
        public PathAlreadyExistsException( string message, string path )
            : base( message, path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }
    }
}
