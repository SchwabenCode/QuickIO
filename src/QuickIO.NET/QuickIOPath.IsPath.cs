﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Checks if given path starts with a known root path
        /// </summary>
        [MethodImpl( 256 )]
        public static Boolean IsRelative( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // If IsPath then it is no relative path
            return !IsPath( path );
        }

        /// <summary>
        /// Returns true if given path is <see cref="IsLocal(string)"/> or <see cref="IsShare(string)"/>
        /// </summary>
        /// <remarks>Will return true on C:\ but will return false on C:\folderName</remarks>
        [MethodImpl( 256 )]
        public static bool IsPath( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Local checks
            return ( IsLocal( path ) || IsShare( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( 256 )]
        public static Boolean IsLocal( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // compare to regular and unc
            return ( IsLocalRegular( path ) || IsLocalUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( 256 )]
        public static Boolean IsShare( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // compare to regular and unc
            return ( IsShareRegular( path ) || IsShareUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( 256 )]
        public static Boolean IsLocalRegular( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Validate input
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            return ( ( path.Length >= 3 ) && IsRootLocalRegular( path.Substring( 0, 3 ) ) );
        }

        /// <summary>
        /// Checks if given path matches  \\?\C:\ or \\?\X:\ ...
        /// </summary>
        [MethodImpl( 256 )]
        public static Boolean IsLocalUnc( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Validate input
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            return ( ( path.Length >= 7 ) && IsRootLocalUnc( path.Substring( 0, 7 ) ) );
        }

        /// <summary>
        /// Checks if given path matches  \\s\s
        /// </summary>
        [MethodImpl( 256 )]
        public static Boolean IsShareRegular( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // check if path exists and starts with \\
            if( String.IsNullOrWhiteSpace( path ) || !path.StartsWith( RegularLocalPathPrefix ) )
            {
                return false;
            }

            // filter unc paths
            if( InternalStartsWithExpected( path, UncLocalPathPrefix ) || InternalStartsWithExpected( path, UncSharePathPrefix ) )
            {
                return false;
            }

            const string expectedPrefix = QuickIOPath.RegularSharePathPrefix;
            if( !InternalStartsWithExpected( path, expectedPrefix ) )
            {
                return false;
            }

            var location = path.Substring( expectedPrefix.Length );

            // strip information
            string serverName;
            string shareName;
            if( !TryParseShare( location, QuickIOPathType.Regular, out serverName, out shareName ) )
            {
                return false;
            }

            // validate
            return IsValidServerName( serverName ) && IsValidShareName( shareName );
        }

        /// <summary>
        /// True if <param name="path" /> starts with <see cref="UncLocalPathPrefix"/> or <see cref="UncLocalPathPrefix"/>
        /// </summary>
        [MethodImpl( 256 )]
        public static bool IsUnc( string path )
        {
            return ( IsShareUnc( path ) || IsLocalUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches \\?\UNC\server\name
        /// </summary>
        /// <remarks>Min length: \\?\UNC\s\s</remarks>
        [MethodImpl( 256 )]
        public static Boolean IsShareUnc( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Validate input
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            const string expectedPrefix = QuickIOPath.UncSharePathPrefix;
            if( !InternalStartsWithExpected( path, expectedPrefix ) || expectedPrefix == path )
            {
                return false;
            }

            // strip information
            string serverName;
            string shareName;
            if( !TryParseShare( path, QuickIOPathType.UNC, out serverName, out shareName ) )
            {
                return false;
            }

            // validate
            return IsValidServerName( serverName ) && IsValidShareName( shareName );
        }



        /// <summary>
        /// Checks if given path starts with expected prefix and has min length
        /// </summary>
        /// <remarks>Internal = no validation</remarks>
        [MethodImpl( 256 )]
        internal static Boolean InternalStartsWithExpected( string path, String prefix )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( prefix ) );

            return
                // check length
                ( path.Length >= prefix.Length )
                // check prefix
                && ( path.Substring( 0, prefix.Length ).Equals( prefix, StringComparison.OrdinalIgnoreCase ) );
        }
    }
}
