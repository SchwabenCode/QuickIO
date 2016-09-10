// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// This error is raised if a file should be created that already exists.
    /// </summary>   
    public class FileAlreadyExistsException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="FileAlreadyExistsException"/>
        /// </summary>
        /// <param name="path">Affected file path</param>
        public FileAlreadyExistsException( string path )
            : base( "Cannot create a file when that file already exists.", path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }

        /// <summary>
        /// Creates an instance of <see cref="FileAlreadyExistsException"/>
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="path">Affected file path</param>
        public FileAlreadyExistsException( string message, string path )
            : base( message, path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }
    }
}

