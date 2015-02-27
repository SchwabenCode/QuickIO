// <copyright file="QuickIOTransferFileCreationStartedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferFileCreationStartedEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains further information when a file creation process fails
    /// </summary>
    public class QuickIOTransferFileCreationErrorEventArgs : QuickIOTransferJobWriteEventArgs
    {
        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="QuickIOTransferFileCreationErrorEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Target file path</param>
        /// <param name="e">Exception</param>
        public QuickIOTransferFileCreationErrorEventArgs( IQuickIOTransferJob job, string targetPath, Exception e )
            : base( job, targetPath )
        {
            Exception = e;
        }
    }
}