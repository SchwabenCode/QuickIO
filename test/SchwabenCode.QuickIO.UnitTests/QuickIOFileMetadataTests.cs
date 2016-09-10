using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOFileMetadataTests
    {
        [Fact]
        public void QuickIOFileMetadataInstance()
        {
            Win32FindDataTestValue data = new Win32FindDataTestValue();

            QuickIOFileMetadata instance = new QuickIOFileMetadata( @"C:\test.txt", data );
            instance.FullName.Should().Be( @"C:\test.txt" );
            instance.FullNameUnc.Should().Be( @"\\?\C:\test.txt" );
            instance.Name.Should().Be( @"test.txt" );

        }
    }
}
