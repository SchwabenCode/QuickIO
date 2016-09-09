// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Core;
using SchwabenCode.QuickIO.Win32;

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
            Contract.Requires( !String.IsNullOrWhiteSpace( server ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( shareName ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( remark ) );

            if( QuickIOShareType.Special == shareType && "IPC$" == shareName )
            {
                shareType = QuickIOShareType.IPC;
            }

            Server = server;
            ShareName = shareName;
            ShareType = shareType;
            Remark = remark;
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
                Contract.Requires( !String.IsNullOrWhiteSpace( ShareName ) );

                return
                    // DISK
                    ( ShareType == QuickIOShareType.Disk )
                    // OR SHARETYPE and NAME
                    || QuickIOShareType.Special == ShareType && !String.IsNullOrEmpty( ShareName );
            }
        }


        /// <summary>
        /// Returns the path to this share
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( FullName ) );
            Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );

            return FullName;
        }

        /// <summary>
        /// Returns the path in regular format (\\server\share\)
        /// </summary>
        private string _fullName;
        /// <summary>
        /// Returns the Fullname
        /// </summary>
        public string FullName
        {
            get
            {
                Contract.Requires( !String.IsNullOrWhiteSpace( ShareName ) );
                Contract.Ensures( !String.IsNullOrWhiteSpace( Contract.Result<String>() ) );
                Contract.Ensures( Contract.Result<String>() != null );

                if( _fullName == null )
                {
                    string name = ( String.IsNullOrEmpty( Server ) ? Environment.MachineName : Server );

                    _fullName = $@"\\{name}\{ShareName}";
                }

                return _fullName;
            }
        }
    }
}