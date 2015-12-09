// <copyright file="QuickIOFileSystemMetadataBase.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOFileSystemMetadataBase</summary>


using System;
using System.Diagnostics.Contracts;
using System.IO;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Abstract class for file system entries such as files and directory.
    /// Just for meta data reprentation
    /// </summary>
    public abstract class QuickIOFileSystemMetadataBase
    {
        #region Fields
        private string _fullName;
        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="path"></param>
        internal QuickIOFileSystemMetadataBase( string path, Win32FindData win32FindData )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Requires( win32FindData != null );

            FullNameUnc = QuickIOPath.ToPathUnc( FullNameUnc );
            FullName = QuickIOPath.ToPathRegular( FullNameUnc );

            this.LastWriteTimeUtc = win32FindData.GetLastWriteTimeUtc();
            this.LastAccessTimeUtc = win32FindData.GetLastAccessTimeUtc();
            this.CreationTimeUtc = win32FindData.GetCreationTimeUtc();

            Name = win32FindData.cFileName;

            Attributes = win32FindData.dwFileAttributes;
        }


        /// <summary>
        /// Path to file or directory (regular format)
        /// </summary>
        public String FullName { get; }

        /// <summary>
        /// Name of file or directory
        /// </summary>
        public String Name { get; }
        /// <summary>
        /// Path to file or directory (unc format)
        /// </summary>
        public String FullNameUnc { get; }

        #region FileTimes
        /// <summary>
        /// Gets the creation time (UTC)
        /// </summary>
        public DateTime CreationTimeUtc { get; }
        /// <summary>
        /// Gets the creation time
        /// </summary>
        public DateTime CreationTime => CreationTimeUtc.ToLocalTime();

        /// <summary>
        /// Gets the time (UTC) of last access. 
        /// </summary>
        public DateTime LastAccessTimeUtc { get; }
        /// <summary>
        /// Gets the time that the  file was last accessed
        /// </summary>
        public DateTime LastAccessTime => LastAccessTimeUtc.ToLocalTime();

        /// <summary>
        /// Gets the time (UTC) was last written to
        /// </summary>
        public DateTime LastWriteTimeUtc { get; }
        /// <summary>
        /// Gets the time the file was last written to.
        /// </summary>
        public DateTime LastWriteTime => LastWriteTimeUtc.ToLocalTime();

        #endregion

        /// <summary>
        /// File Attributes
        /// </summary>
        public FileAttributes Attributes { get; internal set; }

        /// <summary>
        /// Returns a new instance of <see cref="QuickIOPathInfo"/> of the current path
        /// </summary>
        /// <returns><see cref="QuickIOPathInfo"/></returns>
        public QuickIOPathInfo ToPathInfo()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( FullNameUnc ) );
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
            return new QuickIOPathInfo( FullNameUnc );
        }
    }
}