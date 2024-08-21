using System.Diagnostics.CodeAnalysis;
using SchwabenCode.QuickIO.Compatibility;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Provides static methods to access files. For example creating, deleting and retrieving content and security information such as the owner.
/// </summary>
public static partial class QuickIOFile
{

    /// <summary>
    /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/> is true
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="targetDirectory">Target directory</param>      
    /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>'s name</param>
    /// <param name="overwrite">true to overwrite existing file</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
    /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
    public static void CopyToDirectory(string sourceFileName, string targetDirectory,
        string? newFileName = null, bool overwrite = false)
    {
        CopyToDirectory(InternalQuickIO.LoadFileFromPathInfo(new QuickIOPathInfo(sourceFileName)), InternalQuickIO.LoadDirectoryFromPathInfo(new QuickIOPathInfo(targetDirectory)), newFileName, overwrite);
    }

    /// <summary>
    /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/> is true
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="targetDirectory">Target directory</param>      
    /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>'s name</param>
    /// <param name="overwrite">true to overwrite existing file</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
    /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
    public static Task CopyToDirectoryAsync(string sourceFileName, string targetDirectory,
        string? newFileName = null, bool overwrite = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => CopyToDirectory(sourceFileName, targetDirectory, newFileName, overwrite));
    }

    /// <summary>
    /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="targetDirectory">Target directory</param>
    /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>' name</param>
    /// <param name="overwrite">true to overwrite existing files</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
    /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
    public static void CopyToDirectory(QuickIOFileInfo sourceFileName, QuickIODirectoryInfo targetDirectory,
        string? newFileName = null, bool overwrite = false)
    {
        string targetFileName = sourceFileName.Name;
        if (!string.IsNullOrEmpty(newFileName))
        {
            // TODO: Check for invalid chars 
            targetFileName = newFileName;
        }

        Copy(sourceFileName.FullNameUnc, QuickIOPath.Combine(targetDirectory.FullNameUnc, targetFileName), overwrite);
    }

    /// <summary>
    /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
    /// </summary>
    /// <param name="sourceFileName">The file to copy.</param>
    /// <param name="targetDirectory">Target directory</param>
    /// <param name="newFileName">New File name. Null or empty to use <paramref name="sourceFileName"/>' name</param>
    /// <param name="overwrite">true to overwrite existing files</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
    /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
    public static Task CopyToDirectoryAsync(QuickIOFileInfo sourceFileName, QuickIODirectoryInfo targetDirectory,
        string? newFileName = null, bool overwrite = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(
            () => CopyToDirectory(sourceFileName, targetDirectory, newFileName, overwrite));
    }

    /// <summary>
    /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
    /// </summary>
    /// <param name="uncSourceFullName">The file to copy.</param>
    /// <param name="uncTargetFullName">Target file</param>      
    /// <param name="overwrite">true to overwrite existing files</param>
    /// <param name="createRecursive">Creates parent path if not exists. Decreases copy performance</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
    /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
    public static void Copy(string uncSourceFullName, string uncTargetFullName, bool overwrite = false, bool createRecursive = true)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(uncSourceFullName);
        ArgumentNullException.ThrowIfNullOrEmpty(uncTargetFullName);

        if (createRecursive)
        {
            string? targetDirectoryPath = QuickIOPath.GetParentPath( uncTargetFullName )
                ?? throw new InvalidPathException("Invalid parent path. Cannot create directory.");

            try
            {
                QuickIODirectory.Create(targetDirectoryPath, true);
            }
            catch (PathAlreadyExistsException)
            {
                // yay ignore this!
            }
        }

        if (!InternalQuickIO.CopyFile(uncSourceFullName, uncTargetFullName, out int win32Error, overwrite))
        {
            InternalQuickIOCommon.NativeExceptionMapping(!Exists(uncSourceFullName) ? uncSourceFullName : uncTargetFullName, win32Error);
        }
    }

    /// <summary>
    /// Copies an existing file. Overwrites an existing file if <paramref name="overwrite"/>  is true
    /// </summary>
    /// <param name="uncSourceFullName">The file to copy.</param>
    /// <param name="uncTargetFullName">Target file</param>      
    /// <param name="overwrite">true to overwrite existing files</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/c6cfw35a(v=vs.110).aspx</remarks>
    /// <exception cref="FileSystemIsBusyException">Filesystem is busy</exception>
    public static Task CopyAsync(string uncSourceFullName, string uncTargetFullName, bool overwrite = false)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Copy(uncSourceFullName, uncTargetFullName, overwrite));
    }


    /// <summary>
    /// Deletes the file. 
    /// </summary>
    /// <param name="path">The fullname of the file to be deleted.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.delete(v=vs.110).aspx</remarks>
    /// <exception cref="FileNotFoundException">File does not exist.</exception>
    public static void Delete(string path)
    {
        Delete(new QuickIOPathInfo(path));
    }
    /// <summary>
    /// Deletes the file. 
    /// </summary>
    /// <param name="path">The fullname of the file to be deleted.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.delete(v=vs.110).aspx</remarks>
    /// <exception cref="FileNotFoundException">File does not exist.</exception>
    public static Task DeleteAsync(string path)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Delete(path));
    }

    /// <summary>
    /// Deletes the file. 
    /// </summary>
    /// <param name="pathInfo">The file to be deleted.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.delete(v=vs.110).aspx</remarks>
    /// <exception cref="FileNotFoundException">File does not exist.</exception>
    public static void Delete(QuickIOPathInfo pathInfo)
    {
        InternalQuickIO.DeleteFile(pathInfo);
    }
    /// <summary>
    /// Deletes the file. 
    /// </summary>
    /// <param name="pathInfo">The file to be deleted.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.delete(v=vs.110).aspx</remarks>
    /// <exception cref="FileNotFoundException">File does not exist.</exception>
    public static Task DeleteAsync(QuickIOPathInfo pathInfo)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Delete(pathInfo));
    }

    /// <summary>
    /// Checks whether the specified file exists.
    /// </summary>
    /// <param name="path">The path to check.</param>
    /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
    /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static bool Exists(string path)
    {
        return InternalFileExists(QuickIOPath.ToUncPath(path));
    }

    /// <summary>
    /// Checks whether the specified file exists.
    /// </summary>
    /// <param name="path">The path to check.</param>
    /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
    /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static Task<bool> ExistsAsync(string path)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => Exists(path));
    }

    /// <summary>
    /// Checks whether the specified file exists.
    /// </summary>
    /// <param name="pathInfo">The the file to check.</param>
    /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
    /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static bool Exists(QuickIOPathInfo pathInfo)
    {
        return InternalFileExists(pathInfo.FullNameUnc);
    }

    /// <summary>
    /// Checks whether the specified file exists.
    /// </summary>
    /// <param name="pathInfo">The the file to check.</param>
    /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
    /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static Task<bool> ExistsAsync(QuickIOPathInfo pathInfo)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => Exists(pathInfo));
    }

    /// <summary>
    /// Checks whether the specified file exists.
    /// </summary>
    /// <param name="fileInfo">The the file to check.</param>
    /// <returns><b>true</b> if the caller has the required permissions and path contains the name of an existing file; otherwise, <b>false</b></returns>
    /// <remarks>The original Exists method returns also false on null! http://msdn.microsoft.com/en-us/library/system.io.file.exists(v=vs.110).aspx</remarks>
    /// <exception cref="UnmatchedFileSystemEntryTypeException">Searched for file but found folder.</exception>
    /// <exception cref="InvalidPathException">Path is invalid.</exception>
    public static bool Exists(QuickIOFileInfo fileInfo)
    {
        return InternalFileExists(fileInfo.FullNameUnc);
    }

    /// <summary>
    /// Moves a specified file to a new location, providing the option to give a new file name.
    /// </summary>
    /// <param name="sourceFileName">The name of the file to move. </param>
    /// <param name="destinationFileName">The new path for the file. Parent directory must exist.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
    public static void Move(string sourceFileName, string destinationFileName)
    {
        InternalQuickIO.MoveFile(sourceFileName, destinationFileName);
    }

    /// <summary>
    /// Moves a specified file to a new location, providing the option to give a new file name.
    /// </summary>
    /// <param name="sourceFileName">The name of the file to move. </param>
    /// <param name="destinationFileName">The new path for the file. Parent directory must exist.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
    public static Task MoveAsync(string sourceFileName, string destinationFileName)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Move(sourceFileName, destinationFileName));
    }

    /// <summary>
    /// Moves a file, providing the option to give a new file name.
    /// </summary>
    /// <param name="sourceFileInfo">The file to move.</param>
    /// <param name="destinationFolder">Target directory to move the file.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
    public static void Move(QuickIOPathInfo sourceFileInfo, QuickIOPathInfo destinationFolder)
    {
        InternalQuickIO.MoveFile(sourceFileInfo.FullNameUnc, Path.Combine(destinationFolder.FullNameUnc, sourceFileInfo.Name));
    }

    /// <summary>
    /// Moves a file, providing the option to give a new file name.
    /// </summary>
    /// <param name="sourceFileInfo">The file to move.</param>
    /// <param name="destinationFolder">Target directory to move the file.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
    public static Task MoveAsync(QuickIOPathInfo sourceFileInfo, QuickIOPathInfo destinationFolder)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Move(sourceFileInfo, destinationFolder));
    }

    /// <summary>
    /// Moves a file, providing the option to give a new file name.
    /// </summary>
    /// <param name="sourceFileInfo">The file to move.</param>
    /// <param name="destinationFolder">Target directory to move the file.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
    public static void Move(QuickIOPathInfo sourceFileInfo, QuickIODirectoryInfo destinationFolder)
    {
        InternalQuickIO.MoveFile(sourceFileInfo.FullNameUnc, Path.Combine(destinationFolder.FullNameUnc, sourceFileInfo.Name));
    }

    /// <summary>
    /// Moves a file, providing the option to give a new file name.
    /// </summary>
    /// <param name="sourceFileInfo">The file to move.</param>
    /// <param name="destinationFolder">Target directory to move the file.</param>
    /// <remarks>http://msdn.microsoft.com/en-us/library/system.io.file.move(v=vs.110).aspx</remarks>
    public static Task MoveAsync(QuickIOPathInfo sourceFileInfo, QuickIODirectoryInfo destinationFolder)
    {
        return NETCompatibility.AsyncExtensions.ExecuteAsync(() => Move(sourceFileInfo, destinationFolder));
    }

    private static bool InternalFileExists([NotNullWhen(true)] string? uncPath)
    {
        if (uncPath is null || uncPath.Length is 0)
        {
            return false;
        }

        uint attrs = InternalQuickIO.SafeGetAttributes( uncPath, out _ );

        if (Equals(attrs, 0xffff_ffff))
        {
            return false;
        }

        if (!InternalHelpers.ContainsFileAttribute(FileAttributes.Directory, (FileAttributes)attrs))
        {
            return true;
        }

        throw new UnmatchedFileSystemEntryTypeException(
            QuickIOFileSystemEntryType.File, QuickIOFileSystemEntryType.Directory, uncPath);
    }
}
