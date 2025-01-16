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

public partial class QuickIODirectory
{
    /// <summary>
    /// Returns the root information
    /// </summary>
    /// <param name="path">The path of a file or directory. </param>
    /// <returns>A QuickIOPathInfo that represents the root or null if <paramref name="path"/> is root.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.getdirectoryroot(v=vs.110).aspx</remarks>
    public static Task<QuickIOPathInfo?> GetDirectoryRootAsync( string path )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.GetDirectoryRoot( path ) );
    }

    /// <summary>
    /// Returns the root information
    /// </summary>
    /// <param name="info">A file or directory. </param>
    /// <returns>A QuickIOPathInfo that represents the root or null if <paramref name="info"/> is root.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.getdirectoryroot(v=vs.110).aspx</remarks>
    public static Task<QuickIOPathInfo?> GetDirectoryRootAsync( QuickIOPathInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.GetDirectoryRoot( info ) );
    }

	/// <summary>
    /// Returns the root information
    /// </summary>
    /// <param name="info">A file or directory. </param>
    /// <returns>A QuickIOPathInfo that represents the root or null if <paramref name="info"/> is root.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.directory.getdirectoryroot(v=vs.110).aspx</remarks>
    public static Task<QuickIOPathInfo?> GetDirectoryRootAsync( QuickIODirectoryInfo info )
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult( ( ) => QuickIODirectory.GetDirectoryRoot( info ) );
    }
}
