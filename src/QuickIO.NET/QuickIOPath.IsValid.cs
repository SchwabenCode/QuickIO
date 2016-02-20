﻿// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using SchwabenCode.QuickIO.Core;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Checks if given name is a valid server name
        /// </summary>
        /// <remarks>Ignores Unix File Systems</remarks>
        /// <param name="name">Name to check</param>
        /// <exception cref="InvalidPathException">If invalid character found</exception>
        [MethodImpl( 256 )]
        public static bool IsValidFolderName( String name )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( name ) );

            // check system names

            if( String.IsNullOrWhiteSpace( name ) || name == "." || name == ".." )
            {
                return false;
            }

            // whitespace and the start or end not allowed
            if( name[ 0 ] == WhiteSpace || name[ name.Length - 1 ] == WhiteSpace )
            {
                return false;
            }

            // max length
            if( name.Length > QuickIOPath.MaxFolderNameLength )
            {
                return false;
            }

            // point at the beginning or at the end is not allowed
            // windows would automatically remove the point at the end
            if( name[ 0 ] == '.' || name[ name.Length - 1 ] == '.' )
            {
                return false;
            }

            return name.All( IsValidFolderChar );
        }

        /// <summary>
        /// returns true if char is invalid for a folder name
        /// </summary>
        /// <remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx#naming_conventions</remarks>
        [MethodImpl( 256 )]
        public static Boolean IsValidFolderChar( char c )
        {
            // TODO: think about whitelisting instead of blacklisting
            const string forbiddenChars = "<>:\"/\\|?*\0";

            // Whitespaces are allowed
            if( c == WhiteSpace )
            {
                return true;
            }

            // but all others chars below ascii 32 are forbidden
            if( c < 32 )
            {
                return false;
            }

            // at least some chars are forbidden
            return ( forbiddenChars.IndexOf( c ) == -1 );
        }

        /// <summary>
        /// Checks if given char is a valid windows drive letter
        /// </summary>
        [MethodImpl( 256 )]
        public static bool IsValidDriveLetter( char c )
        {
            // hint: older versions of windows were able to allow [:\ but current systems won't!
            return ( ( c >= 'A' && c <= 'Z' ) || ( c >= 'a' && c <= 'z' ) );
        }

        /// <summary>
        /// Verifies server name
        /// </summary>
        [MethodImpl( 256 )]
        public static bool IsValidServerName( string serverName )
        {
            if( String.IsNullOrWhiteSpace( serverName ) )
            {
                return false;
            }

            // TODO: check rule set
            return serverName.All( IsValidServerNameChar );
        }

        /// <summary>
        /// returns true if char is valid for a server name
        /// </summary>
        [MethodImpl( 256 )]
        public static bool IsValidServerNameChar( char c )
        {
            // TODO: constant
            // TODO: are these all? https://technet.microsoft.com/en-us/library/cc959336.aspx
            const string allowedChars = "-";
            return ( Char.IsLetterOrDigit( c ) || ( allowedChars.IndexOf( c ) > -1 ) );
        }

        /// <summary>
        /// Returns true if share name is valid
        /// </summary>
        [MethodImpl( 256 )]
        public static bool IsValidShareName( string serverName )
        {
            if( String.IsNullOrWhiteSpace( serverName ) )
            {
                return false;
            }

            // TODO: check rule set
            return serverName.All( IsValidShareNameChar );
        }

        /// <summary>
        /// Returns true if char is valid for a share name
        /// </summary>
        [MethodImpl( 256 )]
        public static bool IsValidShareNameChar( char c )
        {
            // TODO: constant
            const string allowedChars = "_- .";
            return ( Char.IsLetterOrDigit( c ) || ( allowedChars.IndexOf( c ) > -1 ) );
        }
    }
}
