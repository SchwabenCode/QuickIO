// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

namespace SchwabenCode.QuickIO.Transfer
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