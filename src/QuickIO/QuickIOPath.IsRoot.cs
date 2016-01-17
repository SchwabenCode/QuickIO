using System;
using System.Runtime.CompilerServices;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Returns true if given path is <see cref="IsRootLocal(string)"/> or <see cref="IsRootLocalRegular(string)"/>
        /// </summary>
        /// <remarks>Will return true on C:\ but will return false on C:\folderName</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsRoot( string path )
        {
            // Local checks
            return ( IsRootLocal( path ) || IsRootShare( path ) );
        }

        /// <summary>
        /// Checks if given path is local root
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsRootLocal( string path )
        {
            return ( IsRootLocalRegular( path ) || IsRootLocalUnc( path ) );
        }

        /// <summary>
        /// Checks if given path is share root
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsRootShare( string path )
        {
            return ( IsRootShareRegular( path ) || IsRootShareUnc( path ) );
        }

        /// <summary>
        /// Checks if given path matches C:\ or X:\ ...
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsRootLocalRegular( string path )
        {
            // Validate input
            if( string.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            return
                // check length
                ( path.Length == 3
                // check root
                && ( ( IsValidDriveLetter( path[ 0 ] ) && path[ 1 ] == ':' && path[ 2 ] == '\\' ) ) );
        }

        /// <summary>
        /// Checks if given path matches  \\?\C:\ or \\?\X:\ ...
        /// </summary>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsRootLocalUnc( string path )
        {
            // Validate input
            if( string.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            return
                // check length
                ( ( path.Length == 7 )
                // check prefix
                && InternalStartsWithExpected( path, UncLocalPathPrefix )
                // check root
                && IsRootLocalRegular( path.Substring( 4, 3 ) ) );
        }

        /// <summary>
        /// Checks if given path matches \\server\name
        /// </summary>
        /// <remarks>Min length: \\s\s</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean IsRootShareRegular( string path )
        {
            // Validate input
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            // check prefix
            const string expectedPrefix = RegularSharePathPrefix;
            if( !InternalStartsWithExpected( path, expectedPrefix ) )
            {
                return false;
            }

            string location = path.Substring( expectedPrefix.Length );
            // first char if location must be alphnum
            if( !char.IsLetterOrDigit( location[ 0 ] ) )
            {
                return false;
            }

            // try to found server and name
            // only two parts are valid here!
            string[ ] names = location.TrimEnd( '\\' ).Split( '\\' );
            if( names.Length != 2 )
            {
                // if less than two it is invalid
                return false;
            }

            string serverName = names[ 0 ];
            string shareName = names[ 1 ];

            // TODO: validate server and share names here

            return IsValidServerName( serverName ) && IsValidShareName( shareName );
        }

        /// <summary>
        /// Checks if given path matches \\?\UNC\server\name
        /// </summary>
        /// <remarks>Min length: \\?\UNC\s\s</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsRootShareUnc( string path )
        {
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

            // strip information
            string serverName;
            string shareName;
            if( !TryGetServerAndShareNameFromLocation( path, QuickIOPathType.UNC, out serverName, out shareName ) )
            {
                return false;
            }

            // validate
            return IsValidServerName( serverName ) && IsValidShareName( shareName );
        }





    }
}
