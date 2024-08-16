//using FluentAssertions;
//using Moq;
//using SchwabenCode.QuickIO;
//using SchwabenCode.QuickIO.Transfer;
//using Xunit;

//namespace SchwabenCode.QuickIOTests.UnitTests;
// TODO
//public class TransferCopyJob_Tests
//{
//    [Fact]
//    public void Test_Ctor1()
//    {
//        Mock<IQuickIOTransferObserver> observerMock = new( );

//        string targetFile = @"C:\temp\qio_target\file.txt";

//        IQuickIOTransferObserver observer = observerMock.Object;
//        QuickIOTransferFileCopyJob job = new( observer, @"C:\temp\qio_source\file.txt",
//            targetFile, 1024, false, true, 0 );

//        try
//        {
//            job.Run();
//        }
//        catch (FileAlreadyExistsException)
//        {
//            QuickIOFile.Delete(targetFile);
//        }

//        job.Run();
//    }

//    [Fact]
//    public void Test_QuickIOCanceledException()
//    {
//        Mock<IQuickIOTransferObserver> observerMock = new( );

//        CancellationTokenSource source = new( );

//        IQuickIOTransferObserver observer = observerMock.Object;
//        QuickIOTransferFileCopyJob job = new( observer, @"C:\temp\qio_source\file.txt",
//            @"C:\temp\qio_target\file.txt", 1024, false, true, 0, source.Token );

//        source.Cancel();

//        Action act = () => job.Run();
//        act.Should().Throw<OperationCanceledException>();
//    }

//    [Fact]
//    public void Test_Ctor2()
//    {
//        _ = new QuickIOTransferFileCopyJob(@"C:\temp\qio_source\file.txt", @"C:\temp\qio_target", 1024, false, true, 0);
//    }
//}
