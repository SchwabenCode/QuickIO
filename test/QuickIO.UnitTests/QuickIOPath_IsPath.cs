using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOPath_IsPath : UnitTestBase
    {
        [Theory]
        [InlineData( @"C:", false )]
        [InlineData( @"1:", false )]
        [InlineData( @"\\server\name", false )]
        [InlineData( @"\\?\UNC\\server\name", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"C:\", true )]
        [InlineData( @"c:\", true )]
        [InlineData( @"C:\sadasd", true )]
        [InlineData( @"c:\sadasd", true )]
        public void IsLocalRegular( string test, bool expected )
        {
            QuickIOPath.IsLocalRegular( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( @"C:", false )]
        [InlineData( @"1:", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"C:\", false )]
        [InlineData( @"c:\", false )]
        [InlineData( @"C:\sadasd", false )]
        [InlineData( @"c:\sadasd", false )]
        [InlineData( @"\\", false )]
        [InlineData( @"\\server", false )]
        [InlineData( @"c:\sadasd", false )]
        [InlineData( @"\\server\", false )]
        [InlineData( @"\\?\UNC\server\name", false )]
        [InlineData( @"\\server\name", true )]
        [InlineData( @"\\server\name\", true )]
        [InlineData( @"\\server\name\folder", true )]
        public void IsShareRegular( string test, bool expected )
        {
            QuickIOPath.IsShareRegular( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( @"\\server\name", false )]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"\\?\c:\", false )]
        [InlineData( @"\\?\C:\sadasd", false )]
        [InlineData( @"\\?\c:\sadasd", false )]
        [InlineData( @"\\?\UNC\", false )]
        [InlineData( @"\\?\UNC\server", false )]
        [InlineData( @"\\?\UNC\server\", false )]
        [InlineData( @"\\?\UNC\server\share", true )]
        [InlineData( @"\\?\UNC\server\share\", true )]
        public void IsShareUnc( string test, bool expected )
        {
            QuickIOPath.IsShareUnc( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"", false )]
        [InlineData( @"\\server\", false )]
        [InlineData( @"C", false )]
        [InlineData( @"C:\", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\?\C:\", true )]
        [InlineData( @"\\?\UNC\server\share", true )]
        [InlineData( @"\\?\UNC\server\share\", true )]
        public void IsUnc( string test, bool expected )
        {
            QuickIOPath.IsUnc( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"", false )]
        [InlineData( @"\\server\", false )]
        [InlineData( @"C", false )]
        [InlineData( @"C:\", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\?\UNC\server\share", false )]
        [InlineData( @"\\?\UNC\server\share\", false )]
        [InlineData( @"\\?\C:\", true )]
        public void IsLocalUnc( string test, bool expected )
        {
            QuickIOPath.IsLocalUnc( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"C:\", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\?\UNC\server\share", false )]
        [InlineData( @"\\?\UNC\server\share\", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"folder\file.txt", true )]
        [InlineData( @"\\server\", true )]
        public void IsRelative( string test, bool expected )
        {
            QuickIOPath.IsRelative( test ).Should().Be( expected, because: test );
        }
    }
}
