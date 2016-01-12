// <copyright file="InternalQuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/08/2014</date>
// <summary>Provides internal methods</summary>

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.PInvoke;
using Microsoft.Win32.SafeHandles;

namespace SchwabenCode.QuickIO.Internal
{

    internal static partial class InternalQuickIO
    {
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static void SetAllFileTimes( QuickIOPathInfo pathInfo, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            Contract.Requires( pathInfo != null );

            long longCreateTime = creationTimeUtc.ToFileTime();
            long longAccessTime = lastAccessTimeUtc.ToFileTime();
            long longWriteTime = lastWriteTimeUtc.ToFileTime();

            using( SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if( Win32SafeNativeMethods.SetAllFileTimes( fileHandle, ref longCreateTime, ref longAccessTime, ref longWriteTime ) == 0 )
                {
                    int win32Error = Marshal.GetLastWin32Error();
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Sets the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="utcTime">The time that is to be used (UTC)</param>
        public static void SetCreationTimeUtc( QuickIOPathInfo pathInfo, DateTime utcTime )
        {
            Contract.Requires( pathInfo != null );

            long longTime = utcTime.ToFileTime();
            using( SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if( !Win32SafeNativeMethods.SetCreationFileTime( fileHandle, ref longTime, IntPtr.Zero, IntPtr.Zero ) )
                {
                    int win32Error = Marshal.GetLastWin32Error();
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Sets the time at which the file or directory was last written to (UTC)
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="utcTime">The time that is to be used (UTC)</param>
        public static void SetLastWriteTimeUtc( QuickIOPathInfo pathInfo, DateTime utcTime )
        {
            Contract.Requires( pathInfo != null );

            long longTime = utcTime.ToFileTime();
            using( SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if( !Win32SafeNativeMethods.SetLastWriteFileTime( fileHandle, IntPtr.Zero, IntPtr.Zero, ref longTime ) )
                {
                    int win32Error = Marshal.GetLastWin32Error();
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

        /// <summary>
        /// Sets the time at which the file or directory was last accessed to (UTC)
        /// </summary>
        /// <param name="pathInfo">Affected file or directory</param>     
        /// <param name="utcTime">The time that is to be used (UTC)</param>
        public static void SetLastAccessTimeUtc( QuickIOPathInfo pathInfo, DateTime utcTime )
        {
            Contract.Requires( pathInfo != null );

            long longTime = utcTime.ToFileTime();
            using( SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle( pathInfo.FullNameUnc ) )
            {
                if( !Win32SafeNativeMethods.SetLastAccessFileTime( fileHandle, IntPtr.Zero, ref longTime, IntPtr.Zero ) )
                {
                    int win32Error = Marshal.GetLastWin32Error();
                    InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error );
                }
            }
        }

    }
}