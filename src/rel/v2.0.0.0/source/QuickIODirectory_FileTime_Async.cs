
// <copyright file="QuickIODirectory_FileTimeMethods.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/06/2014</date>
// <summary>QuickIODirectory_FileTimeMethods></summary>

#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectory
    {
        #region Get Creation Time
        /// <summary>
        /// Returns the creation time of the file or directory
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetCreationTimeAsync( String path )
        {
           return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetCreationTime( path ) );
        }
        /// <summary>
        /// Returns the creation time of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetCreationTimeAsync( QuickIOPathInfo info )
        {
             return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetCreationTime( info ) );
        }
        /// <summary>
        /// Returns the creation time of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetCreationTimeAsync( QuickIODirectoryInfo info )
        {
           return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetCreationTime( info ) );
        }

        /// <summary>
        /// Returns the creation time of the file or directory (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetCreationTimeUtcAsync( String path )
        {
             return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetCreationTimeUtc( path ) );
        }
        /// <summary>
        /// Returns the creation time of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetCreationTimeUtcAsync( QuickIOPathInfo info )
        {
                return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetCreationTimeUtc( info ) );
        }
        /// <summary>
        /// Returns the creation time of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetCreationTimeUtcAsync( QuickIODirectoryInfo info )
        {
         return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetCreationTimeUtc( info ) );
        }
        #endregion

        #region Get Last Access Time
        /// <summary>
        /// Returns the time of last access of the file or directory
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastAccessTimeAsync( String path )
        {
           return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTime( path ) );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastAccessTimeAsync( QuickIOPathInfo info )
        {
           return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTime( info ) );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastAccessTimeAsync( QuickIODirectoryInfo info )
        {
          return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTime( info ) );
        }

        /// <summary>
        /// Returns the time of last access of the file or directory (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastAccessTimeUtcAsync( String path )
        {
			return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTimeUtc( path ) );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastAccessTimeUtcAsync( QuickIOPathInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTimeUtc( info ) );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastAccessTimeUtcAsync( QuickIODirectoryInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTimeUtc( info ) );
        }
        #endregion

        #region Get Last Write Time
        /// <summary>
        /// Returns the time of the file or directory was last written
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastWriteTimeAsync( String path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTimeUtc( path ) );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastWriteTimeAsync( QuickIOPathInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTimeUtc( info ) );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastWriteTimeAsync( QuickIODirectoryInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastAccessTimeUtc( info ) );
        }

        /// <summary>
        /// Returns the time of the file or directory was last written (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static Task<DateTime> GetLastWriteTimeUtcAsync( String path )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastWriteTimeUtc( path ) );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception> 
        public static Task<DateTime> GetLastWriteTimeUtcAsync( QuickIOPathInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastWriteTimeUtc( info ) );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception> 
        public static Task<DateTime> GetLastWriteTimeUtcAsync( QuickIODirectoryInfo info )
        {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIODirectory.GetLastWriteTimeUtc( info ) );
        }
        #endregion

        #region Set All Times
        /// <summary>
        /// Sets the time the file was created.
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        public static Task SetAllFileTimesAsync( String path, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetAllFileTimes( path, creationTime, lastAccessTime, lastWriteTime ) );
        }
        /// <summary>
        /// Sets the time the file was created.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        public static Task SetAllFileTimesAsync( QuickIOPathInfo info, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetAllFileTimes( info, creationTime, lastAccessTime, lastWriteTime ) );
        }
        /// <summary>
        /// Sets the time the file was created.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        public static Task SetAllFileTimesAsync( QuickIODirectoryInfo info, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetAllFileTimes( info, creationTime, lastAccessTime, lastWriteTime ) );
        }
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static Task SetAllFileTimesUtcAsync( String path, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetAllFileTimesUtc( path, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc ) );
        }
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static Task SetAllFileTimesUtcAsync( QuickIOPathInfo info, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetAllFileTimesUtc( info, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc ) );
        }
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static Task SetAllFileTimesUtcAsync( QuickIODirectoryInfo info, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetAllFileTimesUtc( info, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc ) );
        }
        #endregion

        #region Set Creation Time
        /// <summary>
        /// Defines the time at which the file or directory was created
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static Task SetCreationTimeAsync( String path, DateTime creationTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetCreationTime( path, creationTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static Task SetCreationTimeAsync( QuickIOPathInfo info, DateTime creationTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetCreationTime( info, creationTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static Task SetCreationTimeAsync( QuickIODirectoryInfo info, DateTime creationTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetCreationTime( info, creationTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
        public static Task SetCreationTimeUtcAsync( String path, DateTime creationTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetCreationTimeUtc( path, creationTimeUtc ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
        public static Task SetCreationTimeUtcAsync( QuickIOPathInfo info, DateTime creationTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetCreationTimeUtc( info, creationTimeUtc ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
        public static Task SetCreationTimeUtcAsync( QuickIODirectoryInfo info, DateTime creationTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetCreationTimeUtc( info, creationTimeUtc ) );
        }
        #endregion

        #region Set Last Access Time
        /// <summary>
        /// Defines the time at which the file or directory was last accessed
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static Task SetLastAccessTimeAsync( String path, DateTime lastAccessTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastAccessTime( path, lastAccessTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstime(v=vs.110).aspx</remarks>
        public static Task SetLastAccessTimeAsync( QuickIOPathInfo info, DateTime lastAccessTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastAccessTime( info, lastAccessTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstime(v=vs.110).aspx</remarks>
        public static Task SetLastAccessTimeAsync( QuickIODirectoryInfo info, DateTime lastAccessTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastAccessTime( info, lastAccessTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
        public static Task SetLastAccessTimeUtcAsync( String path, DateTime lastAccessTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastAccessTimeUtc( path, lastAccessTimeUtc ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
        public static Task SetLastAccessTimeUtcAsync( QuickIOPathInfo info, DateTime lastAccessTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastAccessTimeUtc( info, lastAccessTimeUtc ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
        public static Task SetLastAccessTimeUtcAsync( QuickIODirectoryInfo info, DateTime lastAccessTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastAccessTimeUtc( info, lastAccessTimeUtc ) );
        }
        #endregion

        #region Set Last Write Time
        /// <summary>
        /// Defines the time at which the file or directory was last written
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static Task SetLastWriteTimeAsync( String path, DateTime lastWriteTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastWriteTime( path, lastWriteTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetime(v=vs.110).aspx</remarks>
        public static Task SetLastWriteTimeAsync( QuickIOPathInfo info, DateTime lastWriteTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastWriteTime( info, lastWriteTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetime(v=vs.110).aspx</remarks>
        public static Task SetLastWriteTimeAsync( QuickIODirectoryInfo info, DateTime lastWriteTime )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastWriteTime( info, lastWriteTime ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>     
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
        public static Task SetLastWriteTimeUtcAsync( String path, DateTime lastWriteTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastWriteTimeUtc( path, lastWriteTimeUtc ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>     
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
        public static Task SetLastWriteTimeUtcAsync( QuickIOPathInfo info, DateTime lastWriteTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastWriteTimeUtc( info, lastWriteTimeUtc ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>     
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
        public static Task SetLastWriteTimeUtcAsync( QuickIODirectoryInfo info, DateTime lastWriteTimeUtc )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIODirectory.SetLastWriteTimeUtc( info, lastWriteTimeUtc ) );
        }
        #endregion
    }
}
#endif
