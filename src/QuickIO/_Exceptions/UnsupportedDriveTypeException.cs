// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Represents an exception for unsuuported drive types
    /// </summary>
    public class UnsupportedDriveTypeException : QuickIOBaseException
    {
        /// <summary>
        /// Creates an instance of <see cref="UnsupportedDriveTypeException"/>
        /// </summary>
        /// <param name="path">Unsupported drive</param>
        public UnsupportedDriveTypeException( string path )
            : base( "Unsupported Drive Type: only logical drives are supported; do not use mapped network drives.", path )
        {
        }
    }
}
