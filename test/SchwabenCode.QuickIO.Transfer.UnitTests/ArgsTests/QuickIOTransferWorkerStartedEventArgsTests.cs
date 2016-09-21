using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferWorkerStartedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            int workerId = 7;

            var args = new QuickIOTransferWorkerStartedEventArgs(workerId);
            args.WorkerID.Should().Be(workerId);
        }
    }
}