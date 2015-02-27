// <copyright file="UnsupportedDriveType.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>This error is raised if you try to interact for example with a mapped network drive.</summary>

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents an exception for unsuuported drive types
    /// </summary>
    public class UnsupportedDriveType : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="UnsupportedDriveType"/>
        /// </summary>
        /// <param name="path">Unsupported drive</param>
        public UnsupportedDriveType( string path )
            : base( "Unsupported Drive Type: only logical drives are supported; do not use mapped network drives.", path )
        {
        }
    }
}
