// <copyright file="QuickIOPath.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Performs operations for files or directories and path information</summary>

using System;
using System.Diagnostics.Contracts;
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
    }
}
