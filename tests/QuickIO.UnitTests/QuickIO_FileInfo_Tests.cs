using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_FileInfo_Tests
{
    [Fact]
    public void QuickIOFileInfo_Explizit_Cast()
    {
        string tempFile = Guid.NewGuid( ).ToString( );
        File.Create(tempFile);

        FileInfo fi = new( tempFile );
        Assert.True(fi.Exists);

        QuickIOFileInfo QuickIOFileInfo = ( QuickIOFileInfo ) fi;
        Assert.NotNull(QuickIOFileInfo);
    }

    [Fact]
    public void QuickIOFileInfo_AsFileInfo_Test()
    {
        string tempFile = Path.GetTempPath( ) + Guid.NewGuid( );
        File.Create(tempFile);

        FileInfo fi = new( tempFile );
        Assert.True(fi.Exists);

        QuickIOFileInfo QuickIOFileInfo = ( QuickIOFileInfo ) fi;
        Assert.NotNull(QuickIOFileInfo);

        FileInfo fi2 = QuickIOFileInfo.AsFileInfo( );
        Assert.NotNull(fi2);

        Assert.Equal(fi.FullName, fi2.FullName);
    }
}
