// <copyright file="QuickIOFileMetadata.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOFileMetadata</summary>

using System;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// File metadata information
    /// </summary>
    public sealed class QuickIOFileMetadata : QuickIOFileSystemMetadataBase
    {
        /// <summary>
        /// Creates instance of <see cref="QuickIOFileMetadata"/>
        /// </summary>
        /// <param name="uncResultPath">UNC Path of current file</param>
        /// <param name="win32FindData">Win32FindData of current file</param>
        internal QuickIOFileMetadata( string uncResultPath, Win32FindData win32FindData )
            : base( uncResultPath )
        {
            base.SetFindData( win32FindData );

            Bytes = win32FindData.CalculateBytes( );
        }

        /// <summary>
        /// Size of the file. 
        /// </summary>
        public UInt64 Bytes { get; private set; }


        /// <summary>
        /// Returns a new instance of <see cref="QuickIOFileInfo"/> of the current file
        /// </summary>
        /// <returns><see cref="QuickIOFileInfo"/></returns>
        public QuickIOFileInfo QuickIOFileInfo()
        {
            return new QuickIOFileInfo( ToPathInfo( ) );
        }
    }
}