// <copyright file="QuickIOShareInfo_Metadata.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShareInfo_Metadata</summary>

using SchwabenCode.QuickIO.Internal;
using System;
using System.Diagnostics.Contracts;

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

            if ( this.ShareType != QuickIOShareType.Disk )
            {
                throw new UnsupportedShareTypeException( this.FullName, "Metadata not supported for this Sharetype" );
            }

            return InternalQuickIO.GetDiskInformation( this.FullName );
        }
    }
}