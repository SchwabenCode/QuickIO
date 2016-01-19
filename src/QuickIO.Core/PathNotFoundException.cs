// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Win32;

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
            : base( $"The system cannot find the path specified: '{path}'", path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }

        /// <summary>
        /// Exception if path does not exist.
        /// </summary>
        public PathNotFoundException( string message, string path )
            : base( message, path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }
    }
}
