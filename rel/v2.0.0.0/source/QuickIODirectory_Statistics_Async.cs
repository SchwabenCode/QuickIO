// <copyright file="QuickIODirectory_Statistics_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory_Statistics_Async</summary>


#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides static methods to access folders. For example creating, deleting and retrieving content and security information such as the owner.
    /// </summary>
    public static partial class QuickIODirectory
    {
        #region GetStatistics

        /// <summary>
        /// Gets the directory statistics: total files, folders and bytes
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
        public static Task<QuickIOFolderStatisticResult> GetStatisticsAsync( String path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetStatistics( path ) );
        }

        /// <summary>
        /// Gets the directory statistics: total files, folders and bytes
        /// </summary>
        /// <param name="pathInfo"></param>
        /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
        public static Task<QuickIOFolderStatisticResult> GetStatisticsAsync( QuickIOPathInfo pathInfo )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetStatistics( pathInfo ) );
        }

        /// <summary>
        /// Gets the directory statistics: total files, folders and bytes
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
        public static Task<QuickIOFolderStatisticResult> GetStatisticsAsync( QuickIODirectoryInfo directoryInfo )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => GetStatistics( directoryInfo ) );
        }
        #endregion
    }
}

#endif
