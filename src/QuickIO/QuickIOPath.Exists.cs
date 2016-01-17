﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.IO;
using System.Net.Mail;
using SchwabenCode.QuickIO.Internal;
using System.Diagnostics.Contracts;
using System.Diagnostics;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Checks if path exists
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns>True on exists</returns>
        public static Boolean Exists( String path )
        {
            return InternalQuickIO.Exists( path );
        }
    }
}
