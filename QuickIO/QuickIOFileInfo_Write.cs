// <copyright file="QuickIOFileInfo_Write.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

using System.Collections.Generic;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {

        /// <summary>
        /// Writes the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes to write. </param>
        public void WriteAllBytes( IEnumerable<byte> bytes )
        {
            QuickIOFile.WriteAllBytes( PathInfo, bytes );
        }

        /// <summary>
        /// Writes the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes to write. </param>
        public void WriteAllBytes( byte[ ] bytes )
        {
            QuickIOFile.WriteAllBytes( PathInfo, bytes );
        }

        /// <summary>
        /// Writes a collection of strings.
        /// Uses UTF-8 without Emitted UTF-8 identifier.
        /// </summary>
        /// <param name="contents">The lines write to.</param>
        public void WriteAllLines( IEnumerable<string> contents )
        {
            QuickIOFile.WriteAllLines( PathInfo, contents );
        }

        /// <summary>
        /// Writes a collection of strings.
        /// </summary>
        /// <param name="contents">The lines write to.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public void WriteAllLines( IEnumerable<string> contents, Encoding encoding )
        {
            QuickIOFile.WriteAllLines( PathInfo, contents, encoding );
        }

        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="contents">The string to write to. </param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        public void WriteAllText( string contents, Encoding encoding )
        {
            QuickIOFile.WriteAllText( PathInfo, contents, encoding );
        }

        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="contents">The string to write to. </param>
        public void WriteAllText( string contents )
        {
            QuickIOFile.WriteAllText( PathInfo, contents );
        }
    }
}
