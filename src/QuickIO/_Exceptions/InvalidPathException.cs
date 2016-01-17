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
            : base( Win32ErrorCodes.FormatMessage( Win32ErrorCodes.ERROR_INVALID_NAME ), path )
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
