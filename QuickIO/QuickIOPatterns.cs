// <copyright file="QuickIOPatterns.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOPatterns</summary>
using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Pattern Collection
    /// </summary>
    public static class QuickIOPatterns
    {
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

        /// <summary>
        /// Matching Server Name
        /// </summary>
        /// <remarks>[a-zA-Z0-9_]+</remarks>
        public const String ServerNamePattern = @"[a-zA-Z0-9_]+";
        /// <summary>
        /// Matching QuickIOShareInfo Name
        /// </summary>
        /// <remarks>[a-zA-Z0-9_]+</remarks>
        public const String ShareNamePattern = @"[a-zA-Z0-9_]+";
        /// <summary>
        /// Matching Folder Name
        /// </summary>
        /// <remarks>[a-zA-Z0-9_]+</remarks>
        public const String FolderNamePattern = @"[a-zA-Z0-9_]+";

        /// <summary>
        /// Optional UNC Separator
        /// </summary>
        /// <remarks>\\{0,1}</remarks>
        public const String OptionalSperatorPattern = @"\\{0,1}";

        /// <summary>
        /// Pattern matching share root
        /// </summary>
        public const String RegularShareRootPattern = @"(?<Root>\\\\(?<Server>" + ServerNamePattern + @"|" + IPv4v6Pattern + @")\\(?<Name>" + ShareNamePattern + @"))" + OptionalSperatorPattern;

        /// <summary>
        /// Pattern matching share path
        /// </summary>
        public const String RegularSharePattern = @"(?<Fullname>" + RegularShareRootPattern + @"\\{0,1}(?<Path>((\\(" + FolderNamePattern + @")){0,})))" + OptionalSperatorPattern;

        /// <summary>
        /// Returns ^<paramref name="pattern"/>$
        /// </summary>
        public static String GetStrict( String pattern )
        {
            return "^" + pattern + "$";
        }
    }
}