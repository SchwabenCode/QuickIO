// <copyright file="QuickIODirectory_Create.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory_Create_Async</summary>

using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exist.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/54a0at6s(v=vs.110).aspx</remarks>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <example>
        /// Creates directory structure
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         // Creates directory C:\temp\QuickIOTest\sub\folder\tree and all not existing parent folders
        ///         QuickIODirectory.Create( @"C:\temp\QuickIOTest\sub\folder\tree", recursive: true );
        ///     }
        /// </code>
        /// </example>
        /// <example>
        /// Shows how to handle sample exception if parent directory does not exist.
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         try
        ///         {
        ///              QuickIODirectory.Create( @"C:\temp\QuickIOTest\sub\folder\tree", recursive: false );
        ///         }
        ///         catch ( PathNotFoundException pathNotFoundException )
        ///         {
        ///             // Parent directory does not exist.
        ///         }
        ///     }
        /// </code>
        /// </example>
        public static void Create(string path, bool recursive = false)
        {
            Create(new QuickIOPathInfo(path), recursive);
        }

        /// <summary>
        /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exist.
        /// </summary>
        /// <param name="pathInfo">The directory.</param>
        /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/54a0at6s(v=vs.110).aspx</remarks>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <example>
        /// Creates directory structure
        /// <code>
        ///     public static void Create_With_PathInfo_Example( );
        ///     {
        ///         QuickIOPathInfo pathInfo = new QuickIOPathInfo( @"C:\temp\QuickIOTest\sub\folder\tree" );
        /// 
        ///         // Creates directory C:\temp\QuickIOTest\sub\folder\tree and all not existing parent folders
        ///         QuickIODirectory.Create( pathInfo, recursive: true );
        ///     }
        /// </code>
        /// </example>
        /// <example>
        /// Shows how to handle sample exception if parent directory does not exist.
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         QuickIOPathInfo pathInfo = new QuickIOPathInfo( @"C:\temp\QuickIOTest\sub\folder\tree" );
        /// 
        ///         try
        ///         {
        ///              QuickIODirectory.Create( pathInfo, recursive: false );
        ///         }
        ///         catch ( PathNotFoundException pathNotFoundException )
        ///         {
        ///             // Parent directory does not exist.
        ///         }
        ///     }
        /// </code>
        /// </example>
        public static void Create( QuickIOPathInfo pathInfo, bool recursive = false )
        {
            InternalQuickIO.CreateDirectory( pathInfo, recursive );
        }
    }
}
