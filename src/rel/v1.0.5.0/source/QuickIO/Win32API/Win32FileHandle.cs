// <copyright file="Win32ApiFileHandle.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides a class for Win32 safe handle implementations</summary>


using System;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace SchwabenCode.QuickIO.Win32API
{
    /// <summary>
    /// Provides a class for Win32 safe handle implementations
    /// </summary>
    internal sealed class Win32FileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the Win32ApiFileHandle class, specifying whether the handle is to be reliably released.
        /// </summary>
        [SecurityPermission( SecurityAction.LinkDemand, UnmanagedCode = true )]
        internal Win32FileHandle()
            : base( true )
        {
        }

        /// <summary>
        /// Initializes a new instance of the Win32ApiFileHandle class, specifying whether the handle is to be reliably released.
        /// </summary>
        public Win32FileHandle( IntPtr preExistingHandle, bool ownsHandle )
            : base( ownsHandle )
        {
            base.SetHandle( preExistingHandle );
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        protected override bool ReleaseHandle()
        {
            if ( !( IsInvalid || IsClosed ) )
            {
                return Win32SafeNativeMethods.FindClose( this );
            }
            return ( IsInvalid || IsClosed );
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Win32ApiFileHandle class specifying whether to perform a normal dispose operation. 
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( !( IsInvalid || IsClosed ) )
            {
                Win32SafeNativeMethods.FindClose( this );
            }
            base.Dispose( disposing );
        }
    }
}
