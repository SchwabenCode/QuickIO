using System;

namespace SchwabenCode.QuickIO.Transfer.UnitTests
{
    public class TestJob : IQuickIOTransferJob
    {
        public IQuickIOTransferObserver Observer { get; }
        public int CurrentRetryCount { get; set; }
        public int PriorityLevel { get; set; }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}