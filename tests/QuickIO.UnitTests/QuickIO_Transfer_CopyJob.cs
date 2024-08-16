using SchwabenCode.QuickIO.Transfer;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_Transfer_CopyJob
{
    [Fact]
    public void TestCopyJob_1()
    {
        string testFile = Path.GetFullPath( @"TestFiles\Test.txt" );
        string target = @"D:\testfile.txt";

        QuickIOTransferFileCopyJob copyJob = new( testFile, target, 65535, overwrite: true );
        copyJob.Run();
    }
}
