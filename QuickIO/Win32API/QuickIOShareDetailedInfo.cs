// <copyright file="QuickIOShareDetailedInfo.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/04/2014</date>
// <summary>QuickIOShareDetailedInfo</summary>
using System;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Container of detailed share information
    /// </summary>
    public class QuickIOShareDetailedInfo
    {
        /// <summary>
        /// Transfers the struct information to the class
        /// </summary>
        /// <param name="shareInfo">share information</param>
        internal QuickIOShareDetailedInfo( Win32ApiShareInfoAdmin shareInfo )
        {
            this.Name = shareInfo.ShareName;
            this.Type = shareInfo.ShareType;
            this.Remark = shareInfo.Remark;

            this.Permissions = shareInfo.Permissions;
            this.MaxUsers = shareInfo.MaxUsers;
            this.CurrentUsers = shareInfo.CurrentUsers;
            this.Path = shareInfo.Path;
            this.Password = shareInfo.Password;
        }

        /// <summary>
        /// Transfers the struct information to the class
        /// </summary>
        /// <param name="shareInfo">share information</param>
        internal QuickIOShareDetailedInfo( Win32ApiShareInfoNormal shareInfo )
        {
            this.Name = shareInfo.ShareName;
            this.Type = shareInfo.ShareType;
            this.Remark = shareInfo.Remark;
        }

        #region Required

        /// <summary>
        /// Name of Share
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Share Type
        /// </summary>
        public QuickIOShareType Type { get; private set; }

        /// <summary>
        /// Remark / Comment
        /// </summary>
        public String Remark { get; private set; }

        #endregion

        #region Optional

        /// <summary>
        /// Permissions. Is null, if admin privileges are not granted.
        /// </summary>
        public Int32? Permissions { get; private set; }

        /// <summary>
        /// MaxUsers of the parallel connected users. Is null, if admin privileges are not granted.
        /// </summary>
        public Int32? MaxUsers { get; private set; }

        /// <summary>
        /// CurrentUsers connected to the share. Is null, if admin privileges are not granted.
        /// </summary>
        public Int32? CurrentUsers { get; private set; }

        /// <summary>
        /// Permissions. Is null, if admin privileges are not granted.
        /// </summary>
        public String Path { get; private set; }

        /// <summary>
        /// Password. Is null, if admin privileges are not granted.
        /// </summary>
        public String Password { get; private set; }

        #endregion
    }
}