using System.IO;
using FluentAssertions;
using SchwabenCode.QuickIO.Core;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOFileSystemEntryTests
    {
        [Fact]
        public void QuickIOFileSystemEntryCtor()
        {
            QuickIOFileSystemEntry fse = new QuickIOFileSystemEntry( @"C:\temp\quickio",
                QuickIOFileSystemEntryType.Directory, FileAttributes.Directory | FileAttributes.Hidden, 1024 );

            fse.Should().NotBe( null );

            fse.Path.Should().Be( @"C:\temp\quickio" );
            fse.GetPathUnc().Should().Be( @"\\?\C:\temp\quickio" );
            fse.GetPathRegular().Should().Be( @"C:\temp\quickio" );

            fse.Type.Should().Be( QuickIOFileSystemEntryType.Directory );

            InternalHelpers.ContainsFileAttribute( fse.Attributes, FileAttributes.Directory ).Should().BeTrue();
            InternalHelpers.ContainsFileAttribute( fse.Attributes, FileAttributes.Hidden ).Should().BeTrue();
            InternalHelpers.ContainsFileAttribute( fse.Attributes, FileAttributes.Encrypted ).Should().BeFalse();

            fse.Bytes.Should().Be( 1024 );
        }
    }
}
