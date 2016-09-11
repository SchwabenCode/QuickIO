// <copyright file="QuickIOTransferFileCopyErrorEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCopyErrorEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains further information when a file copy process fails
    /// </summary>
    public class QuickIOTransferFileCopyErrorEventArgs : QuickIOTransferJobWriteWithSourceEventArgs
    {
        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferFileCopyErrorEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="source">Source file path</param>
        /// <param name="target">Target file path</param>
        /// <param name="e">Exception</param>
        public QuickIOTransferFileCopyErrorEventArgs( IQuickIOTransferJob job, string source, String target, Exception e )
            : base( job, source, target )
        {
            Exception = e;
        }
    }
}