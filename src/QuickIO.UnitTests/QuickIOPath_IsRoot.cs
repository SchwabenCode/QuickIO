using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SchwabenCode.QuickIO.UnitTests
{

    [TestClass()]
    public class QuickIOPath_IsRoot
    {

        [Theory]
        [InlineData( TestHelpers.AlphabethUpperCase, true )]
        [InlineData( TestHelpers.AlphabethLowerCase, true )]
        public void IsRootLocalRegular_TrueTestsLoop( string test, bool expected )
        {
            // True
            foreach( var c in test )
            {
                QuickIOPath.IsRootLocalRegular( c + @":\" ).Should().Be( expected );
            }
        }
        [Theory]
        [InlineData( "", false )]
        [InlineData( @"   ", false )]
        [InlineData( @"2:\", false )]
        [InlineData( @"_:\", false )]
        [InlineData( @"\\server", false )]
        [InlineData( @"#:\", false )]
        [InlineData( @"C:\folder", false )]
        public void IsRootLocalRegular_FalseTests( string test, bool expected )
        {
            QuickIOPath.IsRootLocalRegular( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"C:", false )]
        [InlineData( @"C:\", false )]
        [InlineData( @"C:\folder", false )]
        [InlineData( @"1:", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\server\share\folder", false )]
        [InlineData( @"\\?\UNC\\server\share", false )]
        [InlineData( @"\\?\UNC\\server\share\folder", false )]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\folder", false )]
        [InlineData( @"\\?\C:\", true )]
        [InlineData( @"\\?\c:\", true )]
        public void IsRootLocalUnc( string test, bool expected )
        {
            QuickIOPath.IsRootLocalUnc( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"\\?\UNC\\server\share", false )]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"\\?\c:\", false )]
        [InlineData( @"\\?\C:\sadasd", false )]
        [InlineData( @"\\?\c:\sadasd", false )]
        [InlineData( @"\\server\share\folder", false )]
        [InlineData( @"\\server\share", true )]
        [InlineData( @"\\server\share\", true )]
        [InlineData()]
        [InlineData()]
        public void IsRootShareRegular( string test, bool expected )
        {
            QuickIOPath.IsRootShareRegular( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"\\?\c:\", false )]
        [InlineData( @"\\?\C:\sadasd", false )]
        [InlineData( @"\\?\c:\sadasd", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\server\share\folder", false )]
        [InlineData( @"\\?\UNC\\server\share", true )]
        [InlineData( @"\\?\UNC\\server\share\", true )]
        public void IsRootShareUnc( string test, bool expected )
        {
            QuickIOPath.IsRootShareUnc( test ).Should().Be( expected );
        }
    }
}