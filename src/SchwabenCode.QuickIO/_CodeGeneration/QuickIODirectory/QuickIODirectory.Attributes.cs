
// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>


using System;
using System.IO;
using SchwabenCode.QuickIO.Engine;

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
        public static void SetAttributes( string path , FileAttributes attributes )
        {
			QuickIOEngine.SetAttributes( QuickIOPath.ToPathUnc( path ), attributes );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIOPathInfo info, FileAttributes attributes )
        {
            QuickIOEngine.SetAttributes( info.FullNameUnc, attributes);
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attributes">New attributes to set.</param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static void SetAttributes( QuickIODirectoryInfo info, FileAttributes attributes )
        {
            QuickIOEngine.SetAttributes( info.FullNameUnc, attributes);
        }

        #region Attributes
        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="path">The path to the directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( string path )
        {
            return QuickIOEngine.GetAttributes( QuickIOPath.ToPathUnc (path) );
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIOPathInfo info )
        {
            return QuickIOEngine.GetAttributes( info.FullNameUnc );
        }

		/// <summary>
        /// Gets the <see cref="FileAttributes"/> of the directory or file.
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <returns>The <see cref="FileAttributes"/> of the directory or file.</returns>
        public static FileAttributes GetAttributes( QuickIODirectoryInfo info )
        {
            return QuickIOEngine.GetAttributes(info.FullNameUnc);
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
            FileAttributes updatedAttributes;
            bool result = QuickIOEngine.TryRemoveAttribute(QuickIOPath.ToPathUnc(path), attribute, out updatedAttributes);

            return result;
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIOPathInfo info, FileAttributes attribute)
        {
            FileAttributes updatedAttributes;
            bool result = QuickIOEngine.TryRemoveAttribute(info.FullNameUnc, attribute, out updatedAttributes);
            info.Attributes = updatedAttributes;

            return result;
        }

        /// <summary>
        /// Removes the specified attribute from file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to remove </param>
        /// <returns>true if removed. false if not exists in attributes</returns>
        public static bool RemoveAttribute( QuickIODirectoryInfo info, FileAttributes attribute )
        {
            FileAttributes updatedAttributes;
            bool result = QuickIOEngine.TryRemoveAttribute(info.FullNameUnc, attribute, out updatedAttributes);
            info.Attributes = updatedAttributes;

            return result;
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
            FileAttributes updatedAttributes;
            bool result = QuickIOEngine.TryAddAttribute(QuickIOPath.ToPathUnc(path), attribute, out updatedAttributes);

            return result;
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIOPathInfo info, FileAttributes attribute )
        {
            FileAttributes updatedAttributes;
            bool result = QuickIOEngine.TryAddAttribute(info.FullNameUnc, attribute, out updatedAttributes);
            info.Attributes = updatedAttributes;

            return result;
        }

        /// <summary>
        /// Adds the specified attribute to file or directory
        /// </summary>
        /// <param name="info">A directory or file. </param>
        /// <param name="attribute">Attribute to add </param>
        /// <returns>true if added. false if already exists in attributes</returns>
        public static bool AddAttribute( QuickIODirectoryInfo info, FileAttributes attribute )
        {
            FileAttributes updatedAttributes;
            bool result = QuickIOEngine.TryAddAttribute(info.FullNameUnc, attribute, out updatedAttributes);
            info.Attributes = updatedAttributes;

            return result;
        }

        #endregion
    }
}
