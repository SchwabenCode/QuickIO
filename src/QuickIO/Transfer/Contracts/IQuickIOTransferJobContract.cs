using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Transfer.Contracts;

/// <summary>
/// Contract for <see cref="IQuickIOTransferJob"/>
/// </summary>  
[ContractClass(typeof(IQuickIOTransferJob))]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
internal abstract class IQuickIOTransferJobContract : IQuickIOTransferJob
{
    public CancellationToken Token { get; private set; }

    public IQuickIOTransferObserver? Observer { get; private set; }

    public int CurrentRetryCount { get; set; }
    public int PriorityLevel { get; set; }
    public void Run()
    {
        throw new NotImplementedException();
    }

    public Task RunAsync()
    {
        return Task.CompletedTask;
    }
}
