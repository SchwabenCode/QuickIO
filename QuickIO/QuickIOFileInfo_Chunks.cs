// <copyright file="QuickIOFileInfo_Chunks.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/19/2014</date>
// <summary>QuickIOFileInfo_Chunks</summary>

using System;
using System.Collections.Generic;
using System.IO;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFileInfo
    {
        /// <summary>
        /// Default ChunkSize
        /// </summary>
        private const Int32 DefaultChunkSize = 1024; // Bytes


        /// <summary>
        /// Returns the file chunks by given chunksize
        /// </summary>
        /// <param name="chunkSize">Chunk size (Bytes)</param>
        /// <returns>Collection of chunks. On enumerator, the file gets read.</returns>
        public IEnumerable<QuickIOFileChunk> GetFileChunks( Int32 chunkSize = DefaultChunkSize )
        {
            return InternalEnumerateFileChunks( chunkSize );
        }

        /// <summary>
        /// Returns the chunks of current file that are identical with the other file
        /// </summary>
        /// <param name="file">File to compare</param>
        /// <param name="chunkSize">Chunk size (Bytes)</param>
        /// <returns>Returns the chunks of current file that are identical with the other file</returns>
        public IEnumerable<QuickIOFileChunk> GetFileChunksEqual( QuickIOFileInfo file, Int32 chunkSize = DefaultChunkSize )
        {
            var en1 = GetFileChunksEnumerator( chunkSize );
            var en2 = file.GetFileChunksEnumerator( chunkSize );

            while ( en1.MoveNext( ) && en2.MoveNext( ) )
            {
                // check of the chunks are equal
                if ( en1.Current.ChunkEquals( en2.Current ) )
                {
                    // equal
                    yield return en1.Current;
                }
            }
        }

        /// <summary>
        /// Returns the chunks of current file that are NOT identical with the other file
        /// </summary>
        /// <param name="file">File to compare</param>
        /// <param name="chunkSize">Chunk size (Bytes)</param>
        /// <returns>Returns the chunks of current file that are NOT identical with the other file</returns>
        public IEnumerable<QuickIOFileChunk> GetFileChunksUnequal( QuickIOFileInfo file, Int32 chunkSize = DefaultChunkSize )
        {
            var en1 = GetFileChunksEnumerator( chunkSize );
            var en2 = file.GetFileChunksEnumerator( chunkSize );

            while ( en1.MoveNext( ) )
            {
                var mn2 = en2.MoveNext( );

                // EOF of file2?
                if ( !mn2 )
                {
                    // current chunk must be unequal
                    yield return en1.Current;
                }
                else
                {
                    // check of the chunks are unequal
                    if ( !en1.Current.ChunkEquals( en2.Current ) )
                    {
                        // unequal
                        yield return en1.Current;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the <see>
        ///         <cref>IEnumerator</cref></see>
        ///   of <see cref="GetFileChunks"/>
        /// </summary>
        /// <param name="chunkSize">Chunk size (Bytes)</param>
        /// <returns></returns>
        public IEnumerator<QuickIOFileChunk> GetFileChunksEnumerator( Int32 chunkSize = DefaultChunkSize )
        {
            return GetFileChunks( chunkSize ).GetEnumerator( );
        }

        /// <summary>
        /// Checks if both file contents are equal.
        /// Opens both files for read and breaks on first unequal chunk.
        /// </summary>
        /// <param name="file">File to compare</param>
        /// <param name="chunkSize">Chunk size (Bytes)</param>
        /// <returns>true if contents are equal</returns>
        public Boolean IsEqualContents( QuickIOFileInfo file, Int32 chunkSize = DefaultChunkSize )
        {
            var en1 = GetFileChunksEnumerator( chunkSize );
            var en2 = file.GetFileChunksEnumerator( chunkSize );

            while ( true )
            {
                // Go to next element
                var mn1 = en1.MoveNext( );
                var mn2 = en2.MoveNext( );

                // check if next element exists
                if ( mn1 != mn2 )
                {
                    // collections count diff
                    return false;
                }

                // no more elements in both collections
                if ( !mn1 )
                {
                    return true;
                }

                // check chunks
                var chunk1 = en1.Current;
                var chunk2 = en2.Current;

                if ( !chunk1.ChunkEquals( chunk2 ) )
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Reads the file and returns containign chunks
        /// </summary>
        /// <param name="chunkSize">Chunk size (Bytes)</param>
        /// <returns>Collection of chunks</returns>
        private IEnumerable<QuickIOFileChunk> InternalEnumerateFileChunks( Int32 chunkSize = DefaultChunkSize )
        {
            FileStream fs;
            try
            {
                // Open first File
                fs = OpenRead( );
            }
            catch ( Exception e )
            {
                throw new Exception( "Failed to file to read", e );
            }

            using ( fs )
            {
                // check buffer for small files; will be faster
                var bytes = new byte[ Math.Min( fs.Length, chunkSize ) ];

                UInt64 position = 0;
                // transfer chunks
                while ( ( fs.Read( bytes, 0, bytes.Length ) ) > 0 )
                {
                    //var arr = new byte[ bytes.Length ];
                    //Buffer.BlockCopy( bytes, 0, arr, 0, bytes.Length );
                    yield return new QuickIOFileChunk( position, bytes );
                    position += Convert.ToUInt64( bytes.Length );
                }
            }
        }
    }
}