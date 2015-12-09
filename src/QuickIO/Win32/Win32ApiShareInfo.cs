using SchwabenCode.QuickIO.Contracts;
using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Win32
{
    [ContractClass( typeof( ContractForIWin32ApiShareInfo ) )]
    internal interface IWin32ApiShareInfo
    {
        /// <summary>
        /// Returns the share name
        /// </summary>
        String GetShareName();

        /// <summary>
        /// Returns the share name
        /// </summary>
        QuickIOShareType GetShareType();

        /// <summary>
        /// Returns the remark
        /// </summary>
        String GetRemark();
    }
}
