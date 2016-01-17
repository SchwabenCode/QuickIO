// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.PInvoke;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO
{
    public partial class QuickIODirectory
    {
        /// <summary>
        /// Moves a directory
        /// </summary>
        /// <param name="from">Fullname to move</param>
        /// <param name="to">Full targetname</param>
        /// <param name="overwrite">true to overwrite target</param>
        /// <exception cref="DirectoryAlreadyExistsException">Target exists</exception>
        public static void Move( String from, String to, bool overwrite = false )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( from ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( to ) );

            if( !overwrite && Exists( to ) )
            {
                throw new DirectoryAlreadyExistsException( "Target directory already exists.", to );
            }

            if( !Win32SafeNativeMethods.MoveFile( from, to ) )
            {
                var win32Error = Marshal.GetLastWin32Error();
                InternalQuickIOCommon.NativeExceptionMapping( from, win32Error );
            }
        }
    }
}
