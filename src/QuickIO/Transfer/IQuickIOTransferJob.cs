
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Transfer.Contracts;

namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Interface for transfer jobs
/// </summary>
[ContractClass(typeof(IQuickIOTransferJobContract))]
public interface IQuickIOTransferJob
{
    /// <summary>
    /// Cancellation Token
    /// </summary>
    CancellationToken Token { get; }

    /// <summary>
    /// Observer for Condition Monitoring
    /// </summary>
    IQuickIOTransferObserver? Observer { get; }

    /// <summary>
    /// Retry count before firing broken exception
    /// </summary>
    int CurrentRetryCount { get; set; }

    /// <summary>
    /// Prority level. Higher priority = higher value. 0 = default
    /// </summary>
    int PriorityLevel { get; set; }

    /// <summary>
    /// Run implementation
    /// </summary>
    void Run();

    /// <summary>
    /// Executes <see cref="Run"/> in Async context
    /// </summary>
    Task RunAsync();
}
