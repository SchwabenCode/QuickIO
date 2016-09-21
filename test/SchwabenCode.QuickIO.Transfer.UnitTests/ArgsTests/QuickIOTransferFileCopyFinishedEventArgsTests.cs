using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCopyFinishedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testPath = @"C:\testpath";
            long testBytes = 123;
            DateTime testStarted = DateTime.Now;

            var args = new QuickIOTransferFileCopyFinishedEventArgs(testJob, testPath, testPath, testBytes, testStarted);
            args.Job.Should().Be(testJob);
            args.SourcePath.Should().Be(testPath);
            args.TargetPath.Should().Be(testPath);
            args.TotalBytes.Should().Be(testBytes);
            args.TransferStarted.Should().Be(testStarted);
        }
    }
}