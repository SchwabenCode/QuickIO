using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferJobEnqueuedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();

            var args = new QuickIOTransferJobEnqueuedEventArgs(testJob);
            args.Job.Should().Be(testJob);
        }
    }
}