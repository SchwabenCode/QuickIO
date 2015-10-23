// <copyright file="NETCompatibility.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>Extensions to provide several methods for all .NET Framework verions</summary>

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;


namespace SchwabenCode.QuickIO.Compatibility
{
    public static class NETCompatibility
    {
        /// <summary>
        /// Several methods for async operations
        /// </summary>
        public static class AsyncExtensions
        {
            private static readonly TaskFactory AsyncTaskFactory = Task.Factory;

            /// <summary>
            /// Executes the action in a wrapped task to use async operation
            /// </summary>
            /// <typeparam name="T">Result Type</typeparam>
            /// <param name="action">Action to execute in wrapped task</param>
            /// <param name="resultValue">Returns this value if finished</param>
            /// <returns><see cref="Task"/></returns>
            public static Task ExecuteAsyncResult<T>( Action action, T resultValue )
            {
                Contract.Requires( action != null );

                Contract.Ensures( Contract.Result<Task>( ) != null );

                var tcs = new TaskCompletionSource<T>( );

                AsyncTaskFactory.StartNew( ( ) =>
                {
                    try
                    {
                        action( );
                        tcs.SetResult( resultValue );
                    }
                    catch ( Exception ex )
                    {
                        tcs.SetException( ex );
                    }
                } );

                return tcs.Task;
            }

            /// <summary>
            /// Executes the action in a wrapped task to use async operation and gets the result
            /// </summary>
            /// <typeparam name="T">Result Type</typeparam>
            /// <param name="action">Action to execute in wrapped task</param>
            /// <returns><see cref="Task"/> with result value</returns>
            public static Task<T> GetAsyncResult<T>( Func<T> action )
            {
                Contract.Requires( action != null );

                Contract.Ensures( Contract.Result<Task<T>>( ) != null );

                var tcs = new TaskCompletionSource<T>( );

                AsyncTaskFactory.StartNew( ( ) =>
                {
                    try
                    {
                        tcs.SetResult( action( ) );
                    }
                    catch ( Exception ex )
                    {
                        tcs.SetException( ex );
                    }
                } );

                return tcs.Task;
            }

            /// <summary>
            /// Executes the action in a wrapped task to use async operation
            /// </summary>
            /// <param name="action">Action to execute in wrapped task</param>
            /// <returns><see cref="Task"/></returns>
            public static Task ExecuteAsync( Action action )
            {
                Contract.Requires( action != null );

                Contract.Ensures( Contract.Result<Task>( ) != null );

                return AsyncTaskFactory.StartNew( action );
            }
        }
    }
}
