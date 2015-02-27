// <copyright file="QuickIOFileInfo_Write_Async.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>
#if NET40_OR_GREATER
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Writes the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes to write. </param>
        public Task WriteAllBytesAsync( IEnumerable<byte> bytes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => WriteAllBytes( bytes ) );
        }

        /// <summary>
        /// Writes the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes to write. </param>
        public Task WriteAllBytesAsync( byte[ ] bytes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => WriteAllBytes( bytes ) );
        }

        /// <summary>
        /// Writes a collection of strings.
        /// Uses UTF-8 without Emitted UTF-8 identifier.
        /// </summary>
        /// <param name="contents">The lines write to.</param>
        public Task WriteAllLinesAsync( IEnumerable<string> contents )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => WriteAllLines( contents ) );
        }

        /// <summary>
        /// Writes a collection of strings.
        /// </summary>
        /// <param name="contents">The lines write to.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public Task WriteAllLinesAsync( IEnumerable<string> contents, Encoding encoding )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => WriteAllLines( contents, encoding ) );
        }

        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="contents">The string to write to. </param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        public Task WriteAllTextAsync( string contents, Encoding encoding )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => WriteAllText( contents, encoding ) );
        }

        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="contents">The string to write to. </param>
        public Task WriteAllTextAsync( string contents )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => WriteAllText( contents ) );
        }
    }
}
#endif