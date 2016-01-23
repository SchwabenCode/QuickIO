// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Core
{
    /// <summary>
    /// Represents an exception for unsuuported drive types
    /// </summary>
    public class UnsupportedShareTypeException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="UnsupportedShareTypeException"/>
        /// </summary>
        /// <param name="path">Unsupported drive</param>
        /// <param name="message">Error</param>
        public UnsupportedShareTypeException( string path, String message )
            : base( message, path )
        {
        }
    }
}