// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Core
{
    /// <summary>
    /// Exception of already running transfer activity
    /// </summary>
    public class QuickIOTransferAlreadyRunningException : Exception
    {
        /// <summary>
        /// Creates a new exception of <see cref="QuickIOTransferAlreadyRunningException"/>
        /// </summary>
        /// <param name="message">The error message</param>
        public QuickIOTransferAlreadyRunningException( string message ) : base( message )
        {

        }
    }
}
