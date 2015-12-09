// <copyright file="QuickIOFileInfo_Open.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

using System.IO;

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="mode"><see cref="FileMode"/> </param>
        /// <param name="access"><see cref="FileAccess"/></param>
        /// <param name="share"><see cref="FileShare"/></param>
        /// <returns><see cref="FileStream"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/y973b725(v=vs.110).aspx</remarks>
        public FileStream Open( FileMode mode, FileAccess access = FileAccess.Read, FileShare share = FileShare.None )
        {
            return QuickIOFile.Open( FullNameUnc, mode, access, share );
        }

        /// <summary>
        /// Opens an existing file for reading.
        /// </summary>
        /// <returns>A read-only <see cref="FileStream"/> on the specified path.</returns>
        public FileStream OpenRead()
        {
            return QuickIOFile.OpenRead( FullNameUnc );
        }

        /// <summary>
        /// Opens an existing UTF-8 encoded text file for reading.
        /// </summary>
        /// <returns>A <see cref="StreamReader"/>.</returns>
        public StreamReader OpenText()
        {
            return QuickIOFile.OpenText( FullNameUnc );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for writing.
        /// </summary>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        public FileStream OpenWrite()
        {
            return QuickIOFile.OpenWrite( FullNameUnc );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for appending.
        /// </summary>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        public FileStream OpenAppend()
        {
            return QuickIOFile.OpenAppend( FullNameUnc );
        }
    }
}
