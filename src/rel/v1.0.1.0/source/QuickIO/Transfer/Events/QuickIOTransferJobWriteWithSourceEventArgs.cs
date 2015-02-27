// <copyright file="QuickIOTransferWithSourceEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferWithSourceEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Abstract class for other event argument implementaions
    /// </summary>
    public abstract class QuickIOTransferJobWriteWithSourceEventArgs : QuickIOTransferJobWriteEventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobWriteWithSourceEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="sourcePath">Source path</param>
        /// <param name="targetPath">target path</param>
        protected QuickIOTransferJobWriteWithSourceEventArgs( IQuickIOTransferJob job, string sourcePath, string targetPath )
            : base( job, targetPath )
        {
            SourcePath = sourcePath;
        }

        /// <summary>
        /// Source file path
        /// </summary>
        public String SourcePath { get; private set; }
    }
}