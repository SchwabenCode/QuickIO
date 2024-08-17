using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using SchwabenCode.QuickIO.Compatibility;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO.Internal;

/// <summary>
/// Provides internal utility methods and operations related to file and directory handling.
/// This class is used internally by QuickIO to abstract common file system tasks.
/// </summary>
/// <remarks>
/// This class contains methods for interacting with the Windows file system API and managing file and directory attributes.
/// It is not intended to be used directly by external code, and its members are only accessible within the assembly.
/// </remarks>
internal static class InternalQuickIO
{
    /// <summary>
    /// Creates a new file or opens an existing file specified by the <see cref="QuickIOPathInfo"/> object with the specified access, sharing, mode, and attributes.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object that specifies the path of the file to be created or opened.</param>
    /// <param name="fileAccess">The level of access to the file. The default is <see cref="FileAccess.Write"/>.</param>
    /// <param name="fileShare">Specifies the type of access other processes can have to the file while it is open. The default is <see cref="FileShare.None"/>.</param>
    /// <param name="fileMode">Specifies how the operating system should open the file. The default is <see cref="FileMode.Create"/>.</param>
    /// <param name="fileAttributes">The attributes to set for the file. The default is <c>0</c> (no attributes).</param>
    /// <remarks>
    /// This method creates a new file or opens an existing file based on the specified parameters. If the file already exists and the <paramref name="fileMode"/> is set to <see cref="FileMode.Create"/>, the existing file will be overwritten.
    /// The <paramref name="fileAccess"/> parameter controls the type of access to the file, <paramref name="fileShare"/> determines how other processes can access the file, and <paramref name="fileAttributes"/> sets the file's attributes.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\newfile.txt");
    /// try
    /// {
    ///     CreateFile(pathInfo, FileAccess.ReadWrite, FileShare.None, FileMode.Create, FileAttributes.Normal);
    ///     Console.WriteLine("File created or opened successfully.");
    /// }
    /// catch (Exception ex)
    /// {
    ///     Console.WriteLine($"Error creating or opening file: {ex.Message}");
    /// }
    /// </code>
    /// </example>
    public static void CreateFile(QuickIOPathInfo pathInfo, FileAccess fileAccess = FileAccess.Write, FileShare fileShare = FileShare.None, FileMode fileMode = FileMode.Create, FileAttributes fileAttributes = 0)
    {
        using SafeFileHandle fileHandle = Win32SafeNativeMethods.CreateFile(pathInfo.FullNameUnc, fileAccess, fileShare, IntPtr.Zero, fileMode, fileAttributes, IntPtr.Zero);

        int win32Error = Marshal.GetLastWin32Error();
        if (fileHandle.IsInvalid)
        {
            InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
        }
    }

    /// <summary>
    /// Deletes a file specified by the given path.
    /// </summary>
    /// <param name="path">The path of the file to delete.</param>
    /// <remarks>
    /// This method removes all attributes from the file before attempting to delete it. 
    /// If the deletion fails, it will throw an exception based on the Win32 error code retrieved.
    /// </remarks>
    public static void DeleteFile(string path)
    {
        // Remove all file attributes before deletion.
        RemoveAllFileAttributes(path);

        // Attempt to delete the file.
        bool result = Win32SafeNativeMethods.DeleteFile(path);
        int win32Error = Marshal.GetLastWin32Error();

        // Check if the deletion was unsuccessful and map the error to an exception.
        if (!result)
        {
            InternalQuickIOCommon.NativeExceptionMapping(path, win32Error);
        }
    }


    /// <summary>
    /// Removes all file attributes from the file specified by the given path by setting its attributes to <see cref="FileAttributes.Normal"/>.
    /// </summary>
    /// <param name="path">The path of the file from which to remove all attributes.</param>
    /// <remarks>
    /// This method sets the file attributes of the specified file to <see cref="FileAttributes.Normal"/>, effectively removing
    /// all other attributes that might be set on the file. This is useful for ensuring that a file has no special attributes
    /// that could affect its visibility, read/write permissions, or other aspects of file handling.
    /// </remarks>
    /// <example>
    /// <code>
    /// string filePath = @"C:\example\file.txt";
    /// try
    /// {
    ///     RemoveAllFileAttributes(filePath);
    ///     Console.WriteLine("File attributes removed successfully.");
    /// }
    /// catch (Exception ex)
    /// {
    ///     Console.WriteLine($"Error removing file attributes: {ex.Message}");
    /// }
    /// </code>
    /// </example>
    public static void RemoveAllFileAttributes(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path), "The file path cannot be null or empty.");
        }

        SetAttributes(path, FileAttributes.Normal);
    }


    /// <summary>
    /// Deletes the file represented by the specified <paramref name="pathInfo"/> object.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object representing the file to delete.</param>
    /// <remarks>
    /// This method uses the UNC path provided by the <paramref name="pathInfo"/> object to delete the specified file. 
    /// It calls the <see cref="DeleteFile(string)"/> method to perform the actual deletion.
    /// If the file does not exist or cannot be deleted due to permissions or other I/O errors, appropriate exceptions will be thrown.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"\\server\share\file.txt");
    /// try
    /// {
    ///     DeleteFile(pathInfo);
    ///     Console.WriteLine("File deleted successfully.");
    /// }
    /// catch (Exception ex)
    /// {
    ///     Console.WriteLine($"Error deleting file: {ex.Message}");
    /// }
    /// </code>
    /// </example>
    public static void DeleteFile(QuickIOPathInfo pathInfo)
    {
        if (pathInfo is null)
        {
            throw new ArgumentNullException(nameof(pathInfo));
        }

        DeleteFile(pathInfo.FullNameUnc);
    }


    /// <summary>
    /// Deletes the file represented by the <paramref name="fileInfo"/> object.
    /// </summary>
    /// <param name="fileInfo">The <see cref="QuickIOFileInfo"/> object representing the file to delete.</param>
    /// <remarks>
    /// This method uses the path information provided by the <paramref name="fileInfo"/> object to delete the specified file. It calls the <see cref="DeleteFile(string)"/> method, which performs the actual deletion. 
    /// If the file does not exist or cannot be deleted due to permissions or other I/O errors, appropriate exceptions will be thrown. 
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOFileInfo fileInfo = new QuickIOFileInfo(@"C:\example\file.txt");
    /// try
    /// {
    ///     DeleteFile(fileInfo);
    ///     Console.WriteLine("File deleted successfully.");
    /// }
    /// catch (Exception ex)
    /// {
    ///     Console.WriteLine($"Error deleting file: {ex.Message}");
    /// }
    /// </code>
    /// </example>
    public static void DeleteFile(QuickIOFileInfo fileInfo)
    {

        DeleteFile(fileInfo.PathInfo);
    }

    /// <summary>
    /// Removes the specified attribute from the file or directory represented by the <paramref name="pathInfo"/> object.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object representing the file or directory from which to remove the attribute.</param>
    /// <param name="attribute">The attribute to remove from the file or directory.</param>
    /// <returns><c>true</c> if the attribute was successfully removed; otherwise, <c>false</c> if the attribute was not present.</returns>
    /// <remarks>
    /// This method checks if the specified attribute is present on the file or directory represented by <paramref name="pathInfo"/>. If the attribute is present, it removes the attribute and updates the file or directory attributes using the <see cref="SetAttributes(QuickIOPathInfo, FileAttributes)"/> method. If the attribute is not present, no changes are made. The method returns <c>true</c> if the attribute was removed and <c>false</c> if the attribute was not present. 
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// bool attributeRemoved = RemoveAttribute(pathInfo, FileAttributes.ReadOnly);
    /// if (attributeRemoved)
    /// {
    ///     Console.WriteLine("Attribute removed successfully.");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Attribute was not present.");
    /// }
    /// </code>
    /// </example>
    public static bool RemoveAttribute(QuickIOPathInfo pathInfo, FileAttributes attribute)
    {
        if ((pathInfo.Attributes & attribute) == attribute)
        {
            FileAttributes attributes = pathInfo.Attributes;
            attributes &= ~attribute;
            SetAttributes(pathInfo, attributes);
            return true;
        }
        return false;
    }


    /// <summary>
    /// Removes the specified attribute from the file or directory at the given path.
    /// </summary>
    /// <param name="path">The path of the file or directory from which to remove the attribute.</param>
    /// <param name="attribute">The attribute to remove from the file or directory.</param>
    /// <returns><c>true</c> if the attribute was successfully removed; otherwise, <c>false</c> if the attribute was not present.</returns>
    /// <remarks>
    /// This method checks if the specified attribute is present on the file or directory. If the attribute is present, it removes the attribute and updates the file or directory attributes. If the attribute is not present, no changes are made. The method returns <c>true</c> if the attribute was removed and <c>false</c> if the attribute was not present. The actual change is applied by calling the <see cref="SetAttributes(string, FileAttributes)"/> method, which should handle the process of setting the new attributes on the file or directory.
    /// </remarks>
    /// <example>
    /// <code>
    /// string path = @"C:\example\file.txt";
    /// bool attributeRemoved = RemoveAttribute(path, FileAttributes.ReadOnly);
    /// if (attributeRemoved)
    /// {
    ///     Console.WriteLine("Attribute removed successfully.");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Attribute was not present.");
    /// }
    /// </code>
    /// </example>
    public static bool RemoveAttribute(string path, FileAttributes attribute)
    {
        FileAttributes currentAttributes = GetAttributes(path);

        if ((currentAttributes & attribute) == attribute)
        {
            FileAttributes attributes = currentAttributes;
            attributes &= ~attribute;
            SetAttributes(path, attributes);
            return true;
        }
        return false;
    }


    /// <summary>
    /// Adds the specified attribute to the file or directory represented by the given path information.
    /// </summary>
    /// <param name="pathInfo">The path information of the file or directory to modify.</param>
    /// <param name="attribute">The attribute to add to the file or directory.</param>
    /// <returns><c>true</c> if the attribute was successfully added; otherwise, <c>false</c> if the attribute was already present.</returns>
    /// <remarks>
    /// This method checks if the specified attribute is already present on the file or directory. If the attribute is not present, it adds the attribute and updates the file or directory attributes. If the attribute is already present, no changes are made. The method returns <c>true</c> if the attribute was added and <c>false</c> if it was already present. The actual change is applied by calling the <see cref="SetAttributes(QuickIOPathInfo, FileAttributes)"/> method, which should handle the process of setting the new attributes on the file or directory.
    /// </remarks>
    /// <example>
    /// <code>
    /// var pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// bool attributeAdded = AddAttribute(pathInfo, FileAttributes.ReadOnly);
    /// if (attributeAdded)
    /// {
    ///     Console.WriteLine("Attribute added successfully.");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Attribute was already present.");
    /// }
    /// </code>
    /// </example>
    public static bool AddAttribute(QuickIOPathInfo pathInfo, FileAttributes attribute)
    {
        if ((pathInfo.Attributes & attribute) != attribute)
        {
            FileAttributes attributes = pathInfo.Attributes;
            attributes |= attribute;
            SetAttributes(pathInfo, attributes);
            return true;
        }

        return false;
    }


    /// <summary>
    /// Creates a new directory at the specified path. Optionally, creates any necessary parent directories if <paramref name="recursive"/> is set to <c>true</c>.
    /// </summary>
    /// <param name="pathInfo">The path information for the directory to create.</param>
    /// <param name="recursive">A <c>bool</c> indicating whether to create any missing parent directories. If <c>true</c>, the method will recursively create parent directories if they do not exist; otherwise, only the specified directory is created if its parent directories already exist.</param>
    /// <remarks>
    /// This method first checks if the directory already exists. If it does, the method exits without making any changes. If the directory does not exist, it will check if the path is a root directory and throw an exception if the root directory is not found and cannot be created. If <paramref name="recursive"/> is set to <c>true</c>, the method will also create any missing parent directories by recursively calling itself. Finally, it attempts to create the directory and throws an exception if the creation fails for any reason.
    /// </remarks>
    /// <example>
    /// <code>
    /// var pathInfo = new QuickIOPathInfo(@"C:\example\newDirectory");
    /// CreateDirectory(pathInfo, recursive: true);
    /// </code>
    /// </example>
    public static void CreateDirectory(QuickIOPathInfo pathInfo, bool recursive = false)
    {
        if (QuickIODirectory.Exists(pathInfo))
        {
            return;
        }

        if (pathInfo.IsRoot)
        {
            throw new PathNotFoundException("Root directory " + pathInfo.FullName + " does not exist and cannot be created.");
        }

        if (recursive)
        {
            QuickIOPathInfo? parent = pathInfo.Parent ?? throw new PathNotFoundException("Parent directory of " + pathInfo.FullName + " does not exist and cannot be created.");
            if (parent.IsRoot)
            {
                // Root
                if (!parent.Exists)
                {
                    throw new PathNotFoundException("Root path does not exist. You cannot create a root this way.", parent.FullName);
                }
            }
            else if (!parent.Exists)
            {
                CreateDirectory(parent, recursive);
            }
        }

        bool created = Win32SafeNativeMethods.CreateDirectory(pathInfo.FullNameUnc, IntPtr.Zero);
        int win32Error = Marshal.GetLastWin32Error();
        if (!created)
        {
            InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
        }
    }


    /// <summary>
    /// Deletes all files in the specified directory. Optionally, it can also delete files in subdirectories if <paramref name="recursive"/> is set to <c>true</c>.
    /// </summary>
    /// <param name="directoryPath">The path to the directory from which files will be deleted.</param>
    /// <param name="recursive">A <c>bool</c> indicating whether to include files in subdirectories. If <c>true</c>, the method will delete files in all subdirectories; otherwise, only files in the top-level directory are deleted.</param>
    /// <remarks>
    /// This method enumerates all files in the specified directory and, if <paramref name="recursive"/> is <c>true</c>, it also includes files in all subdirectories. Each file is then deleted using the <see cref="DeleteFile"/> method. If an error occurs while deleting any file, an exception is thrown with details of the issue.
    /// </remarks>
    /// <example>
    /// <code>
    /// string directoryPath = @"C:\example\directory";
    /// DeleteFiles(directoryPath, recursive: true);
    /// </code>
    /// </example>
    public static void DeleteFiles(string directoryPath, bool recursive = false)
    {
        IEnumerable<string> allFilePaths = EnumerateFilePaths(directoryPath, QuickIOPatternConstants.All, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions.None);
        foreach (string filePath in allFilePaths)
        {
            DeleteFile(filePath);
        }
    }


    /// <summary>
    /// Deletes the directory specified by the given path information and optionally its contents. If <paramref name="recursive"/> is set to <c>true</c>, all files and subdirectories within the directory will be deleted first.
    /// </summary>
    /// <param name="pathInfo">An instance of <see cref="QuickIOPathInfo"/> representing the path to the directory to delete.</param>
    /// <param name="recursive">A <c>bool</c> indicating whether to delete all files and subdirectories within the specified directory. If <c>true</c>, the method will recursively delete all contents; otherwise, only the specified directory is deleted if it is empty.</param>
    /// <remarks>
    /// If <paramref name="recursive"/> is <c>true</c>, this method will convert the <paramref name="pathInfo"/> to a <see cref="QuickIODirectoryInfo"/> and then enumerate all files and subdirectories within the specified directory, delete all files, and recursively delete all subdirectories before deleting the top-level directory itself. If the directory cannot be removed, an exception is thrown with details of the Win32 error.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\directory");
    /// DeleteDirectory(pathInfo, recursive: true);
    /// </code>
    /// </example>
    public static void DeleteDirectory(QuickIOPathInfo pathInfo, bool recursive = false)
    {
        DeleteDirectory(new QuickIODirectoryInfo(pathInfo), recursive);
    }


    /// <summary>
    /// Deletes the specified directory and optionally its contents. If <paramref name="recursive"/> is set to <c>true</c>, all files and subdirectories within the directory will be deleted first.
    /// </summary>
    /// <param name="directoryInfo">An instance of <see cref="QuickIODirectoryInfo"/> representing the directory to delete.</param>
    /// <param name="recursive">A <c>bool</c> indicating whether to delete all files and subdirectories within the specified directory. If <c>true</c>, the method will recursively delete all contents; otherwise, only the specified directory is deleted if it is empty.</param>
    /// <remarks>
    /// If <paramref name="recursive"/> is <c>true</c>, this method will enumerate all files and subdirectories within the specified directory, delete all files, and then recursively delete all subdirectories before deleting the top-level directory itself. If the directory cannot be removed, an exception is thrown with details of the Win32 error.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIODirectoryInfo directoryInfo = new QuickIODirectoryInfo(@"C:\example\directory");
    /// DeleteDirectory(directoryInfo, recursive: true);
    /// </code>
    /// </example>
    public static void DeleteDirectory(QuickIODirectoryInfo directoryInfo, bool recursive = false)
    {
        if (recursive)
        {
            IEnumerable<string> subFiles = QuickIODirectory.EnumerateFilePaths(directoryInfo.FullNameUnc, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOPathType.UNC, QuickIOEnumerateOptions.None);

            foreach (string item in subFiles)
            {
                DeleteFile(item);
            }

            IEnumerable<QuickIODirectoryInfo> subDirs = QuickIODirectory.EnumerateDirectories(directoryInfo, QuickIOPatternConstants.All, SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions.None);

            foreach (QuickIODirectoryInfo subDir in subDirs)
            {
                DeleteDirectory(subDir, recursive);
            }
        }

        bool removed = Win32SafeNativeMethods.RemoveDirectory(directoryInfo.FullNameUnc);
        int win32Error = Marshal.GetLastWin32Error();
        if (!removed)
        {
            InternalQuickIOCommon.NativeExceptionMapping(directoryInfo.FullName, win32Error);
        }
    }


    /// <summary>
    /// Attempts to retrieve the <see cref="Win32FindData"/> for the file or directory specified by the given <see cref="QuickIOPathInfo"/> object.
    /// </summary>
    /// <param name="pathInfo">An instance of <see cref="QuickIOPathInfo"/> representing the path of the file or directory to retrieve information for.</param>
    /// <param name="pathFindData">When this method returns, contains the <see cref="Win32FindData"/> for the file or directory if successful; otherwise, null. This parameter is passed uninitialized.</param>
    /// <returns><c>true</c> if the <see cref="Win32FindData"/> was successfully retrieved; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method calls the Win32 API function <c>FindFirstFile</c> to obtain file or directory data. If the handle is invalid, an exception is thrown. If the entry is not a system directory entry, the data is returned. Otherwise, <c>false</c> is returned and <paramref name="pathFindData"/> is set to null.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// if (TryGetFindDataFromPath(pathInfo, out Win32FindData? findData))
    /// {
    ///     Console.WriteLine("File found: " + findData.cFileName);
    /// }
    /// else
    /// {
    ///     Console.WriteLine("File not found or is a system directory.");
    /// }
    /// </code>
    /// </example>
    public static bool TryGetFindDataFromPath(QuickIOPathInfo pathInfo, [NotNullWhen(true)] out Win32FindData? pathFindData)
    {
        Win32FindData win32FindData = new();

        using (Win32FileHandle fileHandle = FindFirstSafeFileHandle(pathInfo.FullNameUnc, win32FindData, out int win32Error))
        {
            if (fileHandle.IsInvalid)
            {
                InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
            }

            if (!InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                pathFindData = win32FindData;
                return true;
            }
        }

        pathFindData = null;
        return false;
    }

    /// <summary>
    /// Obtains a handle to the first file or directory matching the specified path and initializes a <see cref="Win32FindData"/> object with the file or directory information.
    /// </summary>
    /// <param name="path">The path of the file or directory to search for.</param>
    /// <param name="win32FindData">An instance of <see cref="Win32FindData"/> that will be populated with information about the found file or directory.</param>
    /// <param name="win32Error">An output parameter that will contain the last Win32 error code if the handle is invalid.</param>
    /// <returns>A <see cref="Win32FileHandle"/> handle to the first file or directory found. If no file is found or an error occurs, the handle will be invalid.</returns>
    /// <remarks>
    /// This method calls the Win32 API function <c>FindFirstFile</c> to search for the first file or directory matching the specified path. If the handle is invalid, the <paramref name="win32Error"/> output parameter will contain the Win32 error code.
    /// </remarks>
    /// <example>
    /// <code>
    /// Win32FindData findData = new Win32FindData();
    /// int errorCode;
    /// using (Win32FileHandle handle = FindFirstSafeFileHandle(@"C:\example\*", findData, out errorCode))
    /// {
    ///     if (!handle.IsInvalid)
    ///     {
    ///         Console.WriteLine("First file found: " + findData.cFileName);
    ///     }
    ///     else
    ///     {
    ///         Console.WriteLine("Error occurred: " + errorCode);
    ///     }
    /// }
    /// </code>
    /// </example>
    private static Win32FileHandle FindFirstSafeFileHandle(string path, Win32FindData win32FindData, out int win32Error)
    {
        Win32FileHandle result = Win32SafeNativeMethods.FindFirstFile(path, win32FindData);
        win32Error = Marshal.GetLastWin32Error();

        return result;
    }


    /// <summary>
    /// Checks whether a file or directory exists based on the provided <paramref name="pathInfo"/>.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object containing the path to check.</param>
    /// <returns><c>true</c> if the file or directory exists; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method calls the <see cref="Exists(string)"/> method with the UNC path from the <paramref name="pathInfo"/> object.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// bool exists = Exists(pathInfo);
    /// Console.WriteLine(exists ? "Path exists." : "Path does not exist.");
    /// </code>
    /// </example>
    public static bool Exists(QuickIOPathInfo pathInfo)
    {
        return Exists(pathInfo.FullNameUnc);
    }


    /// <summary>
    /// Checks whether a file or directory exists at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path of the file or directory to check.</param>
    /// <returns><c>true</c> if the file or directory exists; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method uses the Win32 API to retrieve the file attributes for the given path. If the API call fails or returns an invalid attribute value,
    /// the method will return <c>false</c>, indicating that the file or directory does not exist.
    /// </remarks>
    /// <example>
    /// <code>
    /// string path = @"C:\example\file.txt";
    /// bool exists = Exists(path);
    /// Console.WriteLine(exists ? "Path exists." : "Path does not exist.");
    /// </code>
    /// </example>
    public static bool Exists(string path)
    {
        uint attributes = Win32SafeNativeMethods.GetFileAttributes(path);
        return attributes != 0xffffffff;
    }


    /// <summary>
    /// Retrieves a <see cref="Win32FindData"/> structure for a file or directory specified by the <paramref name="pathInfo"/>.
    /// </summary>
    /// <param name="pathInfo">An instance of <see cref="QuickIOPathInfo"/> representing the file or directory to retrieve information for.</param>
    /// <returns>A <see cref="Win32FindData"/> structure containing the file or directory information.</returns>
    /// <exception cref="PathNotFoundException">Thrown if the path cannot be found.</exception>
    /// <remarks>
    /// This method attempts to obtain the find data for the file or directory at the path specified in <paramref name="pathInfo"/>.
    /// It ensures that the handle is valid and ignores system directory entries such as "." and "..".
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// Win32FindData findData = GetFindDataFromPath(pathInfo);
    /// Console.WriteLine($"File size: {findData.nFileSizeLow} bytes");
    /// </code>
    /// </example>
    public static Win32FindData GetFindDataFromPath(QuickIOPathInfo pathInfo)
    {
        Win32FindData win32FindData = new();
        using (Win32FileHandle fileHandle = FindFirstSafeFileHandle(pathInfo.FullNameUnc, win32FindData, out int win32Error))
        {
            // Take care of invalid handles
            if (fileHandle.IsInvalid)
            {
                InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
            }

            // Ignore . and .. directories
            if (!InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                return win32FindData;
            }
        }

        throw new PathNotFoundException(pathInfo.FullName);
    }


    /// <summary>
    /// Retrieves a <see cref="Win32FindData"/> structure for a file or directory specified by the <paramref name="pathInfo"/>. Optionally verifies that the entry matches the expected type specified by <paramref name="estimatedFileSystemEntryType"/>.
    /// </summary>
    /// <param name="pathInfo">An instance of <see cref="QuickIOPathInfo"/> representing the file or directory to retrieve information for.</param>
    /// <param name="estimatedFileSystemEntryType">An optional parameter to specify the expected file system entry type (file or directory). If null, no type verification is performed.</param>
    /// <returns>A <see cref="Win32FindData"/> structure containing the file or directory information.</returns>
    /// <exception cref="PathNotFoundException">Thrown if the path cannot be found.</exception>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Thrown if the file system entry does not match the expected type.</exception>
    /// <remarks>
    /// This method calls <see cref="GetFindDataFromPath(string, QuickIOFileSystemEntryType?)"/> with the UNC path from the <paramref name="pathInfo"/>.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// Win32FindData findData = GetFindDataFromPath(pathInfo, QuickIOFileSystemEntryType.File);
    /// Console.WriteLine($"File size: {findData.nFileSizeLow} bytes");
    /// </code>
    /// </example>
    public static Win32FindData GetFindDataFromPath(QuickIOPathInfo pathInfo, QuickIOFileSystemEntryType? estimatedFileSystemEntryType)
    {
        return GetFindDataFromPath(pathInfo.FullNameUnc, estimatedFileSystemEntryType);
    }



    /// <summary>
    /// Retrieves a <see cref="Win32FindData"/> structure for a file or directory specified by the <paramref name="fullUncPath"/>. Optionally verifies that the entry matches the expected type specified by <paramref name="estimatedFileSystemEntryType"/>.
    /// </summary>
    /// <param name="fullUncPath">The full UNC path of the file or directory to retrieve information for.</param>
    /// <param name="estimatedFileSystemEntryType">An optional parameter to specify the expected file system entry type (file or directory). If null, no type verification is performed.</param>
    /// <returns>A <see cref="Win32FindData"/> structure containing the file or directory information.</returns>
    /// <exception cref="PathNotFoundException">Thrown if the path cannot be found.</exception>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Thrown if the file system entry does not match the expected type.</exception>
    /// <remarks>
    /// This method opens a handle to the file or directory and retrieves its metadata. If the <paramref name="estimatedFileSystemEntryType"/> is specified, the method checks that the retrieved data matches the expected type.
    /// </remarks>
    /// <example>
    /// <code>
    /// string path = @"C:\example\file.txt";
    /// Win32FindData findData = GetFindDataFromPath(path, QuickIOFileSystemEntryType.File);
    /// Console.WriteLine($"File size: {findData.nFileSizeLow} bytes");
    /// </code>
    /// </example>
    public static Win32FindData GetFindDataFromPath(string fullUncPath, QuickIOFileSystemEntryType? estimatedFileSystemEntryType)
    {
        Win32FindData win32FindData = new();
        using (Win32FileHandle fileHandle = FindFirstSafeFileHandle(fullUncPath, win32FindData, out int win32Error))
        {
            if (fileHandle.IsInvalid)
            {
                InternalQuickIOCommon.NativeExceptionMapping(fullUncPath, win32Error);
            }

            if (!InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                switch (estimatedFileSystemEntryType)
                {
                    case null:
                        return win32FindData;
                    case QuickIOFileSystemEntryType.Directory:
                        if (InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
                        {
                            return win32FindData;
                        }
                        throw new UnmatchedFileSystemEntryTypeException(QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.File, fullUncPath);
                    case QuickIOFileSystemEntryType.File:
                        if (!InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
                        {
                            return win32FindData;
                        }
                        throw new UnmatchedFileSystemEntryTypeException(QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, fullUncPath);
                }
            }
        }
        throw new PathNotFoundException(fullUncPath);
    }



    /// <summary>
    /// Creates a <see cref="SafeFileHandle"/> with read and write access to the file or directory specified by the <paramref name="pathInfo"/> object, with no sharing and default file attributes.
    /// </summary>
    /// <param name="pathInfo">A <see cref="QuickIOPathInfo"/> object containing the path to the file or directory.</param>
    /// <returns>A <see cref="SafeFileHandle"/> that represents the open handle to the file or directory.</returns>
    /// <remarks>
    /// This method calls <see cref="CreateSafeFileHandle(string)"/> using the <see cref="FullNameUnc"/> property of the <paramref name="pathInfo"/> object.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\example\file.txt");
    /// using SafeFileHandle handle = CreateSafeFileHandle(pathInfo);
    /// if (!handle.IsInvalid)
    /// {
    ///     Console.WriteLine("Handle created successfully.");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Failed to create handle.");
    /// }
    /// </code>
    /// </example>
    internal static SafeFileHandle CreateSafeFileHandle(QuickIOPathInfo pathInfo)
    {
        return CreateSafeFileHandle(pathInfo.FullNameUnc);
    }


    /// <summary>
    /// Creates a <see cref="SafeFileHandle"/> with read and write access to a file or directory, with no sharing and default file attributes.
    /// </summary>
    /// <param name="path">The path to the file or directory to open.</param>
    /// <returns>A <see cref="SafeFileHandle"/> that represents the open handle to the file or directory.</returns>
    /// <remarks>
    /// The handle is created with the following access rights:
    /// <list type="bullet">
    ///     <item>Read and Write access</item>
    ///     <item>No sharing</item>
    ///     <item>Default security attributes</item>
    ///     <item>Open existing file</item>
    ///     <item>Normal file attributes</item>
    /// </list>
    /// The handle is opened using <see cref="FileMode.Open"/> and <see cref="FileAccess.ReadWrite"/> access. The file is created with normal attributes and no template file.
    /// </remarks>
    /// <example>
    /// <code>
    /// string path = @"C:\example\file.txt";
    /// using SafeFileHandle handle = CreateSafeFileHandle(path);
    /// if (!handle.IsInvalid)
    /// {
    ///     Console.WriteLine("Handle created successfully.");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Failed to create handle.");
    /// }
    /// </code>
    /// </example>
    private static SafeFileHandle CreateSafeFileHandle(string path)
    {
        return Win32SafeNativeMethods.CreateFile(
            path,
            FileAccess.ReadWrite, // Desired access
            FileShare.None, // Share mode
            IntPtr.Zero, // Security attributes
            FileMode.Open, // File mode
            FileAttributes.Normal, // File attributes
            IntPtr.Zero // Template file
        );
    }


    /// <summary>
    /// Opens a handle to a file or directory with read and write access, allowing for sharing of the file or directory with other processes.
    /// </summary>
    /// <param name="path">The path to the file or directory to open.</param>
    /// <returns>A <see cref="SafeFileHandle"/> that represents the open handle to the file or directory.</returns>
    /// <remarks>
    /// The handle is opened with the following access rights:
    /// <list type="bullet">
    ///     <item>Read and Write access</item>
    ///     <item>Shared access for reading, writing, and deleting</item>
    /// </list>
    /// The handle is opened using <see cref="FileMode.Open"/> and <see cref="FileAccess.ReadWrite"/> access. The handle is created with specific flags and permissions.
    /// </remarks>
    /// <example>
    /// <code>
    /// string path = @"C:\example\file.txt";
    /// using SafeFileHandle handle = OpenReadWriteFileSystemEntryHandle(path);
    /// if (!handle.IsInvalid)
    /// {
    ///     Console.WriteLine("Handle opened successfully.");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Failed to open handle.");
    /// }
    /// </code>
    /// </example>
    internal static SafeFileHandle OpenReadWriteFileSystemEntryHandle(string path)
    {
        return Win32SafeNativeMethods.OpenReadWriteFileSystemEntryHandle(
            path,
            (0x40000000 | 0x80000000), // Desired access
            FileShare.Read | FileShare.Write | FileShare.Delete, // Share mode
            IntPtr.Zero, // Security attributes
            FileMode.Open, // File mode
            (0x02000000), // File attributes
            IntPtr.Zero // Template file
        );
    }


    /// <summary>
    /// Enumerates metadata for files and subdirectories within a directory specified by the <see cref="QuickIOPathInfo"/>. This method gathers metadata about files and directories based on the provided options.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object representing the directory to enumerate.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior.</param>
    /// <returns>A <see cref="QuickIODirectoryMetadata"/> object containing metadata about the directory and its contents, or <c>null</c> if the enumeration fails.</returns>
    /// <remarks>
    /// This method calls <see cref="EnumerateDirectoryMetadata(string, Win32FindData, QuickIOEnumerateOptions)"/> to perform the actual enumeration.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"\\server\share\exampleDirectory");
    /// QuickIODirectoryMetadata? metadata = EnumerateDirectoryMetadata(pathInfo);
    /// if (metadata != null)
    /// {
    ///     Console.WriteLine($"Directory: {metadata.Path}");
    ///     foreach (var file in metadata.Files)
    ///     {
    ///         Console.WriteLine($"File: {file.Path}");
    ///     }
    ///     foreach (var subDir in metadata.Subdirectories)
    ///     {
    ///         Console.WriteLine($"Subdirectory: {subDir.Path}");
    ///     }
    /// }
    /// </code>
    /// </example>
    internal static QuickIODirectoryMetadata? EnumerateDirectoryMetadata(
        QuickIOPathInfo pathInfo,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return EnumerateDirectoryMetadata(pathInfo.FullNameUnc, pathInfo.FindData, enumerateOptions);
    }


    /// <summary>
    /// Enumerates metadata for files and subdirectories within a specified directory. This method gathers metadata about files and directories found in the directory and its subdirectories, based on the provided options.
    /// </summary>
    /// <param name="uncDirectoryPath">The UNC path of the directory to enumerate.</param>
    /// <param name="findData">The <see cref="Win32FindData"/> containing metadata for the directory itself.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior.</param>
    /// <returns>A <see cref="QuickIODirectoryMetadata"/> object containing metadata about the directory and its contents, or <c>null</c> if the enumeration fails.</returns>
    /// <remarks>
    /// This method creates a recursive structure to collect metadata for all files and subdirectories. It uses the specified <see cref="QuickIOEnumerateOptions"/> to handle enumeration and error conditions.
    /// </remarks>
    /// <example>
    /// <code>
    /// string directoryPath = @"\\server\share\exampleDirectory";
    /// Win32FindData directoryData = new Win32FindData(); // Assume this is initialized with the directory's data
    /// QuickIODirectoryMetadata? metadata = EnumerateDirectoryMetadata(directoryPath, directoryData, QuickIOEnumerateOptions.None);
    /// if (metadata != null)
    /// {
    ///     Console.WriteLine($"Directory: {metadata.Path}");
    ///     foreach (var file in metadata.Files)
    ///     {
    ///         Console.WriteLine($"File: {file.Path}");
    ///     }
    ///     foreach (var subDir in metadata.Subdirectories)
    ///     {
    ///         Console.WriteLine($"Subdirectory: {subDir.Path}");
    ///     }
    /// }
    /// </code>
    /// </example>
    internal static QuickIODirectoryMetadata? EnumerateDirectoryMetadata(
        string uncDirectoryPath,
        Win32FindData findData,
        QuickIOEnumerateOptions enumerateOptions)
    {
        // Results
        List<QuickIOFileMetadata> subFiles = new();
        List<QuickIODirectoryMetadata> subDirs = new();

        string currentPath = QuickIOPath.Combine(uncDirectoryPath, QuickIOPatternConstants.All);

        Win32FindData win32FindData = new();
        using (Win32FileHandle fileHandle = FindFirstSafeFileHandle(currentPath, win32FindData, out int win32Error))
        {
            if (fileHandle.IsInvalid)
            {
                if (win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES)
                {
                    InternalQuickIOCommon.NativeExceptionMapping(uncDirectoryPath, win32Error);
                }

                if (EnumerationHandleInvalidFileHandle(uncDirectoryPath, enumerateOptions, win32Error))
                {
                    return null;
                }
            }

            do
            {
                if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
                {
                    continue;
                }

                string uncResultPath = QuickIOPath.Combine(uncDirectoryPath, win32FindData.cFileName);

                if (!InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
                {
                    QuickIOFileMetadata fileMetaData = new(uncResultPath, win32FindData);
                    subFiles.Add(fileMetaData);
                }
                else
                {
                    QuickIODirectoryMetadata? dir = EnumerateDirectoryMetadata(uncResultPath, win32FindData, enumerateOptions);
                    if (dir is not null)
                    {
                        subDirs.Add(dir);
                    }
                }

                win32FindData = new Win32FindData();
            }
            while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
        }

        return new QuickIODirectoryMetadata(uncDirectoryPath, findData, subDirs, subFiles);
    }


    /// <summary>
    /// Enumerates directories within the specified path information, matching a given pattern, with options for recursive searching and additional enumeration settings. Returns a collection of <see cref="QuickIODirectoryInfo"/> objects representing the directories found.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object containing the path to search within.</param>
    /// <param name="pattern">The search pattern to match directories. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>An <see cref="IEnumerable{QuickIODirectoryInfo}"/> containing <see cref="QuickIODirectoryInfo"/> objects representing directories.</returns>
    /// <remarks>
    /// This method uses the provided <see cref="QuickIOPathInfo"/> to construct the search path and then enumerates directories. It handles errors and invalid handles according to the options provided.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\exampleDirectory");
    /// foreach (var directory in EnumerateDirectories(pathInfo, "*", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine(directory.FullName);
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<QuickIODirectoryInfo> EnumerateDirectories(
        QuickIOPathInfo pathInfo,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        string currentPath = QuickIOPath.Combine(pathInfo.FullNameUnc, pattern);

        Win32FindData win32FindData = new();
        using Win32FileHandle fileHandle = FindFirstSafeFileHandle(currentPath, win32FindData, out int win32Error);

        if (fileHandle.IsInvalid)
        {
            if (win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES)
            {
                InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
            }

            if (EnumerationHandleInvalidFileHandle(pathInfo.FullName, enumerateOptions, win32Error))
            {
                yield break;
            }
        }

        do
        {
            if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                continue;
            }

            string resultPath = QuickIOPath.Combine(pathInfo.FullName, win32FindData.cFileName);

            if (InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
            {
                yield return new QuickIODirectoryInfo(resultPath, win32FindData);

                // SubFolders?!
                if (searchOption == SearchOption.AllDirectories)
                {
                    foreach (QuickIODirectoryInfo match in EnumerateDirectories(new QuickIOPathInfo(resultPath, win32FindData.cFileName), pattern, searchOption, enumerateOptions))
                    {
                        yield return match;
                    }
                }
            }
            win32FindData = new Win32FindData();
        }
        while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
    }



    /// <summary>
    /// Enumerates file system entries (both files and directories) for the specified path information, matching a given pattern, with options for recursive searching and additional enumeration settings. Returns a collection of file system entries and their types as <see cref="KeyValuePair{QuickIOPathInfo, QuickIOFileSystemEntryType}"/> pairs.
    /// </summary>
    /// <param name="pathInfo">The <see cref="QuickIOPathInfo"/> object containing the path to search within.</param>
    /// <param name="pattern">The search pattern to match file system entries. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>An <see cref="IEnumerable{KeyValuePair{QuickIOPathInfo, QuickIOFileSystemEntryType}}"/> containing pairs of <see cref="QuickIOPathInfo"/> and their corresponding file system entry types.</returns>
    /// <remarks>
    /// This method forwards the request to <see cref="EnumerateFileSystemEntries(string, string, SearchOption, QuickIOEnumerateOptions)"/> using the path information from <paramref name="pathInfo"/>.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\exampleDirectory");
    /// foreach (var entry in EnumerateFileSystemEntries(pathInfo, "*", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"{entry.Key.FullName} is a {entry.Value}");
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries(
        QuickIOPathInfo pathInfo,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return EnumerateFileSystemEntries(pathInfo.FullNameUnc, pattern, searchOption, enumerateOptions);
    }


    /// <summary>
    /// Enumerates file system entries (both files and directories) within the specified directory, matching a given pattern, with options for recursive searching and additional enumeration settings. Returns a collection of file system entries and their types as <see cref="KeyValuePair{QuickIOPathInfo, QuickIOFileSystemEntryType}"/> pairs.
    /// </summary>
    /// <param name="uncDirectoryPath">The UNC path of the directory to search within.</param>
    /// <param name="pattern">The search pattern to match file system entries. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>An <see cref="IEnumerable{KeyValuePair{QuickIOPathInfo, QuickIOFileSystemEntryType}}"/> containing pairs of <see cref="QuickIOPathInfo"/> and their corresponding file system entry types.</returns>
    /// <remarks>
    /// This method iterates through all entries in the specified directory, yielding each entry along with its type. It handles system entries and manages invalid file handles, potentially re-throwing exceptions based on the provided options.
    /// </remarks>
    /// <example>
    /// <code>
    /// foreach (var entry in EnumerateFileSystemEntries(@"C:\exampleDirectory", "*", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"{entry.Key.FullName} is a {entry.Value}");
    /// }
    /// </code>
    /// </example>
    private static IEnumerable<KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>> EnumerateFileSystemEntries(
        string uncDirectoryPath,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        string currentPath = QuickIOPath.Combine(uncDirectoryPath, pattern);

        Win32FindData win32FindData = new();
        using Win32FileHandle fileHandle = FindFirstSafeFileHandle(currentPath, win32FindData, out int win32Error);

        if (fileHandle.IsInvalid)
        {
            if (win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES)
            {
                InternalQuickIOCommon.NativeExceptionMapping(uncDirectoryPath, win32Error);
            }

            if (EnumerationHandleInvalidFileHandle(uncDirectoryPath, enumerateOptions, win32Error))
            {
                yield return new KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>();
            }
        }

        do
        {
            if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                continue;
            }

            string resultPath = QuickIOPath.Combine(uncDirectoryPath, win32FindData.cFileName);

            if (InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
            {
                yield return new KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>(new QuickIOPathInfo(resultPath) { FindData = win32FindData }, QuickIOFileSystemEntryType.Directory);

                // SubFolders?!
                if (searchOption == SearchOption.AllDirectories)
                {
                    foreach (KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType> match in EnumerateFileSystemEntries(resultPath, pattern, searchOption, enumerateOptions))
                    {
                        yield return match;
                    }
                }
            }
            else
            {
                yield return new KeyValuePair<QuickIOPathInfo, QuickIOFileSystemEntryType>(new QuickIOPathInfo(resultPath) { FindData = win32FindData }, QuickIOFileSystemEntryType.File);
            }
            win32FindData = new Win32FindData();
        }
        while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
    }


    /// <summary>
    /// Enumerates file system entry paths and their types (files or directories) within the specified directory represented by <see cref="QuickIOPathInfo"/>, matching a given pattern, with options for recursive searching and path formatting.
    /// </summary>
    /// <param name="pathInfo">An instance of <see cref="QuickIOPathInfo"/> representing the directory to search within.</param>
    /// <param name="pattern">The search pattern to match file system entries. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <param name="pathFormatReturn">Specifies the format of the paths returned. Defaults to <see cref="QuickIOPathType.Regular"/>.</param>
    /// <returns>An <see cref="IEnumerable{KeyValuePair{String, QuickIOFileSystemEntryType}}"/> containing pairs of paths and their corresponding file system entry types.</returns>
    /// <remarks>
    /// This method calls the internal method <see cref="EnumerateFileSystemEntryPaths"/> with the UNC path of the directory, enabling the same functionality for path enumeration as if the path was a string.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\exampleDirectory");
    /// 
    /// foreach (var entry in EnumerateFileSystemEntryPaths(pathInfo, "*", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"{entry.Key} is a {entry.Value}");
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths(
        QuickIOPathInfo pathInfo,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None,
        QuickIOPathType pathFormatReturn = QuickIOPathType.Regular)
    {
        return EnumerateFileSystemEntryPaths(
            pathInfo.FullNameUnc,
            pattern,
            searchOption,
            enumerateOptions,
            pathFormatReturn);
    }


    /// <summary>
    /// Enumerates file system entry paths and their types (files or directories) within a specified directory that match a given pattern, with options for recursive searching and path formatting.
    /// </summary>
    /// <param name="uncDirectoryPath">The path of the directory to search within.</param>
    /// <param name="pattern">The search pattern to match file system entries. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <param name="pathFormatReturn">Specifies the format of the paths returned. Defaults to <see cref="QuickIOPathType.Regular"/>.</param>
    /// <returns>An <see cref="IEnumerable{KeyValuePair{String, QuickIOFileSystemEntryType}}"/> containing pairs of paths and their corresponding file system entry types.</returns>
    /// <remarks>
    /// This method uses the native Windows API to enumerate file system entries and yields a sequence of <see cref="KeyValuePair{String, QuickIOFileSystemEntryType}"/> objects.
    /// It supports recursive searching when <see cref="SearchOption.AllDirectories"/> is specified and formats paths according to the <see cref="pathFormatReturn"/> parameter.
    /// If the handle is invalid, it checks the error code and either maps the exception or suppresses it based on the <see cref="enumerateOptions"/>.
    /// </remarks>
    /// <example>
    /// <code>
    /// string directoryPath = @"C:\exampleDirectory";
    /// 
    /// foreach (var entry in EnumerateFileSystemEntryPaths(directoryPath, "*", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"{entry.Key} is a {entry.Value}");
    /// }
    /// </code>
    /// </example>
    private static IEnumerable<KeyValuePair<string, QuickIOFileSystemEntryType>> EnumerateFileSystemEntryPaths(
        string uncDirectoryPath,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None,
        QuickIOPathType pathFormatReturn = QuickIOPathType.Regular)
    {
        string currentPath = QuickIOPath.Combine(uncDirectoryPath, pattern);

        Win32FindData win32FindData = new();
        using Win32FileHandle fileHandle = FindFirstSafeFileHandle(currentPath, win32FindData, out int win32Error);

        // Handle invalid file handles
        if (fileHandle.IsInvalid)
        {
            if (win32Error != Win32ErrorCodes.ERROR_NO_MORE_FILES)
            {
                InternalQuickIOCommon.NativeExceptionMapping(uncDirectoryPath, win32Error);
            }

            if (EnumerationHandleInvalidFileHandle(uncDirectoryPath, enumerateOptions, win32Error))
            {
                yield return new KeyValuePair<string, QuickIOFileSystemEntryType>();
            }
        }

        do
        {
            if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                continue;
            }

            string resultPath = QuickIOPath.Combine(uncDirectoryPath, win32FindData.cFileName);

            if (InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
            {
                yield return new KeyValuePair<string, QuickIOFileSystemEntryType>(FormatPathByType(pathFormatReturn, resultPath), QuickIOFileSystemEntryType.Directory);

                // Recursively search subdirectories
                if (searchOption == SearchOption.AllDirectories)
                {
                    foreach (KeyValuePair<string, QuickIOFileSystemEntryType> match in EnumerateFileSystemEntryPaths(resultPath, pattern, searchOption, enumerateOptions, pathFormatReturn))
                    {
                        yield return match;
                    }
                }
            }
            else
            {
                yield return new KeyValuePair<string, QuickIOFileSystemEntryType>(FormatPathByType(pathFormatReturn, resultPath), QuickIOFileSystemEntryType.File);
            }

            win32FindData = new Win32FindData();
        }
        while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
    }


    /// <summary>
    /// Enumerates directory paths in a specified directory that match a given pattern, with options for recursive searching and path formatting.
    /// </summary>
    /// <param name="path">The path of the directory to search within.</param>
    /// <param name="pattern">The search pattern to match directories. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <param name="pathFormatReturn">Specifies the format of the paths returned. Defaults to <see cref="QuickIOPathType.Regular"/>.</param>
    /// <returns>An <see cref="IEnumerable{String}"/> containing the directory paths that match the specified criteria.</returns>
    /// <remarks>
    /// This method uses the <see cref="FindPaths"/> method to find directories that match the given pattern and options.
    /// It supports recursive searching when <see cref="SearchOption.AllDirectories"/> is specified and formats paths according to the <see cref="pathFormatReturn"/> parameter.
    /// </remarks>
    /// <example>
    /// <code>
    /// string directoryPath = @"C:\exampleDirectory";
    /// 
    /// foreach (string dirPath in EnumerateDirectoryPaths(directoryPath, "*", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"Directory found: {dirPath}");
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<string> EnumerateDirectoryPaths(
        string path,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None,
        QuickIOPathType pathFormatReturn = QuickIOPathType.Regular)
    {
        return FindPaths(path, pattern, searchOption, QuickIOFileSystemEntryType.Directory, enumerateOptions, pathFormatReturn);
    }


    /// <summary>
    /// Enumerates files in the directory specified by the <see cref="QuickIOPathInfo"/> object that match a given pattern, with options for recursive searching.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the directory to search within.</param>
    /// <param name="pattern">The search pattern to match files. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>An <see cref="IEnumerable{QuickIOFileInfo}"/> containing file information objects that match the specified criteria.</returns>
    /// <remarks>
    /// This method delegates the actual file enumeration to the <see cref="EnumerateFiles"/> method that operates on UNC paths.
    /// It provides a convenient way to enumerate files using a <see cref="QuickIOPathInfo"/> object.
    /// </remarks>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo(@"C:\exampleDirectory");
    /// 
    /// foreach (QuickIOFileInfo fileInfo in EnumerateFiles(pathInfo, "*.txt", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"File found: {fileInfo.FullName}");
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<QuickIOFileInfo> EnumerateFiles(
        QuickIOPathInfo pathInfo,
        string pattern = QuickIOPatternConstants.All,
        SearchOption searchOption = SearchOption.TopDirectoryOnly,
        QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return EnumerateFiles(pathInfo.FullNameUnc, pattern, searchOption, enumerateOptions);
    }


    /// <summary>
    /// Retrieves a handle to the first file or directory that matches the specified path, and provides the associated file data.
    /// </summary>
    /// <param name="uncPath">The path of the file or directory to search for. Can include wildcards for pattern matching.</param>
    /// <param name="win32FindData">An output parameter that will be populated with information about the found file or directory.</param>
    /// <param name="win32Error">An output parameter that will be populated with the last Win32 error code.</param>
    /// <returns>A <see cref="Win32FileHandle"/> that represents the handle to the found file or directory. If no file is found, the handle is invalid.</returns>
    /// <remarks>
    /// This method calls the native Windows API function <see cref="Win32SafeNativeMethods.FindFirstFile"/> to obtain a handle to the first matching file or directory.
    /// The handle should be used in conjunction with <see cref="Win32SafeNativeMethods.FindNextFile"/> and should be properly closed after use.
    /// </remarks>
    /// <example>
    /// <code>
    /// Win32FindData findData = new Win32FindData();
    /// int errorCode;
    /// using (Win32FileHandle handle = FindFirstFileManaged(@"C:\exampleDirectory\*.txt", findData, out errorCode))
    /// {
    ///     if (!handle.IsInvalid)
    ///     {
    ///         do
    ///         {
    ///             Console.WriteLine($"Found file: {findData.cFileName}");
    ///         }
    ///         while (Win32SafeNativeMethods.FindNextFile(handle, findData));
    ///     }
    ///     else
    ///     {
    ///         Console.WriteLine($"Error: {errorCode}");
    ///     }
    /// }
    /// </code>
    /// </example>
    private static Win32FileHandle FindFirstFileManaged(string uncPath, Win32FindData win32FindData, out int win32Error)
    {
        Win32FileHandle handle = Win32SafeNativeMethods.FindFirstFile(uncPath, win32FindData);
        win32Error = Marshal.GetLastWin32Error();
        return handle;
    }


    /// <summary>
    /// Enumerates files in a specified directory that match a given pattern, with options for recursive searching.
    /// </summary>
    /// <param name="uncDirectoryPath">The UNC path of the directory to search within.</param>
    /// <param name="pattern">The search pattern to match files. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>An <see cref="IEnumerable{QuickIOFileInfo}"/> containing file information objects that match the specified criteria.</returns>
    /// <remarks>
    /// This method uses a managed file handle to search for files and yields <see cref="QuickIOFileInfo"/> objects that match the pattern.
    /// It supports recursive searching when <see cref="SearchOption.AllDirectories"/> is specified.
    /// </remarks>
    /// <example>
    /// <code>
    /// string directoryPath = @"C:\exampleDirectory";
    /// 
    /// foreach (QuickIOFileInfo fileInfo in EnumerateFiles(directoryPath, "*.txt", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine($"File found: {fileInfo.FullName}");
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<QuickIOFileInfo> EnumerateFiles(string uncDirectoryPath, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        // Match for start of search
        string currentPath = QuickIOPath.Combine( uncDirectoryPath, pattern );


        Win32FindData win32FindData = new( );
        using Win32FileHandle fileHandle = FindFirstFileManaged(currentPath, win32FindData, out int win32Error);

        if (fileHandle.IsInvalid && EnumerationHandleInvalidFileHandle(uncDirectoryPath, enumerateOptions, win32Error))
        {
            yield break;
        }

        do
        {
            if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
            {
                continue;
            }

            string resultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

            if (!InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
            {
                yield return new QuickIOFileInfo(resultPath, win32FindData);
            }
            else
            {
                // SubFolders?!
                if (searchOption == SearchOption.AllDirectories)
                {
                    foreach (QuickIOFileInfo match in EnumerateFiles(resultPath, pattern, searchOption, enumerateOptions))
                    {
                        yield return match;
                    }
                }
            }
            win32FindData = new Win32FindData();
        }
        while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
    }

    /// <summary>
    /// Enumerates file paths in a specified directory that match a given pattern, with options for recursive searching and path formatting.
    /// </summary>
    /// <param name="path">The path of the directory to search within.</param>
    /// <param name="pattern">The search pattern to match files. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <param name="pathFormatReturn">Specifies the format of the paths returned. Defaults to <see cref="QuickIOPathType.Regular"/>.</param>
    /// <returns>An <see cref="IEnumerable{String}"/> containing the file paths that match the specified criteria.</returns>
    /// <example>
    /// <code>
    /// string directoryPath = @"C:\exampleDirectory";
    /// 
    /// foreach (string filePath in EnumerateFilePaths(directoryPath, "*.txt", SearchOption.AllDirectories))
    /// {
    ///     Console.WriteLine(filePath);
    /// }
    /// </code>
    /// </example>
    internal static IEnumerable<string> EnumerateFilePaths(string path, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular)
    {
        return FindPaths(path, pattern, searchOption, QuickIOFileSystemEntryType.File, enumerateOptions, pathFormatReturn);
    }

    /// <summary>
    /// Loads a file information object from the specified path information if the path corresponds to a file.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the path to be loaded as a file.</param>
    /// <returns>A <see cref="QuickIOFileInfo"/> object containing information about the file.</returns>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Thrown if the path does not correspond to a file but to a different type of file system entry.</exception>
    /// <exception cref="PathNotFoundException">Thrown if the path does not exist.</exception>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\exampleFile.txt");
    /// 
    /// try
    /// {
    ///     QuickIOFileInfo fileInfo = LoadFileFromPathInfo(pathInfo);
    ///     Console.WriteLine($"File loaded: {fileInfo.FullName}");
    /// }
    /// catch (Exception ex)
    /// {
    ///     Console.WriteLine($"Error: {ex.Message}");
    /// }
    /// </code>
    /// </example>
    public static QuickIOFileInfo LoadFileFromPathInfo(QuickIOPathInfo pathInfo)
    {
        if (TryGetFindDataFromPath(pathInfo, out Win32FindData? findData))
        {
            if (InternalQuickIOCommon.DetermineFileSystemEntry(findData) == QuickIOFileSystemEntryType.File)
            {
                return new QuickIOFileInfo(pathInfo, findData);
            }
            throw new UnmatchedFileSystemEntryTypeException(QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, pathInfo.FullName);
        }

        throw new PathNotFoundException(pathInfo.FullName);
    }

    /// <summary>
    /// Loads a directory information object from the specified path information if the path corresponds to a directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the path to be loaded as a directory.</param>
    /// <returns>A <see cref="QuickIODirectoryInfo"/> object containing information about the directory.</returns>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Thrown if the path does not correspond to a directory but to a different type of file system entry.</exception>
    /// <exception cref="PathNotFoundException">Thrown if the path does not exist.</exception>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\exampleDirectory");
    /// 
    /// try
    /// {
    ///     QuickIODirectoryInfo directoryInfo = LoadDirectoryFromPathInfo(pathInfo);
    ///     Console.WriteLine($"Directory loaded: {directoryInfo.FullName}");
    /// }
    /// catch (Exception ex)
    /// {
    ///     Console.WriteLine($"Error: {ex.Message}");
    /// }
    /// </code>
    /// </example>
    public static QuickIODirectoryInfo LoadDirectoryFromPathInfo(QuickIOPathInfo pathInfo)
    {
        if (TryGetFindDataFromPath(pathInfo, out Win32FindData? findData))
        {
            if (InternalQuickIOCommon.DetermineFileSystemEntry(findData) == QuickIOFileSystemEntryType.Directory)
            {
                return new QuickIODirectoryInfo(pathInfo, findData);
            }

            throw new UnmatchedFileSystemEntryTypeException(
                QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, pathInfo.FullName);
        }

        throw new PathNotFoundException(pathInfo.FullName);
    }

    /// <summary>
    /// Searches for files and directories in a specified directory that match a given pattern and filter type, with support for recursive searching.
    /// </summary>
    /// <param name="uncDirectoryPath">The UNC path of the directory to search within.</param>
    /// <param name="pattern">The search pattern to match files and directories. Defaults to <see cref="QuickIOPatternConstants.All"/>.</param>
    /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <param name="filterType">The type of file system entries to include in the results. If <c>null</c>, includes all types.</param>
    /// <param name="enumerateOptions">Options to control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <param name="pathFormatReturn">Specifies the format of the paths returned. Defaults to <see cref="QuickIOPathType.Regular"/>.</param>
    /// <returns>A list of paths that match the specified criteria.</returns>
    /// <example>
    /// <code>
    /// string directoryPath = @"\\server\share\folder";
    /// string searchPattern = "*.txt";
    /// QuickIOFileSystemEntryType filter = QuickIOFileSystemEntryType.File;
    /// 
    /// List<string> files = FindPaths(directoryPath, searchPattern, SearchOption.AllDirectories, filter);
    /// 
    /// foreach (string file in files)
    /// {
    ///     Console.WriteLine(file);
    /// }
    /// </code>
    /// </example>
    private static List<string> FindPaths(string uncDirectoryPath, string pattern = QuickIOPatternConstants.All, SearchOption searchOption = SearchOption.TopDirectoryOnly, QuickIOFileSystemEntryType? filterType = null, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None, QuickIOPathType pathFormatReturn = QuickIOPathType.Regular)
    {
        List<string> results = [];
        string currentPath = QuickIOPath.Combine( uncDirectoryPath, pattern );

        Win32FindData win32FindData = new( );
        using (Win32FileHandle fileHandle = FindFirstSafeFileHandle(currentPath, win32FindData, out int win32Error))
        {
            if (fileHandle.IsInvalid && EnumerationHandleInvalidFileHandle(uncDirectoryPath, enumerateOptions, win32Error))
            {
                return [];
            }

            do
            {
                if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
                {
                    continue;
                }

                string resultPath = QuickIOPath.Combine( uncDirectoryPath, win32FindData.cFileName );

                // if it's a file, add to the collection
                if (!InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
                {
                    if (filterType != null && ((QuickIOFileSystemEntryType)filterType == QuickIOFileSystemEntryType.File))
                    {
                        results.Add(FormatPathByType(pathFormatReturn, resultPath));
                    }
                }
                else
                {
                    if (filterType != null && ((QuickIOFileSystemEntryType)filterType == QuickIOFileSystemEntryType.Directory))
                    {
                        results.Add(FormatPathByType(pathFormatReturn, resultPath));
                    }

                    if (searchOption == SearchOption.AllDirectories)
                    {
                        List<string> r = new( FindPaths( resultPath, pattern, searchOption, filterType, enumerateOptions ) );
                        if (r.Count > 0)
                        {
                            results.AddRange(r);
                        }

                    }
                }
                win32FindData = new Win32FindData();
            }
            while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
        }

        return results;
    }

    /// <summary>
    /// Handles errors related to invalid file handles during enumeration, and determines whether to suppress exceptions based on the enumeration options.
    /// </summary>
    /// <param name="path">The path associated with the file handle error.</param>
    /// <param name="enumerateOptions">Options specifying how to handle errors during enumeration.</param>
    /// <param name="win32Error">The Win32 error code associated with the invalid file handle.</param>
    /// <returns><c>true</c> if exceptions are suppressed and handled successfully; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// string path = @"C:\\example.txt";
    /// QuickIOEnumerateOptions options = QuickIOEnumerateOptions.SuppressAllExceptions;
    /// int errorCode = 1234; // Example Win32 error code
    /// 
    /// bool handled = EnumerationHandleInvalidFileHandle(path, options, errorCode);
    /// 
    /// Console.WriteLine($"Exception handled: {handled}");
    /// </code>
    /// </example>
    private static bool EnumerationHandleInvalidFileHandle(string path, QuickIOEnumerateOptions enumerateOptions, int win32Error)
    {
        try
        {
            InternalQuickIOCommon.NativeExceptionMapping(path, win32Error);
        }
        catch (Exception)
        {
            if ((enumerateOptions & QuickIOEnumerateOptions.SuppressAllExceptions) == QuickIOEnumerateOptions.SuppressAllExceptions)
            {
                return true;
            }

            throw;
        }
        return false;
    }


    /// <summary>
    /// Formats a path based on the specified path type, converting it to a regular path if required.
    /// </summary>
    /// <param name="pathFormatReturn">The type of path format to return. If <see cref="QuickIOPathType.Regular"/>, converts to a regular path.</param>
    /// <param name="uncPath">The UNC path to be formatted.</param>
    /// <returns>The formatted path as a string. Returns the original path if no formatting is needed.</returns>
    /// <example>
    /// <code>
    /// string uncPath = @"\\server\share\example.txt";
    /// QuickIOPathType formatType = QuickIOPathType.Regular;
    /// 
    /// string formattedPath = FormatPathByType(formatType, uncPath);
    /// 
    /// Console.WriteLine($"Formatted path: {formattedPath}");
    /// </code>
    /// </example>
    private static string FormatPathByType(QuickIOPathType pathFormatReturn, string uncPath)
    {
        return pathFormatReturn == QuickIOPathType.Regular ? QuickIOPath.ToRegularPath(uncPath) : uncPath;
    }


    /// <summary>
    /// Retrieves the file or directory attributes for the specified UNC path.
    /// </summary>
    /// <param name="uncPath">The UNC path of the file or directory for which to retrieve the attributes.</param>
    /// <returns>The attributes of the file or directory as a <see cref="FileAttributes"/> value.</returns>
    /// <example>
    /// <code>
    /// string uncPath = @"\\server\share\example.txt";
    /// 
    /// FileAttributes attributes = GetAttributes(uncPath);
    /// 
    /// Console.WriteLine($"File attributes: {attributes}");
    /// </code>
    /// </example>
    internal static FileAttributes GetAttributes(string uncPath)
    {
        uint attrs = SafeGetAttributes(uncPath, out int win32Error);
        InternalQuickIOCommon.NativeExceptionMapping(uncPath, win32Error);

        return (FileAttributes)attrs;
    }


    /// <summary>
    /// Asynchronously sets the attributes for the specified file or directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the attributes.</param>
    /// <param name="attributes">The attributes to set for the file or directory.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example\\file.txt");
    /// FileAttributes attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
    /// await InternalQuickIO.SetAttributesAsync(pathInfo, attributes);
    /// </code>
    /// </example>
    internal static uint SafeGetAttributes(string uncPath, out int win32Error)
    {
        uint attributes = Win32SafeNativeMethods.GetFileAttributes( uncPath );
        win32Error = (attributes) == 0xffffffff ? Marshal.GetLastWin32Error() : 0;
        return attributes;
    }

    /// <summary>
    /// Sets the file or directory attributes for the specified path information object.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the attributes.</param>
    /// <param name="attributes">The attributes to set for the file or directory.</param>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example.txt");
    /// FileAttributes newAttributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
    /// 
    /// SetAttributes(pathInfo, newAttributes);
    /// 
    /// Console.WriteLine("File attributes updated successfully.");
    /// </code>
    /// </example>
    public static void SetAttributes(QuickIOPathInfo pathInfo, FileAttributes attributes)
    {
        SetAttributes(pathInfo.FullNameUnc, attributes);
    }


    /// <summary>
    /// Sets the file or directory attributes for the specified path.
    /// </summary>
    /// <param name="path">The full path of the file or directory for which to set the attributes.</param>
    /// <param name="attributes">The attributes to set for the file or directory.</param>
    /// <example>
    /// <code>
    /// string filePath = "C:\\example.txt";
    /// FileAttributes newAttributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
    /// 
    /// SetAttributes(filePath, newAttributes);
    /// 
    /// Console.WriteLine("File attributes updated successfully.");
    /// </code>
    /// </example>
    public static void SetAttributes(string path, FileAttributes attributes)
    {
        if (!Win32SafeNativeMethods.SetFileAttributes(path, (uint)attributes))
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(path, win32Error);
        }
    }


    /// <summary>
    /// Asynchronously sets the attributes for the specified file or directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the attributes.</param>
    /// <param name="attributes">The attributes to set for the file or directory.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example\\file.txt");
    /// FileAttributes attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
    /// await InternalQuickIO.SetAttributesAsync(pathInfo, attributes);
    /// </code>
    /// </example>
    public static Task SetAttributesAsync(QuickIOPathInfo pathInfo, FileAttributes attributes)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => SetAttributes(pathInfo, attributes));
    }

    /// <summary>
    /// Copies a file from a source path to a target path, with an option to overwrite the file if it already exists.
    /// </summary>
    /// <param name="sourceFilePath">The full path of the file to be copied.</param>
    /// <param name="targetFilePath">The full path where the file will be copied to.</param>
    /// <param name="win32Error">An output parameter that contains the Win32 error code if the copy operation fails, or 0 if it succeeds.</param>
    /// <param name="overwrite">A flag indicating whether to overwrite the target file if it already exists. Defaults to <c>false</c>.</param>
    /// <returns><c>true</c> if the file was copied successfully; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// string sourcePath = "C:\\source\\example.txt";
    /// string targetPath = "C:\\destination\\example.txt";
    /// 
    /// bool success = CopyFile(sourcePath, targetPath, out int errorCode, overwrite: true);
    /// 
    /// if (!success)
    /// {
    ///     Console.WriteLine($"File copy failed with error code: {errorCode}");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("File copied successfully.");
    /// }
    /// </code>
    /// </example>
    public static bool CopyFile(string sourceFilePath, string targetFilePath, out int win32Error, bool overwrite = false)
    {
        bool failOnExists = !overwrite;

        bool result = Win32SafeNativeMethods.CopyFile(sourceFilePath, targetFilePath, failOnExists);
        win32Error = !result ? Marshal.GetLastWin32Error() : 0;
        return result;
    }


    /// <summary>
    /// Retrieves statistics for the specified directory, including the total number of files, subdirectories, and their cumulative sizes.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the directory for which to retrieve statistics.</param>
    /// <param name="enumerateOptions">Options to control how the directory is enumerated. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>A <see cref="QuickIOFolderStatisticResult"/> object containing the directory statistics, or <c>null</c> if the directory does not exist or cannot be accessed.</returns>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\exampleDirectory");
    /// QuickIOFolderStatisticResult? stats = GetDirectoryStatistics(pathInfo);
    /// 
    /// if (stats is not null)
    /// {
    ///     Console.WriteLine($"Total files: {stats.FileCount}");
    ///     Console.WriteLine($"Total directories: {stats.DirectoryCount}");
    ///     Console.WriteLine($"Total size: {stats.TotalSize} bytes");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Directory statistics could not be retrieved.");
    /// }
    /// </code>
    /// </example>
    public static QuickIOFolderStatisticResult? GetDirectoryStatistics(
        QuickIOPathInfo pathInfo, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        return GetDirectoryStatistics(pathInfo.FullNameUnc, enumerateOptions);
    }


    /// <summary>
    /// Retrieves information about the disk space available on a specified drive.
    /// </summary>
    /// <param name="rootPath">The root path of the drive for which to retrieve disk information.</param>
    /// <returns>A <see cref="QuickIODiskInformation"/> object containing information about the free space, total space, and total free space on the drive.</returns>
    /// <example>
    /// <code>
    /// string driveRoot = "C:\\";
    /// QuickIODiskInformation diskInfo = GetDiskInformation(driveRoot);
    /// 
    /// Console.WriteLine($"Free space: {diskInfo.FreeBytes} bytes");
    /// Console.WriteLine($"Total space: {diskInfo.TotalBytes} bytes");
    /// Console.WriteLine($"Total free space: {diskInfo.TotalFreeBytes} bytes");
    /// </code>
    /// </example>
    public static QuickIODiskInformation GetDiskInformation(string rootPath)
    {
        if (!Win32SafeNativeMethods.GetDiskFreeSpaceEx(
            rootPath, out ulong freeBytes, out ulong totalBytes, out ulong totalFreeBytes))
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(rootPath, win32Error);
        }

        return new QuickIODiskInformation(freeBytes, totalBytes, totalFreeBytes);
    }




    /// <summary>
    /// Moves a file from a source path to a destination path.
    /// </summary>
    /// <param name="sourceFileName">The full path of the file to be moved.</param>
    /// <param name="destFileName">The full path of the destination where the file will be moved.</param>
    /// <example>
    /// <code>
    /// string sourceFile = "C:\\source\\example.txt";
    /// string destinationFile = "C:\\destination\\example.txt";
    /// 
    /// MoveFile(sourceFile, destinationFile);
    /// </code>
    /// </example>
    public static void MoveFile(string sourceFileName, string destFileName)
    {
        if (!Win32SafeNativeMethods.MoveFile(sourceFileName, destFileName))
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(sourceFileName, win32Error);
        }
    }

    /// <summary>
    /// Retrieves statistics about a directory, including the number of files, folders, and the total size of files within the directory.
    /// </summary>
    /// <param name="path">The path of the directory to analyze.</param>
    /// <param name="enumerateOptions">Options that control the enumeration behavior. Defaults to <see cref="QuickIOEnumerateOptions.None"/>.</param>
    /// <returns>
    /// A <see cref="QuickIOFolderStatisticResult"/> containing the number of files, number of folders, and total size of files, or <c>null</c> if the directory could not be accessed or an error occurred.
    /// </returns>
    /// <remarks>
    /// This method performs a recursive search to calculate the statistics for all files and directories within the specified path. It skips system directories and files. If the directory is empty or cannot be accessed, the method returns a result with zero counts and size.
    /// </remarks>
    /// <exception cref="UnauthorizedAccessException">
    /// Thrown when the current process does not have permission to access the specified path or its contents.
    /// </exception>
    /// <exception cref="PathTooLongException">
    /// Thrown when the specified path exceeds the system-defined maximum length.
    /// </exception>
    public static QuickIOFolderStatisticResult? GetDirectoryStatistics(
        string path, QuickIOEnumerateOptions enumerateOptions = QuickIOEnumerateOptions.None)
    {
        ulong fileCount = 0;
        ulong folderCount = 0;
        ulong totalSize = 0;

        string currentPath = QuickIOPath.Combine(path, QuickIOPatternConstants.All);

        Win32FindData win32FindData = new();
        using (Win32FileHandle fileHandle = FindFirstSafeFileHandle(currentPath, win32FindData, out int win32Error))
        {
            if (fileHandle.IsInvalid)
            {
                if (EnumerationHandleInvalidFileHandle(currentPath, enumerateOptions, win32Error))
                {
                    return null;
                }
            }

            do
            {
                if (InternalRawDataHelpers.IsSystemDirectoryEntry(win32FindData))
                {
                    continue;
                }

                string resultPath = QuickIOPath.Combine(path, win32FindData.cFileName);
                if (!InternalHelpers.ContainsFileAttribute(win32FindData.dwFileAttributes, FileAttributes.Directory))
                {
                    fileCount++;
                    totalSize += win32FindData.CalculateBytes();
                }
                else
                {
                    folderCount++;
                    QuickIOFolderStatisticResult? result = GetDirectoryStatistics(resultPath, enumerateOptions);
                    if (result is not null)
                    {
                        folderCount += result.FolderCount;
                        fileCount += result.FileCount;
                        totalSize += result.TotalBytes;
                    }
                }

                win32FindData = new Win32FindData();
            }
            while (Win32SafeNativeMethods.FindNextFile(fileHandle, win32FindData));
        }

        return new QuickIOFolderStatisticResult(fileCount, folderCount, totalSize);
    }


    /// <summary>
    /// Sets the creation time, last access time, and last write time, in Coordinated Universal Time (UTC), for the specified file or directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the file times.</param>
    /// <param name="creationTimeUtc">The UTC time to set as the creation time.</param>
    /// <param name="lastAccessTimeUtc">The UTC time to set as the last access time.</param>
    /// <param name="lastWriteTimeUtc">The UTC time to set as the last write time.</param>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example.txt");
    /// DateTime creationTimeUtc = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    /// DateTime lastAccessTimeUtc = DateTime.UtcNow.AddHours(-1);
    /// DateTime lastWriteTimeUtc = DateTime.UtcNow;
    /// 
    /// SetAllFileTimes(pathInfo, creationTimeUtc, lastAccessTimeUtc, lastWriteTimeUtc);
    /// </code>
    /// </example>
    public static void SetAllFileTimes(QuickIOPathInfo pathInfo, DateTime creationTimeUtc, DateTime lastAccessTimeUtc, DateTime lastWriteTimeUtc)
    {
        long longCreateTime = creationTimeUtc.ToFileTime();
        long longAccessTime = lastAccessTimeUtc.ToFileTime();
        long longWriteTime = lastWriteTimeUtc.ToFileTime();

        using SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle(pathInfo.FullNameUnc);
        if (Win32SafeNativeMethods.SetAllFileTimes(fileHandle, ref longCreateTime, ref longAccessTime, ref longWriteTime) == 0)
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
        }
    }

    /// <summary>
    /// Sets the creation time, in Coordinated Universal Time (UTC), for the specified file or directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the creation time.</param>
    /// <param name="utcTime">The UTC time to set as the creation time.</param>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example.txt");
    /// DateTime newCreationTimeUtc = DateTime.UtcNow;
    /// SetCreationTimeUtc(pathInfo, newCreationTimeUtc);
    /// </code>
    /// </example>
    public static void SetCreationTimeUtc(QuickIOPathInfo pathInfo, DateTime utcTime)
    {
        long longTime = utcTime.ToFileTime();
        using SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle(pathInfo.FullNameUnc);

        if (!Win32SafeNativeMethods.SetCreationFileTime(fileHandle, ref longTime, IntPtr.Zero, IntPtr.Zero))
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
        }
    }


    /// <summary>
    /// Sets the last write time, in Coordinated Universal Time (UTC), for the specified file or directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the last write time.</param>
    /// <param name="utcTime">The UTC time to set as the last write time.</param>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example.txt");
    /// DateTime newWriteTimeUtc = DateTime.UtcNow;
    /// SetLastWriteTimeUtc(pathInfo, newWriteTimeUtc);
    /// </code>
    /// </example>
    public static void SetLastWriteTimeUtc(QuickIOPathInfo pathInfo, DateTime utcTime)
    {
        long longTime = utcTime.ToFileTime();
        using SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle(pathInfo.FullNameUnc);
        if (!Win32SafeNativeMethods.SetLastWriteFileTime(fileHandle, IntPtr.Zero, IntPtr.Zero, ref longTime))
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
        }
    }


    /// <summary>
    /// Sets the last access time, in Coordinated Universal Time (UTC), for the specified file or directory.
    /// </summary>
    /// <param name="pathInfo">An object containing information about the file or directory for which to set the last access time.</param>
    /// <param name="utcTime">The UTC time to set as the last access time.</param>
    /// <example>
    /// <code>
    /// QuickIOPathInfo pathInfo = new QuickIOPathInfo("C:\\example.txt");
    /// DateTime newAccessTimeUtc = DateTime.UtcNow;
    /// SetLastAccessTimeUtc(pathInfo, newAccessTimeUtc);
    /// </code>
    /// </example>
    public static void SetLastAccessTimeUtc(QuickIOPathInfo pathInfo, DateTime utcTime)
    {
        long longTime = utcTime.ToFileTime();
        using SafeFileHandle fileHandle = OpenReadWriteFileSystemEntryHandle(pathInfo.FullNameUnc);
        if (!Win32SafeNativeMethods.SetLastAccessFileTime(fileHandle, IntPtr.Zero, ref longTime, IntPtr.Zero))
        {
            int win32Error = Marshal.GetLastWin32Error();
            InternalQuickIOCommon.NativeExceptionMapping(pathInfo.FullName, win32Error);
        }
    }


    /// <summary>
    /// Retrieves information about shared resources on a specified machine.
    /// </summary>
    /// <param name="machineName">The name of the machine on which the shared resources are being enumerated.</param>
    /// <param name="level">The level of information to be retrieved about the shared resources.</param>
    /// <param name="buffer">A pointer to the buffer that receives the information about the shared resources.</param>
    /// <param name="entriesRead">The number of entries that have been read and are available in the buffer.</param>
    /// <param name="totalEntries">The total number of entries available for reading.</param>
    /// <param name="resumeHandle">A handle to resume the enumeration if it was previously incomplete.</param>
    /// <returns>An integer value indicating the status of the operation. A value of 0 indicates success.</returns>
    /// <example>
    /// <code>
    /// IntPtr buffer = IntPtr.Zero;
    /// int entriesRead = 0;
    /// int totalEntries = 0;
    /// int resumeHandle = 0;
    /// int result = GetShareEnumResult("MachineName", QuickIOShareApiReadLevel.Level1, ref buffer, ref entriesRead, ref totalEntries, ref resumeHandle);
    ///
    /// if (result != 0)
    /// {
    ///     throw new System.Runtime.InteropServices.ExternalException("Failed to enumerate shares", result);
    /// }
    /// // Process the buffer containing share information
    /// </code>
    /// </example>
    public static int GetShareEnumResult(string machineName, QuickIOShareApiReadLevel level, ref IntPtr buffer, ref int entriesRead, ref int totalEntries, ref int resumeHandle)
    {
        return Win32SafeNativeMethods.NetShareEnum(machineName,
            (int)level, out buffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
    }
}
