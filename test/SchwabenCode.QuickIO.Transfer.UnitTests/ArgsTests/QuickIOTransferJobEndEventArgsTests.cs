using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobEndEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            var args = new QuickIOTransferJobEndEventArgs(testJob, start, end);
            args.Job.Should().Be(testJob);
            args.StartTime.Should().Be(start);
            args.EndTime.Should().Be(end);
        }
    }
}