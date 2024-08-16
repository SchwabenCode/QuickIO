using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_Directory_Tests
{
    [Fact]
    public void Directory_Create_Test()
    {
        string testFolder = Path.GetFullPath( "TestFiles/" );
        string testPath = Path.Combine( testFolder, "RandomTestFolder_Directory_CREATE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );

        QuickIODirectory.Create(testPath);

        List<string> allDirs = QuickIODirectory.EnumerateDirectoryPaths( testFolder, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.Regular ).ToList( );
        Assert.True(allDirs.Count(x => x.Equals(testPath)) == 1, "Directory not created.");
    }


    [Fact]
    public void Directory_Delete_Test()
    {
        string testFolder = Path.GetFullPath( "TestFiles/" );
        string testPath = Path.Combine( testFolder, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );

        QuickIODirectory.Create(testPath);

        List<string> allDircs = QuickIODirectory.EnumerateDirectoryPaths( testFolder, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.Regular ).ToList( );
        Assert.True(allDircs.Count(x => x.Equals(testPath)) == 1, "Directory not created.");

        QuickIODirectory.Delete(testPath);


        allDircs = QuickIODirectory.EnumerateDirectoryPaths(testFolder, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.Regular).ToList();
        Assert.True(allDircs.Count(x => x.Equals(testPath, StringComparison.Ordinal)) == 0, "Directory not removed.");
    }

    [Fact]
    public void Directory_Delete_Tree_Test()
    {
        string testFolder = Path.GetFullPath( "TestFiles/DELETE/" );
        string testPath1 = Path.Combine( testFolder, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath2 = Path.Combine( testPath1, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath3 = Path.Combine( testPath2, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath4 = Path.Combine( testPath3, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath5 = Path.Combine( testPath4, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath6 = Path.Combine( testPath5, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );
        string testPath7 = Path.Combine( testPath6, "RandomTestFolder_Directory_DELETE_Test_" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) );

        QuickIODirectory.Create(testPath7, true);

        QuickIODirectory.Delete(testFolder, true);
    }


    [Fact]
    public void Directory_Exists_Test()
    {
        string currentDirc = Environment.CurrentDirectory;

        Assert.True(Directory.Exists(currentDirc), "Failed 1");
        Assert.True(QuickIODirectory.Exists(currentDirc), "Failed 2");

        Assert.False(Directory.Exists(currentDirc + "a"), "Failed 3");
        Assert.False(QuickIODirectory.Exists(Path.GetFullPath(currentDirc + "a")), "Failed 4");
    }

    [Fact]
    public void Directory_SetWriteTime_Test()
    {
        string currentDirc = Path.GetFullPath( "TestFiles/DirTimeTest" );
        QuickIODirectoryInfo dirInfo = new( currentDirc );

        DateTime newTime = DateTime.Now.AddDays( -1 );

        QuickIODirectory.SetAllFileTimesUtc(dirInfo, newTime, newTime, newTime);

        QuickIODirectory.GetLastWriteTime(dirInfo).Should().Be(newTime);
        QuickIODirectory.GetLastAccessTime(dirInfo).Should().Be(newTime);
        QuickIODirectory.GetCreationTime(dirInfo).Should().Be(newTime);
    }

    // TODO
    //[Fact]
    //public void Directory_Enumeration_NoAccess()
    //{
    //    Action act = () => QuickIODirectory.EnumerateDirectoryPaths(@"C:\temp\quickiotest");
    //    act.Should().Throw<UnauthorizedAccessException>();
    //}

    [Fact]
    public void Directory_Enumeration_NoAccessIgnored()
    {
        QuickIODirectory.EnumerateDirectoryPaths(@"C:\temp", enumerateOptions: QuickIOEnumerateOptions.SuppressAllExceptions);
    }
}
