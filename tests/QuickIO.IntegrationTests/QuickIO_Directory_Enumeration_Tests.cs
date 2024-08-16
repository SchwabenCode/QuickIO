//using Xunit;

//namespace SchwabenCode.QuickIO.UnitTests;

//public class QuickIO_Directory_Enumerations_Tests
//{
//    [Fact]
//    public void Directory_EnumerateFilePaths_Share_Test()
//    {
//        string path = @"\\testnas\quickiodirectory";

//        QuickIODirectoryInfo dirInfo = new( path );
//        List<string> allDircs1 = dirInfo.EnumerateFilePaths( QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly ).ToList( );
//        List<string> allDircs2 = QuickIODirectory.EnumerateFilePaths( path, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.Regular ).ToList( );

//        Assert.True(allDircs1.Count != 0);
//        Assert.True(allDircs2.Count != 0);
//    }
//}
