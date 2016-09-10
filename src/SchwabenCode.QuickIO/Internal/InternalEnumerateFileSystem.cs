// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO.Internal
{
    internal static class InternalEnumerateFileSystem
    {

        /// <summary>
        /// Search Exection
        /// </summary>
        /// <param name="uncDirectoryPath">Start directory path</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="filterType"><see cref="QuickIOFileSystemEntryType"/></param>
        /// <returns>Collection of path</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static IEnumerable<String> EnumerateSystemPaths( String uncDirectoryPath, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOFileSystemEntryType? filterType = null )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<String>>() != null );


            IEnumerable<QuickIOFileSystemEntry> entries = EnumerateFileSystemEntries( uncDirectoryPath, pattern, searchOption, enumerateOptions );

            // filter?
            if( filterType != null )
            {
                entries = entries.Where( entry => entry.Type == filterType );
            }

            // TODO: path format

            return entries.Select( entry => entry.Path );
        }

        /// <summary>
        /// Determined all sub system entries of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIOFileSystemEntry> EnumerateFileSystemEntries( String uncDirectoryPath, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIOFileSystemEntry>>() != null );

            return
                ( from pair in EnumerateWin32FileSystemEntries( uncDirectoryPath, pattern, searchOption, enumerateOptions )
                  let parentDirectory = pair.Item1
                  let win32Entry = pair.Item2
                  let fullpath = QuickIOPath.Combine( parentDirectory, win32Entry.Name )
                  select
                      new QuickIOFileSystemEntry( fullpath, win32Entry.FileSystemEntryType, win32Entry.Attributes, win32Entry.Bytes ) );
        }

        /// <summary>
        /// Determined all sub system entries of a directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<Tuple<string, Win32FileSystemEntry>> EnumerateWin32FileSystemEntries( String path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<IEnumerable<Tuple<string, Win32FileSystemEntry>>>() != null );

            // Stack
            Stack<string> directoryPathStack = new Stack<string>();
            directoryPathStack.Push( path );

            while( directoryPathStack.Count > 0 )
            {
                string currentDirectory = directoryPathStack.Pop();

                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( currentDirectory, pattern ) ) )
                {
                    yield return new Tuple<string, Win32FileSystemEntry>( currentDirectory, systemEntry );

                    // Create hit for current search result
                    string resultPath = QuickIOPath.Combine( currentDirectory, systemEntry.Name );

                    // Check for Directory
                    if( searchOption == SearchOption.AllDirectories && systemEntry.IsDirectory )
                    {
                        directoryPathStack.Push( resultPath );
                    }
                }
            }
        }


        /// <summary>
        /// Determined metadata of directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryMetadata"/> started with the given directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static QuickIODirectoryMetadata EnumerateDirectoryMetadata( String path, QuickIOEnumerateOptions enumerateOptions )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

            IList<Win32FileSystemEntry> entries =
                new Win32FileHandleCollection( path ).Cast<Win32FileSystemEntry>().ToList();

            //  TODO: search another solution instead of enumerator
            if( entries.Count > 1 )
            {
                throw new InvalidOperationException( "Found more than one entry to one specific path." );
            }

            return EnumerateDirectoryMetadata( path, entries.ElementAt( 0 ), enumerateOptions ); ;
        }
        /// <summary>
        /// Determined metadata of directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="fileSystemEntry"><see cref="Win32FileSystemEntry"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryMetadata"/> started with the given directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static QuickIODirectoryMetadata EnumerateDirectoryMetadata( String path, Win32FileSystemEntry fileSystemEntry, QuickIOEnumerateOptions enumerateOptions )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

            // Results
            IList<QuickIOFileMetadata> subFiles = new List<QuickIOFileMetadata>();
            IList<QuickIODirectoryMetadata> subDirs = new List<QuickIODirectoryMetadata>();


            foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( path, QuickIOPatterns.PathMatchAll ) ) )
            {
                // Create hit for current search result
                var uncResultPath = QuickIOPath.Combine( path, systemEntry.Name );

                // if it's a file, add to the collection
                if( systemEntry.IsFile )
                {
                    subFiles.Add( new QuickIOFileMetadata( uncResultPath, systemEntry.FindData ) );
                }
                else
                {

                    subDirs.Add( EnumerateDirectoryMetadata( uncResultPath, systemEntry, enumerateOptions ) );
                }
            }
            return new QuickIODirectoryMetadata( path, fileSystemEntry.FindData, subDirs, subFiles );
        }


        /// <summary>
        /// Determined all files of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of files</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIOFileInfo> EnumerateFiles( String uncDirectoryPath, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIOFileInfo>>() != null );

            foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( uncDirectoryPath, pattern ) ) )
            {
                // Create hit for current search result
                var resultPath = QuickIOPath.Combine( uncDirectoryPath, systemEntry.Name );

                // Check for Directory
                if( systemEntry.IsFile )
                {
                    yield return new QuickIOFileInfo( resultPath, systemEntry.FindData );
                }
                else if(/* it's already a directory here */ searchOption == SearchOption.AllDirectories )
                {
                    foreach( var match in EnumerateFiles( resultPath, pattern, searchOption, enumerateOptions ) )
                    {
                        yield return match;
                    }
                }

            }

        }

        /// <summary>
        /// Determined all subfolders of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryInfo"/> collection of subfolders</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( string uncDirectoryPath,
            String pattern = QuickIOPatterns.PathMatchAll,
            SearchOption searchOption = SearchOption.TopDirectoryOnly,
            QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIODirectoryInfo>>() != null );

            // Stack
            Stack<string> directoryPathStack = new Stack<string>();
            directoryPathStack.Push( uncDirectoryPath );

            while( directoryPathStack.Count > 0 )
            {
                string currentDirectory = directoryPathStack.Pop();

                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( currentDirectory, pattern ) ) )
                {
                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( currentDirectory, systemEntry.Name );

                    // Check for Directory
                    if( systemEntry.IsDirectory )
                    {
                        yield return new QuickIODirectoryInfo( resultPath, systemEntry.FindData );

                        // SubFolders?!
                        if( searchOption == SearchOption.AllDirectories )
                        {
                            directoryPathStack.Push( resultPath );
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Determines the statistics of the given directory. This includes the number of files, folders and the total size in bytes.        
        /// </summary>
        /// <param name="uncDirectoryPath">Path to the directory to generate the statistics.</param>
        /// <returns>Provides the statistics of the directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static QuickIOFolderStatisticResult EnumerateDirectoryStatistics( String uncDirectoryPath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<QuickIOFolderStatisticResult>() != null );

            UInt64 fileCount = 0;
            UInt64 folderCount = 0;
            UInt64 totalSize = 0;

            Stack < string> directoryPathStack = new Stack<string>();
            directoryPathStack.Push( uncDirectoryPath );

            while( directoryPathStack.Count > 0 )
            {
                folderCount++;

                string currentDirectory = directoryPathStack.Pop();
                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( currentDirectory, QuickIOPatterns.PathMatchAll ) ) )
                {

                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( currentDirectory, systemEntry.Name );

                    // if it's a file, add to the collection
                    if( systemEntry.IsFile )
                    {
                        fileCount++;
                        totalSize += systemEntry.Bytes;
                    }
                    else
                    {
                        directoryPathStack.Push( resultPath );
                    }
                }
            }


            // Return result;
            return new QuickIOFolderStatisticResult( folderCount, fileCount, totalSize );
        }
    }
}
