// <copyright file="Win32SafeNativeMethods.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Methods for secure Win32 API calls</summary>

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO.SafeNative
{
    /// <summary>
    /// Native Methods - take a look on www.pinvoke.net
    /// </summary>
    internal static class Win32SafeNativeMethods
    {
        #region kernel32.dll

        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetAllFileTimes( Win32FindData hFile, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime );

        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetCreationFileTime( Win32FindData hFile, ref long lpCreationTime, IntPtr lpLastAccessTime, IntPtr lpLastWriteTime );

        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetLastAccessFileTime( Win32FindData hFile, IntPtr lpCreationTime, ref long lpLastAccessTime, IntPtr lpLastWriteTime );

        [DllImport( "kernel32.dll", SetLastError = true, EntryPoint = "SetFileTime", ExactSpelling = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool SetLastWriteFileTime( Win32FindData hFile, IntPtr lpCreationTime, IntPtr lpLastAccessTime, ref long lpLastWriteTime );

        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool GetDiskFreeSpaceEx( string fullName,
        out UInt64 freeBytesAvailable,
        out UInt64 totalNumberOfBytes,
        out UInt64 totalNumberOfFreeBytes );

        /// <summary>
        /// Creates a new directory. If the underlying file system supports security on files and directories, the function applies a specified security descriptor to the new directory.
        /// </summary>
        /// <param name="fullName">The path of the directory to be created.</param>
        /// <param name="securityAttributes"></param>
        /// <remarks>There is a default string size limit for paths of 248 characters. This limit is related to how the CreateDirectory function parses paths.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// </remarks>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible errors include the following.
        /// </returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa363855(v=vs.85).aspx</remarks>
        [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool CreateDirectory( string fullName, IntPtr securityAttributes );

        /// <summary>
        /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
        /// </summary>
        /// <param name="fullName">The name of the file or device to be created or opened.</param>
        /// <param name="dwDesiredAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
        /// <param name="dwShareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). </param>
        /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes. This parameter can be NULL.</param>
        /// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist.</param>
        /// <param name="dwFlagsAndAttributes">The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files.</param>
        /// <param name="hTemplateFile">A valid handle to a template file with the GENERIC_READ access right. The template file supplies file attributes and extended attributes for the file that is being created</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx</remarks>
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
        /// Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used).
        /// </summary>
        /// <param name="fullName">The directory or path, and the file name, which can include wildcard characters, for example, an asterisk (*) or a question mark (?).</param>
        /// <param name="win32FindData">A pointer to the <see cref="Win32FileHandle"/> structure that receives information about a found file or directory.</param>
        /// <returns>If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the lpFindFileData parameter contains information about the first file or directory found.
        /// 
        /// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate. To get extended error information, call the GetLastError function.
        /// 
        /// If the function fails because no matching files can be found, the GetLastError function returns ERROR_FILE_NOT_FOUND.
        /// </returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern Win32FileHandle FindFirstFile( string fullName, [In, Out] Win32FindData win32FindData );

/// <summary>
        /// Retrieves the size of the specified file.
/// </summary>
        /// <param name="hFile">A handle to the file. The handle must have been created with either the GENERIC_READ or GENERIC_WRITE access right or equivalent. </param>
        /// <param name="lpFileSize">A pointer to a LARGE_INTEGER structure that receives the file size, in bytes.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// 
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern bool GetFileSizeEx( SafeHandle hFile, out long lpFileSize );

        /// <summary>
        /// Continues a file search from a previous call to the <see cref="FindFirstFile"/>
        /// </summary>
        /// <param name="findFileHandle">The search handle returned by a previous call to the FindFirstFile or FindFirstFileEx function.</param>
        /// <param name="findData">A pointer to the <see cref="Win32FindData"/> structure that receives information about the found file or subdirectory.</param>
        /// <returns>If the function succeeds, the return value is nonzero and the lpFindFileData parameter contains information about the next file or directory found.
        /// If the function fails, the return value is zero and the contents of lpFindFileData are indeterminate. To get extended error information, call the GetLastError function.
        /// If the function fails because no more matching files can be found, the GetLastError function returns ERROR_NO_MORE_FILES.
        /// </returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern bool FindNextFile( Win32FileHandle findFileHandle, [In, Out, MarshalAs( UnmanagedType.LPStruct )] Win32FindData findData );

        /// <summary>
        /// Moves an existing file or a directory, including its children.
        /// </summary>
        /// <param name="fullNameSource">The current name of the file or directory on the local computer.</param>
        /// <param name="fullNameTarget">The new name for the file or directory. The new name must not already exist. A new file may be on a different file system or drive. A new directory must be on the same drive.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool MoveFile( string fullNameSource, string fullNameTarget );

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="fullNameSource">The name of an existing file.</param>
        /// <param name="fullNameTarget">The name of the new file.</param>
        /// <param name="failOnExists">If this parameter is TRUE and the new file specified by lpNewFileName already exists, the function fails. If this parameter is FALSE and the new file already exists, the function overwrites the existing file and succeeds.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool CopyFile( string fullNameSource, string fullNameTarget, bool failOnExists );

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns>Returns true on success, false on error <see cref="Win32Exception"/></returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool DeleteFile( string fullName );

        /// <summary>
        /// Removes a directory.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns>Returns true on success, false on error <see cref="Win32Exception"/></returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool RemoveDirectory( string fullName );

        /// <summary>
        /// Set File Attributes
        /// </summary>
        /// <param name="fullName">Path to the entry</param>
        /// <param name="fileAttributes">Attributes</param>
        /// <returns>Returns true on success, false on error <see cref="Win32Exception"/></returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern bool SetFileAttributes( string fullName, uint fileAttributes );

        /// <summary>
        /// Retrieves file system attributes for a specified file or directory.
        /// </summary>
        /// <param name="fullName">The name of the file or directory. </param>
        /// <returns>Returns bits of attributes or DOWRD-1 (0xffffffff => UInt32.Max on error)</returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
        internal static extern uint GetFileAttributes( string fullName );

        /// <summary>
        /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted, FindFirstStreamTransactedW, or FindFirstStreamW functions.
        /// </summary>
        /// <param name="win32FindData">The file search handle. </param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// 
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = false )]
        [return: MarshalAs( UnmanagedType.Bool )]
        internal static extern bool FindClose( Win32FindData win32FindData );

        /// <summary>
        /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted, FindFirstStreamTransactedW, or FindFirstStreamW functions.
        /// </summary>
        /// <param name="findFile">The file search handle. </param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// 
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport( "kernel32.dll", SetLastError = false, CharSet = CharSet.Unicode )]
        internal static extern bool FindClose( SafeHandle findFile );

        /// <summary>
        /// Frees the specified local memory object and invalidates its handle.
        /// </summary>
        /// <param name="handle">A handle to the local memory object. </param>
        /// <returns>If the function succeeds, the return value is NULL.
        /// 
        /// If the function fails, the return value is equal to a handle to the local memory object. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport( "kernel32.dll", SetLastError = false, CharSet = CharSet.Unicode )]
        internal static extern IntPtr LocalFree( IntPtr handle );
        #endregion

    }
}
