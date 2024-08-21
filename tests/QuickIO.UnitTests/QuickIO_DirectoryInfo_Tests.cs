using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;


public class QuickIO_DirectoryInfo_Tests
{
    [Fact]
    public void QuickIODirectoryInfo_Explizit_Cast()
    {
        string tempDir = Guid.NewGuid( ).ToString( );
        _ = Directory.CreateDirectory(tempDir);

        DirectoryInfo di = new( tempDir );
        Assert.True(di.Exists);

        QuickIODirectoryInfo QuickIODirectoryInfo = ( QuickIODirectoryInfo ) di;
        Assert.NotNull(QuickIODirectoryInfo);
    }

    [Fact]
    public void QuickIOFileInfo_AsFileInfo_Test()
    {
        string tempDir = Guid.NewGuid( ).ToString( );
        _ = Directory.CreateDirectory(tempDir);

        DirectoryInfo di = new( tempDir );
        Assert.True(di.Exists);

        QuickIODirectoryInfo QuickIODirectoryInfo = ( QuickIODirectoryInfo ) di;
        Assert.NotNull(QuickIODirectoryInfo);

        DirectoryInfo di2 = QuickIODirectoryInfo.AsDirectoryInfo( );
        Assert.NotNull(di2);

        Assert.Equal(tempDir, di2.Name);
    }
}
