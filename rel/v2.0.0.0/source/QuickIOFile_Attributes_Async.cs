
// <copyright file="QuickIOFile_Attributes_Async.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/06/2014</date>
// <summary>QuickIOFile_Attributes asynchronous></summary>

#if NET40_OR_GREATER
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;
using System.IO;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFile
    {
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task SetAttributesAsync( string path, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( ( ) => QuickIOFile.SetAttributes( path, attributes ) );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task SetAttributesAsync( QuickIOPathInfo info, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( ( ) => QuickIOFile.SetAttributes( info, attributes) );
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task SetAttributesAsync( QuickIOFileInfo info, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( ( ) => QuickIOFile.SetAttributes( info.PathInfo, attributes) );
        }

        #region Attributes
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task<FileAttributes> GetAttributesAsync( string path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIOFile.GetAttributes( path ) );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task<FileAttributes> GetAttributesAsync( QuickIOPathInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIOFile.GetAttributes( info ) );
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task<FileAttributes> GetAttributesAsync( QuickIOFileInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIOFile.GetAttributes( info ) );
        }

        #endregion

        #region Remove Attribute
        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="path">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static Task<bool> RemoveAttributeAsync( string path, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIOFile.RemoveAttribute( path, attribute ) );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static Task<bool> RemoveAttributeAsync( QuickIOPathInfo info, FileAttributes attribute)
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIOFile.RemoveAttribute( info, attribute ) );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static Task<bool> RemoveAttributeAsync( QuickIOFileInfo info, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIOFile.RemoveAttribute( info, attribute ) );
        }

        #endregion

        #region Add Attribute
        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="path">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static Task<bool> AddAttributeAsync( string path, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIOFile.AddAttribute( path, attribute ) );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static Task<bool> AddAttributeAsync( QuickIOPathInfo info, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIOFile.AddAttribute( info, attribute  ) );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static Task<bool> AddAttributeAsync( QuickIOFileInfo info, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIOFile.AddAttribute( info, attribute ) );
        }

        #endregion
    }
}
#endif
