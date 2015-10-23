// <copyright file="QuickIODirectory_Delete.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/05/2014</date>
// <summary>QuickIODirectory</summary>

using SchwabenCode.QuickIO.Internal;


namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory. 
        /// </summary>
        /// <param name="path">The name of the directory to remove. </param>
        /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false. </param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/fxeahc5f(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        /// <example>
        /// Creates directory structure
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         // Deletes directory C:\temp\QuickIOTest\sub\folder\tree and subfolders and files
        ///         QuickIODirectory.Delete( @"C:\temp\QuickIOTest\sub\folder\tree", recursive: true );
        ///     }
        /// </code>
        /// </example>
        /// <example>
        /// Shows how to handle sample exception if directory is not empty
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         try
        ///         {
        ///              QuickIODirectory.Delete( @"C:\temp\QuickIOTest\sub\folder\tree", recursive: false );
        ///         }
        ///         catch ( DirectoryNotEmptyException directoryNotEmptyException )
        ///         {
        ///             // Directoy is not empty
        ///         }
        ///     }
        /// </code>
        /// </example>
        public static void Delete( string path, bool recursive = false )
        {
            Delete( new QuickIOPathInfo( path ), recursive );
        }

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory. 
        /// </summary>
        /// <param name="info">The name of the directory to remove. </param>
        /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false. </param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/fxeahc5f(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        /// <example>
        /// Creates directory structure
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         QuickIOPathInfo pathInfo = new QuickIOPathInfo( @"C:\temp\QuickIOTest\sub\folder\tree" );
        /// 
        ///         // Deletes directory C:\temp\QuickIOTest\sub\folder\tree and subfolders and files
        ///         QuickIODirectory.Delete( pathInfo, recursive: true );
        ///     }
        /// </code>
        /// </example>
        /// <example>
        /// Shows how to handle sample exception if directory is not empty
        /// <code>
        ///     public static void Create_With_StringPath_Example()
        ///     {
        ///         QuickIOPathInfo pathInfo = new QuickIOPathInfo( @"C:\temp\QuickIOTest\sub\folder\tree" );
        /// 
        ///         try
        ///         {
        ///              QuickIODirectory.Delete( pathInfo, recursive: false );
        ///         }
        ///         catch ( DirectoryNotEmptyException directoryNotEmptyException )
        ///         {
        ///             // Directoy is not empty
        ///         }
        ///     }
        /// </code>
        /// </example>
        public static void Delete( QuickIOPathInfo info, bool recursive = false )
        {
            InternalQuickIO.DeleteDirectory( info, recursive );
        }
    }
}
