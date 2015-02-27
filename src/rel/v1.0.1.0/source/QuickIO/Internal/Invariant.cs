// <copyright file="Invariant.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>02/24/2014</date>
// <summary>Invariant</summary>

using System;

namespace SchwabenCode.QuickIO.Internal
{
    /// <summary>
    /// Several check methods to verify method parameters
    /// </summary>
    internal static class Invariant
    {
        /// <summary>
        /// Returns the given name
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="item">Property Name</param>
        /// <returns>Property Name</returns>
        public static string GetName<T>( T item ) where T : class
        {
            return typeof( T ).GetProperties( )[ 0 ].Name;
        }

        /// <summary>
        /// Checks for null
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="item">Object to check</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="item"/> is null</exception>
        public static void NotNull<T>( T item ) where T : class
        {
            if ( item == null )
            {
                throw new ArgumentNullException( typeof( T ).GetProperties( )[ 0 ].Name );
            }
        }

        /// <summary>
        /// Checks if specified string element is null or emoty
        /// </summary>
        /// <param name="item">Element to check</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="item"/>is null or empty</exception>
        public static void NotEmpty( String item )
        {
            if ( String.IsNullOrEmpty( item ) )
            {
                throw new ArgumentNullException( typeof( String ).GetProperties( )[ 0 ].Name );
            }
        }

        /// <summary>
        /// <paramref name="count"/> has to be greater than <paramref name="min"/>
        /// </summary>
        /// <param name="count">Count to check</param>
        /// <param name="min">Reference value</param>
        public static void Greater( int count, int min )
        {
            if ( count < min )
            {
                throw new ArgumentOutOfRangeException( "count", "Value has to be greather than '" + min + "' but is '" + count + "'" );
            }
        }
    }
}
