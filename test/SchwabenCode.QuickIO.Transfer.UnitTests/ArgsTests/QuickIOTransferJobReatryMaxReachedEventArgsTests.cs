using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobReatryMaxReachedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            Exception testException = new Exception("Test Message");

            var args = new QuickIOTransferJobReatryMaxReachedEventArgs(testJob, testException);
            args.Job.Should().Be(testJob);
            args.LastException.Should().Be(testException);
        }
    }
}
