// <copyright file="QuickIODirectory.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIODirectory</summary>

using System;
using SchwabenCode.QuickIO.Internal;

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
        /// <example>
        /// This example shows how to call <see>
        ///         <cref>GetStatistics</cref>
        ///     </see>
        ///     and write the result to the console.
        /// <code>
        /// public static void GetStatistics_With_StringPath_Example()
        /// {
        ///    const string targetDirectoryPath = @"C:\temp\QuickIOTest";
        /// 
        ///    // Get statistics
        ///    QuickIOFolderStatisticResult statsResult = QuickIODirectory.GetStatistics( targetDirectoryPath );
        /// 
        ///    // Output
        ///    Console.WriteLine( "[Stats] Folders: '{0}' Files: '{1}' Total TotalBytes '{2}'", statsResult.FolderCount, statsResult.FileCount, statsResult.TotalBytes );
        /// }
        /// </code>
        /// </example>
        public static QuickIOFolderStatisticResult GetStatistics( String path )
        {
            return GetStatistics( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Gets the directory statistics: total files, folders and bytes
        /// </summary>
        /// <param name="pathInfo"></param>
        /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
        /// <example>
        /// This example shows how to call <see>
        ///         <cref>GetStatistics</cref>
        ///     </see>
        ///     with <see cref="QuickIOPathInfo"/> and write the result to the console.
        /// <code>
        ///public static void GetStatistics_With_PathInfo_Example()
        ///{
        ///    QuickIOPathInfo targetDirectoryPathInfo = new QuickIOPathInfo( @"C:\temp\QuickIOTest" );
        ///
        ///    // Get statistics
        ///    QuickIOFolderStatisticResult stats = QuickIODirectory.GetStatistics( targetDirectoryPathInfo );
        ///
        ///    // Output
        ///    Console.WriteLine( "[Stats] Folders: '{0}' Files: '{1}' Total TotalBytes '{2}'", stats.FolderCount, stats.FileCount, stats.TotalBytes );
        ///}
        /// </code>
        /// </example>
        public static QuickIOFolderStatisticResult GetStatistics( QuickIOPathInfo pathInfo )
        {
            return InternalQuickIO.GetDirectoryStatistics( pathInfo );
        }

        /// <summary>
        /// Gets the directory statistics: total files, folders and bytes
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object that holds the folder statistics such as number of folders, files and total bytes</returns>
        /// <example>
        /// This example shows how to call <see>
        ///         <cref>GetStatistics</cref>
        ///     </see>
        ///     with <see cref="QuickIODirectoryInfo"/> and write the result to the console.
        /// <code>
        ///public static void GetStatistics_With_DirectoryInfo_Example()
        ///{
        ///    QuickIODirectoryInfo targetDirectoryPathInfo = new QuickIODirectoryInfo( @"C:\temp\QuickIOTest" );
        ///
        ///    // Get statistics
        ///    QuickIOFolderStatisticResult stats = QuickIODirectory.GetStatistics( targetDirectoryPathInfo );
        ///
        ///    // Output
        ///    Console.WriteLine( "[Stats] Folders: '{0}' Files: '{1}' Total TotalBytes '{2}'", stats.FolderCount, stats.FileCount, stats.TotalBytes );
        ///}
        /// </code>
        /// </example>
        public static QuickIOFolderStatisticResult GetStatistics( QuickIODirectoryInfo directoryInfo )
        {
            return InternalQuickIO.GetDirectoryStatistics( directoryInfo.PathInfo );
        }
        #endregion
    }
}
