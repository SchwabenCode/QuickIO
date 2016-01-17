// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Collections.Generic;
using SchwabenCode.QuickIO.Internal;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFileInfo
    {
        /// <summary>
        /// Returns the if all timestamps are equal
        /// </summary>
        /// <param name="file">File to compare with</param>
        /// <returns>Returns the if all timestamps are equal</returns>
        public Boolean IsEqualTimestamps( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );
            return ( InternalIsEqualTimestampCreated( file ) && InternalIsEqualTimestampLastAccessed( file ) && InternalIsEqualTimestampsLastWritten( file ) );
        }

        /// <summary>
        /// Checks all timestamps.
        /// </summary>
        /// <param name="file">File to compare with</param>
        /// <returns>If collection is empty, all timestamps are equal. Otherwise unequal timestamp is returned.</returns>
        public IEnumerable<QuickIOFileCompareCriteria> CompareTimestamps( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );

            if ( InternalIsEqualTimestampCreated( file ) )
            {
                yield return QuickIOFileCompareCriteria.TimestampCreated;
            }

            if ( InternalIsEqualTimestampLastAccessed( file ) )
            {
                yield return QuickIOFileCompareCriteria.TimestampLastAccessed;
            }

            if ( InternalIsEqualTimestampsLastWritten( file ) )
            {
                yield return QuickIOFileCompareCriteria.TimestampLastWritten;
            }
        }

        /// <summary>
        /// Returns the if timestamp 'created' is equal
        /// </summary>
        /// <param name="file">File to compare with</param>
        /// <returns>Returns the if timestamp 'created' is equal</returns>
        public Boolean IsEqualTimestampCreated( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );
            return InternalIsEqualTimestampCreated( file );
        }
        /// <summary>
        /// Same as <see cref="IsEqualTimestampCreated"/> but does not check the param for null
        /// </summary>
        private Boolean InternalIsEqualTimestampCreated( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );

            var result = ( this.CreationTimeUtc.CompareTo( file.CreationTimeUtc ) );
            return ( result == 0 ); // result < 0: file1 is earlier, result > 0: file1 is later. 0 = equal 
        }

        /// <summary>
        /// Returns the if timestamp 'last accessed' is equal
        /// </summary>
        /// <param name="file">File to compare with</param>
        /// <returns>Returns the if timestamp 'last accessed' is equal</returns>
        public Boolean IsEqualTimestampLastAccessed( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );
            return InternalIsEqualTimestampLastAccessed( file );
        }
        /// <summary>
        /// Same as <see cref="IsEqualTimestampLastAccessed"/> but does not check the param for null
        /// </summary>
        private Boolean InternalIsEqualTimestampLastAccessed( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );

            int result = ( this.LastAccessTimeUtc.CompareTo( file.LastAccessTimeUtc ) );
            return ( result == 0 ); // result < 0: file1 is earlier, result > 0: file1 is later. 0 = equal 
        }

        /// <summary>
        /// Returns the if timestamp 'last written to' is equal
        /// </summary>
        /// <param name="file">File to compare with</param>
        /// <returns>Returns the if timestamp 'last written to' is equal</returns>
        public Boolean IsEqualTimestampsLastWritten( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );
            return InternalIsEqualTimestampsLastWritten( file );
        }
        /// <summary>
        /// Same as <see cref="IsEqualTimestampsLastWritten"/> but does not check the param for null
        /// </summary>
        private Boolean InternalIsEqualTimestampsLastWritten( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );

            int result = ( this.LastWriteTimeUtc.CompareTo( file.LastWriteTimeUtc ) );
            return ( result == 0 ); // result < 0: file1 is earlier, result > 0: file1 is later. 0 = equal 
        }
    }
}
