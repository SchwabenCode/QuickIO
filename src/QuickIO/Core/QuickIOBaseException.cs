// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

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
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            this.Path = path;
        }

        /// <summary>
        /// Abstract base class for exceptions
        /// </summary>
        protected QuickIOBaseException( String message, string path, Exception innerException )
            : base( message, innerException )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( message ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            this.Path = path;
        }
    }
}