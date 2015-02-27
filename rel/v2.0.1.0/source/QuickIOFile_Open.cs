// <copyright file="QuickIOFile_Open.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIOFile</summary>

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOFile
    {
        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="path">The file to open.</param>
        /// <param name="mode"><see cref="FileMode"/></param>
        /// <returns>A <see cref="FileStream"/> with read and write access and not shared.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/b9skfh7s(v=vs.110).aspx</remarks>
        public static FileStream Open( string path, FileMode mode = FileMode.Open )
        {
            return Open( new QuickIOPathInfo( path ), mode );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="info">The file to open. </param>
        /// <param name="mode"><see cref="FileMode"/></param>
        /// <returns>A <see cref="FileStream"/> with read and write access and not shared.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/b9skfh7s(v=vs.110).aspx</remarks>
        public static FileStream Open( QuickIOPathInfo info, FileMode mode = FileMode.Open )
        {
            return OpenFileStream( info, FileAccess.ReadWrite, mode, FileShare.None );
        }


        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="path">The file to open. </param>
        /// <param name="mode"><see cref="FileMode"/> </param>
        /// <param name="access"><see cref="FileAccess"/> </param>
        /// <returns>An unshared <see cref="FileStream"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/s67691sb(v=vs.110).aspx</remarks>
        public static FileStream Open( string path, FileMode mode, FileAccess access )
        {
            return Open( new QuickIOPathInfo( path ), mode, access );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="pathInfo">The file to open. </param>
        /// <param name="mode"><see cref="FileMode"/> </param>
        /// <param name="access"><see cref="FileAccess"/> </param>
        /// <returns>An unshared <see cref="FileStream"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/s67691sb(v=vs.110).aspx</remarks>
        public static FileStream Open( QuickIOPathInfo pathInfo, FileMode mode, FileAccess access )
        {
            return OpenFileStream( pathInfo, access, mode, FileShare.None );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/> 
        /// </summary>
        private static FileStream OpenFileStream( QuickIOPathInfo pathInfo, FileAccess fileAccess, FileMode fileOption = FileMode.Open, FileShare shareMode = FileShare.Read, Int32 buffer = 0 )
        {
            var fileHandle = Win32SafeNativeMethods.CreateFile( pathInfo.FullNameUnc, fileAccess, shareMode, IntPtr.Zero, fileOption, 0, IntPtr.Zero );
            var win32Error = Marshal.GetLastWin32Error( );
            if ( fileHandle.IsInvalid )
            {
                InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error ); // Throws an exception
            }

            return buffer > 0 ? new FileStream( fileHandle, fileAccess, buffer ) : new FileStream( fileHandle, fileAccess );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/> 
        /// </summary>
        private static FileStream OpenAppendFileStream( QuickIOPathInfo pathInfo, FileAccess fileAccess, FileMode fileOption = FileMode.Open, FileShare shareMode = FileShare.Read, Int32 buffer = 0 )
        {
            var fileHandle = Win32SafeNativeMethods.CreateFileForAppend( pathInfo.FullNameUnc, 0x0004 /* Internal Win Append Mode*/, shareMode, IntPtr.Zero, fileOption, 0, IntPtr.Zero );
            var win32Error = Marshal.GetLastWin32Error( );
            if ( fileHandle.IsInvalid )
            {
                InternalQuickIOCommon.NativeExceptionMapping( pathInfo.FullName, win32Error ); // Throws an exception
            }

            return buffer > 0 ? new FileStream( fileHandle, fileAccess, buffer ) : new FileStream( fileHandle, fileAccess );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/> 
        /// </summary>
        /// <param name="path">The file to open. </param>
        /// <param name="mode"><see cref="FileMode"/></param>
        /// <param name="access"><see cref="FileAccess"/></param>
        /// <param name="share"><see cref="FileShare"/> </param>
        /// <returns>A <see cref="FileStream"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/y973b725(v=vs.110).aspx</remarks>
        public static FileStream Open( string path, FileMode mode, FileAccess access, FileShare share )
        {
            return OpenFileStream( new QuickIOPathInfo( path ), access, mode, share );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="pathInfo">The file to open. </param>
        /// <param name="mode"><see cref="FileMode"/> </param>
        /// <param name="access"><see cref="FileAccess"/></param>
        /// <param name="share"><see cref="FileShare"/></param>
        /// <returns><see cref="FileStream"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/y973b725(v=vs.110).aspx</remarks>
        public static FileStream Open( QuickIOPathInfo pathInfo, FileMode mode, FileAccess access, FileShare share )
        {
            return OpenFileStream( pathInfo, access, mode, share );
        }

        /// <summary>
        /// Opens an existing file for reading.
        /// </summary>
        /// <param name="path">The file to be opened for reading. </param>
        /// <returns>A read-only <see cref="FileStream"/> on the specified path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.openread(v=vs.110).aspx</remarks>
        public static FileStream OpenRead( string path )
        {
            return OpenRead( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Opens an existing file for reading.
        /// </summary>
        /// <param name="pathInfo">The file to be opened for reading. </param>
        /// <returns>A read-only <see cref="FileStream"/> on the specified path.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.openread(v=vs.110).aspx</remarks>
        public static FileStream OpenRead( QuickIOPathInfo pathInfo )
        {
            return OpenFileStream( pathInfo, FileAccess.Read, FileMode.Open, FileShare.Read );
        }

        /// <summary>
        /// Opens an existing UTF-8 encoded text file for reading.
        /// </summary>
        /// <param name="path">The file to be opened for reading. </param>
        /// <returns>A <see cref="StreamReader"/>.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.opentext(v=vs.110).aspx</remarks>
        public static StreamReader OpenText( string path )
        {
            return OpenText( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Opens an existing UTF-8 encoded text file for reading.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <returns>A <see cref="StreamReader"/>.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.opentext(v=vs.110).aspx</remarks>
        public static StreamReader OpenText( QuickIOPathInfo pathInfo )
        {
            return new StreamReader( OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.Open, FileShare.Read ), Encoding.UTF8 );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for writing.
        /// </summary>
        /// <param name="path">The file.</param>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.openwrite(v=vs.110).aspx</remarks>
        public static FileStream OpenWrite( string path )
        {
            return OpenWrite( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for writing.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.openwrite(v=vs.110).aspx</remarks>
        public static FileStream OpenWrite( QuickIOPathInfo pathInfo )
        {
            return OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.OpenOrCreate, FileShare.None );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for appending.
        /// </summary>
        /// <param name="path">The file.</param>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.openwrite(v=vs.110).aspx</remarks>
        public static FileStream OpenAppend( string path )
        {
            return OpenAppend( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for appending.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.openwrite(v=vs.110).aspx</remarks>
        public static FileStream OpenAppend( QuickIOPathInfo pathInfo )
        {
            return OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.Append, FileShare.None );
        }
    }
}
