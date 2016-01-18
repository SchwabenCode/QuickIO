// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using SchwabenCode.QuickIO.Internal;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIOFileInfo
    {
        /// <summary>
        /// Checks byte length (NOT CONTENTS!)
        /// </summary>
        /// <param name="file">File to compare with</param>
        /// <returns>Returns true if both <see cref="QuickIOFileInfo.Bytes"/> properties are equal</returns>
        public Boolean IsEqualByteLength( QuickIOFileInfo file )
        {
            Contract.Requires( file != null );
            return ( this.Bytes == file.Bytes );
        }
    }
}
