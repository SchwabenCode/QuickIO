using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchwabenCode.QuickIO.UnitTests
{

    [TestClass()]
    public class QuickIOPath_Get
    {

        [TestMethod()]
        public void GetName()
        {
            Assert.AreEqual( "text.txt", QuickIOPath.GetName( @"folder\text.txt" ), @"folder\text.txt" );
            Assert.AreEqual( "text.txt", QuickIOPath.GetName( @"C:\folder\text.txt" ), @"C:\folder\text.txt" );
            Assert.AreEqual( "text.txt", QuickIOPath.GetName( @"text.txt" ), @"text.txt" );
            Assert.AreEqual( "", QuickIOPath.GetName( @"" ), @"" );
            Assert.AreEqual( "folder2", QuickIOPath.GetName( @"C:\folder\folder2\" ), @"C:\folder\folder2\" );
        }

        [TestMethod()]
        public void GetFullPath()
        {
            string path = @"_TestFiles\TextFile.txt";
            Assert.AreEqual( System.IO.Path.GetFullPath( path ), QuickIOPath.GetFullPath( path ) );
        }

        [TestMethod()]
        public void GetFullPathInfo()
        {
            string path = @"_TestFiles\TextFile.txt";
            Assert.AreEqual( System.IO.Path.GetFullPath( path ), QuickIOPath.GetFullPathInfo( path ).FullName );
        }
    }
}