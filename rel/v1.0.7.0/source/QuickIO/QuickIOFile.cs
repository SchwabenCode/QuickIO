// <copyright file="QuickIOFile.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIOFile</summary>

using System;
using System.IO;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides static methods to access files. For example creating, deleting and retrieving content and security information such as the owner.
    /// </summary>
    public static partial class QuickIOFile
    {

        /// <summary>
        /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/> is true
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="targetDirectory">Target directory</param>      
        /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>'s name</param>
        /// <param name="overwrite">true to overwrite existing file</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
        public static void CopyToDirectory( string sourceFileName, string targetDirectory, String newFileName = null, Boolean overwrite = false )
        {
            CopyToDirectory( InternalQuickIO.LoadFileFromPathInfo( new QuickIOPathInfo( sourceFileName ) ), InternalQuickIO.LoadDirectoryFromPathInfo( new QuickIOPathInfo( targetDirectory ) ), newFileName, overwrite );
        }


        /// <summary>
        /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="targetDirectory">Target directory</param>
        /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>' name</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
        public static void CopyToDirectory( QuickIOFileInfo sourceFileName, QuickIODirectoryInfo targetDirectory, String newFileName = null, Boolean overwrite = false )
        {
            var targetFileName = sourceFileName.Name;
            if ( !String.IsNullOrEmpty( newFileName ) )
            {
                // TODO: Check for invalid chars 
                targetFileName = newFileName;
            }

            Copy( sourceFileName.FullNameUnc, QuickIOPath.Combine( targetDirectory.FullNameUnc, targetFileName ), overwrite );
        }

        /// <summary>
        /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
        /// </summary>
        /// <param name="uncSourceFullName">The file to copy.</param>
        /// <param name="uncTargetFullName">Target file</param>      
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
        public static void Copy( string uncSourceFullName, string uncTargetFullName, Boolean overwrite = false )
        {
            Invariant.NotEmpty( uncSourceFullName );
            Invariant.NotEmpty( uncTargetFullName );

            int win32Error;
            if ( !InternalQuickIO.CopyFile( uncSourceFullName, uncTargetFullName, out win32Error, overwrite ) )
            {
                InternalQuickIOCommon.NativeExceptionMapping( uncSourceFullName, win32Error );
            }
        }


        /// <summary>
        /// Deletes the file. 
        /// </summary>
        /// <param name="path">The fullname of the file to be deleted.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.delete(v=vs.110).aspx</remarks>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static void Delete( string path )
        {
            Delete( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Deletes the file. 
        /// </summary>
        /// <param name="pathInfo">The file to be deleted.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.delete(v=vs.110).aspx</remarks>
        /// <exception cref="FileNotFoundException">File does not exist.</exception>
        public static void Delete( QuickIOPathInfo pathInfo )
        {
            InternalQuickIO.DeleteFile( pathInfo );
        }

        /// <summary>
        /// Checks whether the specified file exists.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
        /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool Exists( string path )
        {
            return InternalQuickIOCommon.Exists( path, QuickIOFileSystemEntryType.File );
        }

        /// <summary>
        /// Checks whether the specified file exists.
        /// </summary>
        /// <param name="pathInfo">The the file to check.</param>
        /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
        /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool Exists( QuickIOPathInfo pathInfo )
        {
            return InternalQuickIOCommon.Exists( pathInfo, QuickIOFileSystemEntryType.File );
        }

        /// <summary>
        /// Moves a specified file to a new location, providing the option to give a new file name.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move. </param>
        /// <param name="destinationFileName">The new path for the file. Parent directory must exist.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
        public static void Move( string sourceFileName, string destinationFileName )
        {
            InternalQuickIO.MoveFile( sourceFileName, destinationFileName );
        }

        /// <summary>
        /// Moves a file, providing the option to give a new file name.
        /// </summary>
        /// <param name="sourceFileInfo">The file to move.</param>
        /// <param name="destinationFolder">Target directory to move the file.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
        public static void Move( QuickIOPathInfo sourceFileInfo, QuickIOPathInfo destinationFolder )
        {
            InternalQuickIO.MoveFile( sourceFileInfo.FullNameUnc, Path.Combine( destinationFolder.FullNameUnc, sourceFileInfo.Name ) );
        }

        /// <summary>
        /// Moves a file, providing the option to give a new file name.
        /// </summary>
        /// <param name="sourceFileInfo">The file to move.</param>
        /// <param name="destinationFolder">Target directory to move the file.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
        public static void Move( QuickIOPathInfo sourceFileInfo, QuickIODirectoryInfo destinationFolder )
        {
            InternalQuickIO.MoveFile( sourceFileInfo.FullNameUnc, Path.Combine( destinationFolder.FullNameUnc, sourceFileInfo.Name ) );
        }

    }
}
