using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIODirectoryInfoTests
    {
        [Theory]
        [InlineData(@"C:\some_folder", @"C:\")]
        public void ParentFullName(string test, string expected)
        {
            new QuickIODirectoryInfo(test).Parent.Should().Be(expected);
        }
    }
}
