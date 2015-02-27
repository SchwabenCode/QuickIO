// <copyright file="QuickIOShare_Enumerate.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/04/2014</date>
// <summary>QuickIOShare</summary>

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    public static partial class QuickIOShare
    {

        /// <summary>
        /// Enumerate shares of specific machine. If no machine is specified, local machine is used
        /// </summary>
        /// <returns>Collection of <see cref="QuickIOShareInfo"/></returns>
        public static IEnumerable<QuickIOShareInfo> EnumerateShares( String machineName = null, QuickIOShareApiReadLevel level = QuickIOShareApiReadLevel.Admin )
        {
            // Specify 
            var targetName = String.IsNullOrEmpty( machineName ) ? Environment.MachineName : machineName;

            Int32 resumeHandle = 0;
            var buffer = IntPtr.Zero;

            try
            {
                Int32 entriesRead = 0;
                Int32 totalEntries = 0;

                var returnCode = InternalQuickIO.GetShareEnumResult( targetName, level, ref buffer, ref entriesRead, ref totalEntries, ref resumeHandle );

                // Available return codes: http://msdn.microsoft.com/en-us/library/windows/desktop/bb525387(v=vs.85).aspx

                if ( returnCode == Win32ErrorCodes.ERROR_ACCESS_DENIED ) // Access Denied
                {
                    // Admin required, but not granted? try with normal usr
                    level = QuickIOShareApiReadLevel.Normal;
                    returnCode = InternalQuickIO.GetShareEnumResult( targetName, level, ref buffer, ref entriesRead, ref totalEntries, ref resumeHandle );
                }

                if ( returnCode != 0 ) // we only handle return 0 here
                {
                    yield break;

                }
                // Ignore no entries
                if ( entriesRead <= 0 )
                {
                    yield break;
                }

                Type shareType = ( level == QuickIOShareApiReadLevel.Admin ) ? typeof( Win32ApiShareInfoAdmin ) : typeof( Win32ApiShareInfoNormal );
                Int32 dataOffset = Marshal.SizeOf( shareType );

                for ( int i = 0, currentDataItem = buffer.ToInt32( ) ; i < entriesRead ; i++, currentDataItem += dataOffset )
                {

                    if ( level == QuickIOShareApiReadLevel.Normal )
                    {
                        yield return GetShareInfoWithNormalInformation( targetName, new IntPtr( currentDataItem ) );

                    }
                    else
                    {
                        yield return GetShareInfoWithAdminInformation( targetName, new IntPtr( currentDataItem ) );

                    }
                }
            }
            finally
            {
                // Clean up buffer allocated by system
                if ( buffer != IntPtr.Zero )
                {
                    Win32SafeNativeMethods.NetApiBufferFree( buffer );
                }
            }
        }
    }
}
