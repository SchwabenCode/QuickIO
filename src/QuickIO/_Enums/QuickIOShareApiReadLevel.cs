// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Read level indicator for share access
    /// </summary>
    public enum QuickIOShareApiReadLevel : int
    {
        /// <summary>
        /// Requests all information and required admin privilegs
        /// </summary>
        Admin = 2,
        /// <summary>
        /// Default call type
        /// </summary>
        Normal = 1
    }
}