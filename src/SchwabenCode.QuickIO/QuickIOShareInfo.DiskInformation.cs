// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Engine;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOShareInfo
    {
        /// <summary>
        /// Returns <see cref="QuickIODiskInformation"/> of this instance.
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>Only supported for <see cref="QuickIOShareType.Disk"/></remarks>
        /// <exception cref="UnsupportedShareTypeException">Metadata not supported for this Sharetype. Only available for <see cref="QuickIOShareType.Disk"/></exception>
        public QuickIODiskInformation GetDiskInformation()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( FullName ) );
            Contract.Ensures( Contract.Result<QuickIODiskInformation>() != null );

            if( this.ShareType != QuickIOShareType.Disk )
            {
                throw new UnsupportedShareTypeException( "Metadata not supported for this Sharetype", this.FullName );
            }

            return QuickIOEngine.GetDiskInformation( this.FullName );
        }
    }
}