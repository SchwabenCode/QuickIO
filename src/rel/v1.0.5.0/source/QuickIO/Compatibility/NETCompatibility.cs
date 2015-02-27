// <copyright file="NETCompatibility.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/24/2014</date>
// <summary>Extensions to provide several methods for all .NET Framework verions</summary>

using System;
using System.Collections.Generic;
#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif


namespace SchwabenCode.QuickIO.Compatibility
{
    /// <summary>
    /// Extensions to provide several methods for all .NET Framework verions
    /// </summary>
    internal static class NETCompatibility
    {
        /// <summary>
        /// Extensions for support LINQ in .NET 2.0
        /// </summary>
        public static class Collections
        {
            /// <summary>
            /// Plain Cast implementation of LINQ
            /// </summary>
            public static IEnumerable<TBase> Cast<TDerived, TBase>( IEnumerable<TDerived> source ) where TDerived : TBase
            {
                foreach ( var item in source )
                {
                    yield return item;
                }
            }

            /// <summary>
            /// Converts an array to an IEnumerable collection
            /// </summary>
            public static IEnumerable<T> AsEnumerable<T>( T[ ] source )
            {
                return new List<T>( source );
            }

            /// <summary>
            /// Converts an IList collection to an array
            /// </summary>
            public static T[ ] ToArray<T>( IList<T> source )
            {
                var targetArray = new T[ source.Count ];
                for ( var index = 0 ; index < source.Count ; index++ )
                {
                    targetArray[ index ] = source[ index ];
                }

                return targetArray;
            }

            /// <summary>
            /// Converts an IEnumerable collection to an array
            /// </summary>
            public static T[ ] ToArray<T>( IEnumerable<T> source )
            {
                return ToArray( new List<T>( source ) );
            }

        }

#if NET40_OR_GREATER
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
                return AsyncTaskFactory.StartNew( action );
            }
        }
#endif
    }
}
