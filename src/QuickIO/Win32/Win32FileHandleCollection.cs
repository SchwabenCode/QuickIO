// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Collections;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Win32
{
    internal class Win32FileHandleCollection : IEnumerable
    {
        public string DirectoryPath { get; private set; }

        /// <summary>
        /// Creates an instance of with given directory path
        /// </summary>
        /// <param name="path">Directory</param>
        public Win32FileHandleCollection( string path )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( path ) );
            if( String.IsNullOrWhiteSpace( path ) )
            {
                throw new ArgumentNullException( nameof( path ) );
            }


            DirectoryPath = path;
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Win32FileHandleEnumerator GetEnumerator()
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( DirectoryPath ) );
            Contract.Ensures( Contract.Result<Win32FileHandleEnumerator>() != null );

            return new Win32FileHandleEnumerator( DirectoryPath );
        }
    }
}