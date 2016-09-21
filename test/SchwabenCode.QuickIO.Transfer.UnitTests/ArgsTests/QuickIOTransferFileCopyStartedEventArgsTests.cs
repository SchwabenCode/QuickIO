using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCopyStartedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testSource = @"C:\testSource";
            string testTarget = @"C:\testTarget";
            long testBytes = 123;
            DateTime testStarted = DateTime.Now;

            var args = new QuickIOTransferFileCopyStartedEventArgs(testJob, testSource, testTarget, testBytes, testStarted);
            args.Job.Should().Be(testJob);
            args.SourcePath.Should().Be(testSource);
            args.TargetPath.Should().Be(testTarget);
            args.TotalBytes.Should().Be(testBytes);
            args.TransferStarted.Should().Be(testStarted);
        }
    }
}