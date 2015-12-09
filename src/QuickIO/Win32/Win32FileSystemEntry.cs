using SchwabenCode.QuickIO.Win32;
using System;
using System.IO;

namespace SchwabenCode.QuickIO.Win32
{
    internal class Win32FileSystemEntry
    {
        public Win32FileSystemEntry( Win32FileHandle fileHandle, Win32FindData findData )
        {
            FileHandle = fileHandle;
            FindData = findData;
        }

        public Win32FileHandle FileHandle
        {
            get;
            private set;
        }

        public Win32FindData FindData
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns name of entry (not fullname!)
        /// </summary>
        public String Name
        {
            get
            {
                return FindData.cFileName;
            }
        }

        /// <summary>
        /// Returns all <see cref="FileAttributes"/> responding to this <see cref="FindData"/>
        /// </summary>
        public FileAttributes Attributes
        {
            get
            {
                return FindData.dwFileAttributes;
            }
        }

        private bool? _isDirectory = null;
        /// <summary>
        /// Returns true if entry is a directory
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public Boolean IsDirectory
        {
            get
            {
                return FindData.IsDirectory;
            }
        }

        /// <summary>
        /// Returns true if entry is a file
        /// </summary>
        /// <remarks>Checks <see cref="FileAttributes.Directory"/></remarks>
        public Boolean IsFile
        {
            get
            {
                return FindData.IsFile;
            }
        }

        /// <summary>
        /// Returns total size of entry in Bytes
        /// </summary>
        public UInt64 Bytes
        {
            get
            {
                return FindData.Bytes;
            }
        }

        /// <summary>
        /// Returns type of entry
        /// </summary>
        public QuickIOFileSystemEntryType FileSystemEntryType
        {
            get { return FindData.FileSystemEntryType; }
        }
    }
}