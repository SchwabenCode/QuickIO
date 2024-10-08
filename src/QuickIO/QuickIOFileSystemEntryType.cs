﻿namespace SchwabenCode.QuickIO;

/// <summary>
/// Represents type of path or handle
/// </summary>
public enum QuickIOFileSystemEntryType
{
    /// <summary>
    /// Represents a file (<see cref="FileAttributes"/> does not contain directory flag)
    /// </summary>
    File = 0,

    /// <summary>
    /// Represents a directory (<see cref="FileAttributes"/>contains directory flag)
    /// </summary>
    Directory = 1
}
