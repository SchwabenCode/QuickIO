// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOFile
    {
        /// <summary>
        /// Appends lines by using the specified encoding.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't exist.</param>
        /// <param name="contents">The lines to append.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383356(v=vs.110).aspx</remarks>
        public static void AppendAllLines( string path, IEnumerable<string> contents, Encoding encoding = null )
        {
            Contract.Requires( !string.IsNullOrWhiteSpace( path ) );
            Contract.Requires( contents != null );

            using( FileStream fileStream = OpenAppendFileStream( path, FileAccess.Write, FileMode.OpenOrCreate, FileShare.Write ) )
            using( StreamWriter streamWriter = new StreamWriter( fileStream, ( encoding ?? Encoding.UTF8 ) ) )
            {
                foreach( var line in contents )
                {
                    streamWriter.WriteLine( line );
                }
            }

        }

        /// <summary>
        /// Appends lines by using the specified encoding.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="pathInfo">The file to append the lines to. The file is created if it doesn't exist.</param>
        /// <param name="contents">The lines to append.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383356(v=vs.110).aspx</remarks>
        public static void AppendAllLines( QuickIOPathInfo pathInfo, IEnumerable<string> contents, Encoding encoding = null )
        {
            Contract.Requires( pathInfo != null );
            Contract.Requires( contents != null );

            AppendAllLines( pathInfo.FullNameUnc, contents, encoding );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public static void AppendAllText( string path, string contents, Encoding encoding = null )
        {
            Contract.Requires( !string.IsNullOrWhiteSpace( path ) );
            Contract.Requires( contents != null );

            using( FileStream fileStream = OpenAppendFileStream( path, FileAccess.Write, FileMode.OpenOrCreate, FileShare.Write ) )
            {
                var bytes = ( encoding ?? Encoding.UTF8 ).GetBytes( contents );
                fileStream.Write( bytes, 0, bytes.Length );
            }
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="pathInfo">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public static void AppendAllText( QuickIOPathInfo pathInfo, string contents, Encoding encoding )
        {
            Contract.Requires( pathInfo != null );
            Contract.Requires( contents != null );

            AppendAllText( pathInfo.FullNameUnc, contents, encoding );
        }
    }
}
