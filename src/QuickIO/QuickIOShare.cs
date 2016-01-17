// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.Internal;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides static methods to access network shares.
    /// </summary>
    public static partial class QuickIOShare
    {
        /// <summary>
        /// Receives <see cref="QuickIODiskInformation"/> of specifies share path
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
        public static QuickIODiskInformation GetDiskInformation( String sharePath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( sharePath ) );
            Contract.Ensures( Contract.Result<QuickIODiskInformation>() != null );

            return InternalQuickIO.GetDiskInformation( sharePath );
        }

    }
}
