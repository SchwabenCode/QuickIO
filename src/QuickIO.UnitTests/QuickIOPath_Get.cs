using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{

    public class QuickIOPath_Get
    {
        [Theory]
        [InlineData( @"folder\text.txt", "text.txt" )]
        [InlineData( @"C:\folder\text.txt", "text.txt" )]
        [InlineData( @"text.txt", "text.txt" )]
        [InlineData( @"", "" )]
        [InlineData( @"C:\folder\folder2\", "folder2" )]
        public void GetName( string test, string expected )
        {
            QuickIOPath.GetName( test ).Should().Be( expected );
        }

        [Fact]
        public void GetFullPath()
        {
            string path = @"_TestFiles\TextFile.txt";
            QuickIOPath.GetFullPath( path ).Should().Be( System.IO.Path.GetFullPath( path ) );
        }

        //    [Theory]
        //    [InlineData( @"jhdsajdv\ ", "jhdsajdv" )]
        //    public void InternalTrimTrailingSeparator( string test, string expected )
        //    {
        //        QuickIOPath.InternalTrimTrailingSeparator( test ).Should().Be( expected );
        //    }
    }
}