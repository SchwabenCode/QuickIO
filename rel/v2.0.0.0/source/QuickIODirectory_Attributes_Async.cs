
// <copyright file="QuickIODirectory_Attributes_Async.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/06/2014</date>
// <summary>QuickIODirectory_Attributes asynchronous></summary>

#if NET40_OR_GREATER
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;
using System.IO;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectory
    {
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task SetAttributesAsync( string path, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( ( ) => QuickIODirectory.SetAttributes( path, attributes ) );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task SetAttributesAsync( QuickIOPathInfo info, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( ( ) => QuickIODirectory.SetAttributes( info, attributes) );
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task SetAttributesAsync( QuickIODirectoryInfo info, FileAttributes attributes )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( ( ) => QuickIODirectory.SetAttributes( info.PathInfo, attributes) );
        }

        #region Attributes
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task<FileAttributes> GetAttributesAsync( string path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIODirectory.GetAttributes( path ) );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task<FileAttributes> GetAttributesAsync( QuickIOPathInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIODirectory.GetAttributes( info ) );
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static Task<FileAttributes> GetAttributesAsync( QuickIODirectoryInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIODirectory.GetAttributes( info ) );
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
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.RemoveAttribute( path, attribute ) );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static Task<bool> RemoveAttributeAsync( QuickIOPathInfo info, FileAttributes attribute)
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIODirectory.RemoveAttribute( info, attribute ) );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static Task<bool> RemoveAttributeAsync( QuickIODirectoryInfo info, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIODirectory.RemoveAttribute( info, attribute ) );
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
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.AddAttribute( path, attribute ) );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static Task<bool> AddAttributeAsync( QuickIOPathInfo info, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) =>  QuickIODirectory.AddAttribute( info, attribute  ) );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static Task<bool> AddAttributeAsync( QuickIODirectoryInfo info, FileAttributes attribute )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.AddAttribute( info, attribute ) );
        }

        #endregion
    }
}
#endif
