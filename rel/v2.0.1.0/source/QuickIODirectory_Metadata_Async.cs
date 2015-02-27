// <copyright file="QuickIODirectory_Metadata_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory_Metadata</summary>
#if NET40_OR_GREATER
using System;
using SchwabenCode.QuickIO.Compatibility;
using SchwabenCode.QuickIO.Internal;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadataAsync( String directoryPath, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Invariant.NotEmpty( directoryPath );
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetMetadata( directoryPath, enumerateOptions ) );
        }
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadataAsync( QuickIODirectoryInfo directoryInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Invariant.NotNull( directoryInfo );
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetMetadata( directoryInfo, enumerateOptions ) );
        }
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadataAsync( QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Invariant.NotNull( pathInfo );
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetMetadata( pathInfo, enumerateOptions ) );
        }
    }
}
#endif