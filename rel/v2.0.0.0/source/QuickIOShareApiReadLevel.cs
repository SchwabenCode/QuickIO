// <copyright file="QuickIOShareApiReadLevel.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/15/2014</date>
// <summary>QuickIOShareApiReadLevel</summary>

namespace SchwabenCode.QuickIO
{
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