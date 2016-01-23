// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOPath
    {
        /// <summary>
        /// Converts unc path to regular path
        /// </summary>
        /// <exception cref="InvalidOperationException">If path is invalid or cannot be identified</exception>
        public static String ToPathRegular( String path )
        {
            Contract.Requires( !String.IsNullOrEmpty( path ) );
            Contract.Ensures( !String.IsNullOrEmpty( Contract.Result<String>() ) );


            // convert to share
            if( IsShareUnc( path ) )
            {
                return QuickIOPath.ToSharePathRegular( path );
            }
            // convert to local
            if( IsLocalUnc( path ) )
            {
                return QuickIOPath.ToLocalPathRegular( path );
            }

            // give origin if already regular
            if( IsShareRegular( path ) || IsLocalRegular( path ) )
            {
                // already regular
                return path;
            }


            // it is already a regular path
            // or invalid. but will not be checked here
            return path;
        }

        /// <summary>
        /// Converts regular path to unc path
        /// </summary>
        /// <exception cref="InvalidOperationException">If path is invalid or cannot be identified</exception>
        public static string ToPathUnc( string path )
        {
            Contract.Requires( !String.IsNullOrEmpty( path ) );

            // give origin if already unc
            if( IsShareUnc( path ) || IsLocalUnc( path ) )
            {
                // already unc
                return path;
            }

            // convert to share
            if( IsShareRegular( path ) )
            {
                return QuickIOPath.ToSharePathUnc( path );
            }
            // convert to local
            if( IsLocalRegular( path ) )
            {
                return QuickIOPath.ToLocalPathUnc( path );
            }

            // it is already a regular path
            // or invalid. but will not be checked here
            return path;
        }

        /// <summary>
        /// Formats a path 
        /// </summary>
        /// <param name="pathFormatReturn">Target format type</param>
        /// <param name="uncPath">Path to format</param>
        /// <returns>Formatted path</returns>
        internal static string InternalFormatPathByType( QuickIOPathType pathFormatReturn, string uncPath )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( uncPath ) );
            Contract.Ensures( Contract.Result<String>() != null );

            return pathFormatReturn == QuickIOPathType.Regular ? ToPathRegular( uncPath ) : uncPath;
        }

        /// <summary>
        /// Converts an unc path to a local regular path
        /// </summary>
        /// <param name="uncLocalPath">Unc Path</param>
        /// <example>\\?\C:\temp\file.txt >> C:\temp\file.txt</example>
        /// <returns>Local Regular Path</returns>
        public static String ToLocalPathRegular( String uncLocalPath )
        {
            return uncLocalPath.Substring( UncLocalPathPrefix.Length );
        }

        /// <summary>
        /// Converts an unc path to a share regular path
        /// </summary>
        /// <param name="uncSharePath">Unc Path</param>
        /// <example>\\?\UNC\server\share >> \\server\share</example>
        /// <returns>QuickIOShareInfo Regular Path</returns>
        public static String ToSharePathRegular( String uncSharePath )
        {
            return RegularSharePathPrefix + uncSharePath.Substring( UncSharePathPrefix.Length );
        }

        /// <summary>
        /// Converts a regular local path to an unc path
        /// </summary>
        /// <param name="regularLocalPath">Regular Path</param>
        /// <example>C:\temp\file.txt >> \\?\C:\temp\file.txt</example>
        /// <returns>Local Unc Path</returns>
        public static String ToLocalPathUnc( String regularLocalPath )
        {
            return UncLocalPathPrefix + regularLocalPath;
        }

        /// <summary>
        /// Converts a regular share path to an unc path
        /// </summary>
        /// <param name="regularSharePath">Regular Path</param>
        /// <example>\\server\share\file.txt >> \\?\UNC\server\share\file.txt</example>
        /// <returns>QuickIOShareInfo Unc Path</returns>
        public static String ToSharePathUnc( String regularSharePath )
        {
            return UncSharePathPrefix + regularSharePath.Substring( RegularSharePathPrefix.Length );
        }
    }
}
