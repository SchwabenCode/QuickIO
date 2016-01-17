// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using SchwabenCode.QuickIO.Internal;
using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace SchwabenCode.QuickIO
{
    public class QuickIO
    {
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( string path, FileAttributes attributes )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            InternalQuickIO.SetAttributes( path, attributes );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIOPathInfo info, FileAttributes attributes )
        {
            Contract.Requires( info != null );
            SetAttributes( info.FullNameUnc, attributes );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIOFileInfo info, FileAttributes attributes )
        {
            Contract.Requires( info != null );
            SetAttributes( info.PathInfo, attributes );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIODirectoryInfo info, FileAttributes attributes )
        {
            Contract.Requires( info != null );
            SetAttributes( info.PathInfo, attributes );
        }

        #region Attributes
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return InternalQuickIO.GetAttributes( path );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIOPathInfo info )
        {
            Contract.Requires( info != null );
            return GetAttributes( info.FullNameUnc );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIOFileInfo info )
        {
            Contract.Requires( info != null );
            return GetAttributes( info.PathInfo );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIODirectoryInfo info )
        {
            Contract.Requires( info != null );
            return GetAttributes( info.PathInfo );
        }

        #endregion

        #region Remove Attribute
        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="path">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( string path, FileAttributes attribute )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return InternalQuickIO.RemoveAttribute( path, attribute );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIOPathInfo info, FileAttributes attribute )
        {
            Contract.Requires( info != null );
            return RemoveAttribute( info.FullNameUnc, attribute );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIOFileInfo info, FileAttributes attribute )
        {
            Contract.Requires( info != null );
            return RemoveAttribute( info.PathInfo, attribute );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIODirectoryInfo info, FileAttributes attribute )
        {
            Contract.Requires( info != null );
            return RemoveAttribute( info.PathInfo, attribute );
        }

        #endregion

        #region Add Attribute
        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="path">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( string path, FileAttributes attribute )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            return InternalQuickIO.AddAttribute( path, attribute );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIOPathInfo info, FileAttributes attribute )
        {
            Contract.Requires( info != null );
            return AddAttribute( info.FullNameUnc, attribute );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIOFileInfo info, FileAttributes attribute )
        {
            Contract.Requires( info != null );
            return AddAttribute( info.PathInfo, attribute );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIODirectoryInfo info, FileAttributes attribute )
        {
            Contract.Requires( info != null );
            return AddAttribute( info.PathInfo, attribute );
        }

        #endregion Add Attribute
    }
}
