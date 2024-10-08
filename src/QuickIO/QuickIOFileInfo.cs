﻿using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides properties and instance methods for files
/// </summary>
public sealed partial class QuickIOFileInfo : QuickIOFileSystemEntryBase
{
    /// <summary>
    /// Create new instance of <see cref="QuickIOFileInfo"/>
    /// </summary>
    public QuickIOFileInfo(string path)
        : this(new QuickIOPathInfo(path))
    {

    }

    /// <summary>
    /// Create new instance of <see cref="QuickIOFileInfo"/>
    /// </summary>
    public QuickIOFileInfo(FileInfo fileInfo)
        : this(new QuickIOPathInfo(fileInfo.FullName))
    {

    }


    /// <summary>
    /// Create new instance of <see cref="QuickIOFileInfo"/>
    /// </summary>
    public QuickIOFileInfo(QuickIOPathInfo pathInfo)
        : this(pathInfo, InternalQuickIO.GetFindDataFromPath(pathInfo))
    {
    }


    /// <summary>
    /// Creates the file information on the basis of the path and <see cref="Win32FindData"/>
    /// </summary>
    /// <param name="fullName">Full path to the file</param>
    /// <param name="win32FindData"><see cref="Win32FindData"/></param>
    internal QuickIOFileInfo(string fullName, Win32FindData win32FindData)
        : this(new QuickIOPathInfo(fullName), win32FindData)
    {
        RetriveDateTimeInformation(win32FindData);
        CalculateSize(win32FindData);
    }

    /// <summary>
    /// Creates the file information on the basis of the path and <see cref="Win32FindData"/>
    /// </summary>
    /// <param name="pathInfo">Full path to the file</param>
    /// <param name="win32FindData"><see cref="Win32FindData"/></param>
    internal QuickIOFileInfo(QuickIOPathInfo pathInfo, Win32FindData win32FindData)
        : base(pathInfo, win32FindData)
    {
        RetriveDateTimeInformation(win32FindData);
        CalculateSize(win32FindData);
    }

    /// <summary>
    /// Returns true if file exists. Uncached.
    /// </summary>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Path exists but it's a directory.</exception>
    public override bool Exists
    {
        get
        {
            return QuickIOFile.Exists(this);
        }
    }

    /// <summary>
    /// Size of the file. Cached.
    /// </summary>
    public ulong Bytes { get; private set; }

    /// <summary>
    /// Size of the file (returns <see cref="Bytes"/>).
    /// </summary>
    public ulong Length { get { return Bytes; } }


    /// <summary>
    /// Determines the time stamp of the given <see cref="Win32FindData"/>
    /// </summary>
    /// <param name="win32FindData"><see cref="Win32FindData"/></param>
    private void RetriveDateTimeInformation(Win32FindData win32FindData)
    {
        LastWriteTimeUtc = win32FindData.GetLastWriteTimeUtc();
        LastAccessTimeUtc = win32FindData.GetLastAccessTimeUtc();
        CreationTimeUtc = win32FindData.GetCreationTimeUtc();
    }

    /// <summary>
    /// Calculates the size of the file from the handle
    /// </summary>
    /// <param name="win32FindData"></param>
    private void CalculateSize(Win32FindData win32FindData)
    {
        Bytes = win32FindData.CalculateBytes();
    }
}
