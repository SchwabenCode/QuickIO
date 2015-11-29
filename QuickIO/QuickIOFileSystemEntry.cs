using System;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents a file system entry type
    /// </summary>
    public class QuickIOFileSystemEntry
    {
        /// <summary>
        /// Creates an instance of <see cref = "QuickIOFileSystemEntryInfo"/>
        /// </summary>
        internal QuickIOFileSystemEntry( String fullName, QuickIOFileSystemEntryType type )
        {
            Contract.Requires( !String.IsNullOrEmpty( fullName ) );
            FullName = fullName;
            Type = type;
        }

        /// <summary>
        /// Entries fullname
        /// </summary>
        public String FullName
        {
            get;
            private set;
        }

        /// <summary>
        /// Entries type
        /// </summary>
        public QuickIOFileSystemEntryType Type
        {
            get;
            private set;
        }
    }
}