// <copyright file="QuickIOFile_Append.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIOFile</summary>

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOFile
    {
        /// <summary>
        /// Appends lines to a file.
        /// If the file does not exist, it creates the file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't exist.</param>
        /// <param name="contents">The lines to append.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383691(v=vs.110).aspx</remarks>
        public static void AppendAllLines( string path, IEnumerable<string> contents )
        {
            AppendAllLines( new QuickIOPathInfo( path ), contents, Encoding.UTF8 );
        }

        /// <summary>
        /// Appends lines to a file.
        /// If the file does not exist, it creates the file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="pathInfo">The file to append the lines to. The file is created if it doesn't exist.</param>
        /// <param name="contents">The lines to append.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383691(v=vs.110).aspx</remarks>
        public static void AppendAllLines( QuickIOPathInfo pathInfo, IEnumerable<string> contents )
        {
            AppendAllLines( pathInfo, contents, QuickIOSystemRules.UTF8EncodingNoEmit );
        }

        /// <summary>
        /// Appends lines by using the specified encoding.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't exist.</param>
        /// <param name="contents">The lines to append.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383356(v=vs.110).aspx</remarks>
        public static void AppendAllLines( string path, IEnumerable<string> contents, Encoding encoding )
        {
            AppendAllLines( new QuickIOPathInfo( path ), contents, encoding );
        }

        /// <summary>
        /// Appends lines by using the specified encoding.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="pathInfo">The file to append the lines to. The file is created if it doesn't exist.</param>
        /// <param name="contents">The lines to append.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/dd383356(v=vs.110).aspx</remarks>
        public static void AppendAllLines( QuickIOPathInfo pathInfo, IEnumerable<string> contents, Encoding encoding )
        {
            var fileStream = OpenAppendFileStream( pathInfo, FileAccess.Write, FileMode.OpenOrCreate, FileShare.Write );
            using ( var streamWriter = new StreamWriter( fileStream, encoding ) )
            {
                foreach ( var line in contents )
                {
                    streamWriter.WriteLine( line );
                }
            }
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public static void AppendAllText( string path, string contents )
        {
            AppendAllText( new QuickIOPathInfo( path ), contents, Encoding.UTF8 );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="pathInfo">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public static void AppendAllText( QuickIOPathInfo pathInfo, string contents )
        {
            AppendAllText( pathInfo, contents, Encoding.UTF8 );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public static void AppendAllText( string path, string contents, Encoding encoding )
        {
            AppendAllText( new QuickIOPathInfo( path ), contents, encoding );
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
            using ( var fileStream = OpenAppendFileStream( pathInfo, FileAccess.Write, FileMode.OpenOrCreate, FileShare.Write ) )
            {
                var bytes = encoding.GetBytes( contents );
                fileStream.Write( bytes, 0, bytes.Length );
            }
        }
    }
}
