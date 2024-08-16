using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_File_Copy_Tests
{
    [Fact]
    public void File_Copy_Test()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(File.Exists(file), "Created test file does not exists (SystemIO).");

        string newFileName = "COPY" + Path.GetFileName( file );
        QuickIOFile.CopyToDirectory(file, Path.GetDirectoryName(file)!, newFileName);

        Assert.True(File.Exists(Path.Combine(Path.GetDirectoryName(file)!, newFileName)), "File does not exist after delete.");
    }

    [Fact]
    public void File_Copy_Test_TargetNotExists()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );
        string targetFileName = Path.Combine( prov.GetTestFileDirectory( ), prov.GetRandomTestFileName(), "TestFileName" );

        QuickIOFile.Copy(file, targetFileName);
    }
}
