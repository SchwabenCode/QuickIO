// <copyright file="QuickIOShareInfo.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/15/2014</date>
// <summary>QuickIOShareInfo</summary>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Information about a local share
    /// </summary>
    public partial class QuickIOShareInfo
    {
        /// <summary>
        /// Called by enumeration
        /// </summary>
        /// <param name="server">Servername</param>
        /// <param name="shareName">Name of Share</param>
        /// <param name="shareType">Type of share</param>
        /// <param name="remark">Comment or smth</param>
        internal QuickIOShareInfo( String server, String shareName, QuickIOShareType shareType, String remark )
        {
            if ( QuickIOShareType.Special == shareType && "IPC$" == shareName )
            {
                shareType = QuickIOShareType.IPC;
            }

            InternalSetRequiredProperties( server, shareName, shareType, remark );
        }

        /// <summary>
        /// Sets the required properties
        /// </summary>
        /// <param name="server">Servername</param>
        /// <param name="shareName">Name of Share</param>
        /// <param name="shareType">Type of share</param>
        /// <param name="remark">Comment or smth</param>
        private void InternalSetRequiredProperties( String server, String shareName, QuickIOShareType shareType, String remark )
        {
            this.Server = server;
            this.ShareName = shareName;
            this.ShareType = shareType;
            this.Remark = remark;
        }

        /// <summary>
        /// The name of the computer that this share belongs to
        /// </summary>
        public String Server { get; private set; }

        /// <summary>
        /// QuickIOShareInfo name
        /// </summary>
        public String ShareName { get; private set; }

        /// <summary>
        /// QuickIOShareInfo type
        /// </summary>
        public QuickIOShareType ShareType { get; private set; }

        /// <summary>
        /// Comment
        /// </summary>
        public String Remark { get; private set; }

        /// <summary>
        /// Returns true if this is a file system share
        /// </summary>
        public bool IsFileSystem
        {
            get
            {
                if ( ShareType == QuickIOShareType.Disk )
                {
                    return true;
                }

                // Handle local special shares like C$
                if ( QuickIOShareType.Special == ShareType && !String.IsNullOrEmpty( ShareName ) )
                {
                    return true;
                }

                return false;
            }
        }


        /// <summary>
        /// Returns the path to this share
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return FullName;
        }

        /// <summary>
        /// Returns the path
        /// </summary>
        public String FullName
        {
            get { return String.Format( @"\\{0}\{1}", String.IsNullOrEmpty( Server ) ? Environment.MachineName : Server, ShareName ); }
        }
    }
}