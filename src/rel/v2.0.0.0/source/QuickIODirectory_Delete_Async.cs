// <copyright file="QuickIODirectory_Delete_Async.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory</summary>
#if NET40_OR_GREATER
using SchwabenCode.QuickIO.Internal;

using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;


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
        public static Task DeleteAsync( string path, bool recursive = false )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => Delete( path, recursive ) );
        }

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory. 
        /// </summary>
        /// <param name="info">The name of the directory to remove. </param>
        /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false. </param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/fxeahc5f(v=vs.110).aspx</remarks>
        /// <exception cref="PathNotFoundException">One or more intermediate directories do not exist; this function will only create the final directory in the path.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        public static Task DeleteAsync( QuickIOPathInfo info, bool recursive = false )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => Delete( info, recursive ) );
        }
    }
}
#endif