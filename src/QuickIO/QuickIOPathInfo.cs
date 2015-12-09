// <copyright file="QuickIOPathInfo.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/08/2014</date>
// <summary>Static implementation for paths, files and directories</summary>

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Principal;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides properties and instance method for paths
    /// </summary>
    public sealed class QuickIOPathInfo
    {
        /// <summary>
        /// Creates the path information container
        /// </summary>
        /// <param name="anyFullname">Full path to the file or directory (regular or unc)</param>
        public QuickIOPathInfo( String path ) :
            this( path, InternalQuickIO.GetFindDataFromPath( path ) )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
        }

        /// <summary>
        /// Creates the path information container
        /// </summary>
        /// <param name="anyFullname">Full path to the file or directory (regular or unc)</param>
        internal QuickIOPathInfo( String path, Win32FindData win32FindData )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Requires( win32FindData != null );

            this.FindData = win32FindData;

            this.IsRoot = QuickIOPath.IsRoot( path );
            this.Name = QuickIOPath.GetName( path );

            this.ParentFullName = QuickIOPath.GetParentPath( path );

            this.FullName = QuickIOPath.ToPathRegular( path );
            this.FullNameUnc = QuickIOPath.ToPathUnc( path );
        }


        public String GetFullname( QuickIOPathType formatReturn = QuickIOPathType.Regular )
        {
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<string>() ) );

            if( formatReturn == QuickIOPathType.Regular )
            {
                return FullName;
            }
            return FullNameUnc;
        }

        /// <summary>
        /// Path to file or directory (regular format)
        /// </summary>
        public String FullName { get; }

        /// <summary>
        /// Path to file or directory (unc format)
        /// </summary>
        public String FullNameUnc { get; }

        /// <summary>
        /// Name of file or directory
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// <see cref="PathType"/>
        /// </summary>
        public QuickIOPathType PathType { get; private set; } // TODO: NO SET!!

        /// <summary>
        /// Fullname of Root. null if current path is root.
        /// </summary>
        public string RootFullName { get; private set; } // TODO: NO SET!!

        /// <summary>
        /// Fullname of Parent. null if current path is root.
        /// </summary>
        public string ParentFullName { get; }

        /// <summary>
        /// Parent Directory
        /// </summary>
        public QuickIOPathInfo Parent => ( ParentFullName == null ? null : new QuickIOPathInfo( ParentFullName ) );

        /// <summary>
        /// <see cref="QuickIOPathLocation"/> of current path
        /// </summary>
        public QuickIOPathLocation PathLocation { get; }  // TODO: NO SET!!

        /// <summary>
        /// FindData
        /// </summary>
        internal Win32FindData FindData
        {
            get
            {
                if( IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide owner access" );
                }
                return _findData ?? ( _findData = InternalQuickIO.GetFindDataFromPath( FullNameUnc ) );
            }
            private set
            {
                _findData = value;
            }
        }
        private Win32FindData _findData;

        /// <summary>
        /// Attributes. Cached.
        /// </summary>
        /// <exception cref="NotSupportedException">if path is root</exception>
        public FileAttributes Attributes
        {
            get
            {
                if( IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide attributes" );
                }
                return FindData.dwFileAttributes;
            }
        }

        /// <summary>
        /// Returns true if current path is root
        /// </summary>
        public bool IsRoot { get; }

        /// <summary>
        /// Returns Root or null if current path is root
        /// </summary>
        public QuickIOPathInfo Root
        {
            get { return ( RootFullName == null ? null : new QuickIOPathInfo( RootFullName ) ); }
        }

        /// <summary>
        /// Returns true if path exists. Checks <see cref="QuickIOFileSystemEntryType"/>
        /// </summary>
        /// <returns></returns>
        public Boolean Exists
        {
            get
            {
                Contract.Requires( !String.IsNullOrWhiteSpace( FullNameUnc ) );
                return InternalQuickIO.Exists( FullNameUnc );
            }
        }

        ///// <summary>
        ///// Returns true if path exists. Checks <see cref="QuickIOFileSystemEntryType"/>
        ///// </summary>
        ///// <returns></returns>
        //public Boolean CheckExistance( QuickIOFileSystemEntryType? systemEntryType = null )
        //{
        //    return systemEntryType == null ? InternalQuickIO.Exists( this ) : InternalQuickIOCommon.Exists( FullNameUnc, ( QuickIOFileSystemEntryType ) systemEntryType );
        //}

        /// <summary>
        /// Returns true if path exists. Checks <see cref="QuickIOFileSystemEntryType"/> against the file system
        /// </summary>
        public QuickIOFileSystemEntryType SystemEntryType
        {
            get
            {
                Contract.Requires( !String.IsNullOrWhiteSpace( FullNameUnc ) );
                return InternalQuickIOCommon.DetermineFileSystemEntry( FullNameUnc );
            }

        }

        /// <summary>
        /// Returns current <see cref="QuickIOFileSystemSecurity"/>
        /// </summary>
        /// <returns><see cref="QuickIOFileSystemSecurity"/></returns>
        public QuickIOFileSystemSecurity GetFileSystemSecurity()
        {
            Contract.Ensures( Contract.Result<QuickIOFileSystemSecurity>() != null );
            return new QuickIOFileSystemSecurity( this );
        }

        /// <summary>
        /// Determines the owner
        /// </summary>
        /// <returns><see cref="NTAccount"/></returns>
        public NTAccount GetOwner()
        {
            Contract.Ensures( Contract.Result<NTAccount>() != null );

            if( IsRoot )
            {
                throw new NotSupportedException( "Root directory does not provide owner access" );
            }
            return GetOwnerIdentifier().Translate( typeof( NTAccount ) ) as NTAccount;
        }

        /// <summary>
        /// Determines the owner
        /// </summary>
        /// <returns><see cref="IdentityReference"/></returns>
        public IdentityReference GetOwnerIdentifier()
        {
            Contract.Ensures( Contract.Result<IdentityReference>() != null );

            if( IsRoot )
            {
                throw new NotSupportedException( "Root directory does not provide owner access" );
            }
            return GetFileSystemSecurity().FileSystemSecurityInformation.GetOwner( typeof( SecurityIdentifier ) );
        }

        /// <summary>
        /// Sets the owner
        /// </summary>
        public void SetOwner( NTAccount newOwner )
        {
            Contract.Requires( newOwner != null );

            if( IsRoot )
            {
                throw new NotSupportedException( "Root directory does not provide owner access" );
            }
            GetFileSystemSecurity().FileSystemSecurityInformation.SetOwner( newOwner.Translate( typeof( SecurityIdentifier ) ) );
        }

        /// <summary>
        /// Sets the owner
        /// </summary>
        public void SetOwner( IdentityReference newOwersIdentityReference )
        {
            Contract.Requires( newOwersIdentityReference != null );

            if( IsRoot )
            {
                throw new NotSupportedException( "Root directory does not provide owner access" );
            }
            GetFileSystemSecurity().FileSystemSecurityInformation.SetOwner( newOwersIdentityReference );
        }
    }
}
