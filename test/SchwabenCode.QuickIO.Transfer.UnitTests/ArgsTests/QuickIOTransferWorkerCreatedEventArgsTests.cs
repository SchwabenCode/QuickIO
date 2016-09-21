using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferWorkerCreatedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            int workerId = 7;

            var args = new QuickIOTransferWorkerCreatedEventArgs(workerId);
            args.WorkerID.Should().Be(workerId);
        }
    }
}