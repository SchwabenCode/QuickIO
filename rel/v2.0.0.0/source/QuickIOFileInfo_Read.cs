// <copyright file="QuickIOFileInfo_Read.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Reads the contents of the file into a byte collection.
        /// </summary>
        /// <returns>A byte collection containing the contents.</returns>
        public byte[ ] ReadAllBytes( Int32 readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes )
        {
            return QuickIOFile.ReadAllBytes( PathInfo, readBuffer );
        }

        /// <summary>
        /// Reads all lines.
        /// </summary>
        /// <returns>A string collection containing all lines.</returns>
        public IEnumerable<string> ReadAllLines()
        {
            return QuickIOFile.ReadAllLines( PathInfo );
        }

        /// <summary>
        /// Reads all lines with the specified encoding
        /// </summary>
        /// <param name="encoding">The encoding applied to the contents. </param>
        /// <returns>A string collection containing all lines.</returns>
        public IEnumerable<string> ReadAllLines( Encoding encoding )
        {
            return QuickIOFile.ReadAllLines( PathInfo, encoding );
        }

        /// <summary>
        /// Reads all text.
        /// </summary>
        /// <returns>A string represents the content.</returns>
        public string ReadAllText()
        {
            return QuickIOFile.ReadAllText( PathInfo );
        }

        /// <summary>
        /// Reads all text with the specified encoding.
        /// </summary>
        /// <param name="encoding">The encoding applied to the content. </param>
        /// <returns>A string represents the content.</returns>
        public string ReadAllText( Encoding encoding )
        {
            return QuickIOFile.ReadAllText( PathInfo, encoding );
        }
    }
}
