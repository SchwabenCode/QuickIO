// <copyright file="QuickIOFileInfo_Append_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

#if NET40_OR_GREATER
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Appends lines to a file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="contents">The lines to append.</param>
        public Task AppendAllLinesAsync( IEnumerable<string> contents )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => AppendAllLines( contents ) );
        }

        /// <summary>
        /// Appends lines by using the specified encoding.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="contents">The lines to append.</param>
        /// <param name="encoding">The character encoding.</param>
        public Task AppendAllLinesAsync( IEnumerable<string> contents, Encoding encoding )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => AppendAllLines( contents, encoding ) );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// Uses UTF-8 Encoding.
        /// </summary>
        /// <param name="contents">The string to append to the file.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public Task AppendAllTextAsync( string contents )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => AppendAllText( contents ) );
        }

        /// <summary>
        /// Appends the specified string.
        /// If the file does not exist, it creates the file.
        /// </summary>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/ms143356(v=vs.110).aspx</remarks>
        public Task AppendAllTextAsync( string contents, Encoding encoding )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => AppendAllText( contents, encoding ) );
        }

    }
}
#endif