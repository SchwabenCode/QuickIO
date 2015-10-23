// <copyright file="IQuickIOTransferJobContract.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2015 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>IQuickIOTransferJobContract</summary>

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Contract for <see cref="IQuickIOTransferJob"/>
    /// </summary>  
    [ContractClass( typeof( IQuickIOTransferJob ) )]
    [Browsable( false )]
    [EditorBrowsable( EditorBrowsableState.Never )]
    internal abstract class IQuickIOTransferJobContract : IQuickIOTransferJob
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
    }
}