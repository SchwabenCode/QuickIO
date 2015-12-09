﻿// <copyright file="QuickIOPath.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Performs operations for files or directories and path information</summary>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Performs operations for files or directories and path information. 
    /// </summary>
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Removes spaces end <see cref="DirectorySeparatorChar "/> at the end of a string
        /// </summary>
        internal static String InternalTrimTrailingSeparator( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );

            return path.TrimEnd( WhiteSpace ).TrimEnd( DirectorySeparatorChar );
        }



        /// <summary>
        /// Combines given path elements
        /// </summary>
        /// <param name="pathElements">Path elements to combine</param>
        /// <returns>Combined Path</returns>
        /// <remarks>No validation</remarks>
        public static String Combine( params String[ ] pathElements )
        {
            Contract.Requires( pathElements != null );
            Contract.Requires( pathElements != null );
            Contract.Ensures(!String.IsNullOrWhiteSpace( Contract.Result<String>()) );

            if( pathElements == null || pathElements.Length == 0 )
            {
                throw new ArgumentNullException( nameof( pathElements ), "Cannot be null or empty" );
            }

            // Verify not required; System.IO.Path.Combine calls internal path invalid char verifier

            // First Element
            var combinedPath = pathElements[ 0 ];

            // Other elements
            for( var i = 1 ;i < pathElements.Length ;i++ )
            {
                var el = pathElements[ i ];

                // Combine
                combinedPath = System.IO.Path.Combine( combinedPath, el );
            }

            return combinedPath;
        }

        /// <summary>
        /// Returns the parent directory path
        ///  </summary>
        /// <param name="fullName">Path to get the parent from</param>
        /// <returns>Parent directory</returns>
        public static String GetParentPath( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return new QuickIOPathInfo( path ).ParentFullName;
        }


        public static Tuple<string, string> GetParentAndName( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            // remove trailing slashes
            string cleaned = QuickIOPath.Clean( path );

            //return root path without name if it's root
            if( QuickIOPath.IsRoot( path ) )
            {
                return new Tuple<string, string>( path, null );
            }

            // get position of last split char
            int latestSplitPosition = cleaned.LastIndexOf( DirectorySeparatorChar );

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all spaces and trims backslahes at the end.
        /// </summary>
        public static string Clean( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return path.Trim().TrimEnd( '\\' );
        }

        /// <summary>
        /// Returns the root directory path
        ///  </summary>
        /// <param name="path">Path to get the parent from</param>
        /// <returns>Root directory</returns>
        public static String GetRoot( String path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            return new QuickIOPathInfo( path ).RootFullName;
        }
    }
}
