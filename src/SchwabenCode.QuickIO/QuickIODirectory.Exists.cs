// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System.IO;
using SchwabenCode.QuickIO.Core;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        #region Exist
        /// <summary>
        /// Checks whether the given directory exists.
        /// </summary>
        /// <param name="path">The path to test. </param>
        /// <returns>true if exists; otherwise, false.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool Exists( string path )
        {
            return InternalDirectoryExists( path );
        }

        /// <summary>
        /// Checks whether the given directory exists.
        /// </summary>
        /// <param name="pathInfo">The path to test. </param>
        /// <returns>true if exists; otherwise, false.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool Exists( QuickIOPathInfo pathInfo )
        {
            return Exists( pathInfo.FullNameUnc);
        }

        /// <summary>
        /// Checks whether the given directory exists.
        /// </summary>
        /// <param name="directoryInfo">The path to test. </param>
        /// <returns>true if exists; otherwise, false.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.exists(v=vs.110).aspx</remarks>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool Exists( QuickIODirectoryInfo directoryInfo )
        {
            return Exists( directoryInfo.FullNameUnc );
        }

        #endregion

        #region Internal Directory
        private static bool InternalDirectoryExists( string uncPath )
        {
            int win32Error;
            var attrs = InternalQuickIO.SafeGetAttributes( uncPath, out win32Error );

            if( Equals( attrs, 0xffffffff ) )
            {
                return false;
            }
            if( InternalHelpers.ContainsFileAttribute( FileAttributes.Directory, ( FileAttributes )attrs ) )
            {
                return true;
            }

            throw new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.File, uncPath );
        }
        #endregion
    }
}
