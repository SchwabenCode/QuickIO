using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.Win32API;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

namespace SchwabenCode.QuickIO.Internal.FileSystem
{
    internal static class EnumerateFileSystem
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
        private static IEnumerable<String> EnumerateSystemPaths( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular, QuickIOFileSystemEntryType? filterType = null )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<String>>() != null );


            IEnumerable<QuickIOFileSystemEntry> entries = EnumerateFileSystemEntries( uncDirectoryPath, pattern, searchOption, enumerateOptions, pathFormatReturn );

            // filter?
            if( filterType != null )
            {
                entries = entries.Where( entry => entry.Type == filterType );
            }

            return entries.Select( x => x.FullName );
        }


        /// <summary>
        /// Determined all sub file system entries of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static IEnumerable<QuickIOFileSystemEntry> EnumerateFileSystemEntries( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIOFileSystemEntryInfo>>() != null );

            foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( uncDirectoryPath, pattern ) ) )
            {
                // Create hit for current search result
                string resultPath = QuickIOPath.Combine( uncDirectoryPath, systemEntry.Name );
                string formattedPath = QuickIOPath.FormatPathByType( pathFormatReturn, resultPath );

                yield return new QuickIOFileSystemEntry( formattedPath, systemEntry.FileSystemEntryType );

                // Check for Directory
                if( searchOption == SearchOption.AllDirectories && systemEntry.IsDirectory )
                {
                    foreach( var match in EnumerateFileSystemEntries( resultPath, pattern, searchOption, enumerateOptions, pathFormatReturn ) )
                    {
                        yield return match;
                    }
                }
            }
        }



        /// <summary>
        /// Determined metadata of directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="findData"><see cref="Win32FindData"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryMetadata"/> started with the given directory</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static QuickIODirectoryMetadata EnumerateDirectoryMetadata( String uncDirectoryPath, Win32FindData findData, QuickIOEnumerateOptions enumerateOptions )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Requires( findData != null );
            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

            // Results
            var subFiles = new List<QuickIOFileMetadata>();
            var subDirs = new List<QuickIODirectoryMetadata>();

            foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( uncDirectoryPath, QuickIOPatternConstants.All ) ) )
            {
                // Create hit for current search result
                var uncResultPath = QuickIOPath.Combine( uncDirectoryPath, systemEntry.Name );

                // if it's a file, add to the collection
                if( systemEntry.IsFile )
                {
                    subFiles.Add( new QuickIOFileMetadata( uncResultPath, systemEntry.FindData ) );
                }
                else
                {
                    subDirs.Add( EnumerateDirectoryMetadata( uncResultPath, systemEntry.FindData, enumerateOptions ) );
                }
            }

            return new QuickIODirectoryMetadata( uncDirectoryPath, findData, subDirs, subFiles );
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
        internal static IEnumerable<QuickIOFileInfo> EnumerateFiles( String uncDirectoryPath, String pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
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
        /// <param name="pathInfo">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns><see cref="QuickIODirectoryInfo"/> collection of subfolders</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories( string uncDirectoryPath,
            String pattern = QuickIOPatternConstants.All,
            SearchOption searchOption = SearchOption.TopDirectoryOnly,
            QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIODirectoryInfo>>() != null );

            // Stack
            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push( uncDirectoryPath );

            while( directoryStack.Count > 0 )
            {
                string currentDirectory = directoryStack.Pop();

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
                            directoryStack.Push( resultPath );
                        }
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
        private static IEnumerable<T> EnumerateFileSystemEntries<T>( string uncDirectoryPath,
                        QuickIOFileSystemEntryType filterType,
            String pattern = QuickIOPatternConstants.All,
            SearchOption searchOption = SearchOption.TopDirectoryOnly,
            QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None ) where T : QuickIOFileSystemEntryBase,new()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncDirectoryPath ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIODirectoryInfo>>() != null );

            // Stack
            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push( uncDirectoryPath );

            while( directoryStack.Count > 0 )
            {
                string currentDirectory = directoryStack.Pop();

                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( currentDirectory, pattern ) ) )
                {
                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( currentDirectory, systemEntry.Name );

                    // Check for Directory
                    if( systemEntry.FileSystemEntryType == filterType )
                    {
                        yield return( T )Activator.CreateInstance( typeof( T ), resultPath, systemEntry.FindData );
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

            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push( uncDirectoryPath );

            while( directoryStack.Count > 0 )
            {
                folderCount++;

                string currentDirectory = directoryStack.Pop();
                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( currentDirectory, QuickIOPatternConstants.All ) ) )
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
                        directoryStack.Push( resultPath );
                    }

                }
            }


            // Return result;
            return new QuickIOFolderStatisticResult( folderCount, fileCount, totalSize );
        }
    }
}
