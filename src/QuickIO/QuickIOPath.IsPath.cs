using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Returns true if given path is <see cref="IsLocalRoot(string)"/> or <see cref="IsShareRoot(string)"/>
        /// </summary>
        /// <remarks>Will return true on C:\ but will return false on C:\folderName</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsPath( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Local checks
            return ( IsLocal( path ) || IsShare( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean IsLocal( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // compare to regular and unc
            return ( IsLocalRegular( path ) || IsLocalUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean IsShare( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // compare to regular and unc
            return ( IsShareRegular( path ) || IsShareUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
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
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
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
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
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
            if( !TryGetServerAndShareNameFromLocation( location, out serverName, out shareName ) )
            {
                return false;
            }

            // validate
            if( !IsValidServerName( serverName ) || !IsValidShareName( shareName ) )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// True if <param name="path" /> starts with <see cref="UncLocalPathPrefix"/> or <see cref="UncLocalPathPrefix"/>
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsUnc( string path )
        {
            return ( IsShareUnc( path ) || IsLocalUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches \\?\UNC\server\name
        /// </summary>
        /// <remarks>Min length: \\?\UNC\s\s</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean IsShareUnc( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // Validate input
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            const string expectedPrefix = QuickIOPath.UncSharePathPrefix;
            if( !InternalStartsWithExpected( path, expectedPrefix ) )
            {
                return false;
            }

            var location = path.Substring( expectedPrefix.Length );
            // first char if location must be alphnum
            if( !char.IsLetterOrDigit( location[ 0 ] ) )
            {
                return false;
            }

            // strip information
            string serverName;
            string shareName;
            if( !TryGetServerAndShareNameFromLocation( location, out serverName, out shareName ) )
            {
                return false;
            }

            // validate
            if( !IsValidServerName( serverName ) || !IsValidShareName( shareName ) )
            {
                return false;
            }

            // TODO: validate server and share names here

            return true;
        }



        /// <summary>
        /// Checks if given path starts with expected prefix and has min length
        /// </summary>
        /// <remarks>Internal = no validation</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
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
