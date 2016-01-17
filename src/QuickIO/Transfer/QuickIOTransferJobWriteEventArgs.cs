// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Abstract base class for file transfer event arguments
    /// </summary>
    public abstract class QuickIOTransferJobWriteEventArgs : QuickIOTransferJobEventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobWriteEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="targetPath">Target file path</param>
        protected QuickIOTransferJobWriteEventArgs( IQuickIOTransferJob job, string targetPath )
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