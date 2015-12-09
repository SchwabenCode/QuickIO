using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchwabenCode.QuickIO.UnitTests
{

    [TestClass()]
    public class QuickIOPath_IsValid
    {
        [TestMethod()]
        public void IsValidFolderName()
        {
            Assert.IsFalse( QuickIOPath.IsValidFolderName( " " ), " " );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "     " ), "     " );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "." ), "." );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( ".." ), ".." );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "/" ), "/" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "\\" ), "\\" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "<" ), "<" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( ">" ), ">" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "*" ), "*" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "?" ), "?" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( ":" ), ":" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "\0" ), "\\0" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( ".point" ), ".point" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( "point." ), "point." );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( Environment.NewLine ), "Environment.NewLine" );
            Assert.IsFalse( QuickIOPath.IsValidFolderName( new string( 'A', QuickIOPath.MaxFolderNameLength + 1 ) ), "QuickIOPath.MaxFolderNameLength +1" );

            Assert.IsTrue( QuickIOPath.IsValidFolderName( new string( 'A', QuickIOPath.MaxFolderNameLength ) ), "QuickIOPath.MaxFolderNameLength " + ( new string( 'A', QuickIOPath.MaxFolderNameLength ).Length ) );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "_" ), "_" );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "♥" ), "♥" );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "%" ), "%" );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "folder" ), "folder" );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "folder name" ), "folder name" );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "folder.name" ), "folder.name" );
            Assert.IsTrue( QuickIOPath.IsValidFolderName( "folder_name" ), "folder_name" );
        }

        [TestMethod()]
        public void IsValidFolderChar()
        {
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '<' ), "<" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '>' ), ">" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( ':' ), ":" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '"' ), "\"" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '/' ), "/" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '\\' ), "\"" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '|' ), "|" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '?' ), "?" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '*' ), "*" );
            Assert.IsFalse( QuickIOPath.IsValidFolderChar( '\0' ), "\\0" );

            Assert.IsTrue( QuickIOPath.IsValidFolderChar( '_' ), "_" );
            Assert.IsTrue( QuickIOPath.IsValidFolderChar( '♥' ), "♥" );
            Assert.IsTrue( QuickIOPath.IsValidFolderChar( 'A' ), "A" );
            Assert.IsTrue( QuickIOPath.IsValidFolderChar( '-' ), "-" );
            Assert.IsTrue( QuickIOPath.IsValidFolderChar( 'c' ), "c" );
            Assert.IsTrue( QuickIOPath.IsValidFolderChar( '3' ), "3" );
            Assert.IsTrue( QuickIOPath.IsValidFolderChar( '.' ), "." );

        }


        [TestMethod()]
        public void IsValidDriveLetter()
        {
            Assert.IsFalse( QuickIOPath.IsValidDriveLetter( '_' ), "_" );
            Assert.IsFalse( QuickIOPath.IsValidDriveLetter( '1' ), "1" );
            Assert.IsFalse( QuickIOPath.IsValidDriveLetter( '%' ), "%" );
            Assert.IsFalse( QuickIOPath.IsValidDriveLetter( ' ' ), " " );
            Assert.IsFalse( QuickIOPath.IsValidDriveLetter( '#' ), "#" );
            Assert.IsFalse( QuickIOPath.IsValidDriveLetter( '♥' ), "♥" );

            Assert.IsTrue( QuickIOPath.IsValidDriveLetter( 'A' ), "A" );
            Assert.IsTrue( QuickIOPath.IsValidDriveLetter( 'R' ), "R" );
            Assert.IsTrue( QuickIOPath.IsValidDriveLetter( 'Z' ), "Z" );
            Assert.IsTrue( QuickIOPath.IsValidDriveLetter( 'a' ), "a" );
            Assert.IsTrue( QuickIOPath.IsValidDriveLetter( 'r' ), "r" );
            Assert.IsTrue( QuickIOPath.IsValidDriveLetter( 'z' ), "z" );
        }

        [TestMethod()]
        public void IsValidServerName()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsValidServerName( value ); };

            string[ ] falste = new[ ]{
                  " ",
                  "@",
                  ", "
                };


            foreach( var testCase in falste )
            {
                Assert.IsFalse( testMethod( testCase ), testCase );
            }



            // True
            string[ ] trueTests = new[ ]{
                  "valid",
                  "valid2",
                };


            foreach( var testCase in trueTests )
            {
                Assert.IsTrue( testMethod( testCase ), testCase );
            }
        }

        [TestMethod()]
        public void IsValidShareName()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsValidShareName( value ); };

            string[ ] falste = new[ ]{
                  " ",
                  "@",
                  ", "
                };


            foreach( var testCase in falste )
            {
                Assert.IsFalse( testMethod( testCase ), testCase );
            }



            // True
            string[ ] trueTests = new[ ]{
                      "valid",
                  "valid2",
                };


            foreach( var testCase in trueTests )
            {
                Assert.IsTrue( testMethod( testCase ), testCase );
            }
        }

        [TestMethod()]
        public void TryGetServerAndShareNameFromLocation()
        {
            string testCase = @"serverName\shareName";

            string serverName, shareName;
            if( !QuickIOPath.TryGetServerAndShareNameFromLocation( testCase, out serverName, out shareName ) )
            {
                Assert.Fail( "Failed test" );
            }
            else
            {
                Assert.AreEqual( "serverName", serverName, "serverName" );
                Assert.AreEqual( "shareName", shareName, "shareName" );
            }
        }
    }
}