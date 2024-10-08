﻿using System.Security.Principal;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides properties and instance method for paths
/// </summary>
public sealed class QuickIOPathInfo
{
    /// <summary>
    /// Creates the path information container
    /// </summary>
    /// <param name="anyFullname">Full path to the file or directory (regular or unc)</param>
    public QuickIOPathInfo(string anyFullname)
        : this(anyFullname, QuickIOPath.GetName(anyFullname))
    {
        QuickIOPath.ThrowIfPathContainsInvalidChars(anyFullname);
    }

    /// <summary>
    /// Creates the path information container
    /// </summary>
    /// <param name="anyFullname">Full path to the file or directory (regular or unc). Relative path will be recognized as local regular path.</param>
    /// <param name="name">Name of file or directory</param>
    public QuickIOPathInfo(string anyFullname, string name)
    {
        if (!QuickIOPath.TryParsePath(anyFullname, out QuickIOParsePathResult? parsePathResult, supportRelativePath: true))
        {
            // Unknown path
            throw new InvalidPathException("Unable to parse path", anyFullname);
        }

        FullNameUnc = parsePathResult.FullNameUnc;
        FullName = parsePathResult.FullName;
        ParentFullName = parsePathResult.ParentPath;
        RootFullName = parsePathResult.RootPath;
        IsRoot = parsePathResult.IsRoot;
        PathLocation = parsePathResult.PathLocation;
        Name = name;
        PathType = parsePathResult.PathType;

        if (PathLocation == QuickIOPathLocation.Local)
        {
            string testRoot = (IsRoot ? FullName : RootFullName)!;

            string[] allDrives = Environment.GetLogicalDrives();
            bool exists = Array.Exists(allDrives,(string drve) => drve.Equals(testRoot, StringComparison.OrdinalIgnoreCase));
            if (exists is false)
            {
                throw new UnsupportedDriveTypeException(testRoot);
            }
        }
    }

    /// <summary>
    /// Path to file or directory (regular format)
    /// </summary>
    public string FullName { get; private set; }

    /// <summary>
    /// Path to file or directory (unc format)
    /// </summary>
    public string FullNameUnc { get; private set; }

    /// <summary>
    /// Name of file or directory
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// <see cref="PathType"/>
    /// </summary>
    public QuickIOPathType PathType { get; private set; }

    /// <summary>
    /// Fullname of Root. null if current path is root.
    /// </summary>
    public string? RootFullName { get; private set; }

    /// <summary>
    /// Fullname of Parent. null if current path is root.
    /// </summary>
    public string? ParentFullName { get; set; }

    /// <summary>
    /// Parent Directory
    /// </summary>
    public QuickIOPathInfo? Parent
        => ParentFullName == null ? null : new QuickIOPathInfo(ParentFullName);

    /// <summary>
    /// <see cref="QuickIOPathLocation"/> of current path
    /// </summary>
    public QuickIOPathLocation PathLocation { get; private set; }

    /// <summary>
    /// FindData
    /// </summary>
    internal Win32FindData FindData
    {
        get
        {
            if (IsRoot)
            {
                throw new NotSupportedException("Root directory does not provide owner access");
            }
            return _findData ??= InternalQuickIO.GetFindDataFromPath(this);
        }
        set
        {
            _findData = value;
        }
    }
    private Win32FindData? _findData;

    /// <summary>
    /// Attributes. Cached.
    /// </summary>
    /// <exception cref="NotSupportedException">if path is root</exception>
    public FileAttributes Attributes
    {
        get
        {
            if (IsRoot)
            {
                throw new NotSupportedException("Root directory does not provide attributes");
            }
            return FindData.dwFileAttributes;
        }
    }

    /// <summary>
    /// Returns true if current path is root
    /// </summary>
    public bool IsRoot { get; private set; }

    /// <summary>
    /// Returns Root or null if current path is root
    /// </summary>
    public QuickIOPathInfo? Root
    {
        get { return (RootFullName == null ? null : new QuickIOPathInfo(RootFullName)); }
    }

    /// <summary>
    /// Returns true if path exists. Checks <see cref="QuickIOFileSystemEntryType"/>
    /// </summary>
    /// <returns></returns>
    public bool Exists
    {
        get
        {
            return InternalQuickIO.Exists(this);
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
            return InternalQuickIOCommon.DetermineFileSystemEntry(this);
        }

    }

    /// <summary>
    /// Returns current <see cref="QuickIOFileSystemSecurity"/>
    /// </summary>
    /// <returns><see cref="QuickIOFileSystemSecurity"/></returns>
    public QuickIOFileSystemSecurity GetFileSystemSecurity()
    {
        return new QuickIOFileSystemSecurity(this);
    }

    /// <summary>
    /// Determines the owner
    /// </summary>
    /// <returns><see cref="NTAccount"/></returns>
    public NTAccount? GetOwner()
    {
        if (IsRoot)
        {
            throw new NotSupportedException("Root directory does not provide owner access");
        }
        return GetOwnerIdentifier()?.Translate(typeof(NTAccount)) as NTAccount;
    }

    /// <summary>
    /// Determines the owner
    /// </summary>
    /// <returns><see cref="IdentityReference"/></returns>
    public IdentityReference? GetOwnerIdentifier()
    {
        if (IsRoot)
        {
            throw new NotSupportedException("Root directory does not provide owner access");
        }
        return GetFileSystemSecurity().FileSystemSecurityInformation.GetOwner(typeof(SecurityIdentifier));
    }

    /// <summary>
    /// Sets the owner
    /// </summary>
    public void SetOwner(NTAccount newOwner)
    {
        if (IsRoot)
        {
            throw new NotSupportedException("Root directory does not provide owner access");
        }
        GetFileSystemSecurity().FileSystemSecurityInformation.SetOwner(newOwner.Translate(typeof(SecurityIdentifier)));
    }

    /// <summary>
    /// Sets the owner
    /// </summary>
    public void SetOwner(IdentityReference newOwersIdentityReference)
    {
        if (IsRoot)
        {
            throw new NotSupportedException("Root directory does not provide owner access");
        }
        GetFileSystemSecurity().FileSystemSecurityInformation.SetOwner(newOwersIdentityReference);
    }
}
