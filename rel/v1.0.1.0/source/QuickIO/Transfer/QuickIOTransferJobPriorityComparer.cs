// <copyright file="QuickIOTransferJobPriorityComparer.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferJobPriorityComparer</summary>

using System.Collections.Generic;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Job Priority Implementation
    /// </summary>
    internal class QuickIOTransferJobPriorityComparer : IComparer<IQuickIOTransferJob>
    {
        /// <summary>
        /// Comparer Implementation - descending
        /// </summary>
        /// <param name="leftJob">Left Job</param>
        /// <param name="rightJob">Right Job</param>
        /// <returns>Higher Prio</returns>
        public int Compare( IQuickIOTransferJob leftJob, IQuickIOTransferJob rightJob )
        {
            if ( leftJob == null )// cancellation token
            {
                return 1;
            }
            if ( rightJob == null )// cancellation token
            {
                return -1;
            }

            if ( leftJob.PriorityLevel < rightJob.PriorityLevel )
            {
                return 1;
            }

            if ( leftJob.PriorityLevel > rightJob.PriorityLevel )
            {
                return -1;
            }

            return 0;
        }
    }
}