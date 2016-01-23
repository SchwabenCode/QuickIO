// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Win32;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Core;

namespace SchwabenCode.QuickIO.Internal
{
    internal static partial class InternalQuickIO
    {
        /// <summary>
        /// Enumerate shares of specific machine. If no machine is specified, local machine is used
        /// </summary>
        /// <returns>Collection of <see cref="QuickIOShareInfo"/></returns>
        public static IEnumerable<QuickIOShareInfo> EnumerateShares<T>( QuickIOShareApiReadLevel level, String machineName = null ) where T : IWin32ApiShareInfo
        {
            Contract.Ensures( Contract.Result<IEnumerable<QuickIOShareInfo>>() != null );

            // Specify 
            string machine = String.IsNullOrEmpty( machineName ) ? Environment.MachineName : machineName;
            IntPtr buffer = IntPtr.Zero;

            try
            {
                int resumeHandle = 0;
                int entriesRead, totalEntries;
                int returnCode = Win32SafeNativeMethods.NetShareEnum( machineName, ( int )level, out buffer, -1, out entriesRead, out totalEntries, ref resumeHandle );

                // Available return codes: http://msdn.microsoft.com/en-us/library/windows/desktop/bb525387(v=vs.85).aspx

                //if( returnCode == Win32ErrorCodes.ERROR_ACCESS_DENIED ) // Access Denied
                //{
                //    level = QuickIOShareApiReadLevel.Normal
                //    // Admin required, but not granted? try with normal usr
                //    returnCode = InternalQuickIO.GetShareEnumResult( machine, level, ref buffer, ref entriesRead, ref totalEntries, ref resumeHandle );
                //}

                //// skip if zero or no entries
                //if( returnCode != 0 || entriesRead <= 0 ) // we only handle return 0 here
                //{
                //    yield break;
                //}

                if( returnCode > 0 )
                {
                    Type type = typeof( T );
                    int typeSize = Marshal.SizeOf( type );

                    for( int i = 0, currentDataItem = buffer.ToInt32() ;i < entriesRead ;i++, currentDataItem += typeSize )
                    {
                        IWin32ApiShareInfo shareInfo = ( T )Marshal.PtrToStructure( new IntPtr( currentDataItem ), typeof( T ) );
                        yield return new QuickIOShareInfo( machine, shareInfo.GetShareName(), shareInfo.GetShareType(), shareInfo.GetRemark() );
                    }
                }
            }
            finally
            {
                // Clean up buffer allocated by system
                // TODO: check if this is enough here
                if( buffer != IntPtr.Zero )
                {
                    Win32SafeNativeMethods.NetApiBufferFree( buffer );
                }
            }
        }
    }
}