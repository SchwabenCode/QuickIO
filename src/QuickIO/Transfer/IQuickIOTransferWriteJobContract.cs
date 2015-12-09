// <copyright file="IQuickIOTransferWriteJobContract.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>IQuickIOTransferWriteJobContract</summary>

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Contract implementation
    /// </summary>
    [ContractClass( typeof( IQuickIOTransferObserver ) )]
    [Browsable( false )]
    [EditorBrowsable( EditorBrowsableState.Never )]
    public abstract class IQuickIOTransferWriteJobContract : IQuickIOTransferWriteJob
    {
        private CancellationToken _token;
        private IQuickIOTransferObserver _observer;

        public CancellationToken Token
        {
            get
            {
                Contract.Ensures( Contract.Result<CancellationToken>( ) != null );
                return _token;
            }
            private set
            {
                Contract.Requires( value != null );
                _token = value;
            }
        }

        public IQuickIOTransferObserver Observer
        {
            get
            {
                Contract.Ensures( Contract.Result<IQuickIOTransferObserver>( ) != null );
                return _observer;
            }
            private set
            {
                Contract.Requires( value != null );
                _observer = value;
            }
        }

        public int CurrentRetryCount { get; set; }
        public int PriorityLevel { get; set; }
        public void Run( )
        {
            throw new NotImplementedException( );
        }

        public Task RunAsync( )
        {
            Contract.Ensures( Contract.Result<Task>( ) != null );
            return default( Task );
        }

        public int MaxBufferSize { get; set; }
        public bool ParentExistanceCheck { get; private set; }
        public bool Overwrite { get; set; }
    }
}