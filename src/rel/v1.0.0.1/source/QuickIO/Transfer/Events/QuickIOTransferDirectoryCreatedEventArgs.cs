// <copyright file="QuickIOTransferDirectoryCreatedEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferDirectoryCreatedEventArgs</summary>

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Contains information after a directory create operation was performed
    /// </summary>
    public class QuickIOTransferDirectoryCreatedEventArgs : QuickIOTransferJobEventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferDirectoryCreatedEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Directory fullname that was created</param>
        public QuickIOTransferDirectoryCreatedEventArgs( IQuickIOTransferJob job, string targetPath )
            : base( job )
        {
            TargetPath = targetPath;
        }

        /// <summary>
        /// Target path
        /// </summary>
        public string TargetPath { get; private set; }
    }
}