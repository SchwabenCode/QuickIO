﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Core;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides properties and instance methods for directories
    /// </summary>
    public sealed partial class QuickIODirectoryInfo : QuickIOFileSystemEntryBase
    {
        #region CTOR

        /// <summary>
        /// Create new instance of <see cref="QuickIODirectoryInfo"/>
        /// </summary>
        public QuickIODirectoryInfo( String path )
            : this( new QuickIOPathInfo( QuickIOPath.GetFullPath( path ) ) )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }

        /// <summary>
        /// Create new instance of <see cref="QuickIODirectoryInfo"/>
        /// </summary>
        public QuickIODirectoryInfo( System.IO.DirectoryInfo directoryInfo )
            : this( new QuickIOPathInfo( directoryInfo.FullName ) )
        {
            Contract.Requires( directoryInfo != null );
        }

        /// <summary>
        /// Create new instance of <see cref="QuickIODirectoryInfo"/>
        /// </summary>
        public QuickIODirectoryInfo( QuickIOPathInfo pathInfo )
            : this( pathInfo, pathInfo.IsRoot ? null : pathInfo.FindData )
        {
            Contract.Requires( pathInfo != null );
        }

        /// <summary>
        /// Creates the folder information on the basis of the path and the handles
        /// </summary>
        /// <param name="pathInfo"><see cref="QuickIOPathInfo"/></param>
        /// <param name="win32FindData"><see cref="Win32FindData"/></param>
        internal QuickIODirectoryInfo( QuickIOPathInfo pathInfo, Win32FindData win32FindData ) :
            base( pathInfo, win32FindData )
        {

        }

        /// <summary>
        /// Creates the folder information on the basis of the path and the handles
        /// </summary>
        /// <param name="fullname">Full path to the directory</param>
        /// <param name="win32FindData"><see cref="Win32FindData"/></param>
        internal QuickIODirectoryInfo( String fullname, Win32FindData win32FindData )
            : this( new QuickIOPathInfo( fullname ), win32FindData )
        {

        }


        #endregion

        #region Properties
        /// <summary>
        /// Returns true if current path is root
        /// </summary>
        public Boolean IsRoot => PathInfo.IsRoot;

        #endregion

        /// <summary>
        /// Returns true if directory exists. Result starts a file system call and is not cached.
        /// </summary>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a file..</exception>
        public override Boolean Exists => QuickIODirectory.Exists( this );
    }
}
