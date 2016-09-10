// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using SchwabenCode.QuickIO.Engine;

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
            return QuickIOEngine.Exists( path );
        }
    }
}
