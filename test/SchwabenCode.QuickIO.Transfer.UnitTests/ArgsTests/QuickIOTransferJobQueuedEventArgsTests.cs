using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobQueuedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testSource = @"C:\testSource";
            string testTarget = @"C:\testTarget";

            var args = new QuickIOTransferJobQueuedEventArgs(testJob, testSource, testTarget);
            args.Job.Should().Be(testJob);
            args.SourcePath.Should().Be(testSource);
            args.TargetPath.Should().Be(testTarget);
            args.AddedToQueue.Should().NotBe(default(DateTime));
        }
    }
}