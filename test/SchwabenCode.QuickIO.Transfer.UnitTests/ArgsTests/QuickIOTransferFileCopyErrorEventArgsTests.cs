using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferFileCopyErrorEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testSource = @"C:\testSource";
            string testTarget = @"C:\testTarget";
            Exception testException = new Exception("Test Message");

            var args = new QuickIOTransferFileCopyErrorEventArgs(testJob, testSource, testTarget, testException);
            args.Job.Should().Be(testJob);
            args.SourcePath.Should().Be(testSource);
            args.TargetPath.Should().Be(testTarget);
            args.Exception.Should().Be(testException);
        }
    }
}