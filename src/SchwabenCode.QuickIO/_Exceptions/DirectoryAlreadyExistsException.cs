// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// This error is raised if you want to create for example a folder which already exists.
    /// </summary>
    public class DirectoryAlreadyExistsException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="DirectoryAlreadyExistsException"/>
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="path">Affected directory path</param>
        public DirectoryAlreadyExistsException( string message, string path )
            : base( message, path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

        }
    }
}
