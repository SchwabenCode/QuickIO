// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using SchwabenCode.QuickIO.Win32;
using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Contracts
{
    /// <summary>
    /// Contracts for <see cref="ContractForIWin32ApiShareInfo"/>
    /// </summary>
    [ContractClassFor( typeof( IWin32ApiShareInfo ) )]
    public abstract class ContractForIWin32ApiShareInfo : IWin32ApiShareInfo
    {
        /// <summary>
        /// Contract for <see cref="GetRemark"/>
        /// </summary>
        public string GetRemark()
        {
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
            return default( string );
        }

        /// <summary>
        /// Contract for <see cref="GetShareName"/>
        /// </summary>
        public string GetShareName()
        {
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
            return default( string );
        }

        /// <summary>
        /// Contract for <see cref="GetShareType"/>
        /// </summary>
        public QuickIOShareType GetShareType()
        {
            return default( QuickIOShareType );
        }
    }
}
