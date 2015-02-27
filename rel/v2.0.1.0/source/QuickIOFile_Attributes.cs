
// <copyright file="QuickIOFile_Attributes.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/06/2014</date>
// <summary>QuickIOFile_Attributes></summary>

using System;
using System.IO;
using SchwabenCode.QuickIO.Internal;

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
        public static void SetAttributes( string path , FileAttributes attributes )
        {
            SetAttributes( new QuickIOPathInfo( path ), attributes );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIOPathInfo info, FileAttributes attributes )
        {
            InternalQuickIO.SetAttributes( info, attributes);
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIOFileInfo info, FileAttributes attributes )
        {
            InternalQuickIO.SetAttributes( info.PathInfo, attributes);
        }

        #region Attributes
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( string path )
        {
            return GetAttributes( new QuickIOPathInfo( path ) );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIOPathInfo info )
        {
            return InternalQuickIO.GetAttributes( info );
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIOFileInfo info )
        {
            return InternalQuickIO.GetAttributes( info.PathInfo );
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
            return RemoveAttribute( new QuickIOPathInfo( path ), attribute );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIOPathInfo info, FileAttributes attribute)
        {
            return InternalQuickIO.RemoveAttribute( info, attribute );
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIOFileInfo info, FileAttributes attribute )
        {
            return InternalQuickIO.RemoveAttribute( info.PathInfo, attribute );
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
            return AddAttribute( new QuickIOPathInfo( path ), attribute );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIOPathInfo info, FileAttributes attribute )
        {
            return InternalQuickIO.AddAttribute( info, attribute  );
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIOFileInfo info, FileAttributes attribute )
        {
            return InternalQuickIO.AddAttribute( info.PathInfo, attribute );
        }

        #endregion
    }
}
