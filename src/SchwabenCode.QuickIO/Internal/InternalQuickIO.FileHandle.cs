// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO.Internal
{
    internal static partial class InternalQuickIO
    {

        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="pathInfo">Path to the file system entry</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static SafeFileHandle CreateSafeFileHandle( QuickIOPathInfo pathInfo )
        {
            Contract.Requires( pathInfo != null );

            Contract.Ensures( Contract.Result<SafeFileHandle>() != null );

            return CreateSafeFileHandle( pathInfo.FullNameUnc );
        }

        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        private static SafeFileHandle CreateSafeFileHandle( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            Contract.Ensures( Contract.Result<SafeFileHandle>() != null );

            return Win32SafeNativeMethods.CreateFile( path, FileAccess.ReadWrite, FileShare.None, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero );
        }

        /// <summary>
        /// Returns the <see cref="SafeFileHandle"/> and fills <see cref="Win32FindData"/> from the passes path.
        /// </summary>
        /// <param name="path">Path to the file system entry</param>
        /// <returns><see cref="SafeFileHandle"/></returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static SafeFileHandle OpenReadWriteFileSystemEntryHandle( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            Contract.Ensures( Contract.Result<SafeFileHandle>() != null );

            return Win32SafeNativeMethods.OpenReadWriteFileSystemEntryHandle( path, ( 0x40000000 | 0x80000000 ), FileShare.Read | FileShare.Write | FileShare.Delete, IntPtr.Zero, FileMode.Open, ( 0x02000000 ), IntPtr.Zero );
        }

        ///// <summary>
        ///// Handles the options to the fired exception
        ///// </summary>
        //private static bool EnumerationHandleInvalidFileHandle( string path, QuickIOEnumerateOptions enumerateOptions, int win32Error )
        //{
        //    Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

        //    try
        //    {
        //        InternalQuickIOCommon.NativeExceptionMapping( path, win32Error );
        //    }
        //    catch( Exception ) when (enumerateOptions.HasFlag( QuickIOEnumerateOptions.SuppressAllExceptions ))
        //    {
        //        return true;
        //    }


        //    return false;
        //}
    }
}
