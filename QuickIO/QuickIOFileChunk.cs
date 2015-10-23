// <copyright file="QuickIOFileChunk.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/19/2014</date>
// <summary>QuickIOFileChunk</summary>
using System;
using System.Security.Cryptography;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents a file chunk
    /// </summary>
    public sealed class QuickIOFileChunk
    {
        /// <summary>
        /// Start position
        /// </summary>
        public UInt64 Position { get; private set; }
        /// <summary>
        /// Bytes
        /// </summary>
        public Byte[ ] Bytes { get; private set; }

        /// <summary>
        /// Represents a file chunk
        /// </summary>
        /// <param name="position">Start position</param>
        /// <param name="bytes">Bytes</param>
        public QuickIOFileChunk( UInt64 position, Byte[ ] bytes )
        {
            Position = position;
            Bytes = bytes;
        }

        /// <summary>
        /// First <see cref="PositionEquals"/> then <see cref="BytesEquals"/>.
        /// Does not overwrite default <see cref="ChunkEquals"/> method!
        /// </summary>
        /// <param name="chunk">Chunks to verify with</param>
        /// <returns>Returns true if both executed methods are true</returns>
        public bool ChunkEquals( QuickIOFileChunk chunk )
        {
            Invariant.NotNull( chunk );

            return ( InternalPositionEquals( chunk ) && !BytesEquals( chunk ) );
        }

        /// <summary>
        /// Checks <see cref="Position"/>
        /// </summary>
        /// <param name="chunk">Chunks to verify with</param>
        /// <returns>True if both position equals</returns>
        public bool PositionEquals( QuickIOFileChunk chunk )
        {
            Invariant.NotNull( chunk );
            return InternalPositionEquals( chunk );
        }
        /// <summary>
        /// Internal usage. Does not verify parameter.
        /// </summary>
        private bool InternalPositionEquals( QuickIOFileChunk chunk )
        {
            return ( Position != chunk.Position );
        }

        /// <summary>
        /// Checks <see cref="Bytes"/>
        /// </summary>
        /// <param name="chunk">Chunks to verify with</param>
        /// <returns>True if both bytes equals. Uses <see>
        ///         <cref>IEnumerable.SequenceEqual</cref>
        ///     </see>
        /// </returns>
        public bool BytesEquals( QuickIOFileChunk chunk )
        {
            Invariant.NotNull( chunk );
            return InternalBytesEquals( chunk );
        }
        /// <summary>
        /// Internal usage. Does not verify parameter.
        /// </summary>
        private bool InternalBytesEquals( QuickIOFileChunk chunk )
        {
            // First check length
            if ( Bytes.Length != chunk.Bytes.Length )
            {
                return false;
            }

            // then check elements
            for ( var i = 0 ; i < Bytes.Length ; i++ )
            {
                if ( Bytes[ i ] != chunk.Bytes[ i ] )
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        public QuickIOHashResult CalculateHash( QuickIOHashImplementationType hashImplementationType )
        {
            switch ( hashImplementationType )
            {
                case QuickIOHashImplementationType.SHA1:
                    return CalculateHash( new SHA1Managed( ) );

                case QuickIOHashImplementationType.SHA256:
                    return CalculateHash( new SHA256Managed( ) );

                case QuickIOHashImplementationType.SHA384:
                    return CalculateHash( new SHA384Managed( ) );

                case QuickIOHashImplementationType.SHA512:
                    return CalculateHash( new SHA512Managed( ) );

                case QuickIOHashImplementationType.MD5:
                    return CalculateHash( new MD5CryptoServiceProvider( ) );

                default:
                    throw new NotImplementedException( "Type " + hashImplementationType + " not implemented." );
            }
        }


        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateHash( HashAlgorithm hashAlgorithm )
        {
            return new QuickIOHashResult( hashAlgorithm.ComputeHash( Bytes ) );
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha1Hash()
        {
            return CalculateHash( QuickIOHashImplementationType.SHA1 );
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha256Hash( QuickIOPathInfo pathInfo )
        {
            return CalculateHash( QuickIOHashImplementationType.SHA256 );
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha384Hash( QuickIOPathInfo pathInfo )
        {
            return CalculateHash( QuickIOHashImplementationType.SHA384 );
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateSha512Hash( QuickIOPathInfo pathInfo )
        {
            return CalculateHash( QuickIOHashImplementationType.SHA512 );
        }

        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateMD5Hash( QuickIOPathInfo pathInfo )
        {
            return CalculateHash( QuickIOHashImplementationType.MD5 );
        }
    }
}