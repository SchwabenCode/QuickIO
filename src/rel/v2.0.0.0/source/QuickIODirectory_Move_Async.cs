// <copyright file="QuickIODirectory_Move.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIODirectory</summary>


#if NET40_OR_GREATER
using System;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectory
    {
        /// <summary>
        /// Moves a directory
        /// </summary>
        /// <param name="from">Fullname to move</param>
        /// <param name="to">Full targetname</param>
        /// <param name="overwrite">true to overwrite target</param>
        /// <exception cref="DirectoryAlreadyExistsException">Target exists</exception>
        public static Task MoveAsync( String from, String to, bool overwrite = false )
        {
            return NETCompatibility.AsyncExtensions.ExecuteAsync( () => Move( from, to, overwrite ) );
        }
    }
}
#endif
