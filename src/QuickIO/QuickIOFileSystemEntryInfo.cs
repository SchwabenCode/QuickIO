using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents a file system entry type
    /// </summary>
    public class QuickIOFileSystemEntryInfo
    {
        /// <summary>
        /// Creates an instance of <see cref = "QuickIOFileSystemEntryInfo"/>
        /// </summary>
        internal QuickIOFileSystemEntryInfo( QuickIOPathInfo pathInfo, QuickIOFileSystemEntryType type )
        {
            Contract.Requires( pathInfo != null );
            PathInfo = pathInfo;
            Type = type;
        }

        /// <summary>
        /// Entry's fullname
        /// </summary>
        public QuickIOPathInfo PathInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// Entry type
        /// </summary>
        public QuickIOFileSystemEntryType Type
        {
            get;
            private set;
        }
    }
}