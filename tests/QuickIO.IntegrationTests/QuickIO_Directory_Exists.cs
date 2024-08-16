//using Xunit;

//namespace SchwabenCode.QuickIO.IntegrationTests;

//public class QuickIO_Directory_Exists
//{
//    [Fact]
//    public void Directory_Exists_LocalRoot_OK()
//    {
//        string drive = @"C:\";
//        QuickIOPathInfo qio = new( drive );
//        Assert.True(qio.Exists, "Main not found: " + drive);

//        Assert.True(QuickIODirectory.Exists(drive), drive + " not found.");
//    }


//    [Fact]
//    public void Directory_Ctor_Share()
//    {
//        string share = @"\\testnas\quickiodirectory";
//        _ = new QuickIODirectoryInfo(share);
//    }
//}
