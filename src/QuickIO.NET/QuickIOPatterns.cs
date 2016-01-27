// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Pattern Collection
    /// </summary>
    public static class QuickIOPatterns
    {
        /// <summary>
        /// Matches all. No filtering.
        /// </summary>
        public const String PathMatchAll = "*";

        /// <summary>
        /// Pattern to match IPv6
        /// </summary>
        /// <remarks>([\da-fA-F]{1,4}(\:[\da-fA-F]{1,4}){7})|(([\da-fA-F]{1,4}:){0,5}::([\da-fA-F]{1,4}:){0,5}[\da-fA-F]{1,4})</remarks>
        public const string IPv6Pattern = @"([\da-fA-F]{1,4}(\:[\da-fA-F]{1,4}){7})|(([\da-fA-F]{1,4}:){0,5}::([\da-fA-F]{1,4}:){0,5}[\da-fA-F]{1,4})";

        /// <summary>
        /// Pattern to match IPv4
        /// </summary>
        /// <remarks>(((([1]?\d)?\d|2[0-4]\d|25[0-5])\.){3}(([1]?\d)?\d|2[0-4]\d|25[0-5]))</remarks>
        public const String IPv4Pattern = @"(((([1]?\d)?\d|2[0-4]\d|25[0-5])\.){3}(([1]?\d)?\d|2[0-4]\d|25[0-5]))";

        /// <summary>
        /// Pattern to match IPv4 and IPv6
        /// </summary>
        /// <remarks>([\da-fA-F]{1,4}(\:[\da-fA-F]{1,4}){7})|(([\da-fA-F]{1,4}:){0,5}::([\da-fA-F]{1,4}:){0,5}[\da-fA-F]{1,4})|(((([1]?\d)?\d|2[0-4]\d|25[0-5])\.){3}(([1]?\d)?\d|2[0-4]\d|25[0-5]))</remarks>
        public const String IPv4v6Pattern = IPv4Pattern + @"|" + IPv6Pattern;

    }
}