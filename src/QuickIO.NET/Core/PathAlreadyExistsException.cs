// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Core
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
