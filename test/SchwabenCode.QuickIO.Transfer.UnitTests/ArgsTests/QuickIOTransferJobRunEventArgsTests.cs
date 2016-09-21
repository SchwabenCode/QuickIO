using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobRunEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            DateTime testStarted = DateTime.Now;

            var args = new QuickIOTransferJobRunEventArgs(testJob, testStarted);
            args.Job.Should().Be(testJob);
            args.StartTime.Should().Be(testStarted);
        }
    }
}