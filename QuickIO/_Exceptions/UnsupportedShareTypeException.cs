// <copyright file="UnsupportedShareType.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>UnsupportedShareType</summary>
using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents an exception for unsuuported drive types
    /// </summary>
    public class UnsupportedShareTypeException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="SchwabenCode.QuickIO.UnsupportedShareTypeException"/>
        /// </summary>
        /// <param name="path">Unsupported drive</param>
        /// <param name="message">Error</param>
        public UnsupportedShareTypeException( string path, String message )
            : base( message, path )
        {
        }
    }
}