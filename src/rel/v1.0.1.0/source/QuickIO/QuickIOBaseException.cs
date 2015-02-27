// <copyright file="FileIOBaseException.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/25/2014</date>
// <summary>QuickIOBaseException</summary>

using System;
using System.ComponentModel;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Abstract base class for exceptions
    /// </summary>
    [Browsable( false )]
    [EditorBrowsable( EditorBrowsableState.Never )]
    public abstract class QuickIOBaseException : Exception
    {
        /// <summary>
        /// Affected Path
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Abstract base class for exceptions
        /// </summary>
        protected QuickIOBaseException( String message, string path )
            : base( message )
        {
            this.Path = path;
        }

        /// <summary>
        /// Abstract base class for exceptions
        /// </summary>
        protected QuickIOBaseException( String message, string path, Exception innerException )
            : base( message, innerException )
        {
            this.Path = path;
        }
    }
}