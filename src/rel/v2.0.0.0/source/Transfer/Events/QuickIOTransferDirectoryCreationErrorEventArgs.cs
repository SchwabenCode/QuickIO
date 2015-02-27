// <copyright file="QuickIOTransferDirectoryCreationErrorEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferDirectoryCreationErrorEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains further information when a directory creation process fails
    /// </summary>
    public class QuickIOTransferDirectoryCreationErrorEventArgs : QuickIOTransferJobWriteEventArgs
    {
        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferFileCopyErrorEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="target">Target path</param>
        /// <param name="e">Exception</param>
        public QuickIOTransferDirectoryCreationErrorEventArgs( IQuickIOTransferJob job, string target, Exception e )
            : base( job, target )
        {
            Exception = e;
        }
    }
}