
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchwabenCode.QuickIO.UnitTests
{
    [TestClass]
    public class QuickIOPath_ToPath : QuickIOTestBase
    {
        [TestMethod]
        public void ToPathRegular()
        {
            Func<string, string> testMethod = delegate ( string value ) { return QuickIOPath.ToPathRegular( value ); };

            // Valid
            Assert.AreEqual( @"C:\test\path", testMethod( @"C:\test\path" ), @"C:\test\path" );
            Assert.AreEqual( @"C:\test\path", testMethod( @"\\?\C:\test\path" ), @"\\?C:\test\path" );
            Assert.AreEqual( @"\\test\path", testMethod( @"\\test\path" ), @"\\test\path" );
            Assert.AreEqual( @"\\test\path", testMethod( @"\\?\UNC\test\path" ), @"\\?\UNC\test\path" );
        }

        [TestMethod]
        public void ToPathUnc()
        {
            Func<string, string> testMethod = delegate ( string value ) { return QuickIOPath.ToPathUnc( value ); };

            // Valid
            Assert.AreEqual( @"\\?\C:\test\path", testMethod( @"C:\test\path" ), @"C:\test\path" );
            Assert.AreEqual( @"\\?\C:\test\path", testMethod( @"\\?\C:\test\path" ), @"\\?C:\test\path" );
            Assert.AreEqual( @"\\?\UNC\test\path", testMethod( @"\\test\path" ), @"\\test\path" );
            Assert.AreEqual( @"\\?\UNC\test\path", testMethod( @"\\?\UNC\test\path" ), @"\\?\UNC\test\path" );
        }

    }
}
