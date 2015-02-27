
// <copyright file="QuickIOFile_FileTimeMethods.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>07/06/2014</date>
// <summary>QuickIOFile_FileTimeMethods></summary>

using System;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFile
    {
        #region Get Creation Time
        /// <summary>
        /// Returns the creation time of the file or directory
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetCreationTime( String path )
        {
            return GetCreationTimeUtc( path ).ToLocalTime( );
        }
        /// <summary>
        /// Returns the creation time of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetCreationTime( QuickIOPathInfo info )
        {
            return GetCreationTimeUtc( info ).ToLocalTime( );
        }
        /// <summary>
        /// Returns the creation time of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetCreationTime( QuickIOFileInfo info )
        {
            return GetCreationTimeUtc( info.PathInfo ).ToLocalTime( );
        }

        /// <summary>
        /// Returns the creation time of the file or directory (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetCreationTimeUtc( String path )
        {
            return GetCreationTimeUtc( new QuickIOPathInfo( path )  );
        }
        /// <summary>
        /// Returns the creation time of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetCreationTimeUtc( QuickIOPathInfo info )
        {
            return info.FindData.GetCreationTimeUtc( );
        }
        /// <summary>
        /// Returns the creation time of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetCreationTimeUtc( QuickIOFileInfo info )
        {
            return info.FindData.GetCreationTimeUtc( );
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
        public static DateTime GetLastAccessTime( String path )
        {
            return GetLastAccessTimeUtc( path ).ToLocalTime( );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastAccessTime( QuickIOPathInfo info )
        {
            return GetLastAccessTimeUtc( info ).ToLocalTime( );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastAccessTime( QuickIOFileInfo info )
        {
            return GetLastAccessTimeUtc( info.PathInfo ).ToLocalTime( );
        }

        /// <summary>
        /// Returns the time of last access of the file or directory (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastAccessTimeUtc( String path )
        {
            return GetLastAccessTimeUtc( new QuickIOPathInfo( path ) );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastAccessTimeUtc( QuickIOPathInfo info )
        {
            return info.FindData.GetLastAccessTimeUtc( );
        }
        /// <summary>
        /// Returns the time of last access of the file or directory (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastAccessTimeUtc( QuickIOFileInfo info )
        {
            return info.FindData.GetLastAccessTimeUtc( );
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
        public static DateTime GetLastWriteTime( String path )
        {
            return GetLastWriteTimeUtc( path ).ToLocalTime( );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastWriteTime( QuickIOPathInfo info )
        {
            return GetLastWriteTimeUtc( info ).ToLocalTime( );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastWriteTime( QuickIOFileInfo info )
        {
            return GetLastWriteTimeUtc( info.PathInfo ).ToLocalTime( );
        }

        /// <summary>
        /// Returns the time of the file or directory was last written (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
        public static DateTime GetLastWriteTimeUtc( String path )
        {
            return GetLastWriteTimeUtc( new QuickIOPathInfo( path ) );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception> 
        public static DateTime GetLastWriteTimeUtc( QuickIOPathInfo info )
        {
            return info.FindData.GetLastWriteTimeUtc( );
        }
        /// <summary>
        /// Returns the time of the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">No entry found for passed path</exception> 
        public static DateTime GetLastWriteTimeUtc( QuickIOFileInfo info )
        {
            return info.FindData.GetLastWriteTimeUtc( );
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
        public static void SetAllFileTimes( String path, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
        {
            SetAllFileTimesUtc( path, creationTime.ToUniversalTime( ), lastAccessTime.ToUniversalTime( ), lastWriteTime.ToUniversalTime( ) );
        }
       /// <summary>
        /// Sets the time the file was created.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        public static void SetAllFileTimes( QuickIOPathInfo info, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
        {
            SetAllFileTimesUtc( info, creationTime.ToUniversalTime( ), lastAccessTime.ToUniversalTime( ), lastWriteTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Sets the time the file was created.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        public static void SetAllFileTimes( QuickIOFileInfo info, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
        {
            SetAllFileTimesUtc( info, creationTime.ToUniversalTime( ), lastAccessTime.ToUniversalTime( ), lastWriteTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static void SetAllFileTimesUtc( String path, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            InternalQuickIO.SetAllFileTimes( new QuickIOPathInfo( path ), creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc );
        }
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static void SetAllFileTimesUtc( QuickIOPathInfo info, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            InternalQuickIO.SetAllFileTimes( info, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc );
        }
        /// <summary>
        /// Sets the dates and times of given directory or file.
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        public static void SetAllFileTimesUtc( QuickIOFileInfo info, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
        {
            InternalQuickIO.SetAllFileTimes( info.PathInfo, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc );
        }
        #endregion

        #region Set Creation Time
        /// <summary>
        /// Defines the time at which the file or directory was created
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static void SetCreationTime( String path, DateTime creationTime )
        {
            SetCreationTimeUtc( path, creationTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static void SetCreationTime( QuickIOPathInfo info, DateTime creationTime )
        {
            SetCreationTimeUtc( info, creationTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static void SetCreationTime( QuickIOFileInfo info, DateTime creationTime )
        {
            SetCreationTimeUtc( info, creationTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
        public static void SetCreationTimeUtc( String path, DateTime creationTimeUtc )
        {
            InternalQuickIO.SetCreationTimeUtc( new QuickIOPathInfo( path ), creationTimeUtc );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
        public static void SetCreationTimeUtc( QuickIOPathInfo info, DateTime creationTimeUtc )
        {
            InternalQuickIO.SetCreationTimeUtc( info, creationTimeUtc );
        }
        /// <summary>
        /// Defines the time at which the file or directory was created (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
        public static void SetCreationTimeUtc( QuickIOFileInfo info, DateTime creationTimeUtc )
        {
            InternalQuickIO.SetCreationTimeUtc( info.PathInfo, creationTimeUtc );
        }
        #endregion

        #region Set Last Access Time
        /// <summary>
        /// Defines the time at which the file or directory was last accessed
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static void SetLastAccessTime( String path, DateTime lastAccessTime )
        {
            SetLastAccessTimeUtc( path, lastAccessTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstime(v=vs.110).aspx</remarks>
        public static void SetLastAccessTime( QuickIOPathInfo info, DateTime lastAccessTime )
        {
            SetLastAccessTimeUtc( info, lastAccessTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstime(v=vs.110).aspx</remarks>
        public static void SetLastAccessTime( QuickIOFileInfo info, DateTime lastAccessTime )
        {
            SetLastAccessTimeUtc( info, lastAccessTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
        public static void SetLastAccessTimeUtc( String path, DateTime lastAccessTimeUtc )
        {
            InternalQuickIO.SetLastAccessTimeUtc( new QuickIOPathInfo( path ), lastAccessTimeUtc );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
        public static void SetLastAccessTimeUtc( QuickIOPathInfo info, DateTime lastAccessTimeUtc )
        {
            InternalQuickIO.SetLastAccessTimeUtc( info, lastAccessTimeUtc );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last accessed (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
        public static void SetLastAccessTimeUtc( QuickIOFileInfo info, DateTime lastAccessTimeUtc )
        {
            InternalQuickIO.SetLastAccessTimeUtc( info.PathInfo, lastAccessTimeUtc );
        }
        #endregion

        #region Set Last Write Time
        /// <summary>
        /// Defines the time at which the file or directory was last written
        /// </summary>
        /// <param name="path">Affected file or directory</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
        public static void SetLastWriteTime( String path, DateTime lastWriteTime )
        {
            SetLastWriteTimeUtc( path, lastWriteTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetime(v=vs.110).aspx</remarks>
        public static void SetLastWriteTime( QuickIOPathInfo info, DateTime lastWriteTime )
        {
            SetLastWriteTimeUtc( info, lastWriteTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written
        /// </summary>
        /// <param name="info">Affected file or directory</param>
        /// <param name="lastWriteTime">The time that is to be used</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetime(v=vs.110).aspx</remarks>
        public static void SetLastWriteTime( QuickIOFileInfo info, DateTime lastWriteTime )
        {
            SetLastWriteTimeUtc( info, lastWriteTime.ToUniversalTime( ) );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written (UTC)
        /// </summary>
        /// <param name="path">Affected file or directory</param>     
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
        public static void SetLastWriteTimeUtc( String path, DateTime lastWriteTimeUtc )
        {
            InternalQuickIO.SetLastWriteTimeUtc( new QuickIOPathInfo( path ), lastWriteTimeUtc );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>     
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
        public static void SetLastWriteTimeUtc( QuickIOPathInfo info, DateTime lastWriteTimeUtc )
        {
            InternalQuickIO.SetLastWriteTimeUtc( info, lastWriteTimeUtc );
        }
        /// <summary>
        /// Defines the time at which the file or directory was last written (UTC)
        /// </summary>
        /// <param name="info">Affected file or directory</param>     
        /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
        public static void SetLastWriteTimeUtc( QuickIOFileInfo info, DateTime lastWriteTimeUtc )
        {
            InternalQuickIO.SetLastWriteTimeUtc( info.PathInfo, lastWriteTimeUtc );
        }
        #endregion
    }
}
