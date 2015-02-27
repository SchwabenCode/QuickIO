
// <copyright file="QuickIODirectory_Root.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/06/2014</date>
// <summary>QuickIODirectory_Root></summary>


#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectory
    {

        #region Root

        /// <summary>
        /// Returns the root information
        /// </summary>
        /// <param name="path">The path of a file or directory. </param>
        /// <returns>A QuickIOPathInfo that represents the root or null if <paramref name="path"/> is root.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.getdirectoryroot(v=vs.110).aspx</remarks>
        public static Task<QuickIOPathInfo> GetDirectoryRootAsync( string path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.GetDirectoryRoot( path ) );
        }

        /// <summary>
        /// Returns the root information
        /// </summary>
        /// <param name="info">A file or directory. </param>
        /// <returns>A QuickIOPathInfo that represents the root or null if <paramref name="info"/> is root.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.getdirectoryroot(v=vs.110).aspx</remarks>
        public static Task<QuickIOPathInfo> GetDirectoryRootAsync( QuickIOPathInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.GetDirectoryRoot( info ) );
        }

		/// <summary>
        /// Returns the root information
        /// </summary>
        /// <param name="info">A file or directory. </param>
        /// <returns>A QuickIOPathInfo that represents the root or null if <paramref name="info"/> is root.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.getdirectoryroot(v=vs.110).aspx</remarks>
        public static Task<QuickIOPathInfo> GetDirectoryRootAsync( QuickIODirectoryInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.GetDirectoryRoot( info ) );
        }

        #endregion
    }
}
#endif
