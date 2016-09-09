// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Hashing and Encryption
    /// </summary>
    public static class QuickIOHash
    {
        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        public static QuickIOHashResult Calculate( HashAlgorithm algorithm, string content, Encoding encoding = null )
        {
            Contract.Requires( algorithm != null );
            Contract.Requires( !String.IsNullOrEmpty( content ) );
            Contract.Ensures( Contract.Result<QuickIOHashResult>() != null );

            encoding = encoding ?? Encoding.UTF8;
            return Calculate( algorithm, encoding.GetBytes( content ) );
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        public static QuickIOHashResult Calculate( HashAlgorithm algorithm, byte[ ] bytes )
        {
            Contract.Requires( algorithm != null );
            Contract.Requires( bytes != null );
            Contract.Ensures( Contract.Result<QuickIOHashResult>() != null );

            return new QuickIOHashResult( algorithm.ComputeHash( bytes ) );
        }
    }
}
