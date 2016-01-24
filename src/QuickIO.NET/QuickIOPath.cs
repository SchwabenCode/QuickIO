// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

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
            string combinedPath = pathElements[ 0 ];

            // Other elements
            for( int i = 1 ;i < pathElements.Length ;i++ )
            {
                string el = pathElements[ i ];

                // Combine
                combinedPath = System.IO.Path.Combine( combinedPath, el );
            }

            return combinedPath;
        }

        /// <summary>
        /// Returns the parent directory path
        ///  </summary>
        /// <param name="path">Path to get the parent</param>
        /// <remarks>System.IO does not support relative paths here. QuickIO does.</remarks>
        /// <returns>Parent directory or null if parent is root</returns>
        public static String GetDirectoryName( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            if( String.IsNullOrWhiteSpace( path ) )
            {
                return null;
            }

            // do here just trim spaces
            string cleanPath = path.Trim();

            if( IsRoot( cleanPath ) )
            {
                return null;
            }

            // trim again spaces and slashes
            cleanPath = Clean( path );

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
        /// <remarks>returns null if <paramref name="path"/> is null.</remarks>
        public static string Clean( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return path?.Trim().Trim( '\\' ).Trim();
        }
    }
}
