using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchwabenCode.QuickIO.IntegrationTests
{
    [TestClass]
    public class QuickIODirectory_Enumerations
    {
        [TestMethod()]
        public void QuickIODirectory_EnumerateFilesEmptyDirectory()
        {
            const string path = "TestContents/EmptyDirectory";

            QuickIODirectoryInfo directoryInfo = new QuickIODirectoryInfo( path );

            IEnumerable<QuickIOFileInfo> resultFilesNoExt = directoryInfo.EnumerateFiles();
            IEnumerable<QuickIOFileInfo> resultFilesExt = directoryInfo.EnumerateFiles( ".ext" );

            Assert.AreEqual( 0, resultFilesNoExt.Count(), "No extension result" );
            Assert.AreEqual( 0, resultFilesExt.Count(), "Extension result" );
        }
    }
}
