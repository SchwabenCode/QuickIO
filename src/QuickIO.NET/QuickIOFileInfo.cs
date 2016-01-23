// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using SchwabenCode.QuickIO.Core;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides properties and instance methods for files
    /// </summary>
    public sealed partial class QuickIOFileInfo : QuickIOFileSystemEntryBase
    {
        /// <summary>
        /// Create new instance of <see cref="QuickIOFileInfo"/>
        /// </summary>
        public QuickIOFileInfo( String path )
            : this( new QuickIOPathInfo( QuickIOPath.GetFullPath( path ) ) )
        {

        }

        /// <summary>
        /// Create new instance of <see cref="QuickIOFileInfo"/>
        /// </summary>
        public QuickIOFileInfo( System.IO.FileInfo fileInfo )
            : this( new QuickIOPathInfo( fileInfo.FullName ) )
        {

        }


        /// <summary>
        /// Create new instance of <see cref="QuickIOFileInfo"/>
        /// </summary>
        public QuickIOFileInfo( QuickIOPathInfo pathInfo )
            : this( pathInfo, pathInfo.FindData )
        {
        }


        /// <summary>
        /// Creates the file information on the basis of the path and <see cref="Win32FindData"/>
        /// </summary>
        /// <param name="fullName">Full path to the file</param>
        /// <param name="win32FindData"><see cref="Win32FindData"/></param>
        internal QuickIOFileInfo( String fullName, Win32FindData win32FindData )
            : this( new QuickIOPathInfo( fullName ), win32FindData )
        {
           
        }

        /// <summary>
        /// Creates the file information on the basis of the path and <see cref="Win32FindData"/>
        /// </summary>
        /// <param name="pathInfo">Full path to the file</param>
        /// <param name="win32FindData"><see cref="Win32FindData"/></param>
        internal QuickIOFileInfo( QuickIOPathInfo pathInfo, Win32FindData win32FindData )
            : base( pathInfo, win32FindData )
        {
            
        }

        /// <summary>
        /// Returns true if file exists. Uncached.
        /// </summary>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a directory.</exception>
        public override Boolean Exists => QuickIOFile.Exists( this );

        /// <summary>
        /// Size of the file. Cached.
        /// </summary>
        public UInt64 Bytes => FindData.GetBytes();

        /// <summary>
        /// Size of the file (returns <see cref="Bytes"/>).
        /// </summary>
        public UInt64 Length => FindData.GetBytes();
    }
}
