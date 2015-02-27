// <copyright file="QuickIOTransferJobWriteJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferJobWriteJob</summary>

using System;
using System.ComponentModel;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Base class for transfer write jobs
    /// </summary>
    [Browsable( false )]
    [EditorBrowsable( EditorBrowsableState.Never )]
    public abstract class QuickIOTransferJobWriteJob : QuickIOTransferJob, IQuickIOTransferWriteJob
    {
        private volatile int _maxBufferSize;
        private volatile bool _parentExistanceCheck;
        private volatile bool _overwrite;

        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJob"/>
        /// </summary>
        /// <param name="observer">Observer for file monitoring by service</param>
        /// <param name="priorityLevel">Default priority</param>
        /// <param name="overwrite">true to overwrite existing elements</param>
        /// <remarks>Thread-safe</remarks>
        protected QuickIOTransferJobWriteJob( IQuickIOTransferObserver observer, Int32 priorityLevel = 0, Boolean overwrite = false )
        {
            Observer = observer;
            _overwrite = overwrite;
        }

        /// <summary>
        /// Creates a new instance of <see cref="QuickIOTransferJob"/>
        /// </summary>
        /// <param name="priorityLevel">Default priority</param>
        /// <param name="overwrite">true to overwrite existing elements</param>
        /// <remarks>Thread-safe</remarks>
        protected QuickIOTransferJobWriteJob( Int32 priorityLevel = 0, Boolean overwrite = false )
            : this( null, priorityLevel, overwrite )
        {

        }

        /// <summary>
        /// True to overwrite existing elements
        /// </summary>
        public bool Overwrite
        {
            get { return _overwrite; }
            set { _overwrite = value; }
        }

        /// <summary>
        /// Max Buffer Size for Transfer
        /// </summary>
        public Int32 MaxBufferSize
        {
            get { return _maxBufferSize; }
            set { _maxBufferSize = value; }
        }

        /// <summary>
        /// True to check parent folder existance. False is much faster, but you have to be sure that the parent exists.
        /// </summary>
        public bool ParentExistanceCheck
        {
            get { return _parentExistanceCheck; }
            protected set { _parentExistanceCheck = value; }
        }

    }
}