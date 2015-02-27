// <copyright file="QuickIOFile_Hash.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIOFile</summary>

using System;
using System.IO;
using System.Security.Cryptography;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOFile
    {
        /// <summary>
        /// File content hash calculation
        /// </summary>
        public static QuickIOHashResult CalculateHash( QuickIOPathInfo pathInfo, QuickIOHashImplementationType hashImplementationType )
        {
            switch ( hashImplementationType )
            {
                case QuickIOHashImplementationType.SHA1:
                    return CalculateSha1Hash( pathInfo );

                case QuickIOHashImplementationType.SHA256:
                    return CalculateSha256Hash( pathInfo );

                case QuickIOHashImplementationType.SHA384:
                    return CalculateSha384Hash( pathInfo );

                case QuickIOHashImplementationType.SHA512:
                    return CalculateSha512Hash( pathInfo );

                case QuickIOHashImplementationType.MD5:
                    return CalculateMD5Hash( pathInfo );

                default:
                    throw new NotImplementedException( "Type " + hashImplementationType + " not implemented." );
            }
        }

        /// <summary>
        /// File content hash calculation
        /// </summary>
        /// <example>
        /// <code>
        /// // Implementation of <see cref="CalculateSha256Hash"/>
        /// public static QuickIOHashResult CalculateSha256Hash( QuickIOPathInfo pathInfo )
        /// {
        ///     using ( var fs = OpenRead( pathInfo ) )
        ///     using ( var hashAlgorithm = SHA256.Create( ) )
        ///     {
        ///         return CalculateHash( hashAlgorithm, fs );
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public static QuickIOHashResult CalculateHash( HashAlgorithm hashAlgorithm, Stream stream )
        {
            return new QuickIOHashResult( hashAlgorithm.ComputeHash( stream ) );
        }

        /// <summary>
        /// File content hash calculation using SHA1
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha1Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
        /// </code>
        /// </example>
        public static QuickIOHashResult CalculateSha1Hash( QuickIOPathInfo pathInfo )
        {
            using ( var fs = OpenRead( pathInfo ) )
            using ( var hashAlgorithm = new SHA1Managed( ) )
            {
                return CalculateHash( hashAlgorithm, fs );
            }
        }

        /// <summary>
        /// File content hash calculation using SHA256
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        /// <remarks>Not compatible with FIPS<br/>http://msdn.microsoft.com/de-de/library/hydyw22a(v=vs.110).aspx</remarks>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha256Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
        /// </code>
        /// </example>
        public static QuickIOHashResult CalculateSha256Hash( QuickIOPathInfo pathInfo )
        {
            using ( var fs = OpenRead( pathInfo ) )
            using ( var hashAlgorithm = new SHA256Managed( ) )
            {
                return CalculateHash( hashAlgorithm, fs );
            }
        }

        /// <summary>
        /// File content hash calculation using SHA384
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha384Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
        /// </code>
        /// </example>
        public static QuickIOHashResult CalculateSha384Hash( QuickIOPathInfo pathInfo )
        {
            using ( var fs = OpenRead( pathInfo ) )
            using ( var hashAlgorithm = new SHA384Managed( ) )
            {
                return CalculateHash( hashAlgorithm, fs );
            }
        }

        /// <summary>
        /// File content hash calculation using SHA512
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        /// <remarks>Not compatible with FIPS<br/>http://msdn.microsoft.com/de-de/library/hydyw22a(v=vs.110).aspx</remarks>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateSha512Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
        /// </code>
        /// </example>
        public static QuickIOHashResult CalculateSha512Hash( QuickIOPathInfo pathInfo )
        {
            using ( var fs = OpenRead( pathInfo ) )
            using ( var hashAlgorithm = new SHA512Managed( ) )
            {
                return CalculateHash( hashAlgorithm, fs );
            }
        }

        /// <summary>
        /// File content hash calculation using MD5
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        /// <example>
        /// <code>
        /// // Show human readable hash
        /// QuickIOHashResult hashResult = QuickIOFile.CalculateMD5Hash( "C:\temp\image.bin" );
        /// Console.WriteLine("Hash: {0}", hashResult.Format( Encoding.UTF8, "x2" );
        /// </code>
        /// </example>
        public static QuickIOHashResult CalculateMD5Hash( QuickIOPathInfo pathInfo )
        {
            using ( var fs = OpenRead( pathInfo ) )
            using ( var hashAlgorithm = new MD5CryptoServiceProvider( ) )
            {
                return CalculateHash( hashAlgorithm, fs );
            }
        }
    }
}
