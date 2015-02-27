// <copyright file="Win32SafeNativeMethods.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Methods for secure Win32 API calls</summary>

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Native Methods - take a look on www.pinvoke.net
    /// </summary>
    internal static class Win32SafeNativeMethods
    {
        #region advapi32.dll
        [DllImport( "advapi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true )]
        internal static extern uint GetSecurityDescriptorLength( IntPtr byteArray );


        [DllImport( "advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        internal static extern uint SetNamedSecurityInfo(
            string unicodePath,
            Win32SecurityObjectType objectType,
            Win32FileSystemEntrySecurityInformation securityInfo,
            IntPtr sidOwner,
            IntPtr sidGroup,
            IntPtr dacl,
            IntPtr sacl );

        [DllImport( "advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        internal static extern uint GetNamedSecurityInfo(
            string unicodePath,
            Win32SecurityObjectType securityObjectType,
            Win32FileSystemEntrySecurityInformation securityInfo,
            out IntPtr sidOwner,
            out IntPtr sidGroup,
            out IntPtr dacl,
            out IntPtr sacl,
            out IntPtr securityDescriptor );

        [DllImport( "advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        internal static extern bool ConvertStringSidToSid( String sidString, ref IntPtr sidHandle );

        [DllImport( "advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        internal static extern uint LookupAccountSid( String systemName, IntPtr sidHandle, StringBuilder name, ref int cchName, StringBuilder domainName, ref int cchDomainName, out int peUse );

        #endregion

        #region kernel32.dll

        /// <summary>
        /// Sets the last all times for files or directories
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        internal static extern Int32 SetAllFileTimes( SafeFileHandle fileHandle, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime );

        /// <summary>
        /// Sets the last creation time for files or directories
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetCreationFileTime( SafeFileHandle hFile, ref long lpCreationTime, IntPtr lpLastAccessTime, IntPtr lpLastWriteTime );

        /// <summary>
        /// Sets the last acess time for files or directories
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetLastAccessFileTime( SafeFileHandle hFile, IntPtr lpCreationTime, ref long lpLastAccessTime, IntPtr lpLastWriteTime );

        /// <summary>
        /// Sets the last write time for files or directories
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetLastWriteFileTime( SafeFileHandle hFile, IntPtr lpCreationTime, IntPtr lpLastAccessTime, ref long lpLastWriteTime );

        /// <summary>
        /// Create directory
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool CreateDirectory( string fullName, IntPtr securityAttributes );

        /// <summary>
        /// Creates a file / directory or opens an handle for an existing file.
        /// <b>If you want to get an handle for an existing folder use <see cref="OpenReadWriteFileSystemEntryHandle"/> with ( 0x02000000 ) as attribute and FileMode ( 0x40000000 | 0x80000000 )</b>
        /// Otherwise it you'll get an invalid handle
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        internal static extern SafeFileHandle CreateFile(
             string fullName,
             [MarshalAs( UnmanagedType.U4 )] FileAccess dwDesiredAccess,
             [MarshalAs( UnmanagedType.U4 )] FileShare dwShareMode,
             IntPtr lpSecurityAttributes,
             [MarshalAs( UnmanagedType.U4 )] FileMode dwCreationDisposition,
             [MarshalAs( UnmanagedType.U4 )] FileAttributes dwFlagsAndAttributes,
             IntPtr hTemplateFile );

        /// <summary>
        /// Use this to open an handle for an existing file or directory to change for example the timestamps
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "CreateFile" )]
        internal static extern SafeFileHandle OpenReadWriteFileSystemEntryHandle(
             string fullName,
             uint dwAccess,
             [MarshalAs( UnmanagedType.U4 )] FileShare dwShareMode,
             IntPtr lpSecurityAttributes,
              [MarshalAs( UnmanagedType.U4 )]FileMode dwMode,
             uint dwAttribute,
             IntPtr hTemplateFile );

        /// <summary>
        /// Open handle for appending
        /// <br/>
        /// FileMode has to be 0x0004 for internal appending mode
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "CreateFile" )]
        internal static extern SafeFileHandle CreateFileForAppend(
             string fullName,
             [MarshalAs( UnmanagedType.U4 )] uint dwDesiredAccess,
             [MarshalAs( UnmanagedType.U4 )] FileShare dwShareMode,
             IntPtr lpSecurityAttributes,
             [MarshalAs( UnmanagedType.U4 )] FileMode dwCreationDisposition,
             [MarshalAs( UnmanagedType.U4 )] FileAttributes dwFlagsAndAttributes,
             IntPtr hTemplateFile );

        /// <summary>
        /// Finds first file of given path
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern Win32FileHandle FindFirstFile( string fullName, [In, Out] Win32FindData win32FindData );

        /// <summary>
        /// Finds next file of current handle
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern bool FindNextFile( Win32FileHandle findFileHandle, [In, Out, MarshalAs( UnmanagedType.LPStruct )] Win32FindData win32FindData );

        /// <summary>
        /// Moves a directory
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool MoveFile( string fullNameSource, string fullNameTarget );

        /// <summary>
        /// Copy file
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool CopyFile( string fullNameSource, string fullNameTarget, bool failOnExists );

        /// <summary>
        /// Removes a file.
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool DeleteFile( string fullName );

        /// <summary>
        /// Removes a file.
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool RemoveDirectory( string fullName );

        /// <summary>
        /// Set File Attributes
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern bool SetFileAttributes( string fullName, uint fileAttributes );

        /// <summary>
        /// Gets Attributes of given path
        /// </summary>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern uint GetFileAttributes( string fullName );

        /// <summary>
        /// Close Hnalde
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = false, CharSet = CharSet.Unicode )]
        internal static extern bool FindClose( SafeHandle fileHandle );

        /// <summary>
        /// Free unmanaged memory
        /// </summary>
        [DllImport( "kernel32.dll", SetLastError = false, CharSet = CharSet.Unicode )]
        internal static extern IntPtr LocalFree( IntPtr handle );

        /// <summary>
        /// QuickIOShareInfo information
        /// </summary>
        /// <returns></returns>
        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool GetDiskFreeSpaceEx( string uncPath,
        out UInt64 freeBytes,
        out UInt64 totalBytes,
        out UInt64 totalFreeBytes );
        #endregion

        #region netapi32.dll
        /// <summary>
        /// Enumerate shares (NT)
        /// </summary>
        /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/bb525387(v=vs.85).aspx</remarks>
        [DllImport( "netapi32", CharSet = CharSet.Unicode, SetLastError = true )]
        public static extern int NetShareEnum(
            string lpServerName,
            int dwLevel,
            out IntPtr lpBuffer,
            int dwPrefMaxLen,
            out int entriesRead,
            out int totalEntries,
            ref int hResume );

        [DllImport( "netapi32", CharSet = CharSet.Unicode, SetLastError = true )]
        public static extern int NetApiBufferFree( IntPtr lpBuffer );
        #endregion
    }
}
