// <copyright file="InternalQuickIO.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 PathMatchAll Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/08/2014</date>
// <summary>Provides internal methods</summary>

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using SchwabenCode.QuickIO.Win32;
using SchwabenCode.QuickIO.PInvoke;

namespace SchwabenCode.QuickIO.Internal
{
    /// <summary>
    /// Provides internal methods. PathMatchAll IO operations are called from here.
    /// </summary>
    [FileIOPermission( SecurityAction.Demand, AllFiles = FileIOPermissionAccess.AllAccess, AllLocalFiles = FileIOPermissionAccess.AllAccess )]
    internal static partial class InternalQuickIO
    {

        /// <summary>
        /// Creates a new directory. If <paramref name="recursive"/> is false, the parent directory must exists.
        /// </summary>
        /// <param name="uncDirectoryPath">Directory path</param>
        /// <param name="recursive">If <paramref name="recursive"/> is false, the parent directory must exist.</param>
        /// <exception cref="PathAlreadyExistsException">The specified path already exists.</exception>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        public static void CreateDirectory( string uncDirectoryPath, bool recursive = false )
        {
            Contract.Requires( !String.IsNullOrEmpty( uncDirectoryPath ) );

            // cancel if path exists
            if( Exists( uncDirectoryPath ) )
            {
                return;
            }

            // cancel if requested path is root
            if( QuickIOPath.IsRoot( uncDirectoryPath ) )
            {
                throw new InvalidOperationException( "A root directory cannot be created." );
            }

            // create parent directory if accepted
            if( recursive )
            {
                string parent = QuickIOPath.GetParentPath( uncDirectoryPath );
                if( parent == null )
                {
                    throw new InvalidOperationException( "Parent directory does not exists and cannot be created." );
                }

                Stack<string> stack = new Stack<string>();
                stack.Push( parent );

                while( stack.Count > 0 )
                {
                    string currentDirectory = stack.Pop();

                    if( QuickIOPath.IsRoot( currentDirectory ) )
                    {
                        if( !QuickIOPath.Exists( currentDirectory ) )
                        {
                            throw new InvalidOperationException( "A root directory cannot be created." );
                        }
                    }
                    else
                    {
                        // no root path here
                        if( !Win32SafeNativeMethods.CreateDirectory( currentDirectory, IntPtr.Zero ) )
                        {
                            InternalQuickIOCommon.NativeExceptionMapping( currentDirectory, Marshal.GetLastWin32Error() );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the given directory. On request  all contents, too.
        /// </summary>
        /// <param name="uncDirectoryPath">Path of directory to delete</param>
        /// <param name="recursive">If <paramref name="recursive"/> is true then all subfolders are also deleted.</param>
        /// <exception cref="PathNotFoundException">This error is fired if the specified path or a part of them does not exist.</exception>
        /// <exception cref="DirectoryNotEmptyException">The directory is not empty.</exception>
        /// <remarks>Function loads every file and attribute. Alls read-only flags will be removed before removing.</remarks>
        public static void DeleteDirectory( string uncDirectoryPath, bool recursive = false )
        {
            Contract.Requires( !String.IsNullOrEmpty( uncDirectoryPath ) );

            // Contents
            if( recursive )
            {
                foreach( Win32FileSystemEntry systemEntry in new Win32FileHandleCollection( QuickIOPath.Combine( uncDirectoryPath, QuickIOPatterns.PathMatchAll ) ) )
                {
                    // Create hit for current search result
                    var resultPath = QuickIOPath.Combine( uncDirectoryPath, systemEntry.Name );
                    if( systemEntry.IsFile )
                    {
                        DeleteFile( resultPath );
                    }

                    else if(/*is directory here*/ recursive )
                    {
                        DeleteDirectory( resultPath, recursive );
                    }
                }
            }

            // Remove specified
            if( !Win32SafeNativeMethods.RemoveDirectory( uncDirectoryPath ) )
            {
                InternalQuickIOCommon.NativeExceptionMapping( uncDirectoryPath, Marshal.GetLastWin32Error() );
            }
        }
    }
}