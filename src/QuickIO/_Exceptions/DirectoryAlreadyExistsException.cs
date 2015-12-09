// <copyright file="DirectoryAlreadyExistsException.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>This error is raised if you want to create for example a folder which already exists.</summary>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// This error is raised if you want to create for example a folder which already exists.
    /// </summary>
    [Serializable]
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
