// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// provides information for job run
    /// </summary>
    public class QuickIOTransferJobRunEventArgs : QuickIOTransferJobEventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJobRunEventArgs"/>
        /// </summary>
        /// <param name="job">Affected job</param>
        /// <param name="jobStart">Time of job start</param>
        public QuickIOTransferJobRunEventArgs( IQuickIOTransferJob job, DateTime jobStart )
            : base( job )
        {
            StartTime = jobStart;
        }

        /// <summary>
        /// Time of job start
        /// </summary>
        public DateTime StartTime { get; private set; }
    }
}