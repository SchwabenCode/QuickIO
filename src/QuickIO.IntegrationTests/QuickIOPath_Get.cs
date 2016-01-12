using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.IntegrationTests
{

    public class QuickIOPath_Get
    {
        [Fact]
        public void GetFullPathInfo()
        {
            string path = @"_TestFiles\ExistingTestFile.txt";
            QuickIOPath.GetFullPathInfo( path ).FullName.Should().Be( System.IO.Path.GetFullPath( path ) );
        }
    }
}