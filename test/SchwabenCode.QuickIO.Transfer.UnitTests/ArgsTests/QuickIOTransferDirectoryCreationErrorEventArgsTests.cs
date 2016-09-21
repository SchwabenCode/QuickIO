using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferDirectoryCreationErrorEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testPath = @"C:\testpath";
            Exception testException = new Exception("Test Message");

            var args = new QuickIOTransferDirectoryCreationErrorEventArgs(testJob, testPath, testException);
            args.Job.Should().Be(testJob);
            args.TargetPath.Should().Be(testPath);
            args.Exception.Should().Be(testException);
        }
    }
}