﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Security.Cryptography;
using System.Diagnostics.Contracts;

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
        public UInt64 Position { get; }
        /// <summary>
        /// Bytes
        /// </summary>
        public Byte[ ] Bytes { get; }

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
            Contract.Requires( chunk != null );
            return ( InternalPositionEquals( chunk ) && BytesEquals( chunk ) );
        }

        /// <summary>
        /// Checks <see cref="Position"/>
        /// </summary>
        /// <param name="chunk">Chunks to verify with</param>
        /// <returns>True if both position equals</returns>
        public bool PositionEquals( QuickIOFileChunk chunk )
        {
            Contract.Requires( chunk != null );
            return InternalPositionEquals( chunk );
        }
        /// <summary>
        /// Internal usage. Does not verify parameter.
        /// </summary>
        private bool InternalPositionEquals( QuickIOFileChunk chunk )
        {
            return ( Position == chunk.Position );
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
            Contract.Requires( chunk != null );
            return InternalBytesEquals( chunk );
        }
        /// <summary>
        /// Internal usage. Does not verify parameter.
        /// </summary>
        private bool InternalBytesEquals( QuickIOFileChunk chunk )
        {
            // First check length
            if( Bytes.Length != chunk.Bytes.Length )
            {
                return false;
            }

            // then check elements
            for( int i = 0 ;i < Bytes.Length ;i++ )
            {
                if( Bytes[ i ] != chunk.Bytes[ i ] )
                {
                    return false;
                }
            }

            return true;
        }




        /// <summary>
        /// File chunk hash calculation
        /// </summary>
        /// <returns><see cref="QuickIOHashResult"/></returns>
        public QuickIOHashResult CalculateHash( HashAlgorithm algorithm )
        {
            Contract.Ensures( Contract.Result<QuickIOHashResult>() != null );

            return QuickIOHash.Calculate( algorithm, Bytes );
        }
    }
}