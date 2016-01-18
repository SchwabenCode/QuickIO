using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{

    public class UT_QuickIOPath
    {
        [Theory]
        [InlineData( @"C:\temp", "test", @"C:\temp\test" )]
        public void Combine( string root, string combine, string expected )
        {
            string result = QuickIOPath.Combine( root, combine );
            string ioResult = System.IO.Path.Combine( root, combine );
            result.Should().Be( ioResult, expected );
            result.Should().Be( expected , expected );
        }
    }
}