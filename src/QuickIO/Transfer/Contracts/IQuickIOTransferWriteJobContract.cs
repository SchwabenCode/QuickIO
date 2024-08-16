using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace SchwabenCode.QuickIO.Transfer.Contracts;

/// <summary>
/// Contract implementation
/// </summary>
[ContractClass(typeof(IQuickIOTransferObserver))]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class IQuickIOTransferWriteJobContract : IQuickIOTransferWriteJob
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

    public int MaxBufferSize { get; set; }
    public bool ParentExistanceCheck { get; private set; }
    public bool Overwrite { get; set; }
}
