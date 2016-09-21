using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferWorkerPickedJobEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            int workerId = 7;

            var args = new QuickIOTransferWorkerPickedJobEventArgs(workerId, testJob);
            args.Job.Should().Be(testJob);
            args.WorkerID.Should().Be(workerId);
        }
    }
}