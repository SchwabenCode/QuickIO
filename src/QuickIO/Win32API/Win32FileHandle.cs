using Microsoft.Win32.SafeHandles;

namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Represents a handle to a file or directory, used for operations such as file enumeration.
/// This class provides safe handling and releasing of Win32 file handles.
/// </summary>
internal sealed class Win32FileHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Win32FileHandle"/> class with an invalid handle.
    /// </summary>
    internal Win32FileHandle()
        : base(true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Win32FileHandle"/> class with a pre-existing handle.
    /// </summary>
    /// <param name="preExistingHandle">The pre-existing handle to be used.</param>
    /// <param name="ownsHandle">A value that indicates whether the handle should be owned and managed by this instance.</param>
    public Win32FileHandle(IntPtr preExistingHandle, bool ownsHandle)
        : base(ownsHandle)
    {
        base.SetHandle(preExistingHandle);
    }

    /// <summary>
    /// Releases the handle by calling the Win32 API to close the handle.
    /// </summary>
    /// <returns><c>true</c> if the handle was released successfully; otherwise, <c>false</c>.</returns>
    protected override bool ReleaseHandle()
    {
        if (!(IsInvalid || IsClosed))
        {
            return Win32SafeNativeMethods.FindClose(this);
        }
        return (IsInvalid || IsClosed);
    }

    /// <summary>
    /// Disposes of the handle and releases any resources held by this instance.
    /// </summary>
    /// <param name="disposing">A value that indicates whether to release both managed and unmanaged resources.</param>
    protected override void Dispose(bool disposing)
    {
        if (!(IsInvalid || IsClosed))
        {
            _ = Win32SafeNativeMethods.FindClose(this);
        }
        base.Dispose(disposing);
    }
}

