using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferWorkerIsSleepingEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            int workerId = 7;

            var args = new QuickIOTransferWorkerIsSleepingEventArgs(workerId);
            args.WorkerID.Should().Be(workerId);
        }
    }
}