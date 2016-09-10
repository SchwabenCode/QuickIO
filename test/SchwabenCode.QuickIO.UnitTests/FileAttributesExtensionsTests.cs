using System.IO;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class FileAttributesExtensionsTests
    {

        [Fact]
        public void AddFileAttrribute()
        {
            FileAttributes attr = FileAttributes.Archive;

            FileAttributes result = attr.Add(FileAttributes.System);

            result.Contains(FileAttributes.Archive).Should().Be(true);
            result.Contains(FileAttributes.System).Should().Be(true);
        }

        [Fact]
        public void ContainsFileAttrribute()
        {
            FileAttributes attr = FileAttributes.Archive | FileAttributes.System | FileAttributes.ReadOnly;

            attr.Contains(FileAttributes.ReadOnly).Should().BeTrue();
            attr.Contains(FileAttributes.Directory).Should().BeFalse();
        }

        [Fact]
        public void RemoveFileAttribute()
        {
            FileAttributes attr = FileAttributes.Archive | FileAttributes.System;

            FileAttributes result = attr.Remove(FileAttributes.Archive);

            result.Contains(FileAttributes.Archive).Should().Be(false);
            result.Contains(FileAttributes.System).Should().Be(true);
        }

        [Fact]
        public void ContainsFileAttribute()
        {
            FileAttributes attr = FileAttributes.Archive;

            attr.Contains(FileAttributes.Archive).Should().Be(true);
            attr.Contains(FileAttributes.System).Should().Be(false);
        }
    }
}
