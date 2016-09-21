using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCreationStartedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testTarget = @"C:\testTarget";
            long totalBytes = 123;
            DateTime dt = DateTime.Now;

            var args = new QuickIOTransferFileCreationStartedEventArgs(testJob, testTarget, totalBytes, dt);
            args.Job.Should().Be(testJob);
            args.TargetPath.Should().Be(testTarget);
            args.TotalBytes.Should().Be(totalBytes);
            args.TransferStarted.Should().Be(dt);
        }
    }
}