// <copyright file="QuickIODirectoryMetadata.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectoryMetadata</summary>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Directory metadata information
    /// </summary>
    public sealed partial class QuickIODirectoryMetadata : QuickIOFileSystemMetadataBase
    {
        /// <summary>
        /// Creates instance of <see cref="QuickIODirectoryMetadata"/>
        /// </summary>
        /// <param name="win32FindData">Win32FindData of current directory</param>
        /// <param name="subDirs">Directories in current directory</param>
        /// <param name="subFiles">Files in current directory</param>
        /// <param name="uncFullname">UNC Path of current directory</param>
        internal QuickIODirectoryMetadata( string uncFullname, Win32FindData win32FindData, IList<QuickIODirectoryMetadata> subDirs, IList<QuickIOFileMetadata> subFiles )
            : base( uncFullname )
        {
            Directories = new ReadOnlyCollection<QuickIODirectoryMetadata>( subDirs );
            Files = new ReadOnlyCollection<QuickIOFileMetadata>( subFiles );

            base.SetFindData( win32FindData );
        }

        /// <summary>
        /// Directories in current directory
        /// </summary>
        public ReadOnlyCollection<QuickIODirectoryMetadata> Directories { get; internal set; }

        /// <summary>
        /// Files in current directory
        /// </summary>
        public ReadOnlyCollection<QuickIOFileMetadata> Files { get; internal set; }

        private UInt64? _bytes;
        /// <summary>
        /// Size of the file. 
        /// </summary>
        public UInt64 Bytes
        {
            get
            {
                if ( _bytes == null )
                {
                    UInt64 bytes = 0;

                    #region Dirs

                    {
                        for ( int i = 0 ; i < Directories.Count ; i++ )
                        {
                            bytes += +Directories[ i ].Bytes;
                        }
                    }

                    #endregion

                    #region Files
                    {
                        for ( int i = 0 ; i < Files.Count ; i++ )
                        {
                            bytes += +Files[ i ].Bytes;
                        }
                    }
                    #endregion

                    _bytes = bytes;
                }
                return ( UInt64 ) _bytes;
            }
        }

        /// <summary>
        /// Returns a new instance of <see cref="QuickIODirectoryInfo"/> of the current directory
        /// </summary>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public QuickIODirectoryInfo ToDirectoryInfo()
        {
            return new QuickIODirectoryInfo( ToPathInfo( ) );
        }
    }
}
