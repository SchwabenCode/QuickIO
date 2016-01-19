// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Contains information of an upcoming directory creation operation
    /// </summary>
    public class QuickIOTransferDirectoryCreatingEventArgs : QuickIOTransferJobEventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferDirectoryCreatingEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Directory fullname to create</param>
        public QuickIOTransferDirectoryCreatingEventArgs( IQuickIOTransferJob job, string targetPath )
            : base( job )
        {
            TargetPath = targetPath;
        }

        /// <summary>
        /// Target file path
        /// </summary>
        public String TargetPath { get; private set; }
    }
}