// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Returns <see cref="System.IO.Path.GetRandomFileName"/>
        /// </summary>
        /// <returns><see cref="System.IO.Path.GetRandomFileName"/></returns>
        public static String GetRandomFileName()
        {
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
            return System.IO.Path.GetRandomFileName();
        }

        /// <summary>
        /// Gets name of file or directory
        /// </summary>
        /// <param name="fullName">Path</param>
        /// <returns>Name of file or directory</returns>
        /// <exception cref="InvalidPathException">Path is invalid</exception>
        public static String GetName( String fullName )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( fullName ) );
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );

            string path = InternalTrimTrailingSeparator( fullName );
            int pos = path.LastIndexOf( DirectorySeparatorChar );

            return ( ( pos == -1 ) ? path : path.Substring( pos + 1 ) );
        }

        /// <summary>
        /// A wrapper for <see cref="System.IO.Path.GetFullPath"/>
        /// </summary>
        /// <remarks>Calls <see cref="System.IO.Path.GetFullPath(string)"/></remarks>
        /// <returns>a regular path</returns>
        public static String GetFullPath( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );

            // Only access System.IO on relative path
            if( IsRelative( path ) )
            {
                return System.IO.Path.GetFullPath( path );
            }

            // otherwise it is a valid path
            return path;

        }

        internal static InternalPath GetInternalPath( string path )
        {
            return new InternalPath( GetFullPath( path ) );
        }

        /// <summary>
        /// A wrapper for <see cref="GetFullPath(string)"/> that returns <see cref="QuickIOPathInfo"/>
        /// </summary>
        public static QuickIOPathInfo GetFullPathInfo( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( Contract.Result<QuickIOPathInfo>() != null );

            return new QuickIOPathInfo( GetFullPath( path ) );
        }

        /// <summary>
        /// Full path, no relative path allowed
        /// </summary>
        /// <remarks>Same return behavior like <see cref="System.IO.Path.GetPathRoot(string)"/></remarks>
        /// <returns>Null if <paramref name="path" /> is null, empty string if <paramref name="path" /> does not contain any root information or is invalid.</returns>
        public static string GetPathRoot( string path )
        {
            if( path == null )
            {
                return null;
            }

            if( !IsPath( path ) )
            {
                return String.Empty;
            }

            // Return C:\
            string root;
            if( TryGetLocalRootPath( path, out root ) )
            {
                return root;
            }


            // Return \\server\name
            if( TryGetShareRootPath( path, out root ) )
            {
                return path;
            }


            // Return \\?\UNC\C:\
            if( TryGetLocalUncRootPath( path, out root ) )
            {
                return path;
            }

            return String.Empty;
        }

        /// <summary>
        /// Returns true if <paramref name="path" /> can be parsed and puts root information to <paramref name="root" />
        /// </summary>
        internal static bool TryGetLocalRootPath( string path, out string root )
        {
            if( IsLocalRegular( path ) )
            {
                root = path.Substring( 0, 3 );
                return true;
            }

            root = null;
            return false;
        }

        /// <summary>
        /// Returns true if <paramref name="path" /> can be parsed and puts root information to <paramref name="root" />
        /// </summary>
        internal static bool TryGetLocalUncRootPath( string path, out string root )
        {
            if( IsLocalUnc( path ) )
            {
                root = path.Substring( 0, 11 );
                return true;
            }

            root = null;
            return false;
        }

        /// <summary>
        /// Returns true if <paramref name="path" /> can be parsed and puts root information to <paramref name="root" />
        /// </summary>
        internal static bool TryGetShareRootPath( string path, out string root )
        {
            string serverName;
            string shareName;
            if( IsShareRegular( path ) && TryGetServerAndShareNameFromLocation( path, QuickIOPathType.Regular, out serverName, out shareName ) )
            {
                root = $@"\\{serverName}\{shareName}";
                return true;
            }

            root = null;
            return false;
        }

        /// <summary>
        /// Returns true if <paramref name="path" /> can be parsed and puts root information to <paramref name="root" />
        /// </summary>
        internal static bool TryGetShareUncRootPath( string path, out string root )
        {
            string serverName;
            string shareName;
            if( IsShareUnc( path ) && TryGetServerAndShareNameFromLocation( path, QuickIOPathType.UNC, out serverName, out shareName ) )
            {
                root = $@"\\{serverName}\{shareName}";
                return true;
            }

            root = null;
            return false;
        }

        /// <summary>
        /// Strips server and share from given path
        /// </summary>
        /// <remarks>Returns false if path is invalid for this operation</remarks>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean TryGetServerAndShareNameFromLocation( string path, QuickIOPathType shouldBe, out string serverName, out string shareName )
        {
            serverName = null;
            shareName = null;

            // Validate input
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return false;
            }

            if( shouldBe == QuickIOPathType.UNC )
            {
                path = path.Substring( QuickIOPath.UncSharePathPrefix.Length );
            }

            // try to found server and name
            string[ ] names = path.Trim( '\\' /*trim start and end */ ).Split( '\\' );
            if( names.Length < 2 )
            {
                // if less than two it is invalid
                return false;
            }

            serverName = names[ 0 ];
            shareName = names[ 1 ];
            return true;
        }
    }
}
