using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;


public class QuickIO_PathInfo_Tests
{
    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_LocalFile_Test()
    {
        QuickIOPathInfo pathInfo = new(@"C:\temp\file.txt");

        Assert.Equal(@"C:\temp\file.txt", pathInfo.FullName);
        Assert.Equal(QuickIOPath.UncLocalPathPrefix + @"C:\temp\file.txt", pathInfo.FullNameUnc);
    }

    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_LocalFolder_Test()
    {
        QuickIOPathInfo pathInfo = new(@"C:\temp");

        Assert.Equal(@"C:\temp", pathInfo.FullName);
        Assert.Equal(QuickIOPath.UncLocalPathPrefix + @"C:\temp", pathInfo.FullNameUnc);
    }

    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_ShareFile_Test()
    {
        QuickIOPathInfo pathInfo = new(@"\\server\share\file.txt");

        Assert.Equal(@"\\server\share\file.txt", pathInfo.FullName);
        Assert.Equal(QuickIOPath.UncSharePathPrefix + @"server\share\file.txt", pathInfo.FullNameUnc);
    }

    [Fact]
    public void QuickIOPathInfo_Create_Object_CTor_ShareFolder_Test()
    {
        QuickIOPathInfo pathInfo = new(@"\\server\share");

        Assert.Equal(@"\\server\share", pathInfo.FullName);
        Assert.Equal(QuickIOPath.UncSharePathPrefix + @"server\share", pathInfo.FullNameUnc);
    }
}
