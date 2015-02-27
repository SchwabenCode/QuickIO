// <copyright file="QuickIOFileInfo_Append.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

using System.Collections.Generic;
using System.Text;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Appends lines to a file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="contents">The lines to append.</param>
        public void AppendAllLines( IEnumerable<string> contents )
        {
            QuickIOFile.AppendAllLines( PathInfo, contents, Encoding.UTF8 );
        }

        /// <summary>
        /// Appends lines by using the specified encoding.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="contents">The lines to append.</param>
        /// <param name="encoding">The character encoding.</param>
        public void AppendAllLines( IEnumerable<string> contents, Encoding encoding )
        {
            QuickIOFile.AppendAllLines( PathInfo, contents, encoding );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="contents">The string to append to the file.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public void AppendAllText( string contents )
        {
            QuickIOFile.AppendAllText( PathInfo, contents, Encoding.UTF8 );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public void AppendAllText( string contents, Encoding encoding )
        {
            QuickIOFile.AppendAllText( PathInfo, contents, encoding );
        }
    }
}
