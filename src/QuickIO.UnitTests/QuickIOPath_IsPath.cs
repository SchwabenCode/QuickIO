
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOPath_IsPath : QuickIOTestBase
    {
        [TestMethod()]
        public void IsLocalRegular()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsLocalRegular( value ); };

            Assert.IsFalse( testMethod( @"C:" ), @"C:" );
            Assert.IsFalse( testMethod( @"1:" ), @"2:" );
            Assert.IsFalse( testMethod( @"\\server\name" ), @"\\server\name" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server\name" ), @"\\?\UNC\\server\name" );
            Assert.IsFalse( testMethod( @"\\?\C:\" ), @"\\?\C:\" );


            Assert.IsTrue( testMethod( @"C:\" ), @"C:\" );
            Assert.IsTrue( testMethod( @"c:\" ), @"c:\" );
            Assert.IsTrue( testMethod( @"C:\sadasd" ), @"C:\sadasd" );
            Assert.IsTrue( testMethod( @"c:\sadasd" ), @"C:\sadasd" );
        }


        [TestMethod()]
        public void IsShareRegular()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsShareRegular( value ); };

            Assert.IsFalse( testMethod( @"C:" ), @"C:" );
            Assert.IsFalse( testMethod( @"1:" ), @"2:" );
            Assert.IsFalse( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
            Assert.IsFalse( testMethod( @"C:\" ), @"C:\" );
            Assert.IsFalse( testMethod( @"c:\" ), @"c:\" );
            Assert.IsFalse( testMethod( @"C:\sadasd" ), @"C:\sadasd" );
            Assert.IsFalse( testMethod( @"c:\sadasd" ), @"C:\sadasd" );


            Assert.IsFalse( testMethod( @"\\" ), @"\\" );
            Assert.IsFalse( testMethod( @"\\server" ), @"\\server" );
            Assert.IsFalse( testMethod( @"\\server\" ), @"\\server\" );

            Assert.IsFalse( testMethod( @"\\?\UNC\server\name" ), @"\\?\UNC\server\name" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server\name" ), @"\\?\UNC\\server\name" );

            // True
            Assert.IsTrue( testMethod( @"\\server\name" ), @"\\server\name" );
            Assert.IsTrue( testMethod( @"\\server\name\" ), @"\\server\name\" );
            Assert.IsTrue( testMethod( @"\\server\name\folder" ), @"\\server\name\folder" );
        }



        [TestMethod()]
        public void IsShareUnc()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsShareUnc( value ); };

            Assert.IsFalse( testMethod( @"\\server\name" ), @"\\server\name" );

            Assert.IsFalse( testMethod( @"\\?\C:" ), @"\\?\C:" );

            Assert.IsFalse( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
            Assert.IsFalse( testMethod( @"\\?\c:\" ), @"\\?\c:\" );
            Assert.IsFalse( testMethod( @"\\?\C:\sadasd" ), @"\\?\C:\sadasd" );
            Assert.IsFalse( testMethod( @"\\?\c:\sadasd" ), @"\\?\C:\sadasd" );

            Assert.IsFalse( testMethod( @"\\?\UNC\" ), @"\\?\UNC\" );
            Assert.IsFalse( testMethod( @"\\?\UNC\server" ), @"\\?\UNC\server" );
            Assert.IsFalse( testMethod( @"\\?\UNC\server\" ), @"\\?\UNC\server\" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server" ), @"\\?\UNC\\server" );
            Assert.IsFalse( testMethod( @"\\?\UNC\\server\" ), @"\\?\UNC\\server\" );

            Assert.IsTrue( testMethod( @"\\?\UNC\server\share" ), @"\\?\UNC\server\share" );
            Assert.IsTrue( testMethod( @"\\?\UNC\server\share\" ), @"\\?\UNC\server\share\" );
        }

        [TestMethod]
        public void IsUnc()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsUnc( value ); };

            // False check
            Assert.IsFalse( testMethod( @"" ) );
            Assert.IsFalse( testMethod( @"\\server\" ) );
            Assert.IsFalse( testMethod( @"C" ) );
            Assert.IsFalse( testMethod( @"C:\" ) );
            Assert.IsFalse( testMethod( @"\\server\share" ) );
            Assert.IsFalse( testMethod( @"\\server\share\" ) );

            // UNC Pathes
            Assert.IsTrue( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
            Assert.IsTrue( testMethod( @"\\?\UNC\server\share" ), @"\\?\UNC\server\share" );
            Assert.IsTrue( testMethod( @"\\?\UNC\server\share\" ), @"\\?\UNC\server\share\" );
        }

        [TestMethod]
        public void IsLocalUnc()
        {
            Func<string, bool> testMethod = delegate ( string value ) { return QuickIOPath.IsLocalUnc( value ); };

            // False check
            Assert.IsFalse( testMethod( @"" ), @"" );
            Assert.IsFalse( testMethod( @"\\server\" ), @"\\server\" );
            Assert.IsFalse( testMethod( @"C" ), @"C" );
            Assert.IsFalse( testMethod( @"C:\" ), @"C:\" );
            Assert.IsFalse( testMethod( @"\\server\share" ), @"\\server\share" );
            Assert.IsFalse( testMethod( @"\\server\share\" ), @"\\server\share\" );
            Assert.IsFalse( testMethod( @"\\?\UNC\server\share" ), @"\\?\UNC\server\share" );
            Assert.IsFalse( testMethod( @"\\?\UNC\server\share\" ), @"\\?\UNC\server\share\" );

            // True check
            Assert.IsTrue( testMethod( @"\\?\C:\" ), @"\\?\C:\" );
        }
    }
}
