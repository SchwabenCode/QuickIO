using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferWorkerWokeUpEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            int workerId = 7;

            var args = new QuickIOTransferWorkerWokeUpEventArgs(workerId);
            args.WorkerID.Should().Be(workerId);
        }
    }
}