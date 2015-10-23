// <copyright file="QuickIOFileInfo_Compress.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>Compressing</summary>


using System;
using System.IO;
using System.IO.Compression;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFileInfo
    {
        /// <summary>
        /// Compress all data of file and returns filled <see cref="MemoryStream"/>
        /// </summary>
        public MemoryStream GetCompressStream( Int32 readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes )
        {
            return InternalGetGZipStream( readBuffer, CompressionMode.Compress );
        }

        /// <summary>
        /// Decompress all data of file and returns filled <see cref="MemoryStream"/>
        /// </summary>
        public MemoryStream GetDecompressStream( Int32 readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes )
        {
            return InternalGetGZipStream( readBuffer, CompressionMode.Decompress );
        }

        /// <summary>
        /// Internal Usage only
        /// </summary>
        private MemoryStream InternalGetGZipStream( Int32 readBuffer, CompressionMode mode )
        {
            var ms = new MemoryStream( );

            using ( var gZipStream = new GZipStream( ms, mode, true ) )
            {
                using ( var readStream = OpenRead( ) )
                {
                    var buffer = new Byte[ readBuffer ];
                    Int32 read;
                    while ( ( read = readStream.Read( buffer, 0, buffer.Length ) ) > 0 )
                    {
                        gZipStream.Write( buffer, 0, read );
                    }
                }
            }
            return ms;
        }

        /// <summary>
        /// Returns all bytes of <see cref="GetCompressStream"/>
        /// </summary>
        public Byte[ ] CompressData()
        {
            using ( var s = GetCompressStream( ) )
            {
                return s.ToArray( );
            }
        }

        /// <summary>
        /// Returns all bytes of <see cref="GetDecompressStream"/>
        /// </summary>
        public Byte[ ] DecompressData()
        {
            using ( var s = GetDecompressStream( ) )
            {
                return s.ToArray( );
            }
        }
    }
}