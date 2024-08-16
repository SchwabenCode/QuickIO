using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;


public class QuickIO_File_Tests
{
    [Fact]
    public void File_AppendAllText_Test()
    {
        string test = "Test text";

        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        QuickIOFile.WriteAllText(file, test);
        Assert.Equal(test, QuickIOFile.ReadAllText(file));

        // Append
        string appended = " Ben";
        QuickIOFile.AppendAllText(file, appended);
        Assert.Equal(test + appended, QuickIOFile.ReadAllText(file));
    }


    [Fact]
    public void File_AppendAllLines_Test()
    {
        string[] test = ["Line0", "Line1", "Line2"];

        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        QuickIOFile.WriteAllLines(file, test);
        List<string> result = QuickIOFile.ReadAllLines( file ).ToList( );
        Assert.Equal(test[0], result[0]);
        Assert.Equal(test[1], result[1]);

        // Append
        QuickIOFile.AppendAllLines(file, new List<string>() { test[2] });
        Assert.Equal(test[0], result[0]);
        Assert.Equal(test[1], result[1]);
        Assert.Equal(test[2], result[2]);
    }

    [Fact]
    public void File_Create_With_Path_Test()
    {
        string testPath = Path.GetFullPath( Path.GetRandomFileName( ) );
        QuickIOFile.Create(testPath);

        Assert.True(File.Exists(testPath));
    }

    [Fact]
    public void File_Delete_Test()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(File.Exists(file), "Created test file does not exists (SystemIO).");


        QuickIOFile.Delete(file);

        Assert.False(File.Exists(file), "File still exists after delete.");
    }
    [Fact]
    public void File_Readonly_Delete_Test()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(File.Exists(file), "Created test file does not exists (SystemIO).");

        File.SetAttributes(file, FileAttributes.ReadOnly);

        FileAttributes attributes = File.GetAttributes( file );
        Assert.True(attributes.HasFlag(FileAttributes.ReadOnly));

        QuickIOFile.Delete(file);

        Assert.False(File.Exists(file), "File still exists after delete.");
    }


    [Fact]
    public void File_Exists_Test()
    {
        string testPathMissing = Path.GetFullPath( Path.GetRandomFileName( ) );
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(File.Exists(file), "1 Created test file does not exists (SystemIO).");
        Assert.True(QuickIOFile.Exists(file), "2 Created test file does not exists (QuickIO).");

        Assert.False(File.Exists(testPathMissing), "3 Created test file exists (SystemIO).");
        Assert.False(QuickIOFile.Exists(testPathMissing), "4 Created test file exists (QuickIO).");
    }

    [Fact]
    public void File_MoveTest_SimplePaths()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        string targetFile = Path.Combine( Path.GetDirectoryName( file )!, "MOVED_" + Path.GetFileName( file ) );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        QuickIOFile.Move(file, targetFile);
        List<string> allFiles = QuickIODirectory.EnumerateFilePaths( Path.GetDirectoryName( file )!, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly ).ToList( );

        Assert.True(allFiles.All(x => !x.Equals(file, StringComparison.InvariantCultureIgnoreCase)), "Created test file still exists.");
        Assert.False(allFiles.Any(x => x.Equals(file, StringComparison.InvariantCultureIgnoreCase)), "Created test file not moved.");

    }

    [Fact]
    public void File_MoveTest_PathInfo()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );
        QuickIOFileInfo info = new( file );

        Assert.True(QuickIOFile.Exists(info), "Created test file does not exists.");

        QuickIOFile.Move(info.PathInfo, info.PathInfo.Parent!);
    }


    [Fact]
    public void File_OpenTest_Read()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        using FileStream fileStream = QuickIOFile.Open(file, FileMode.Open, FileAccess.Read);
        Assert.True(fileStream.CanRead);
        Assert.False(fileStream.CanWrite);
    }

    [Fact]
    public void File_OpenTest_Write()
    {
        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        using FileStream fileStream = QuickIOFile.Open(file, FileMode.Open, FileAccess.ReadWrite);
        Assert.True(fileStream.CanRead);
        Assert.True(fileStream.CanWrite);
    }

    [Fact]
    public void File_Write_And_Read_AllBytesTest()
    {
        byte[] test = [64, 72];

        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        QuickIOFile.WriteAllBytes(file, test);

        List<byte> result = QuickIOFile.ReadAllBytes( file ).ToList( );

        Assert.Equal(test[0], result[0]);
        Assert.Equal(test[1], result[1]);
    }

    [Fact]
    public void File_Write_And_Read_AllLinesTest()
    {
        string[] test = ["Zeile0", "Zeile1"];

        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        QuickIOFile.WriteAllLines(file, test);

        List<string> result = QuickIOFile.ReadAllLines( file ).ToList( );

        Assert.Equal(test[0], result[0]);
        Assert.Equal(test[1], result[1]);
    }


    [Fact]
    public void File_Write_and_Read_AllTextTest()
    {
        string test = "Test text";

        using RandomTestFileProvider prov = new();
        string file = prov.CreateRandomTestFile( );

        Assert.True(QuickIOFile.Exists(file), "Created test file does not exists.");

        QuickIOFile.WriteAllText(file, test);

        string result = QuickIOFile.ReadAllText( file );

        Assert.Equal(test, result);
    }
}
