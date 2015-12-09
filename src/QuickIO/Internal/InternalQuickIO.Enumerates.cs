//// <copyright file="InternalQuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
//// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
//// </copyright>
//// <author>Benjamin Abt</author>
//// <date>01/08/2014</date>
//// <summary>Provides internal methods</summary>

//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Contracts;
//using System.IO;
//using System.Security.Permissions;

//namespace SchwabenCode.QuickIO.Internal
//{
//    [FileIOPermission( SecurityAction.Demand, AllFiles = FileIOPermissionAccess.AllAccess, AllLocalFiles = FileIOPermissionAccess.AllAccess )]
//    internal static partial class InternalQuickIO
//    {
//        /// <summary>
//        /// Determined metadata of directory
//        /// </summary>
//        /// <param name="pathInfo">Path of the directory</param>
//        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
//        /// <returns><see cref="QuickIODirectoryMetadata"/> started with the given directory</returns>
//        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
//        internal static QuickIODirectoryMetadata EnumerateDirectoryMetadata( string path, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None )
//        {
//            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
//            Contract.Ensures( Contract.Result<QuickIODirectoryMetadata>() != null );

//            return InternalEnumerateFileSystem.EnumerateDirectoryMetadata( path, enumerateOptions );
//        }



//        /// <summary>
//        /// Determined all sub directory paths of a directory
//        /// </summary>
//        /// <param name="path">Path of the directory</param>
//        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
//        /// <param name="searchOption"><see cref="SearchOption"/></param>
//        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
//        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
//        /// <returns>Collection of directory paths</returns>
//        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
//        internal static IEnumerable<String> EnumerateDirectoryPaths( String path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
//        {
//            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
//            Contract.Ensures( Contract.Result<IEnumerable<String>>() != null );

//            return InternalEnumerateFileSystem.EnumerateSystemPaths( path, pattern, searchOption, enumerateOptions, pathFormatReturn, QuickIOFileSystemEntryType.Directory );
//        }

//        /// <summary>
//        /// Determined all files paths of a directory
//        /// </summary>
//        /// <param name="path">Path of the directory</param>
//        /// <param name="pattern">Search pattern. Uses Win32 native filtering.</param>
//        /// <param name="searchOption"><see cref="SearchOption"/></param>
//        /// <param name="pathFormatReturn">Specifies the type of path to return.</param>
//        /// <param name="enumerateOptions">The enumeration options for exception handling</param>
//        /// <returns>Collection of file paths</returns>
//        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
//        internal static IEnumerable<String> EnumerateFilePaths( String path, String pattern = QuickIOPatterns.PathMatchAll, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular )
//        {
//            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
//            Contract.Ensures( Contract.Result<IEnumerable<String>>() != null );

//            throw new NotImplementedException();
//            //return EnumerateSystemPaths( path, pattern, searchOption, QuickIOFileSystemEntryType.File, enumerateOptions, pathFormatReturn );
//        }
//    }
//}