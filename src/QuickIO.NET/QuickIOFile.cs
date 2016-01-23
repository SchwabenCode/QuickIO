// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.IO;
using SchwabenCode.QuickIO.Internal;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Core;
using SchwabenCode.QuickIO.Win32;

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
        /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
        public static void CopyToDirectory( string sourceFileName, string targetDirectory, String newFileName = null, Boolean overwrite = false )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( sourceFileName ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( targetDirectory ) );

            if( String.IsNullOrWhiteSpace( sourceFileName ) )
            {
                throw new ArgumentNullException( nameof( sourceFileName ) );
            }
            if( String.IsNullOrWhiteSpace( targetDirectory ) )
            {
                throw new ArgumentNullException( nameof( targetDirectory ) );
            }

            // determine filename
            string targetFileName;
            if( !String.IsNullOrWhiteSpace( newFileName ) )
            {
                // TODO: Check for invalid chars 
                targetFileName = newFileName;
            }
            else
            {
                targetFileName = QuickIOPath.GetName( sourceFileName );
            }

            Copy( sourceFileName, QuickIOPath.Combine( targetDirectory, targetFileName ), overwrite );

        }

        /// <summary>
        /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="targetDirectory">Target directory</param>
        /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>' name</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
        /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
        public static void CopyToDirectory( QuickIOFileInfo sourceFileName, QuickIODirectoryInfo targetDirectory, String newFileName = null, Boolean overwrite = false )
        {
            Contract.Requires( sourceFileName != null );
            Contract.Requires( targetDirectory != null );

            if( sourceFileName == null )
            {
                throw new ArgumentNullException( nameof( sourceFileName ) );
            }
            if( targetDirectory == null )
            {
                throw new ArgumentNullException( nameof( targetDirectory ) );
            }

            CopyToDirectory( sourceFileName.FullNameUnc, targetDirectory.FullNameUnc, newFileName, overwrite );
        }

        /// <summary>
        /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
        /// </summary>
        /// <param name="source">The file to copy.</param>
        /// <param name="target">Target file</param>      
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <param name="createRecursive">Creates parent path if not exists. Decreases copy performance</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
        /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
        public static void Copy( string source, string target, Boolean overwrite = false, Boolean createRecursive = true )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( source ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( target ) );

            if( String.IsNullOrWhiteSpace( source ) )
            {
                throw new ArgumentNullException( nameof( source ) );
            }
            if( String.IsNullOrWhiteSpace( target ) )
            {
                throw new ArgumentNullException( nameof( target ) );
            }

            if( createRecursive )
            {
                var targetDirectoryPath = QuickIOPath.GetParentPath( target );
                try
                {
                    QuickIODirectory.Create( targetDirectoryPath, true );
                }
                catch( PathAlreadyExistsException )
                {
                    // yay ignore this!
                }
            }

            int win32Error;
            if( !InternalQuickIO.CopyFile( source, target, out win32Error, overwrite ) )
            {
                Win32ErrorCodes.NativeExceptionMapping( !Exists( source ) ? target : target, win32Error );
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
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            InternalQuickIO.DeleteFile( path );
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
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );

            return InternalQuickIO.FileExists( path );
        }

        /// <summary>
        /// Checks whether the specified file exists.
        /// </summary>
        /// <param name="fileInfo">The the file to check.</param>
        /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
        /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
        /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
        /// <exception cref="InvalidPathException">Path is invalid.</exception>
        public static bool Exists( QuickIOFileInfo fileInfo )
        {
            Contract.Requires( fileInfo != null );

            return Exists( fileInfo.FullNameUnc );
        }

        /// <summary>
        /// Moves a specified file to a new location, providing the option to give a new file name.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move. </param>
        /// <param name="destinationFileName">The new path for the file. Parent directory must exist.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
        public static void Move( string sourceFileName, string destinationFileName )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( sourceFileName ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( destinationFileName ) );

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
            Contract.Requires( sourceFileInfo != null );
            Contract.Requires( destinationFolder != null );

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
            Contract.Requires( sourceFileInfo != null );
            Contract.Requires( destinationFolder != null );

            InternalQuickIO.MoveFile( sourceFileInfo.FullNameUnc, Path.Combine( destinationFolder.FullNameUnc, sourceFileInfo.Name ) );
        }

    }
}
