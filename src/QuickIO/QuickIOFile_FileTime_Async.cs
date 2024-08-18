﻿
// ------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a T4 template.
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable

using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIOFile
{
    /// <summary>
    /// Returns the creation time of the file or directory
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetCreationTimeAsync( string path )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetCreationTime( path ) );
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
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetCreationTime( info ) );
    }
    /// <summary>
    /// Returns the creation time of the file or directory
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtime(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetCreationTimeAsync( QuickIOFileInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetCreationTime( info ) );
    }

    /// <summary>
    /// Returns the creation time of the file or directory (UTC)
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetCreationTimeUtcAsync( string path )
    {
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetCreationTimeUtc( path ) );
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
            return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetCreationTimeUtc( info ) );
    }
    /// <summary>
    /// Returns the creation time of the file or directory (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getcreationtimeutc(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime?> GetCreationTimeUtcAsync( QuickIOFileInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetCreationTimeUtc( info ) );
    }

    /// <summary>
    /// Returns the time of last access of the file or directory
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetLastAccessTimeAsync( string path )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTime( path ) );
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
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTime( info ) );
    }
    /// <summary>
    /// Returns the time of last access of the file or directory
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstime(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetLastAccessTimeAsync( QuickIOFileInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTime( info ) );
    }

    /// <summary>
    /// Returns the time of last access of the file or directory (UTC)
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetLastAccessTimeUtcAsync( string path )
    {
		return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTimeUtc( path ) );
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
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTimeUtc( info ) );
    }
    /// <summary>
    /// Returns the time of last access of the file or directory (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastaccesstimeutc(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime?> GetLastAccessTimeUtcAsync( QuickIOFileInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTimeUtc( info ) );
    }

    /// <summary>
    /// Returns the time of the file or directory was last written
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetLastWriteTimeAsync( string path )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTimeUtc( path ) );
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
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTimeUtc( info ) );
    }
    /// <summary>
    /// Returns the time of the file or directory was last written
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetime(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime?> GetLastWriteTimeAsync( QuickIOFileInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastAccessTimeUtc( info ) );
    }

    /// <summary>
    /// Returns the time of the file or directory was last written (UTC)
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception>   
    public static Task<DateTime> GetLastWriteTimeUtcAsync( string path )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastWriteTimeUtc( path ) );
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
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastWriteTimeUtc( info ) );
    }
    /// <summary>
    /// Returns the time of the file or directory was last written (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <returns>A <see cref="DateTime"/> structure. (UTC)</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.getlastwritetimeutc(v=vs.110).aspx</remarks>
    /// <exception cref="PathNotFoundException">No entry found for passed path</exception> 
    public static Task<DateTime?> GetLastWriteTimeUtcAsync( QuickIOFileInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( () => QuickIOFile.GetLastWriteTimeUtc( info ) );
    }

    /// <summary>
    /// Sets the time the file was created.
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="creationTime">The time that is to be used</param>
    /// <param name="lastAccessTime">The time that is to be used</param>
    /// <param name="lastWriteTime">The time that is to be used</param>
    public static Task SetAllFileTimesAsync( string path, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetAllFileTimes( path, creationTime, lastAccessTime, lastWriteTime ) );
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
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetAllFileTimes( info, creationTime, lastAccessTime, lastWriteTime ) );
    }
    /// <summary>
    /// Sets the time the file was created.
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="creationTime">The time that is to be used</param>
    /// <param name="lastAccessTime">The time that is to be used</param>
    /// <param name="lastWriteTime">The time that is to be used</param>
    public static Task SetAllFileTimesAsync( QuickIOFileInfo info, DateTime creationTime, DateTime lastAccessTime, DateTime lastWriteTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetAllFileTimes( info, creationTime, lastAccessTime, lastWriteTime ) );
    }
    /// <summary>
    /// Sets the dates and times of given directory or file.
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
    /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
    /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
    public static Task SetAllFileTimesUtcAsync( string path, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetAllFileTimesUtc( path, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc ) );
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
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetAllFileTimesUtc( info, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc ) );
    }
    /// <summary>
    /// Sets the dates and times of given directory or file.
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
    /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
    /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
    public static Task SetAllFileTimesUtcAsync( QuickIOFileInfo info, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetAllFileTimesUtc( info, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc ) );
    }

    /// <summary>
    /// Defines the time at which the file or directory was created
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="creationTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
    public static Task SetCreationTimeAsync( string path, DateTime creationTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetCreationTime( path, creationTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was created
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="creationTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
    public static Task SetCreationTimeAsync( QuickIOPathInfo info, DateTime creationTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetCreationTime( info, creationTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was created
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="creationTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
    public static Task SetCreationTimeAsync( QuickIOFileInfo info, DateTime creationTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetCreationTime( info, creationTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was created (UTC)
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
    public static Task SetCreationTimeUtcAsync( string path, DateTime creationTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetCreationTimeUtc( path, creationTimeUtc ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was created (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
    public static Task SetCreationTimeUtcAsync( QuickIOPathInfo info, DateTime creationTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetCreationTimeUtc( info, creationTimeUtc ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was created (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="creationTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtimeutc(v=vs.110).aspx</remarks>
    public static Task SetCreationTimeUtcAsync( QuickIOFileInfo info, DateTime creationTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetCreationTimeUtc( info, creationTimeUtc ) );
    }

    /// <summary>
    /// Defines the time at which the file or directory was last accessed
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="lastAccessTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
    public static Task SetLastAccessTimeAsync( string path, DateTime lastAccessTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastAccessTime( path, lastAccessTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last accessed
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="lastAccessTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstime(v=vs.110).aspx</remarks>
    public static Task SetLastAccessTimeAsync( QuickIOPathInfo info, DateTime lastAccessTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastAccessTime( info, lastAccessTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last accessed
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="lastAccessTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstime(v=vs.110).aspx</remarks>
    public static Task SetLastAccessTimeAsync( QuickIOFileInfo info, DateTime lastAccessTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastAccessTime( info, lastAccessTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last accessed (UTC)
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
    public static Task SetLastAccessTimeUtcAsync( string path, DateTime lastAccessTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastAccessTimeUtc( path, lastAccessTimeUtc ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last accessed (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
    public static Task SetLastAccessTimeUtcAsync( QuickIOPathInfo info, DateTime lastAccessTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastAccessTimeUtc( info, lastAccessTimeUtc ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last accessed (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="lastAccessTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastaccesstimeutc(v=vs.110).aspx</remarks>
    public static Task SetLastAccessTimeUtcAsync( QuickIOFileInfo info, DateTime lastAccessTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastAccessTimeUtc( info, lastAccessTimeUtc ) );
    }

    /// <summary>
    /// Defines the time at which the file or directory was last written
    /// </summary>
    /// <param name="path">Affected file or directory</param>
    /// <param name="lastWriteTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setcreationtime(v=vs.110).aspx</remarks>
    public static Task SetLastWriteTimeAsync( string path, DateTime lastWriteTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastWriteTime( path, lastWriteTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last written
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="lastWriteTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetime(v=vs.110).aspx</remarks>
    public static Task SetLastWriteTimeAsync( QuickIOPathInfo info, DateTime lastWriteTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastWriteTime( info, lastWriteTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last written
    /// </summary>
    /// <param name="info">Affected file or directory</param>
    /// <param name="lastWriteTime">The time that is to be used</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetime(v=vs.110).aspx</remarks>
    public static Task SetLastWriteTimeAsync( QuickIOFileInfo info, DateTime lastWriteTime )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastWriteTime( info, lastWriteTime ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last written (UTC)
    /// </summary>
    /// <param name="path">Affected file or directory</param>     
    /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
    public static Task SetLastWriteTimeUtcAsync( string path, DateTime lastWriteTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastWriteTimeUtc( path, lastWriteTimeUtc ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last written (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>     
    /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
    public static Task SetLastWriteTimeUtcAsync( QuickIOPathInfo info, DateTime lastWriteTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastWriteTimeUtc( info, lastWriteTimeUtc ) );
    }
    /// <summary>
    /// Defines the time at which the file or directory was last written (UTC)
    /// </summary>
    /// <param name="info">Affected file or directory</param>     
    /// <param name="lastWriteTimeUtc">The time that is to be used (UTC)</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.setlastwritetimeutc(v=vs.110).aspx</remarks>
    public static Task SetLastWriteTimeUtcAsync( QuickIOFileInfo info, DateTime lastWriteTimeUtc )
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync( () => QuickIOFile.SetLastWriteTimeUtc( info, lastWriteTimeUtc ) );
    }
}
