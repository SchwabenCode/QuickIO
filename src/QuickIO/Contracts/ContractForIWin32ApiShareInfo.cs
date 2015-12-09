﻿using SchwabenCode.QuickIO.Win32;
using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Contracts
{
    [ContractClassFor( typeof( IWin32ApiShareInfo ) )]
    public abstract class ContractForIWin32ApiShareInfo : IWin32ApiShareInfo
    {
        public string GetRemark()
        {
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
            return default( string );
        }

        public string GetShareName()
        {
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
            return default( string );
        }

        public QuickIOShareType GetShareType()
        {
            return default( QuickIOShareType );
        }
    }
}