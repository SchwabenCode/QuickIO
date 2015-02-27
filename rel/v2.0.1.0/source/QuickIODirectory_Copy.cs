// <copyright file="QuickIODirectory_Copy.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for copy</summary>

using System;
using System.IO;
using SchwabenCode.QuickIO.Internal;


#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif
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
        public static void Copy( String source, String target, bool overwrite = false )
        {
            Invariant.NotEmpty( source );
            Invariant.NotEmpty( target );

            Copy( new QuickIODirectoryInfo( source ), new QuickIOPathInfo( target ), overwrite );
        }

        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        public static void Copy( QuickIODirectoryInfo source, QuickIOPathInfo target, bool overwrite = false )
        {
            Invariant.NotNull( source );
            Invariant.NotNull( target );

            var allContentUncPaths = EnumerateFileSystemEntryPaths( source, QuickIOPatternConstants.All, SearchOption.AllDirectories, QuickIOPathType.UNC );
            foreach ( var entry in allContentUncPaths )
            {
                string sourcePathUnc = entry.Key;
                var targetFullnameUnc = target.FullNameUnc + sourcePathUnc.Substring( source.FullNameUnc.Length );

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


#if NET40_OR_GREATER
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current directory using a sperare Task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public static Task<QuickIODirectoryMetadata> GetMetadastaAsync( String directoryPath )
        {
            return Compatibility.NETCompatibility.AsyncExtensions.GetAsyncResult( () => InternalQuickIO.EnumerateDirectoryMetadata( new QuickIOPathInfo( directoryPath ) ) );
        }

#endif
    }
}
