
using System.Diagnostics.Contracts;
using SchwabenCode.QuickIO.Transfer.Contracts;

namespace SchwabenCode.QuickIO.Transfer;

/// <summary>
/// Implements <see cref="IQuickIOTransferJob"/> with Overwrite option
/// </summary>
[ContractClass(typeof(IQuickIOTransferWriteJobContract))]
public interface IQuickIOTransferWriteJob : IQuickIOTransferJob
{
    /// <summary>
    /// Max Buffer Size for Transfer
    /// </summary>
    int MaxBufferSize { get; set; }

    /// <summary>
    /// True to check parent folder existance. False is much faster, but you have to be sure that the parent exists.
    /// </summary>
    bool ParentExistanceCheck { get; }

    /// <summary>
    /// true to overwrite existing element
    /// </summary>
    bool Overwrite { get; set; }
}
