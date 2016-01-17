// <copyright file="QuickIOPath.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Performs operations for files or directories and path information</summary>

using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );

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
        /// <param name="path">Path to get the parent</param>
        /// <returns>Parent directory or null if parent is root</returns>
        public static String GetParentPath( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            string cleanPath = Clean( path );

            if( IsRoot( cleanPath ) )
            {
                return null;
            }

            int lastDirectorySeparatorChar = cleanPath.LastIndexOf( DirectorySeparatorChar );
            if( lastDirectorySeparatorChar == -1 )
            {
                return null;
            }
            return cleanPath.Substring( 0, lastDirectorySeparatorChar );

        }


        /// <summary>
        /// Removes all spaces and trims backslahes at the end.
        /// </summary>
        public static string Clean( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return path.Trim().Trim( '\\' );
        }
    }
}
