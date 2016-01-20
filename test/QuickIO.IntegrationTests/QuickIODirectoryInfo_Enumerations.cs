using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.IntegrationTests
{
    public class QuickIODirectoryInfo_Enumerations : IntegrationTestBase
    {
        [Theory]
        [InlineData( true, "_TestFolders/ExistingFolder", "*.txt", 1 )]
        //[InlineData( "_TestFolders/ExistingFolder", "*.txt", 1 )]
        //[InlineData( "_TestFolders/ExistingFolder", "*.TXT", 1 )]
        public void QuickIODirectoryInfo_EnumerateFilesCount( bool isRelative, string path, string pattern, int expected )
        {
            if( isRelative )
            {
                path = QuickIOPath.Combine( CurrentPath(), path );
            }

            QuickIODirectoryInfo directoryInfo = new QuickIODirectoryInfo( path );
            IEnumerable<QuickIOFileInfo> result = ( pattern == null ? directoryInfo.EnumerateFiles() : directoryInfo.EnumerateFiles( pattern ) );

            List<QuickIOFileInfo> list = result.ToList();
            list.Count.Should().Be( expected );
        }
    }
}
