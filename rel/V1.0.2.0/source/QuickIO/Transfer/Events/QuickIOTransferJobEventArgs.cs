// <copyright file="QuickIOTransferJobEventEventArgs.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>04/01/2014</date>
// <summary>QuickIOTransferJobEventEventArgs</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer.Events
{
    /// <summary>
    /// Abstract base class for job event arguments
    /// </summary>
    public abstract class QuickIOTransferJobEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        protected QuickIOTransferJobEventArgs( IQuickIOTransferJob job )
        {
            Job = job;
        }


        /// <summary>
        /// Target file path
        /// </summary>
        public IQuickIOTransferJob Job { get; private set; }
    }
}