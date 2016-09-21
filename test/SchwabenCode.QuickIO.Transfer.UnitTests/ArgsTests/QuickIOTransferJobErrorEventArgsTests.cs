using System;
using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobErrorEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            Exception e = new Exception("Test message");

            var args = new QuickIOTransferJobErrorEventArgs(testJob, e);
            args.Job.Should().Be(testJob);
            args.Exception.Should().Be(e);
        }
    }
}