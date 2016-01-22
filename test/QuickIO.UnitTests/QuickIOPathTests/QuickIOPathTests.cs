using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests.QuickIOPathTests
{
    public class QuickIOPathTests
    {
        [Theory]
        [InlineData( "folder1", "folder2" )]
        [InlineData( @"C:\folder1", "folder2" )]
        [InlineData( @"\\server\share\folder1", "folder2" )]
        public void Combine( string p1, string p2 )
        {
            QuickIOPath.Combine( p1, p2 ).Should().Be( System.IO.Path.Combine( p1, p2 ) );
        }
    }
}
