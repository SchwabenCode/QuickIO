using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCreationProgressEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testTarget = @"C:\testTarget";
            long totalBytes = 123;
            long transferedBytes = 999;
            DateTime dt = DateTime.Now;

            var args = new QuickIOTransferFileCreationProgressEventArgs(testJob, testTarget, totalBytes, transferedBytes, dt);
            args.Job.Should().Be(testJob);
            args.TargetPath.Should().Be(testTarget);
            args.TotalBytes.Should().Be(totalBytes);
            args.BytesTransfered.Should().Be(transferedBytes);
            args.ProgressTimestamp.Should().Be(dt);
        }
    }
}