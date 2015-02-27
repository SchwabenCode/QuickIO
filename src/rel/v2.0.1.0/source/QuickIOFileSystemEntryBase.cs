// <copyright file="QuickIOFileSystemEntryBase.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Abstract base implementation for files and directories</summary>

using System;
using System.ComponentModel;
using System.IO;
using System.Security.Principal;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

#if NET40_OR_GREATER
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;
#endif

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides properties and instance method for files and directories
    /// </summary>
    [Browsable( false )]
    [EditorBrowsable( EditorBrowsableState.Never )]
    public abstract class QuickIOFileSystemEntryBase
    {
        private DateTime _creationTimeUtc;
        private DateTime _lastAccessTimeUtc;
        private DateTime _lastWriteTimeUtc;

        /// <summary>
        /// Returns true if exists
        /// </summary>
        public abstract Boolean Exists { get; }
#if NET40_OR_GREATER
        /// <summary>
        /// Returns true if exists
        /// </summary>
        public abstract Task<Boolean> ExistsAsync { get; }
#endif

        /// <summary>
        /// True if file is readonly. Cached.
        /// </summary>
        public Boolean IsReadOnly
        {
            get
            {
                return InternalHelpers.ContainsFileAttribute( Attributes, FileAttributes.ReadOnly );
            }
            set
            {
                // Force Attribute Existance
                InternalHelpers.ForceFileAttributesExistance( Attributes, FileAttributes.ReadOnly, value );

                // Commit current attributes
                InternalQuickIO.SetAttributes( PathInfo, Attributes );
            }
        }

#if NET40_OR_GREATER
        /// <summary>
        /// True if file is readonly. Cached.
        /// </summary>
        public Task<Boolean> IsReadOnlyAsync
        {
            get
            {
                return NETCompatibility.AsyncExtensions.GetAsyncResult( () => IsReadOnly );
            }
            set
            {
                // Force Attribute Existance
                InternalHelpers.ForceFileAttributesExistance( Attributes, FileAttributes.ReadOnly, value.Result );

                // Commit current attributes
                InternalQuickIO.SetAttributes( PathInfo, Attributes );
            }
        }
#endif


        /// <summary>
        /// QuickIOPathInfo Container
        /// </summary>
        public QuickIOPathInfo PathInfo { get; protected internal set; }


        /// <summary>
        /// Returns true if exists and attends the FileSystemType
        /// </summary>
        /// <param name="throwExceptionIfFileSystemEntryTypeDiffers">Suppress error message if the path exists but the <see cref="QuickIOFileSystemEntryType"/> differs
        /// </param>
        /// <param name="exceptionValue">Default return value if <sparamref name="throwExceptionIfFileSystemEntryTypeDiffers"/> is true</param>
        /// <returns>True or <paramref name="exceptionValue"/> if <see cref="UnmatchedFileSystemEntryTypeException"/> thrown and <paramref name="throwExceptionIfFileSystemEntryTypeDiffers"/> is true</returns>
        public Boolean SafeExists( bool throwExceptionIfFileSystemEntryTypeDiffers = false, bool exceptionValue = false )
        {
            try
            {
                return Exists;
            }
            catch ( UnmatchedFileSystemEntryTypeException )
            {
                if ( throwExceptionIfFileSystemEntryTypeDiffers )
                {
                    return exceptionValue;
                }

                throw;
            }
        }

#if NET40_OR_GREATER
        /// <summary>
        /// Returns true if exists and attends the FileSystemType
        /// </summary>
        /// <param name="throwExceptionIfFileSystemEntryTypeDiffers">Suppress error message if the path exists but the <see cref="QuickIOFileSystemEntryType"/> differs
        /// </param>
        /// <param name="exceptionValue">Default return value if <sparamref name="throwExceptionIfFileSystemEntryTypeDiffers"/> is true</param>
        /// <returns>True or <paramref name="exceptionValue"/> if <see cref="UnmatchedFileSystemEntryTypeException"/> thrown and <paramref name="throwExceptionIfFileSystemEntryTypeDiffers"/> is true</returns>
        public Task<Boolean> SafeExistsAsync( bool throwExceptionIfFileSystemEntryTypeDiffers = false, bool exceptionValue = false )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => SafeExists( throwExceptionIfFileSystemEntryTypeDiffers, exceptionValue ) );

        }
#endif

        #region Base CTOR

        /// <summary>
        /// Initializes a new instance of the QuickIOAbstractBase class, which acts as a wrapper for a file path.
        /// </summary>
        /// <param name="pathInfo"><see cref="QuickIOPathInfo"/></param>
        /// <param name="findData"><see cref="Win32FindData"/></param>
        internal QuickIOFileSystemEntryBase( QuickIOPathInfo pathInfo, Win32FindData findData )
        {
            this.FindData = findData;
            this.PathInfo = pathInfo;
            if ( findData != null )
            {
                this.Attributes = findData.dwFileAttributes;
            }
        }
        #endregion

        /// <summary>
        /// Name of file or directory
        /// </summary>
        public String Name { get { return PathInfo.Name; } }

        #region Path Properties
        /// <summary>
        /// Full path of the directory or file.
        /// </summary>
        public String FullName { get { return PathInfo.FullName; } }
        /// <summary>
        /// Full path of the directory or file (unc format)
        /// </summary>
        public String FullNameUnc { get { return PathInfo.FullNameUnc; } }

        /// <summary>
        /// Fullname of Parent.
        /// </summary>
        public String ParentFullName { get { return PathInfo.ParentFullName; } }
        /// <summary>
        /// Parent. 
        /// </summary>
        public QuickIOPathInfo Parent { get { return PathInfo.Parent; } }


        /// <summary>
        /// <see cref="QuickIOPathLocation"/> of current path
        /// </summary>
        public QuickIOPathLocation PathLocation { get { return PathInfo.PathLocation; } }
        /// <summary>
        /// <see cref="PathType"/>
        /// </summary>
        public QuickIOPathType PathType { get { return PathInfo.PathType; } }

        /// <summary>
        /// Returns current <see cref="QuickIOFileSystemSecurity"/>
        /// </summary>
        /// <returns><see cref="QuickIOFileSystemSecurity"/></returns>
        public QuickIOFileSystemSecurity GetFileSystemSecurity()
        {
            return PathInfo.GetFileSystemSecurity( );
        }

        /// <summary>
        /// Fullname of Root. null if current path is root.
        /// </summary>
        public String RootFullName { get { return PathInfo.RootFullName; } }
        /// <summary>
        /// Returns Root or null if current path is root
        /// </summary>
        public QuickIOPathInfo Root { get { return PathInfo.Root; } }

        #endregion

        /// <summary>
        /// Attributes (Cached Value)
        /// </summary>
        public FileAttributes Attributes { get; protected internal set; }

        #region Time Properties
        #region UNC Times
        /// <summary>
        /// Gets the creation time (UTC)
        /// </summary>
        public DateTime CreationTimeUtc
        {
            get
            {
                if ( PathInfo.IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide time access" );
                }
                return _creationTimeUtc;
            }
            protected set
            {
                if ( PathInfo.IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide time access" );
                }
                _creationTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets the time (UTC) of last access. 
        /// </summary>
        public DateTime LastAccessTimeUtc
        {
            get
            {
                if ( PathInfo.IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide time access" );
                }
                return _lastAccessTimeUtc;
            }
            protected set
            {
                if ( PathInfo.IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide time access" );
                }
                _lastAccessTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets the time (UTC) was last written to
        /// </summary>
        public DateTime LastWriteTimeUtc
        {
            get
            {
                if ( PathInfo.IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide time access" );
                }
                return _lastWriteTimeUtc;
            }
            protected set
            {
                if ( PathInfo.IsRoot )
                {
                    throw new NotSupportedException( "Root directory does not provide time access" );
                }
                _lastWriteTimeUtc = value;
            }
        }

        #endregion

        #region LocalTime
        /// <summary>
        /// Gets the creation time
        /// </summary>
        public DateTime CreationTime { get { return CreationTimeUtc.ToLocalTime( ); } }

        /// <summary>
        /// Gets the time that the  file was last accessed
        /// </summary>
        public DateTime LastAccessTime { get { return LastAccessTimeUtc.ToLocalTime( ); } }

        /// <summary>
        /// Gets the time the file was last written to.
        /// </summary>
        public DateTime LastWriteTime { get { return LastWriteTimeUtc.ToLocalTime( ); } }
        #endregion
        #endregion

        #region Overrides
        /// <summary>
        /// Returns <see cref="FullName"/>
        /// </summary>
        /// <returns><see cref="FullName"/></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        /// <summary>
        /// Win32ApiFindData bag
        /// </summary>
        internal Win32FindData FindData { get; private set; }

        /// <summary>
        /// Determines the owner
        /// </summary>
        /// <returns><see cref="NTAccount"/></returns>
        public NTAccount GetOwner()
        {
            return PathInfo.GetOwner( );
        }

        /// <summary>
        /// Determines the owner
        /// </summary>
        /// <returns><see cref="IdentityReference"/></returns>
        public IdentityReference GetOwnerIdentifier()
        {
            return PathInfo.GetOwnerIdentifier( );
        }

        /// <summary>
        /// Determines the owner
        /// </summary>
        /// <returns><see cref="IdentityReference"/></returns>
        public void SetOwner( NTAccount newOwner )
        {
            PathInfo.SetOwner( newOwner );
        }

        /// <summary>
        /// Sets the owner
        /// </summary>
        public void SetOwner( IdentityReference newOwersIdentityReference )
        {
            PathInfo.SetOwner( newOwersIdentityReference );
        }
    }
}
