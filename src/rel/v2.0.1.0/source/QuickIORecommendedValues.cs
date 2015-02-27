// <copyright file="QuickIORecommendedValues.cs" company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/22/2014</date>
// <summary>QuickIORecommendedValues</summary>

using System;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Various default and recommended values for different operations, connections and API calls
    /// </summary>
    public static class QuickIORecommendedValues
    {
        /// <summary>
        /// Recommended buffer byte size for default read operations
        /// </summary>
        public const Int32 DefaultReadBufferBytes = 4096;

        /// <summary>
        /// Recommended size of Byte packages for TCP connections
        /// </summary>
        public const Int32 TCPMaxPackageBytes = 65535;

        /// <summary>
        /// Recommended size of Byte packages for local ethernet connections
        /// </summary>
        public const Int32 MTUMaxPackageBytes = 1500;

        /// <summary>
        /// Recommended size of Byte packages for SMB connections
        /// </summary>
        /// <remarks>See http://support.microsoft.com/kb/223140</remarks>
        public const Int32 SMBMaxPackageBytes = 60 * 1024;
    }
}
