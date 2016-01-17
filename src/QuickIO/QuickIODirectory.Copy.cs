// <copyright company="Benjamin Abt ( http://www.benjamin-abt.com - http://quickIO.NET )">
//      Copyright (c) 2016 Benjamin Abt Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading;
namespace SchwabenCode.QuickIO
{
    public static partial class QuickIODirectory
    {
        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <param name="cancellationToken">Cancallation Token</param>
        public static void Copy( String source, String target, bool overwrite = false, CancellationToken cancellationToken = default( CancellationToken ) )
        {
            Contract.Requires( !String.IsNullOrWhiteSpace( source ) );
            Contract.Requires( !String.IsNullOrWhiteSpace( target ) );

            Copy( new QuickIODirectoryInfo( source ), new QuickIOPathInfo( target ), overwrite, cancellationToken );
        }

        /// <summary>
        /// Copies a directory and all contents
        /// </summary>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        /// <param name="overwrite">true to overwrite existing files</param>
        /// <param name="cancellationToken">Cancallation Token</param>
        public static void Copy( QuickIODirectoryInfo source, QuickIOPathInfo target, bool overwrite = false, CancellationToken cancellationToken = default( CancellationToken ) )
        {
            Contract.Requires( source != null );
            Contract.Requires( target != null );

            throw new NotImplementedException();
        }
    }
}
