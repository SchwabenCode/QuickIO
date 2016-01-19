using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOPath_ToPath : QuickIOTestBase
    {
        [Theory]
        [InlineData( @"C:\test\path", @"C:\test\path" )]
        [InlineData( @"\\?\C:\test\path", @"C:\test\path" )]
        [InlineData( @"\\test\path", @"\\test\path" )]
        [InlineData( @"\\?\UNC\test\path", @"\\test\path" )]
        public void ToPathRegular( string test, string expected )
        {
            QuickIOPath.ToPathRegular( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"C:\test\path", @"\\?\C:\test\path" )]
        [InlineData( @"\\?\C:\test\path", @"\\?\C:\test\path" )]
        [InlineData( @"\\test\path", @"\\?\UNC\test\path" )]
        [InlineData( @"\\?\UNC\test\path", @"\\?\UNC\test\path" )]
        public void ToPathUnc( string test, string expected )
        {
            QuickIOPath.ToPathUnc( test ).Should().Be( expected );
        }

    }
}
