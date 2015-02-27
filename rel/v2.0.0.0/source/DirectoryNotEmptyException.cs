// <copyright file="DirectoryNotEmptyException.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>This error is raised if a folder that is not empty should be deleted.</summary>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// This error is raised if a folder that is not empty should be deleted.
    /// </summary>
    [Serializable]
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
        }
    }
}
