using System;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOPathTests
    {
        [Fact]
        public void GetRandomFileName()
        {
            string test = QuickIOPath.GetRandomFileName();
            test.Should().NotBeNullOrEmpty();
            test.Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [InlineData( "folder1", "folder1" )]
        [InlineData( null, null )]
        [InlineData( "folder1 ", "folder1" )]
        [InlineData( "folder1\\", "folder1" )]
        [InlineData( "\\folder1\\", "folder1" )]
        [InlineData( " \\ folder1 \\ ", "folder1" )]
        public void Clean( string p1, string expected )
        {
            QuickIOPath.Clean( p1 ).Should().Be( expected );
        }

        [Theory]
        [InlineData( "folder1", "folder2", @"folder1\folder2" )]
        [InlineData( @"C:\folder1", "folder2", @"C:\folder1\folder2" )]
        [InlineData( @"\\server\share\folder1", "folder2", @"\\server\share\folder1\folder2" )]
        [InlineData( @"C:\temp", "test", @"C:\temp\test" )]
        public void Combine( string p1, string p2, string expected )
        {
            string result = QuickIOPath.Combine( p1, p2 );

            result.Should().Be( System.IO.Path.Combine( p1, p2 ) );
            result.Should().Be( expected );
        }


        [Fact]
        public void Combine_ArgumentNullException()
        {
            Action actionNullParameter = () => QuickIOPath.Combine( "", null );
            Action actionNoParameter = () => QuickIOPath.Combine();

            actionNullParameter.ShouldThrow<ArgumentNullException>();
            actionNoParameter.ShouldThrow<ArgumentNullException>();

        }

        [Theory]
        [InlineData( null, null )]
        [InlineData( "", "" )]
        [InlineData( @"dsadasdasdasdasd", "" )]
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
        [InlineData( "", null, true )]
        [InlineData( " ", null, true )]
        [InlineData( null, null, false )]
        [InlineData( @"C:\", null, false )]
        [InlineData( @" C:\ ", null, false )]
        [InlineData( @"\server", null, true )]
        [InlineData( @" \\server\share ", null, false )]

        [InlineData( @"C:\folder\text.txt", @"C:\folder", false )]
        [InlineData( @"folder\text.txt", "folder", true )]
        public void GetDirectoryName( string test, string expected, bool differsFromSystemIO )
        {
            string result = QuickIOPath.GetDirectoryName( test );
            result.Should().Be( expected );

            if( !differsFromSystemIO )
            {
                result.Should().Be( System.IO.Path.GetDirectoryName( test ), "Syste.IO differs" );
            }
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
            string[ ] pathList = new string[ ]
            {
               @"_TestFiles\TextFile.txt",
                @"C:\temp"
            };
            foreach( var entry in pathList )
            {
                QuickIOPath.GetFullPath( entry ).Should().Be( System.IO.Path.GetFullPath( entry ) );
            }
        }

        [Fact]
        public void GetFullPathUnc()
        {
            string path = @"\\?\UNC\Server\Share\File.txt";
            QuickIOPath.GetFullPath( path ).Should().Be( path );
        }

        [Theory]
        [InlineData( @"C:", false )]
        [InlineData( @"1:", false )]
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
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
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
        [InlineData( @"\\server\name", true )]
        [InlineData( @"\\server\name\", true )]
        [InlineData( @"\\server\name\folder", true )]
        public void IsShareRegular( string test, bool expected )
        {
            QuickIOPath.IsShareRegular( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( @"\\server\name", false )]
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
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
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
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
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
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
        [InlineData( null, false )]
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
        [InlineData( null, false )]
        [InlineData( "", false )]
        [InlineData( @"C:", false )]
        [InlineData( @"C:\", false )]
        [InlineData( @"C:\folder", false )]
        [InlineData( @"1:", false )]
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\server\share\folder", false )]
        [InlineData( @"\\?\UNC\server\share", false )]
        [InlineData( @"\\?\UNC\server\share\folder", false )]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\folder", false )]
        [InlineData( @"\\?\C:\", true )]
        [InlineData( @"\\?\c:\", true )]
        public void IsRootLocalUnc( string test, bool expected )
        {
            QuickIOPath.IsRootLocalUnc( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( null, false )]
        [InlineData( "", false )]
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"\\?\c:\", false )]
        [InlineData( @"\\?\C:\sadasd", false )]
        [InlineData( @"\\?\c:\sadasd", false )]
        [InlineData( @"\\server\share\folder", false )]
        [InlineData( @"\\server\share", true )]
        [InlineData( @"\\server\share\", true )]
        [InlineData( @"\\?\UNC\server\share", false )]
        public void IsRootShareRegular( string test, bool expected )
        {
            QuickIOPath.IsRootShareRegular( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( null, false )]
        [InlineData( "", false )]
        [InlineData( @"\\*\*", false )]
        [InlineData( @"\\?\UNC\*\*\", false )]
        [InlineData( @"\\?\C:", false )]
        [InlineData( @"\\?\C:\", false )]
        [InlineData( @"\\?\c:\", false )]
        [InlineData( @"\\?\C:\sadasd", false )]
        [InlineData( @"\\?\c:\sadasd", false )]
        [InlineData( @"\\server\share", false )]
        [InlineData( @"\\server\share\", false )]
        [InlineData( @"\\server\share\folder", false )]
        [InlineData( @"\\?\UNC\", false )]
        [InlineData( @"\\?\UNC\server\", false )]
        [InlineData( @"\\?\UNC\server\share", true )]
        [InlineData( @"\\?\UNC\server\share\", true )]
        [InlineData( @"\\?\UNC\server\share\folder", false )]
        [InlineData( @"\\?\UNC\server\share\folder\", false )]
        public void IsRootShareUnc( string test, bool expected )
        {
            QuickIOPath.IsRootShareUnc( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( " ", false )]
        [InlineData( "     ", false )]
        [InlineData( ".", false )]
        [InlineData( "..", false )]
        [InlineData( "/", false )]
        [InlineData( "\\", false )]
        [InlineData( "<", false )]
        [InlineData( ">", false )]
        [InlineData( "*", false )]
        [InlineData( "?", false )]
        [InlineData( ":", false )]
        [InlineData( "\0", false )]
        [InlineData( ".point", false )]
        [InlineData( "point.", false )]
        [InlineData( " invalid", false )]
        [InlineData( "invalid ", false )]

        [InlineData( "_", true )]
        [InlineData( "♥", true )]
        [InlineData( "%", true )]
        [InlineData( "folder", true )]
        [InlineData( "folder.name", true )]
        [InlineData( "folder_name", true )]
        public void IsValidFolderName( string test, bool expected )
        {
            QuickIOPath.IsValidFolderName( test ).Should().Be( expected );
        }

        [Fact]
        public void IsValidFolderName()
        {
            QuickIOPath.IsValidFolderName( new string( 'a', QuickIOPath.MaxFolderNameLength + 1 ) ).Should().Be( false );
        }

        [Theory]
        [InlineData( '<', false )]
        [InlineData( '>', false )]
        [InlineData( ':', false )]
        [InlineData( '"', false )]
        [InlineData( '/', false )]
        [InlineData( '\\', false )]
        [InlineData( '|', false )]
        [InlineData( '?', false )]
        [InlineData( '*', false )]
        [InlineData( '\0', false )]
        [InlineData( '_', true )]
        [InlineData( '♥', true )]
        [InlineData( 'A', true )]
        [InlineData( '-', true )]
        [InlineData( 'c', true )]
        [InlineData( '3', true )]
        [InlineData( '.', true )]
        [InlineData( ' ', true )]
        public void IsValidFolderChar( char test, bool expected )
        {
            QuickIOPath.IsValidFolderChar( test ).Should().Be( expected );
        }


        [Theory]
        [InlineData( '_', false )]
        [InlineData( '1', false )]
        [InlineData( '%', false )]
        [InlineData( ' ', false )]
        [InlineData( '#', false )]
        [InlineData( '♥', false )]
        [InlineData( 'A', true )]
        [InlineData( 'R', true )]
        [InlineData( 'Z', true )]
        [InlineData( 'a', true )]
        [InlineData( 'r', true )]
        [InlineData( 'z', true )]
        public void IsValidDriveLetter( char test, bool expected )
        {
            QuickIOPath.IsValidDriveLetter( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( " ", false )]
        [InlineData( "@", false )]
        [InlineData( ", ", false )]
        [InlineData( " invalid", false )]
        [InlineData( "invalid ", false )]
        [InlineData( "valid", true )]
        [InlineData( "valid2", true )]
        public void IsValidServerName( string test, bool expected )
        {
            QuickIOPath.IsValidServerName( test ).Should().Be( expected );

        }

        [Theory]
        [InlineData( " ", false )]
        [InlineData( "@", false )]
        [InlineData( ", ", false )]
        [InlineData( "valid", true )]
        [InlineData( "valid2", true )]
        public void IsValidShareName( string test, bool expected )
        {
            QuickIOPath.IsValidShareName( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"\\serverName\shareName", "serverName", "shareName", true )]
        public void TryGetServerAndShareNameFromLocation( string test, string serverNameExpected, string shareNameExpected, bool parseResultExpected )
        {
            string serverName, shareName;

            QuickIOPath.TryParseShare( test, QuickIOPathType.Regular, out serverName, out shareName ).Should().Be( parseResultExpected );
            serverName.Should().Be( serverNameExpected );
            shareName.Should().Be( shareNameExpected );
        }

        [Theory]
        [InlineData( @"\\?\UNC\serverName\shareName\folder\file.txt", @"\\?\UNC\serverName\shareName", true )]
        [InlineData( @"\\serverName\shareName\folder\file.txt", null, false )]
        public void TryGetShareUncRootPath( string test, string rootExpected, bool parseResultExpected )
        {
            string root;

            QuickIOPath.TryGetShareUncRootPath( test, out root ).Should().Be( parseResultExpected );
            root.Should().Be( rootExpected );
        }


        [Theory]
        [InlineData( @"C:\test\path", @"C:\test\path" )]
        [InlineData( @"\\?\C:\test\path", @"C:\test\path" )]
        [InlineData( @"\\test\path", @"\\test\path" )]
        [InlineData( @"\\?\UNC\test\path", @"\\test\path" )]
        [InlineData( @"relative\path", @"relative\path" )]
        public void ToPathRegular( string test, string expected )
        {
            QuickIOPath.ToPathRegular( test ).Should().Be( expected );
        }

        [Theory]
        [InlineData( @"C:\test\path", @"\\?\C:\test\path" )]
        [InlineData( @"\\?\C:\test\path", @"\\?\C:\test\path" )]
        [InlineData( @"\\test\path", @"\\?\UNC\test\path" )]
        [InlineData( @"\\?\UNC\test\path", @"\\?\UNC\test\path" )]
        [InlineData( @"relative\path", @"relative\path" )]
        public void ToPathUnc( string test, string expected )
        {
            QuickIOPath.ToPathUnc( test ).Should().Be( expected );
        }
    }
}
