// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using SchwabenCode.QuickIO.Internal;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata EnumerateDirectoryMetadata( String path, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

            return InternalEnumerateFileSystem.EnumerateDirectoryMetadata( path, enumerateOptions );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata EnumerateDirectoryMetadata( QuickIODirectoryInfo directoryInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( directoryInfo != null );
            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

            return EnumerateDirectoryMetadata( directoryInfo.PathInfo, enumerateOptions );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata EnumerateDirectoryMetadata( QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( pathInfo != null );
            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

            return EnumerateDirectoryMetadata( pathInfo.FullNameUnc, enumerateOptions );
        }

    }
}
