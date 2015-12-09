// <copyright file="FileAlreadyExistsException.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/25/2014</date>
// <summary>his error is raised if a file should be created that already exists.</summary>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// This error is raised if a file should be created that already exists.
    /// </summary>   
    [Serializable]
    public class FileAlreadyExistsException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="FileAlreadyExistsException"/>
        /// </summary>
        /// <param name="path">Affected file path</param>
        public FileAlreadyExistsException( string path )
            : base( Win32ErrorCodes.FormatMessage( Win32ErrorCodes.ERROR_ALREADY_EXISTS ), path )
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

