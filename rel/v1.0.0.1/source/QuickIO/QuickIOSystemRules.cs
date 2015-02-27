// <copyright file="QuickIOSystemRules.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/03/2014</date>
// <summary>QuickIOSystemRules</summary>

using System.Text;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// QuickIOSystemRules
    /// </summary>
    internal static class QuickIOSystemRules
    {
        /// <summary>
        /// UTF8Encoding No Emit
        /// </summary>
        public static UTF8Encoding UTF8EncodingNoEmit = new UTF8Encoding( encoderShouldEmitUTF8Identifier: false );
    }
}
