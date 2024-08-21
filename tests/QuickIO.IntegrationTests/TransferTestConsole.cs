//using SchwabenCode.QuickIO.Transfer;

//namespace SchwabenCode.QuickIO.IntegrationTests;

//internal class TransferTestConsole
//{
//    private static void Main(string[] args)
//    {
//        const string sourceFile = @"C:\transfer_test\source\test.txt";
//        const string targetDirectory = @"C:\transfer_test\to";

//        IQuickIOTransferObserver observer = new QuickIOTransferObserver( );
//        QuickIOTransferFileCopyService service = new( observer, new QuickIOFileInfo( sourceFile ), targetDirectory, threadCount: 1, retryCount: 3, overwrite: true );

//        //  Progress information
//        observer.FileCopyStarted += OnFileCopyStarted;
//        observer.FileCopyProgress += OnFileProgressUpdate;
//        observer.FileCopyFinished += OnFileCopyFinished;

//        // Start progress
//        service.Start(); // Blocks thread until finished

//        Console.WriteLine("Finished");
//        _ = Console.ReadKey();
//    }

//    private static void OnFileCopyFinished(object sender, QuickIOTransferFileCopyFinishedEventArgs e)
//    {
//        Console.WriteLine("Finished: " + e.SourcePath + " - MB/s: " + (e.BytesPerSecond / 1024.0 / 1024.0).ToString("0.0"));
//    }

//    private static void OnFileCopyStarted(object sender, QuickIOTransferFileCopyStartedEventArgs e)
//    {
//        Console.WriteLine("Started: " + e.SourcePath + " to " + e.TargetPath + " (Bytes: " + e.TotalBytes + ")");
//    }

//    private static void OnFileProgressUpdate(object sender, QuickIOTransferFileCopyProgressEventArgs e)
//    {
//        Console.WriteLine("Progress: " + e.SourcePath + " - %: " + e.Percentage + " MB/s: " + (e.BytesPerSecond / 1024.0 / 1024.0).ToString("0.0"));
//    }
//}
