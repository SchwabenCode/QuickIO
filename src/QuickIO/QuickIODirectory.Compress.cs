// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System.IO;
using System;
using System.IO.Compression;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectory
    {
        /// <summary>
        /// Compresses a directory by using <see>
        ///         <cref>ZipFile.CreateFromDirectory</cref>
        ///     </see>
        /// </summary>
        /// <param name="directoryFullPath">Directory fullname to zip</param>
        /// <param name="zipFullPath">Zipfile fullname to save</param>
        /// <param name="overWriteExistingZip">true to overwrite existing zipfile</param>
        /// <param name="compressionLevel"><see cref="CompressionLevel"/></param>
        /// <param name="includeBaseDirectory">True to include basedirectory</param>
        /// <exception cref="DirectoryNotFoundException">if <paramref name="directoryFullPath"/> does not exist.</exception>
        /// <exception cref="FileAlreadyExistsException">if <paramref name="zipFullPath"/> does exist and <paramref name="overWriteExistingZip"/> is <i>false</i>.</exception>
        public static void Compress( String directoryFullPath, String zipFullPath, bool overWriteExistingZip = false, CompressionLevel compressionLevel = CompressionLevel.Fastest, bool includeBaseDirectory = false )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( directoryFullPath ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( zipFullPath ) );

            if( !QuickIODirectory.Exists( directoryFullPath ) )
            {
                throw new DirectoryNotFoundException( $"Directory to zip '{directoryFullPath}' does not exist." );
            }

            if( !overWriteExistingZip && ( QuickIOFile.Exists( zipFullPath ) ) )
            {
                throw new FileAlreadyExistsException( $"The target zipFile name '{zipFullPath}' already exists." );
            }

            throw new NotImplementedException();
            //ZipFile.CreateFromDirectory( directoryFullPath, zipFullPath, compressionLevel, includeBaseDirectory );
        }

        /// <summary>
        /// Compresses a directory by using <see>
        ///         <cref>ZipFile.CreateFromDirectory</cref>
        ///     </see>
        /// </summary>
        /// <param name="directory">Directory to zip</param>
        /// <param name="zipFullPath">Zipfile fullname to save</param>
        /// <param name="overWriteExistingZip">true to overwrite existing zipfile</param>
        /// <param name="compressionLevel"><see cref="CompressionLevel"/></param>
        /// <param name="includeBaseDirectory">True to include basedirectory</param>
        public static void Compress( QuickIODirectoryInfo directory, String zipFullPath, bool overWriteExistingZip = false, CompressionLevel compressionLevel = CompressionLevel.Fastest, bool includeBaseDirectory = false )
        {
            Contract.Requires( directory != null );
            Contract.Requires( !String.IsNullOrWhiteSpace( zipFullPath ) );

            Compress( directory.FullName, zipFullPath, overWriteExistingZip, compressionLevel, includeBaseDirectory );
        }
    }
}