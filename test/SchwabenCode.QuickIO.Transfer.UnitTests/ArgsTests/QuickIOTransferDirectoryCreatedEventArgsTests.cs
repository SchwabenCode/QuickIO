using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferDirectoryCreatedEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testPath = @"C:\testpath";

            var args = new QuickIOTransferDirectoryCreatedEventArgs(testJob, testPath);
            args.Job.Should().Be(testJob);
            args.TargetPath.Should().Be(testPath);
        }
    }
}