// <copyright file="QuickIODirectoryInfo_Operators.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for directories</summary>

using System;
using SchwabenCode.QuickIO.Internal;


#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif
namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata GetMetadata( String directoryPath )
        {
            Invariant.NotEmpty( directoryPath );
            return InternalQuickIO.EnumerateDirectoryMetadata( new QuickIOPathInfo( directoryPath ) );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata GetMetadata( QuickIODirectoryInfo directoryInfo )
        {
            Invariant.NotNull( directoryInfo );
            return InternalQuickIO.EnumerateDirectoryMetadata( directoryInfo.PathInfo );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata GetMetadata( QuickIOPathInfo pathInfo )
        {
            Invariant.NotNull( pathInfo );
            return InternalQuickIO.EnumerateDirectoryMetadata( pathInfo );
        }

#if NET40_OR_GREATER
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadataAsync( String directoryPath )
        {
            Invariant.NotEmpty( directoryPath );
            return Compatibility.NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => InternalQuickIO.EnumerateDirectoryMetadata( new QuickIOPathInfo( directoryPath ) ) );
        }
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadataAsync( QuickIODirectoryInfo directoryInfo )
        {
            Invariant.NotNull( directoryInfo );
            return Compatibility.NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => InternalQuickIO.EnumerateDirectoryMetadata( directoryInfo.PathInfo ) );
        }
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadataAsync( QuickIOPathInfo pathInfo )
        {
            Invariant.NotNull( pathInfo );
            return Compatibility.NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => InternalQuickIO.EnumerateDirectoryMetadata( pathInfo ) );
        }
#endif
    }
}
