using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCreationFinishedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testTarget = @"C:\testTarget";
            long testBytes = 123;
            DateTime testStarted = DateTime.Now;

            var args = new QuickIOTransferFileCreationFinishedEventArgs(testJob, testTarget, testBytes, testStarted);
            args.Job.Should().Be(testJob);
            args.TargetPath.Should().Be(testTarget);
            args.TotalBytes.Should().Be(testBytes);
            args.TransferStarted.Should().Be(testStarted);
        }
    }
}