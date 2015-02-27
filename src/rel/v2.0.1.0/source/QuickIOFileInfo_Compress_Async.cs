// <copyright file="QuickIOFileInfo_Compress.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>Compressing</summary>

using System;
#if NET40_OR_GREATER
using System.IO;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFileInfo
    {
        /// <summary>
        /// Compress all data of file and returns filled <see cref="MemoryStream"/>
        /// </summary>
        public Task<MemoryStream> GetCompressStreamAsync( Int32 readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetCompressStream( readBuffer ) );
        }

        /// <summary>
        /// Decompress all data of file and returns filled <see cref="MemoryStream"/>
        /// </summary>
        public Task<MemoryStream> GetDecompressStreamAsync( Int32 readBuffer = QuickIORecommendedValues.DefaultReadBufferBytes )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetDecompressStream( readBuffer ) );
        }

        /// <summary>
        /// Returns all bytes of <see cref="GetCompressStream"/>
        /// </summary>
        public Task<Byte[ ]> CompressDataAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( CompressData );
        }

        /// <summary>
        /// Returns all bytes of <see cref="GetDecompressStream"/>
        /// </summary>
        public Task<Byte[ ]> DecompressDataAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( DecompressData );
        }
    }
}
#endif