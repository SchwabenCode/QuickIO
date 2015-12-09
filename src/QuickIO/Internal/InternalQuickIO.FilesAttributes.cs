// <copyright file="InternalQuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/08/2014</date>
// <summary>Provides internal methods</summary>

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Pinvoke;

using System.Threading.Tasks;
namespace SchwabenCode.QuickIO.Internal
{
    internal static partial class InternalQuickIO
    {
        /// <summary>
        /// Adds a file attribute
        /// </summary>
        /// <param name="pathInfo">Affected target</param>
        /// <param name="attribute">Attribute to add</param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( string path, FileAttributes attribute )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // read uncached attributes
            FileAttributes attributes = GetAttributes( path );

            if( /* contains */ ( attributes & attribute ) != attribute )
            {
                // is not present but will be set now

                attributes |= attribute;
                SetAttributes( path, attributes );

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets all attributes to <see cref="FileAttributes.Normal"/>
        /// </summary>
        /// <param name="path">Path to file or directory</param>
        /// <exception cref="PathNotFoundException">This error will be fired if the specified path or a part of them does not exist.</exception>
        public static FileAttributes RemoveAllFileAttributes( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return SetAttributes( path, FileAttributes.Normal );
        }

        /// <summary>
        /// Remove a file attribute
        /// </summary>
        /// <param name="path">Affected target</param>
        /// <param name="attribute">Attribute to remove</param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( String path, FileAttributes attribute )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            FileAttributes attributes = GetAttributes( path );

            if(/* contains */ ( attributes & attribute ) == attribute )
            {
                // it is presen
                attributes &= ~attribute;
                SetAttributes( path, attributes );

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the file on the entry.
        /// </summary>
        /// <param name="uncPath">The path to the entry. </param>
        /// <returns>The <see cref="FileAttributes"/> of the file on the entry.</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static FileAttributes GetAttributes( String uncPath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncPath ) );

            int win32Error;
            var attrs = SafeGetAttributes( uncPath, out win32Error );
            InternalQuickIOCommon.NativeExceptionMapping( uncPath, win32Error );

            return ( FileAttributes )attrs;
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the file on the entry.
        /// </summary>
        /// <param name="uncPath">The path to the entry. </param>
        /// <param name="win32Error">Win32 Error Code</param>
        /// <returns>The <see cref="FileAttributes"/> of the file on the entry.</returns>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        internal static uint SafeGetAttributes( String path, out Int32 win32Error )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            uint attributes = Win32SafeNativeMethods.GetFileAttributes( path );
            win32Error = ( attributes ) == 0xffffffff ? Marshal.GetLastWin32Error() : 0;
            return attributes;
        }

        /// <summary>
        /// Sets the specified <see cref="FileAttributes"/> of the entry on the specified path.
        /// </summary>
        /// <param name="path">The path to the entry.</param>
        /// <param name="attributes">A bitwise combination of the enumeration values.</param>
        /// <exception cref="Win32Exception">Unmatched Exception</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static FileAttributes SetAttributes( String path, FileAttributes attributes )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            if( !Win32SafeNativeMethods.SetFileAttributes( path, ( uint )attributes ) )
            {
                var win32Error = Marshal.GetLastWin32Error();
                InternalQuickIOCommon.NativeExceptionMapping( path, win32Error );
            }

            return attributes;
        }
    }
}