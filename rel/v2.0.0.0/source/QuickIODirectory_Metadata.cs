// <copyright file="QuickIODirectory_Metadata.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory_Metadata</summary>

using System;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata GetMetadata( String directoryPath, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Invariant.NotEmpty( directoryPath );
            return InternalQuickIO.EnumerateDirectoryMetadata( new QuickIOPathInfo( directoryPath ), enumerateOptions );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata GetMetadata( QuickIODirectoryInfo directoryInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Invariant.NotNull( directoryInfo );
            return InternalQuickIO.EnumerateDirectoryMetadata( directoryInfo.PathInfo, enumerateOptions );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static QuickIODirectoryMetadata GetMetadata( QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Invariant.NotNull( pathInfo );
            return InternalQuickIO.EnumerateDirectoryMetadata( pathInfo, enumerateOptions );
        }

    }
}
