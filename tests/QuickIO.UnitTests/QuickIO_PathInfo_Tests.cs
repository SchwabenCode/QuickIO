using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;


public class QuickIO_PathInfo_Tests
{
    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_LocalFile_Test()
    {
        QuickIOPathInfo pathInfo = new( @"C:\temp\file.txt" );

        pathInfo.FullName.Should().Be(@"C:\temp\file.txt");
        pathInfo.FullNameUnc.Should().Be(QuickIOPath.UncLocalPathPrefix + @"C:\temp\file.txt");
    }

    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_LocalFolder_Test()
    {
        QuickIOPathInfo pathInfo = new( @"C:\temp" );

        pathInfo.FullName.Should().Be(@"C:\temp");
        pathInfo.FullNameUnc.Should().Be(QuickIOPath.UncLocalPathPrefix + @"C:\temp");
    }

    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_ShareFile_Test()
    {
        QuickIOPathInfo pathInfo = new( @"\\server\share\file.txt" );

        pathInfo.FullName.Should().Be(@"\\server\share\file.txt");
        pathInfo.FullNameUnc.Should().Be(QuickIOPath.UncSharePathPrefix + @"server\share\file.txt");
    }

    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_ShareFolder_Test()
    {
        QuickIOPathInfo pathInfo = new( @"\\server\share" );

        pathInfo.FullName.Should().Be(@"\\server\share");
        pathInfo.FullNameUnc.Should().Be(QuickIOPath.UncSharePathPrefix + @"server\share");
    }
}
