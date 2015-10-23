// <copyright file="QuickIOFile_Create.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIOFile</summary>

using System;
using System.IO;
using System.Text;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{

    public static partial class QuickIOFile
    {
        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="fullName">The path to the file. </param>
        /// <param name="fileAccess"><see cref="FileAccess"/> - default <see cref="FileAccess.Write"/></param>
        /// <param name="fileShare"><see cref="FileShare "/> - default <see cref="FileShare.None"/></param>
        /// <param name="fileMode"><see cref="FileMode"/> - default <see cref="FileMode.Create"/></param>
        /// <param name="fileAttributes"><see cref="FileAttributes"/> - default 0 (none)</param>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        public static void Create( String fullName, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0 )
        {
            Create( new QuickIOPathInfo( fullName ), fileAccess, fileShare, fileMode, fileAttributes );
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="pathInfo">The path to the file. </param>
        /// <param name="fileAccess"><see cref="FileAccess"/> - default <see cref="FileAccess.Write"/></param>
        /// <param name="fileShare"><see cref="FileShare "/> - default <see cref="FileShare.None"/></param>
        /// <param name="fileMode"><see cref="FileMode"/> - default <see cref="FileMode.Create"/></param>
        /// <param name="fileAttributes"><see cref="FileAttributes"/> - default 0 (none)</param>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        public static void Create( QuickIOPathInfo pathInfo, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0 )
        {
            InternalQuickIO.CreateFile( pathInfo, fileAccess, fileShare, fileMode, fileAttributes );
        }

        /// <summary>
        /// Creates or overwrites the specified file.
        /// </summary>
        /// <param name="path">The name of the file. </param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file. </param>
        /// <returns>A <see cref="FileStream"/> with the specified buffer size that provides read/write access to the file specified in <i>path</i>.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/981h90e5(v=vs.110).aspx</remarks>
        public static FileStream Create( string path, int bufferSize )
        {
            return Create( new QuickIOPathInfo( path ), bufferSize );
        }

        /// <summary>
        /// Creates or overwrites the specified file.
        /// </summary>
        /// <param name="pathInfo">The name of the file. </param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file. </param>
        /// <returns>A <see cref="FileStream"/> with the specified buffer size that provides read/write access to the file specified in <i>path</i>.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/981h90e5(v=vs.110).aspx</remarks>
        public static FileStream Create( QuickIOPathInfo pathInfo, int bufferSize )
        {
            return OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.Create, FileShare.None, bufferSize );
        }

        /// <summary>
        /// Creates or opens a file for writing UTF-8 encoded text.
        /// </summary>
        /// <param name="path">The file. </param>
        /// <returns>A <see cref="StreamWriter"/> that writes to the specified file using UTF-8 encoding.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.createtext(v=vs.110).aspx</remarks>
        public static StreamWriter CreateText( string path )
        {
            return CreateText( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Creates or opens a file for writing UTF-8 encoded text.
        /// </summary>
        /// <param name="pathInfo">The file.</param>
        /// <returns>A <see cref="StreamWriter"/> that writes to the specified file using UTF-8 encoding.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.createtext(v=vs.110).aspx</remarks>
        public static StreamWriter CreateText( QuickIOPathInfo pathInfo )
        {
            return new StreamWriter( OpenFileStream( pathInfo, FileAccess.ReadWrite, FileMode.Create, FileShare.None ), Encoding.UTF8 );
        }
    }
}
