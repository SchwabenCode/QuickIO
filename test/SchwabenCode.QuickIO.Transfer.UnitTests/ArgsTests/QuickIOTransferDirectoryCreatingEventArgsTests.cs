using FluentAssertions;
using SchwabenCode.QuickIO.Transfer.Events;
using Xunit;

namespace SchwabenCode.QuickIO.Transfer.UnitTests.ArgsTests
{
    public class QuickIOTransferDirectoryCreatingEventArgsTests
    {
        [Fact]
        public void CtorTests()
        {
            TestJob testJob = new TestJob();
            string testPath = @"C:\testpath";

            var args = new QuickIOTransferDirectoryCreatingEventArgs(testJob, testPath);
            args.Job.Should().Be(testJob);
            args.TargetPath.Should().Be(testPath);
        }
    }
}