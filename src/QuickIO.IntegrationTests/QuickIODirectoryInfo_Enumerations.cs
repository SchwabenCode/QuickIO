using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.IntegrationTests
{
    public class QuickIODirectoryInfo_Enumerations
    {
        [Theory]
        [InlineData( "_TestFolders/ExistingFolder", null, 1 )]
        //[InlineData( "_TestFolders/ExistingFolder", "*.txt", 1 )]
        //[InlineData( "_TestFolders/ExistingFolder", "*.TXT", 1 )]
        public void QuickIODirectoryInfo_EnumerateFilesCount( string path, string pattern, int expected )
        {
            QuickIODirectoryInfo directoryInfo = new QuickIODirectoryInfo( path );
            IEnumerable<QuickIOFileInfo> result
                = ( pattern == null ? directoryInfo.EnumerateFiles() : directoryInfo.EnumerateFiles( pattern ) );

            result.Count().Should().Be( expected );
        }
    }
}
