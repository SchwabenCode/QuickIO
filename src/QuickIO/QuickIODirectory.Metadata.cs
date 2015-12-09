﻿// <copyright file="QuickIODirectory_Metadata.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory_Metadata</summary>

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

            return InternalQuickIO.EnumerateDirectoryMetadata( path, enumerateOptions );
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
