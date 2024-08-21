using System.ComponentModel;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO.Internal;

/// <summary>
/// Provides common internal methods and utilities for QuickIO operations, including determining file system entry types and handling native exceptions.
/// </summary>
internal static class InternalQuickIOCommon
{
    /// <summary>
    /// Determines the type of file system entry (file or directory) based on the given <see cref="QuickIOPathInfo"/>.
    /// </summary>
    /// <param name="pathInfo">The path information of the file system entry.</param>
    /// <returns>
    /// A <see cref="QuickIOFileSystemEntryType"/> indicating whether the path represents a file or a directory.
    /// </returns>
    internal static QuickIOFileSystemEntryType DetermineFileSystemEntry(QuickIOPathInfo pathInfo)
    {
        Win32FindData findData = InternalQuickIO.GetFindDataFromPath(pathInfo);

        return !InternalQuickIO.ContainsFileAttribute(findData.dwFileAttributes, FileAttributes.Directory)
            ? QuickIOFileSystemEntryType.File
            : QuickIOFileSystemEntryType.Directory;
    }

    /// <summary>
    /// Determines the type of file system entry (file or directory) based on the given <see cref="Win32FindData"/>.
    /// </summary>
    /// <param name="findData">The <see cref="Win32FindData"/> structure containing file or directory attributes.</param>
    /// <returns>
    /// A <see cref="QuickIOFileSystemEntryType"/> indicating whether the find data represents a file or a directory.
    /// </returns>
    internal static QuickIOFileSystemEntryType DetermineFileSystemEntry(Win32FindData findData)
    {
        return !InternalHelpers.ContainsFileAttribute(findData.dwFileAttributes, FileAttributes.Directory)
            ? QuickIOFileSystemEntryType.File
            : QuickIOFileSystemEntryType.Directory;
    }

    /// <summary>
    /// Maps native error codes to appropriate .NET exceptions based on the error code and the path involved.
    /// </summary>
    /// <param name="path">The path where the error occurred.</param>
    /// <param name="errorCode">The native Windows error code.</param>
    /// <exception cref="Exception">Thrown based on the error code with a relevant message and inner exception if applicable.</exception>
    public static void NativeExceptionMapping(string path, int errorCode)
    {
        if (errorCode == Win32ErrorCodes.ERROR_SUCCESS)
        {
            return;
        }

        string affectedPath = QuickIOPath.ToRegularPath(path);

        // Reference: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-?

        throw errorCode switch
        {
            Win32ErrorCodes.ERROR_PATH_NOT_FOUND or Win32ErrorCodes.ERROR_FILE_NOT_FOUND
                => new PathNotFoundException(Win32ErrorCodes.FormatMessage(errorCode), affectedPath),
            Win32ErrorCodes.ERROR_ALREADY_EXISTS
                => new PathAlreadyExistsException(Win32ErrorCodes.FormatMessage(errorCode), affectedPath),
            Win32ErrorCodes.ERROR_INVALID_NAME or Win32ErrorCodes.ERROR_DIRECTORY
                => new InvalidPathException(Win32ErrorCodes.FormatMessage(errorCode), affectedPath),
            Win32ErrorCodes.ERROR_REM_NOT_LIST or Win32ErrorCodes.ERROR_NETWORK_BUSY or Win32ErrorCodes.ERROR_BUSY or Win32ErrorCodes.ERROR_PATH_BUSY
                => new FileSystemIsBusyException(Win32ErrorCodes.FormatMessage(errorCode), affectedPath),
            Win32ErrorCodes.ERROR_DIR_NOT_EMPTY
                => new DirectoryNotEmptyException(Win32ErrorCodes.FormatMessage(errorCode), affectedPath),
            Win32ErrorCodes.ERROR_ACCESS_DENIED or Win32ErrorCodes.ERROR_NETWORK_ACCESS_DENIED
                => new UnauthorizedAccessException("Access to '" + affectedPath + "' denied.", new Win32Exception(errorCode)),
            Win32ErrorCodes.ERROR_CURRENT_DIRECTORY or Win32ErrorCodes.ERROR_CANNOT_MAKE
                => new Exception(Win32ErrorCodes.FormatMessage(errorCode) + affectedPath + "'.", new Win32Exception(errorCode)),
            _ => new Exception("Error on '" + affectedPath + "': See InnerException for details.", new Win32Exception(errorCode)),
        };
    }
}

