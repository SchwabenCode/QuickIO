// <copyright file="QuickIOFile_Write.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIOFile</summary>

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOFile
    {

        /// <summary>
        /// Writes the specified byte array.
        /// If the file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file. </param>
        /// <param name="bytes">The bytes to write. </param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.writeallbytes(v=vs.110).aspx</remarks>
        public static void WriteAllBytes( string path, byte[] bytes )
        {
            Contract.Requires( !string.IsNullOrWhiteSpace( path ) );
            Contract.Requires( bytes != null );

            using( var fileStream = OpenFileStream( path, FileAccess.ReadWrite, FileMode.Create, FileShare.None ) )
            {
                fileStream.Seek( 0, SeekOrigin.Begin );
                fileStream.Write( bytes, 0, bytes.Length );
            }
        }

        /// <summary>
        /// Writes the specified byte array.
        /// If the file already exists, it is overwritten.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <param name="bytes">The bytes to write. </param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.writeallbytes(v=vs.110).aspx</remarks>
        public static void WriteAllBytes( QuickIOPathInfo pathInfo, IEnumerable<byte> bytes )
        {
            Contract.Requires( pathInfo != null );
            Contract.Requires( bytes != null );

            WriteAllBytes( pathInfo.FullNameUnc, bytes.ToArray() );
        }




        /// <summary>
        /// Writes a collection of strings.
        /// </summary>
        /// <param name="path">The file.</param>
        /// <param name="contents">The lines write to.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383463(v=vs.110).aspx</remarks>
        public static void WriteAllLines( string path, IEnumerable<string> contents, Encoding encoding = null )
        {
            Contract.Requires( !string.IsNullOrWhiteSpace( path ) );
            Contract.Requires( contents != null );

            using( var fileStream = OpenFileStream( path, FileAccess.ReadWrite, FileMode.Create, FileShare.None ) )
            using( var streamWriter = new StreamWriter( fileStream, ( encoding ?? Encoding.UTF8 ) ) )
            {
                foreach( var entry in contents )
                {
                    streamWriter.WriteLine( entry );
                }
            }
        }

        /// <summary>
        /// Writes a collection of strings.
        /// </summary>
        /// <param name="pathInfo">The file.</param>
        /// <param name="contents">The lines write to.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383463(v=vs.110).aspx</remarks>
        public static void WriteAllLines( QuickIOPathInfo pathInfo, IEnumerable<string> contents, Encoding encoding = null )
        {
            Contract.Requires( pathInfo != null );
            Contract.Requires( contents != null );

            WriteAllLines( pathInfo.FullNameUnc, contents, encoding );
        }


        /// <summary>
        /// Writes the specified string.
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file. </param>
        /// <param name="contents">The string to write to. </param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143376(v=vs.110).aspx</remarks>
        public static void WriteAllText( string path, string contents, Encoding encoding = null)
        {
            Contract.Requires( !string.IsNullOrWhiteSpace( path ) );
            Contract.Requires( contents != null );

            using( var fileStream = OpenFileStream( path, FileAccess.ReadWrite, FileMode.Create, FileShare.None ) )
            using( var streamWriter = new StreamWriter( fileStream, (encoding ?? Encoding.UTF8) ) )
            {
                streamWriter.Write( contents );
            }
        }

        /// <summary>
        /// Writes the specified string.
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="pathInfo">The file. </param>
        /// <param name="contents">The string to write to. </param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143376(v=vs.110).aspx</remarks>
        public static void WriteAllText( QuickIOPathInfo pathInfo, string contents, Encoding encoding = null )
        {
            Contract.Requires( pathInfo != null );
            Contract.Requires( contents != null );

            WriteAllText(pathInfo.FullNameUnc, contents, encoding);
        }
    }
}
