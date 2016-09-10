using System.IO;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOFileSystemEntryTests
    {
        [Fact]
        public void QuickIOFileSystemEntryCtor()
        {
            QuickIOFileSystemEntry fse = new QuickIOFileSystemEntry(@"C:\temp\quickio",
                QuickIOFileSystemEntryType.Directory, FileAttributes.Directory | FileAttributes.Hidden, 1024);

            fse.Should().NotBe(null);

            fse.Path.Should().Be(@"C:\temp\quickio");
            fse.GetPathUnc().Should().Be(@"\\?\C:\temp\quickio");
            fse.GetPathRegular().Should().Be(@"C:\temp\quickio");

            fse.Type.Should().Be(QuickIOFileSystemEntryType.Directory);

            fse.Attributes.Contains(FileAttributes.Directory).Should().BeTrue();
            fse.Attributes.Contains(FileAttributes.Hidden).Should().BeTrue();
            fse.Attributes.Contains(FileAttributes.Encrypted).Should().BeFalse();

            fse.Bytes.Should().Be(1024);
        }
    }
}
