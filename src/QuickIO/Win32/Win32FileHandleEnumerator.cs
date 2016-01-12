using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.PInvoke;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Win32
{
    internal class Win32FileHandleEnumerator : IEnumerator<Win32FileSystemEntry>
    {
        public string DirectoryPath { get; private set; }

        private readonly Win32FileHandle _currentFileHandle;
        private Win32FindData _currentFindData;
        private int _currentErrorCode;
        /// <summary>
        /// Returns current element
        /// </summary>
        public Win32FileSystemEntry Current
        {
            get
            {
                Contract.Ensures( Contract.Result<Win32FileSystemEntry>() != null );
                return new Win32FileSystemEntry( _currentFileHandle, _currentFindData );
            }
        }

        /// <summary>
        /// Returns current element
        /// </summary>
        object IEnumerator.Current => this.Current;

        private Win32FileHandleEnumerator()
        {
            _currentFindData = new Win32FindData();
        }

        /// <summary>
        /// Creates an instance of <see cref = "Win32FileHandleEnumerator"/>
        /// </summary>
        /// <param name = "directoryPath">UNC Path to directory</param>
        internal Win32FileHandleEnumerator( string directoryPath ) : this()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( directoryPath ) );
            if( String.IsNullOrWhiteSpace( directoryPath ) )
            {
                throw new ArgumentNullException( nameof( directoryPath ) );
            }

            DirectoryPath = directoryPath;

            _currentFileHandle = Win32SafeNativeMethods.FindFirstFile( DirectoryPath, _currentFindData );
            _currentErrorCode = Marshal.GetLastWin32Error();
        }

        /// <summary>
        /// Moves to next element
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            // Take care of invalid handles
            if( _currentFileHandle.IsInvalid )
            {
                if( _currentErrorCode != Win32ErrorCodes.ERROR_NO_MORE_FILES )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( DirectoryPath, _currentErrorCode );
                }

                return false;
            }

            // filter system path "." and ".."
            Boolean entryFound;
            do
            {
                _currentFindData = new Win32FindData();
                entryFound = Win32SafeNativeMethods.FindNextFile( _currentFileHandle, _currentFindData );
                _currentErrorCode = Marshal.GetLastWin32Error();
            }
            // skip found element if system entry
            while( _currentFindData.cFileName == "" || _currentFindData.cFileName == "." || _currentFindData.cFileName == ".." );
            return entryFound;
        }

        /// <summary>
        /// You cannot reset this enumerator
        /// </summary>
        public void Reset()
        {
            throw new NotSupportedException();
        }

        #region Dispose

        private bool _disposed;
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if( !_disposed )
            {
                // dispose all
                if( disposing )
                {
                    _currentFileHandle.Dispose();
                }

                // done
                _disposed = true;
            }
        }

        ~Win32FileHandleEnumerator()
        {
            Dispose( false );
        }
    }
    #endregion Dispise
}