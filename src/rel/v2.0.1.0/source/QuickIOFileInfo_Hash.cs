// <copyright file="QuickIOFileInfo_Hash.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

using System.Security.Cryptography;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// File content hash calculation
        /// </summary>
        public QuickIOHashResult CalculateHash( QuickIOHashImplementationType hashImplementationType )
        {
            return QuickIOFile.CalculateHash( PathInfo, hashImplementationType );
        }

        /// <summary>
        /// File content hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateHash( HashAlgorithm hashAlgorithm )
        {
            using ( var sr = OpenRead( ) )
            {
                return QuickIOFile.CalculateHash( hashAlgorithm, sr );
            }
        }

        /// <summary>
        /// File content hash calculation using SHA1
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha1Hash()
        {
            return QuickIOFile.CalculateSha1Hash( PathInfo );
        }

        /// <summary>
        /// File content hash calculation using SHA256
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha256Hash()
        {
            return QuickIOFile.CalculateSha256Hash( PathInfo );
        }

        /// <summary>
        /// File content hash calculation using SHA384
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha384Hash()
        {
            return QuickIOFile.CalculateSha384Hash( PathInfo );
        }

        /// <summary>
        /// File content hash calculation using SHA512
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha512Hash()
        {
            return QuickIOFile.CalculateSha512Hash( PathInfo );
        }

        /// <summary>
        /// File content hash calculation using MD5
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateMD5Hash()
        {
            return QuickIOFile.CalculateMD5Hash( PathInfo );
        }
    }
}
