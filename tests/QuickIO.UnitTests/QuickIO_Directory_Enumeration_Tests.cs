using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_Directory_Enumerations_Tests
{
    [Fact]
    public void Directory_EnumerateDirectoryPaths_Test()
    {
        string testFolder = Path.GetFullPath( "TestFiles/" );
        string testPath1 = Path.Combine( testFolder, "RandomTestFolder__Directory_ENUM_1_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath2 = Path.Combine( testFolder, "RandomTestFolder__Directory_ENUM_2_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );

        QuickIODirectory.Create(testPath1);
        QuickIODirectory.Create(testPath2);

        List<string> allDircs = QuickIODirectory.EnumerateDirectoryPaths( testFolder, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.Regular ).ToList( );

        Assert.True(allDircs.Count(x => x.Equals(testPath1)) == 1, "Directory not found.");
        Assert.True(allDircs.Count(x => x.Equals(testPath2)) == 1, "Directory not found.");

        QuickIODirectory.Delete(testPath1);
        QuickIODirectory.Delete(testPath2);
    }

    [Fact]
    public void Directory_EnumerateFilePaths_Test()
    {
        string testFolder = Path.GetFullPath( "TestFiles/" );
        string testPath1 = Path.Combine( testFolder, "RandomTestFolder__Directory_ENUM_1_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath2 = Path.Combine( testFolder, "RandomTestFolder__Directory_ENUM_2_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );

        QuickIOFile.Create(testPath1);
        QuickIOFile.Create(testPath2);

        List<string> allDircs = QuickIODirectory.EnumerateFilePaths( testFolder, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.Regular ).ToList( );

        Assert.True(allDircs.Count(x => x.Equals(testPath1)) == 1, "File1 not found.");
        Assert.True(allDircs.Count(x => x.Equals(testPath2)) == 1, "File2 not found.");

        QuickIOFile.Delete(testPath1);
        QuickIOFile.Delete(testPath2);
    }

    [Fact]
    public void Directory_EnumerateMetadata_Test()
    {
        string testFolder = Path.GetFullPath( "TestFiles" );

        QuickIODirectoryMetadata? metadata = QuickIODirectory.GetMetadata( testFolder );
        Assert.NotNull(metadata);

        foreach (QuickIOFileMetadata file in metadata.Files)
        {
            Debug.WriteLine("File: " + file.Name);
        }
        foreach (QuickIODirectoryMetadata dir in metadata.Directories)
        {
            Debug.WriteLine("Directory: " + dir.Name);
        }

        bool fileItem = metadata.Files.Any( x => x.Name == "Test.txt" );
        bool directoryItem = metadata.Directories.Any( x => x.Name == "DirTimeTest" );

        Assert.True(fileItem, "File not found.");
        Assert.True(directoryItem, "Directory not found.");
    }

    [Fact]
    public void Directory_Readonly_Test()
    {
        string testfile = Path.Combine( Path.GetFullPath( "TestFiles/" ), Path.GetRandomFileName( ) );

        QuickIODirectory.Create(testfile);
        QuickIODirectory.SetAttributes(testfile, FileAttributes.ReadOnly);

        Assert.True(QuickIODirectory.GetAttributes(testfile).HasFlag(FileAttributes.ReadOnly), "Hidden not set");
    }

    [Fact]
    public void Directory_HiddenDir_Test()
    {
        string testfile = Path.Combine( Path.GetFullPath( "TestFiles/" ), Path.GetRandomFileName( ) );

        QuickIODirectory.Create(testfile);
        QuickIODirectory.SetAttributes(testfile, FileAttributes.Hidden);


        Assert.True(QuickIODirectory.GetAttributes(testfile).HasFlag(FileAttributes.Hidden), "Hidden not set");
    }

    [Fact]
    public void Directory_AttrFail_Test()
    {
        string testfile = Path.Combine( Path.GetFullPath( "TestFiles/" ), "AttrFail_" + Path.GetRandomFileName( ) );

        Action act = () => QuickIODirectory.GetAttributes(testfile).HasFlag(FileAttributes.Hidden);
        act.Should().Throw<PathNotFoundException>();
    }
}
