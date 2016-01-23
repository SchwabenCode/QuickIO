// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIOFileInfo 
    {
        /// <summary>
        /// Receives <see cref="QuickIOFileMetadata"/> of current file
        /// </summary>
        /// <returns><see cref="QuickIOFileMetadata"/></returns>
        public QuickIOFileMetadata GetMetadata()
        {
            return new QuickIOFileMetadata( FullNameUnc, FindData );
        }
    }
}
