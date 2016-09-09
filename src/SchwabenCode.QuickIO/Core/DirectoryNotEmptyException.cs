// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Core
{
    /// <summary>
    /// This error is raised if a folder that is not empty should be deleted.
    /// </summary>
    public class DirectoryNotEmptyException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="DirectoryNotEmptyException"/>
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="path">Affected directory path</param>
        public DirectoryNotEmptyException( string message, string path )
            : base( message, path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }
    }
}
