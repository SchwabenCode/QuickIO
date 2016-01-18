using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{

    public class QuickIOPath_Get
    {

        [Theory]
        [InlineData( null, null )]
        [InlineData( "", "" )]
        [InlineData( @"folder\file", "" )]
        [InlineData( @"C:\", @"C:\" )]
        [InlineData( @"C:\folder", @"C:\" )]
        [InlineData( @"C:\file.txt", @"C:\" )]
        [InlineData( @"C:\folder\file.txt", @"C:\" )]
        [InlineData( @"\\server\share", @"\\server\share" )]
        [InlineData( @"\\server\share\", @"\\server\share" )]
        [InlineData( @"\\server\share\folder", @"\\server\share" )]
        [InlineData( @"\\server\share\file.txt", @"\\server\share" )]
        [InlineData( @"\\server\share\folder\file.txt", @"\\server\share" )]
        [InlineData( @"\\?\C:\", @"\\?\C:\" )]
        [InlineData( @"\\?\C:\folder", @"\\?\C:\" )]
        [InlineData( @"\\?\C:\file.txt", @"\\?\C:\" )]
        [InlineData( @"\\?\C:\folder\file.txt", @"\\?\C:\" )]
        [InlineData( @"\\?\UNC\server\share", @"\\?\UNC\server\share" )]
        [InlineData( @"\\?\UNC\server\share\", @"\\?\UNC\server\share" )]
        [InlineData( @"\\?\UNC\server\share\folder", @"\\?\UNC\server\share" )]
        [InlineData( @"\\?\UNC\server\share\file.txt", @"\\?\UNC\server\share" )]
        [InlineData( @"\\?\UNC\server\share\folder\file.txt", @"\\?\UNC\server\share" )]
        public void GetPathRoot( string test, string expected )
        {
            QuickIOPath.GetPathRoot( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( @"C:\", null )]
        [InlineData( "\\server", null )]
        [InlineData( @"C:\folder\text.txt", @"C:\folder" )]
        public void GetParentPath( string test, string expected )
        {
            QuickIOPath.GetParentPath( test ).Should().Be( expected );
        }

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

        [Fact]
        public void GetFullPathUnc()
        {
            string path = @"\\?\UNC\Server\Share\File.txt";
            QuickIOPath.GetFullPath( path ).Should().Be( path );
        }

        //    [Theory]
        //    [InlineData( @"jhdsajdv\ ", "jhdsajdv" )]
        //    public void InternalTrimTrailingSeparator( string test, string expected )
        //    {
        //        QuickIOPath.InternalTrimTrailingSeparator( test ).Should().Be( expected );
        //    }
    }
}