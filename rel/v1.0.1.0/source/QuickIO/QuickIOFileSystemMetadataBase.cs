// <copyright file="QuickIOFileSystemMetadataBase.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOFileSystemMetadataBase</summary>


using System;
using System.IO;
using SchwabenCode.QuickIO.Win32API;

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
        /// <param name="uncResultPath"></param>
        protected QuickIOFileSystemMetadataBase( string uncResultPath )
        {
            FullNameUnc = uncResultPath;
        }

        /// <summary>
        /// Transfers data from find data
        /// </summary>
        internal void SetFindData( Win32FindData win32FindData )
        {
            this.LastWriteTimeUtc = win32FindData.GetLastWriteTimeUtc( );
            this.LastAccessTimeUtc = win32FindData.GetLastAccessTimeUtc( );
            this.CreationTimeUtc = win32FindData.GetCreationTimeUtc( );

            Name = win32FindData.cFileName;

            Attributes = win32FindData.dwFileAttributes;
        }


        /// <summary>
        /// Path to file or directory (regular format)
        /// </summary>
        public String FullName
        {
            get
            {
                return _fullName ?? ( _fullName = QuickIOPath.ToRegularPath( FullNameUnc ) );
            }
        }

        /// <summary>
        /// Name of file or directory
        /// </summary>
        public String Name { get; private set; }
        /// <summary>
        /// Path to file or directory (unc format)
        /// </summary>
        public String FullNameUnc { get; private set; }

        #region FileTimes
        /// <summary>
        /// Gets the creation time (UTC)
        /// </summary>
        public DateTime CreationTimeUtc { get; private set; }
        /// <summary>
        /// Gets the creation time
        /// </summary>
        public DateTime CreationTime
        {
            get
            {
                return LastWriteTimeUtc.ToLocalTime( );
            }
        }

        /// <summary>
        /// Gets the time (UTC) of last access. 
        /// </summary>
        public DateTime LastAccessTimeUtc { get; private set; }
        /// <summary>
        /// Gets the time that the  file was last accessed
        /// </summary>
        public DateTime LastAccessTime
        {
            get
            {
                return LastAccessTimeUtc.ToLocalTime( );
            }
        }

        /// <summary>
        /// Gets the time (UTC) was last written to
        /// </summary>
        public DateTime LastWriteTimeUtc { get; private set; }
        /// <summary>
        /// Gets the time the file was last written to.
        /// </summary>
        public DateTime LastWriteTime
        {
            get
            {
                return LastWriteTimeUtc.ToLocalTime( );
            }
        }
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
            return new QuickIOPathInfo( FullNameUnc );
        }
    }
}