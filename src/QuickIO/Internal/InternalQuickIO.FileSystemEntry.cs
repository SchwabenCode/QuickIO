using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;

namespace SchwabenCode.QuickIO.Internal
{
    internal static partial class InternalQuickIO
    {
        /// <summary>
        /// Determined all sub system entries of a directory
        /// </summary>
        /// <param name="uncDirectoryPath">Path of the directory</param>
        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
        /// <param name="searchOption"><see cref="SearchOption"/></param>
        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
        /// <returns>Collection of <see cref="QuickIODirectoryInfo"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static IEnumerable<QuickIOFileSystemEntryInfo> EnumerateFileSystemEntryInfos( String path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<IEnumerable<QuickIOFileSystemEntryInfo>>() != null );

            // Stack
            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push( path );

            while( directoryStack.Count > 0 )
            {
                string currentDirectory = directoryStack.Pop();

                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( currentDirectory, pattern ) ) )
                {
                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( currentDirectory, systemEntry.Name );

                    // determine entry
                    QuickIOFileSystemEntryType entryType = systemEntry.IsDirectory ? QuickIOFileSystemEntryType.Directory : QuickIOFileSystemEntryType.File;

                    // return result
                    yield return new QuickIOFileSystemEntryInfo( new QuickIOPathInfo( resultPath, systemEntry.FindData ), entryType );



                    // Check for Directory
                    if( searchOption == SearchOption.AllDirectories && entryType == QuickIOFileSystemEntryType.Directory )
                    {
                        directoryStack.Push( resultPath );
                    }
                }
            }
        }
    }
}
