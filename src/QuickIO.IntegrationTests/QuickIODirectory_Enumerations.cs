using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.IntegrationTests
{
    public class QuickIODirectory_Enumerations
    {
        [Theory]
        [InlineData( "_TestFolders/ExistingFolderEmpty", 0 )]
        public void QuickIODirectory_EnumerateFilesCount( string test, string searchPattern, int expected )
        {
            QuickIODirectoryInfo directoryInfo = new QuickIODirectoryInfo( test );
            IEnumerable<QuickIOFileInfo> result
                = ( searchPattern == null ? directoryInfo.EnumerateFiles() : directoryInfo.EnumerateFiles( searchPattern ) );

            result.Count().Should().Be( expected );
        }
    }
}
