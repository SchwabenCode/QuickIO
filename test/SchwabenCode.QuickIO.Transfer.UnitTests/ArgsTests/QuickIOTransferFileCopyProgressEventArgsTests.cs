using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCopyProgressEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testSource = @"C:\testSource";
            string testTarget = @"C:\testTarget";
            long totalBytes = 123;
            long transferedBytes = 999;
            DateTime testStarted = DateTime.Now;

            var args = new QuickIOTransferFileCopyProgressEventArgs(testJob, testSource, testTarget, totalBytes, transferedBytes, testStarted);
            args.Job.Should().Be(testJob);
            args.SourcePath.Should().Be(testSource);
            args.TargetPath.Should().Be(testTarget);
            args.TotalBytes.Should().Be(totalBytes);
            args.BytesTransfered.Should().Be(transferedBytes);
            args.ProgressTimestamp.Should().Be(testStarted);
        }
    }
}