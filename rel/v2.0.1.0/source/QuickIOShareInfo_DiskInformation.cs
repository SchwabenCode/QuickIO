// <copyright file="QuickIOShareInfo_Metadata.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/29/2014</date>
// <summary>QuickIOShareInfo_Metadata</summary>

using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOShareInfo
    {
        /// <summary>
        /// Returns <see cref="QuickIODiskInformation"/> of this instance.
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>Only supported for <see cref="QuickIOShareType.Disk"/></remarks>
        /// <exception cref="UnsupportedShareType">Metadata not supported for this Sharetype. Only available for <see cref="QuickIOShareType.Disk"/></exception>
        public QuickIODiskInformation GetDiskInformation()
        {
            if ( this.ShareType != QuickIOShareType.Disk )
            {
                throw new UnsupportedShareType( this.FullName, "Metadata not supported for this Sharetype" );
            }

            return InternalQuickIO.GetDiskInformation( this.FullName );
        }
    }
}