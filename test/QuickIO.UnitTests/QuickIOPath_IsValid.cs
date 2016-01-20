using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOPath_IsValid: UnitTestBase
    {
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
        [InlineData( @"\\serverName\shareName", "serverName", "shareName" )]
        public void TryGetServerAndShareNameFromLocation( string test, string serverNameExpected, string shareNameExpected )
        {
            string serverName, shareName;

            QuickIOPath.TryGetServerAndShareNameFromLocation( test, QuickIOPathType.Regular, out serverName, out shareName ).Should().BeTrue();
            serverName.Should().Be( serverNameExpected );
            shareName.Should().Be( shareNameExpected );
        }
    }
}