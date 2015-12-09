// <copyright file="QuickIOHashResult.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOHashResult</summary>

using System;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// This class is used for hash calculations.
    /// Use <see>
    ///         <cref>Format</cref>
    ///     </see>
    ///     for human readable output.
    /// </summary>
    /// <example>
    /// <code>
    /// // Show human readable hash
    /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
    /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
    /// </code>
    /// </example>
    public class QuickIOHashResult
    {
        private readonly byte[ ] _hashBytes;

        /// <summary>
        /// The bytes that represents the calculation result
        /// </summary>
        public byte[ ] HashBytes
        {
            get
            {
                Contract.Ensures( Contract.Result<Byte[ ]>() != null );
                return _hashBytes;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="QuickIOHashResult"/>
        /// </summary>
        /// <param name="hashBytes"></param>
        internal QuickIOHashResult( byte[ ] hashBytes )
        {
            Contract.Requires( hashBytes != null );
            _hashBytes = hashBytes;
        }

        /// <summary>
        /// Formats the <see cref="HashBytes"/> as a hexadecimal string using UTF8 encoding.
        /// </summary>
        /// <returns>Formated string</returns>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( );
        /// </code>
        /// </example>
        public string Format()
        {
            Contract.Ensures( Contract.Result<string>() != null );
            return Format( Encoding.UTF8 );
        }

        /// <summary>
        /// Formats the <see cref="HashBytes"/> as a hexadecimal string using specified encoding.
        /// </summary>
        /// <param name="encoding">Encoding for formatting</param>
        /// <returns>Formated string</returns>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8 );
        /// </code>
        /// </example>
        public string Format( Encoding encoding )
        {
            Contract.Requires( encoding != null );
            Contract.Ensures( Contract.Result<string>() != null );

            return Format( encoding, "x2" );
        }

        /// <summary>
        /// Formats the <see cref="HashBytes"/> using specified encoding and format.
        /// </summary>
        /// <param name="encoding">Encoding for formatting</param>
        /// <param name="format">Pattern for formatting. Use x2 for hexadecimal output.</param>
        /// <returns>Formated string</returns>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
        /// </code>
        /// </example>
        public string Format( Encoding encoding, String format, CancellationToken cancellationToken = default( CancellationToken ) )
        {
            Contract.Requires( encoding != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( format ) );
            Contract.Ensures( Contract.Result<string>() != null );

            StringBuilder sb = new StringBuilder();
            foreach (byte t in HashBytes)
            {
                cancellationToken.ThrowIfCancellationRequested();

                sb.Append( t.ToString( format ) );
            }

            return sb.ToString();
        }
    }
}
