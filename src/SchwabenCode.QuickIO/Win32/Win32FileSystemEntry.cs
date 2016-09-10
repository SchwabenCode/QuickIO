// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.IO;

namespace SchwabenCode.QuickIO.Win32
{
    public class Win32FileSystemEntry
    {
        public Win32FileSystemEntry( Win32FileHandle fileHandle, Win32FindData findData )
        {
            FileHandle = fileHandle;
            FindData = findData;
        }

        public Win32FileHandle FileHandle { get; }

        public Win32FindData FindData { get; }

        /// <summary>
        /// Returns name of entry (not fullname!)
        /// </summary>
        public String Name => FindData.cFileName;

        /// <summary>
        /// Returns all <see cref="FileAttributes"/> responding to this <see cref="FindData"/>
        /// </summary>
        public FileAttributes Attributes => FindData.dwFileAttributes;

        /// <summary>
        /// Returns true if entry is a directory
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public Boolean IsDirectory => FindData.IsDirectory();

        /// <summary>
        /// Returns true if entry is a file
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public Boolean IsFile => FindData.IsFile();

        /// <summary>
        /// Returns total size of entry in Bytes
        /// </summary>
        public UInt64 Bytes => FindData.GetBytes();

        /// <summary>
        /// Returns type of entry
        /// </summary>
        public QuickIOFileSystemEntryType FileSystemEntryType => FindData.GetFileSystemEntryType();

        public Boolean IsValidEntry => !FindData.IsSystemDirectoryEntry();
    }
}