using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobDequeuedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();

            var args = new QuickIOTransferJobDequeuedEventArgs(testJob);
            args.Job.Should().Be(testJob);
        }
    }
}