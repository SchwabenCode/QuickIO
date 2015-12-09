using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchwabenCode.QuickIO.UnitTests
{

    [TestClass()]
    public class QuickIOPath_IsRoot
    {

        [TestMethod()]
        public void IsRootLocalRegular()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsRootLocalRegular( value ); };

            // True
            foreach( var c in TestHelpers.AlphabethUpperCase )
            {
                Assert.IsTrue( testMethod( c + @":\" ), c + @":\" );
            }
            foreach( var c in TestHelpers.AlphabethLowerCase )
            {
                Assert.IsTrue( testMethod( c + @":\" ), c + @":\" );
            }

            // False
            string[ ] falseTests = new
            [ ]{
                "",
                @"   ",
                 @"2:\",
                 @"_:\",
               @"\\server",
               @"#:\",
               @"C:\folder"
            };


            foreach( var expectedFalse in falseTests )
            {
                Assert.IsFalse( testMethod( expectedFalse ), expectedFalse );
            }
        }

        [TestMethod()]
        public void IsRootLocalUnc()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsRootLocalUnc( value ); };

            Assert.IsFalse( testMethod( @"C:" ), @"C:" );
            Assert.IsFalse( testMethod( @"C:\" ), @"C:\" );
            Assert.IsFalse( testMethod( @"C:\folder" ), @"C:\folder" );
            Assert.IsFalse( testMethod( @"1:" ), @"2:" );
            Assert.IsFalse( testMethod( @"\\server\share" ), @"\\server\share" );
            Assert.IsFalse( testMethod( @"\\server\share\" ), @"\\server\share\" );
            Assert.IsFalse( testMethod( @"\\server\share\folder" ), @"\\server\share\folder" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server\share" ), @"\\?\UNC\\server\share" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server\share\folder" ), @"\\?\UNC\\server\share\folder" );
            Assert.IsFalse( testMethod( @"\\?\C:" ), @"\\?\C:" );
            Assert.IsFalse( testMethod( @"\\?\C:\folder" ), @"\\?\C:\folder" );


            Assert.IsTrue( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
            Assert.IsTrue( testMethod( @"\\?\c:\" ), @"\\?\c:\" );
        }

        [TestMethod()]
        public void IsRootShareRegular()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsRootShareRegular( value ); };

            Assert.IsFalse( testMethod( @"\\?\UNC\\server\share" ), @"\\?\UNC\\server\share" );
            Assert.IsFalse( testMethod( @"\\?\C:" ), @"\\?\C:" );
            Assert.IsFalse( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
            Assert.IsFalse( testMethod( @"\\?\c:\" ), @"\\?\c:\" );
            Assert.IsFalse( testMethod( @"\\?\C:\sadasd" ), @"\\?\C:\sadasd" );
            Assert.IsFalse( testMethod( @"\\?\c:\sadasd" ), @"\\?\C:\sadasd" );
            Assert.IsFalse( testMethod( @"\\server\share\folder" ), @"\\server\share\folder" );

            Assert.IsTrue( testMethod( @"\\server\share" ), @"\\server\share" );
            Assert.IsTrue( testMethod( @"\\server\share\" ), @"\\server\share\" );
        }


        [TestMethod()]
        public void IsRootShareUnc()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsRootShareUnc( value ); };

            Assert.IsFalse( testMethod( @"\\?\C:" ), @"\\?\C:" );
            Assert.IsFalse( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
            Assert.IsFalse( testMethod( @"\\?\c:\" ), @"\\?\c:\" );
            Assert.IsFalse( testMethod( @"\\?\C:\sadasd" ), @"\\?\C:\sadasd" );
            Assert.IsFalse( testMethod( @"\\?\c:\sadasd" ), @"\\?\C:\sadasd" );
            Assert.IsFalse( testMethod( @"\\server\share" ), @"\\server\share" );
            Assert.IsFalse( testMethod( @"\\server\share\" ), @"\\server\share\" );
            Assert.IsFalse( testMethod( @"\\server\share\folder" ), @"\\server\share\folder" );

            Assert.IsFalse( testMethod( @"\\?\UNC\\server\share" ), @"\\?\UNC\\server\share" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server\share\" ), @"\\?\UNC\\server\share\" );
        }
    }
}