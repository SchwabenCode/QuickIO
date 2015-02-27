// <copyright file="QuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides static methods for files and directories</summary>

using System;
using System.Collections.Generic;
using System.IO;
using SchwabenCode.QuickIO.Internal;


namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides static methods for files and directories.
    /// </summary>
    public static partial class QuickIO
    {
        /// <summary>
        /// Receives <see cref="QuickIODiskInformation"/> of specifies path
        /// </summary>
        /// <returns><see cref="QuickIODiskInformation"/></returns>
        /// <remarks>See http://support.microsoft.com/kb/231497</remarks>
        public static QuickIODiskInformation GetDiskInformation( String path )
        {
            return InternalQuickIO.GetDiskInformation( path );
        }
    }
}
