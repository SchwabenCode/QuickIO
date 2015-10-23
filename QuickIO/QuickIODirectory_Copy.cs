// <copyright file="QuickIODirectory_Copy.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for copy</summary>

using System;
using System.Diagnostics.Contracts;
using System.IO;

using SchwabenCode.QuickIO.Internal;


using System.Threading;
using System.Threading.Tasks;
namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <param name="cancellationToken">Cancallation Token</param>
        public static void Copy( String source, String target, bool overwrite = false, CancellationToken cancellationToken = default (CancellationToken ) )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( source ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( target ) );

            Copy( new QuickIODirectoryInfo( source ), new QuickIOPathInfo( target ), overwrite, cancellationToken );
        }

        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <param name="cancellationToken">Cancallation Token</param>
        public static void Copy( QuickIODirectoryInfo source, QuickIOPathInfo target, bool overwrite = false, CancellationToken cancellationToken = default (CancellationToken ) )
        {
            Contract.Requires( source != null );
            Contract.Requires( target != null );

            var allContentUncPaths = EnumerateFileSystemEntryPaths( source, QuickIOPatternConstants.All, SearchOption.AllDirectories, QuickIOPathType.UNC );
            foreach ( var entry in allContentUncPaths )
            {
                cancellationToken.ThrowIfCancellationRequested( );
                string sourcePathUnc = entry.Key;
                var targetFullnameUnc = target.FullNameUnc + sourcePathUnc.Substring( source.FullNameUnc.Length );

                if ( !QuickIODirectory.Exists( targetFullnameUnc ) )
                {

                }

                switch ( entry.Value )
                {
                    case QuickIOFileSystemEntryType.Directory:
                        {
                            QuickIODirectory.Create( targetFullnameUnc, true );
                        }
                        break;

                    case QuickIOFileSystemEntryType.File:
                        {
                            QuickIOFile.Copy( sourcePathUnc, targetFullnameUnc, overwrite );
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadastaAsync( String directoryPath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( directoryPath ) );

            Contract.Ensures( Contract.Result<Task<QuickIODirectoryMetadata>>( ) != null );

            return Compatibility.NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => InternalQuickIO.EnumerateDirectoryMetadata( new QuickIOPathInfo( directoryPath ) ) );
        }
    }
}
