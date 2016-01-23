// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Core
{
    /// <summary>
    /// Invalid Path Exception
    /// </summary>
    [Serializable]
    public class InvalidPathException : QuickIOBaseException
    {
        /// <summary>
        /// Invalid Path Exception
        /// </summary>
        /// <param name="path">Invalid Path</param>
        public InvalidPathException( string path )
            : base( "The filename, directory name, or volume label syntax is incorrect.", path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }
        /// <summary>
        /// Invalid Path Exception
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="path">Invalid Path</param>
        public InvalidPathException( string message, string path )
            : base( message, path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }
    }
}
