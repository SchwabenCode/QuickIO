// <copyright file="QuickIOFileInfo_Open_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for files</summary>

#if NET40_OR_GREATER
using System.IO;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;


namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo
    {
        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="mode"><see cref="FileMode"/></param>
        /// <returns>A <see cref="FileStream"/> with read and write access and not shared.</returns>
        public Task<FileStream> OpenAsync( FileMode mode = FileMode.Open )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => Open( mode ) );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="mode"><see cref="FileMode"/> </param>
        /// <param name="access"><see cref="FileAccess"/> </param>
        /// <returns>An unshared <see cref="FileStream"/></returns>
        public Task<FileStream> OpenAsync( FileMode mode, FileAccess access )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => Open( mode, access ) );
        }

        /// <summary>
        /// Opens a <see cref="FileStream"/>
        /// </summary>
        /// <param name="mode"><see cref="FileMode"/> </param>
        /// <param name="access"><see cref="FileAccess"/></param>
        /// <param name="share"><see cref="FileShare"/></param>
        /// <returns><see cref="FileStream"/></returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/y973b725(v=vs.110).aspx</remarks>
        public Task<FileStream> OpenAsync( FileMode mode, FileAccess access, FileShare share )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => Open( mode, access, share ) );
        }

        /// <summary>
        /// Opens an existing file for reading.
        /// </summary>
        /// <returns>A read-only <see cref="FileStream"/> on the specified path.</returns>
        public Task<FileStream> OpenReadAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( OpenRead );
        }

        /// <summary>
        /// Opens an existing UTF-8 encoded text file for reading.
        /// </summary>
        /// <returns>A <see cref="StreamReader"/>.</returns>
        public Task<StreamReader> OpenTextAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( OpenText );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for writing.
        /// </summary>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        public Task<FileStream> OpenWriteAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( OpenWrite );
        }

        /// <summary>
        /// Opens an existing file or creates a new file for appending.
        /// </summary>
        /// <returns>An unshared <see cref="FileStream"/> with Write access.</returns>
        public Task<FileStream> OpenAppendAsync()
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( OpenAppend );
        }
    }
}
#endif