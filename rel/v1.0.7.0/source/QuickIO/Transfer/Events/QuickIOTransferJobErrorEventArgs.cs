// <copyright file="QuickIOTransferJobErrorEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>04/01/2014</date>
// <summary>QuickIOTransferJobErrorEventArgs</summary>

using System;


namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// provides information for job error
    /// </summary>
    public class QuickIOTransferJobErrorEventArgs : QuickIOTransferJobEventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobErrorEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="e">Exception</param>
        public QuickIOTransferJobErrorEventArgs( IQuickIOTransferJob job, Exception e )
            : base( job )
        {
            Exception = e;
        }

        /// <summary>
        /// Error
        /// </summary>
        public Exception Exception { get; private set; }
    }
}