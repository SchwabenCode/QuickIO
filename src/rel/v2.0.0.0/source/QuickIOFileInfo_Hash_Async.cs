// <copyright file="QuickIOFileInfo_Hash.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

#if NET40_OR_GREATER
using System.Security.Cryptography;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;



namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// File content hash calculation
        /// </summary>
        public Task<QuickIOHashResult> CalculateHashAsync( QuickIOHashImplementationType hashImplementationType )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => CalculateHash( hashImplementationType ) );
        }

        /// <summary>
        /// File content hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public Task<QuickIOHashResult> CalculateHashAsync( HashAlgorithm hashAlgorithm )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => CalculateHash( hashAlgorithm ) );
        }

        /// <summary>
        /// File content hash calculation using SHA1
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public Task<QuickIOHashResult> CalculateSha1HashAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( CalculateSha1Hash );
        }

        /// <summary>
        /// File content hash calculation using SHA256
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public Task<QuickIOHashResult> CalculateSha256HashAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( CalculateSha256Hash );
        }

        /// <summary>
        /// File content hash calculation using SHA384
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public Task<QuickIOHashResult> CalculateSha384HashAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( CalculateSha384Hash );
        }

        /// <summary>
        /// File content hash calculation using SHA512
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public Task<QuickIOHashResult> CalculateSha512HashAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( CalculateSha512Hash );
        }

        /// <summary>
        /// File content hash calculation using MD5
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public Task<QuickIOHashResult> CalculateMD5HashAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( CalculateMD5Hash );
        }
    }
}
#endif