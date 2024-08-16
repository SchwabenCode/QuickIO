using System.Diagnostics.CodeAnalysis;
using SchwabenCode.QuickIO.Internal;

namespace SchwabenCode.QuickIO;

/// <summary>
/// Performs operations for files or directories and path information. 
/// </summary>
public static class QuickIOPath
{
    /// <summary>
    /// Maximum allowed length of a regular path
    /// </summary>
    public const int MaxRegularPathLength = 260;

    /// <summary>
    /// Maximum allowed length of a regular folder path
    /// </summary>
    public const int MaxSimpleDirectoryPathLength = 247;

    /// <summary>
    /// Maximum allowed length of an UNC Path
    /// </summary>
    public const int MaxUncPathLength = 32767;

    /// <summary>
    /// Regular local path prefix
    /// </summary>
    public const string RegularLocalPathPrefix = @"";

    /// <summary>
    /// Path prefix for shares
    /// </summary>
    public const string RegularSharePathPrefix = @"\\";

    /// <summary>
    /// Length of Path prefix for shares
    /// </summary>
    public static readonly int RegularSharePathPrefixLength = RegularSharePathPrefix.Length;

    /// <summary>
    /// UNC prefix for regular paths
    /// </summary>
    public const string UncLocalPathPrefix = @"\\?\";

    /// <summary>
    /// Length of UNC prefix for regular paths
    /// </summary>
    public static readonly int UncLocalPathPrefixLength = UncLocalPathPrefix.Length;

    /// <summary>
    /// UNC prefix for shares
    /// </summary>
    public const string UncSharePathPrefix = @"\\?\UNC\";

    /// <summary>
    /// Length of UNC prefix for shares
    /// </summary>
    public static readonly int UncSharePathPrefixLength = UncSharePathPrefix.Length;

    /// <summary>
    /// Directory Separator Char
    /// </summary>
    public static char DirectorySeparatorChar = System.IO.Path.DirectorySeparatorChar;

    /// <summary>
    /// Checks if path exists
    /// </summary>
    /// <param name="path">Path to check</param>
    /// <returns>True on exists</returns>
    public static bool Exists(string path)
    {
        return InternalQuickIO.Exists(path);
    }

    /// <summary>
    /// Converts unc path to regular path
    /// </summary>
    public static string ToRegularPath(string anyFullname)
    {
        // First: Check for UNC QuickIOShareInfo
        if (anyFullname.StartsWith(QuickIOPath.UncSharePathPrefix))
        {
            return QuickIOPath.ToShareRegularPath(anyFullname); // Convert
        }
        // Check for local UNC usage
        if (anyFullname.StartsWith(QuickIOPath.UncLocalPathPrefix))
        {
            return QuickIOPath.ToLocalRegularPath(anyFullname); // Convert
        }

        return anyFullname;
    }

    /// <summary>
    /// Converts regular path to unc path
    /// </summary>
    public static string ToUncPath(string anyFullname)
    {
        // Check for regular share usage
        if (anyFullname.StartsWith(QuickIOPath.UncSharePathPrefix))
        {
            // it's an unc share, do not edit!
            return anyFullname;
        }
        if (anyFullname.StartsWith(QuickIOPath.UncLocalPathPrefix))
        {
            // it's an unc local, do not edit!
            return anyFullname;
        }

        if (anyFullname.StartsWith(QuickIOPath.RegularSharePathPrefix))
        {
            return QuickIOPath.ToShareUncPath(anyFullname); // Convert
        }
        // ehmm.. must be local regular path
        if (anyFullname.StartsWith(QuickIOPath.RegularLocalPathPrefix))
        {
            return QuickIOPath.ToLocalUncPath(anyFullname); // Convert
        }

        return anyFullname;
    }


    /// <summary>
    /// Converts an unc path to a local regular path
    /// </summary>
    /// <param name="uncLocalPath">Unc Path</param>
    /// <example>\\?\C:\temp\file.txt >> C:\temp\file.txt</example>
    /// <returns>Local Regular Path</returns>
    public static string ToLocalRegularPath(string uncLocalPath)
    {
        return uncLocalPath.Substring(UncLocalPathPrefix.Length);
    }

    /// <summary>
    /// Converts an unc path to a share regular path
    /// </summary>
    /// <param name="uncSharePath">Unc Path</param>
    /// <example>\\?\UNC\server\share >> \\server\share</example>
    /// <returns>QuickIOShareInfo Regular Path</returns>
    public static string ToShareRegularPath(string uncSharePath)
    {
        return RegularSharePathPrefix + uncSharePath.Substring(UncSharePathPrefix.Length);
    }

    /// <summary>
    /// Converts a regular local path to an unc path
    /// </summary>
    /// <param name="regularLocalPath">Regular Path</param>
    /// <example>C:\temp\file.txt >> \\?\C:\temp\file.txt</example>
    /// <returns>Local Unc Path</returns>
    public static string ToLocalUncPath(string regularLocalPath)
    {
        return UncLocalPathPrefix + regularLocalPath;
    }

    /// <summary>
    /// Converts a regular share path to an unc path
    /// </summary>
    /// <param name="regularSharePath">Regular Path</param>
    /// <example>\\server\share\file.txt >> \\?\UNC\server\share\file.txt</example>
    /// <returns>QuickIOShareInfo Unc Path</returns>
    public static string ToShareUncPath(string regularSharePath)
    {
        return UncSharePathPrefix + regularSharePath.Substring(2);
    }

    /// <summary>
    /// Gets name of file or directory
    /// </summary>
    /// <param name="fullName">Path</param>
    /// <returns>Name of file or directory</returns>
    /// <exception cref="InvalidPathException">Path is invalid</exception>
    public static string GetName(string fullName)
    {
        string path = TrimTrailingSepartor( fullName );
        int sepPosition = path.LastIndexOf( Path.DirectorySeparatorChar );

        return sepPosition == -1 ? path : path.Substring(sepPosition + 1);
    }

    /// <summary>
    /// A wrapper for <see cref="Path.GetFullPath(string)"/>
    /// </summary>
    public static string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }

    /// <summary>
    /// A wrapper for <see cref="Path.GetFullPath(string)"/> that returns <see cref="QuickIOPathInfo"/>
    /// </summary>
    public static QuickIOPathInfo GetFullPathInfo(string path)
    {
        return new QuickIOPathInfo(Path.GetFullPath(path));
    }

    /// <summary>
    /// Removes Last <see cref="Path.DirectorySeparatorChar "/>
    /// </summary>
    private static string TrimTrailingSepartor(string path)
    {
        return path.TrimEnd(Path.DirectorySeparatorChar);
    }

    /// <summary>
    /// Returns root from path by given location type
    /// </summary>
    public static string GetRootFromLocalPath(string path, QuickIOPathLocation location)
    {
        switch (location)
        {
            case QuickIOPathLocation.Local:
            {
                return path.Substring(0, 3);
            }
            case QuickIOPathLocation.Share:
            {
                string[] pathElements = path.Substring( 2 ).Split( Path.DirectorySeparatorChar );
                if (pathElements.Length < 2)
                {
                    throw new InvalidPathException(path, "Path is invalid for Location " + location);
                }
                return RegularSharePathPrefix + pathElements[0] + Path.DirectorySeparatorChar + pathElements[1];
            }
        }

        throw new ArgumentException("QuickIOPathLocation " + location + " not supported.");
    }

    /// <summary>
    /// Invalid Chars are: " &lt; &gt; | and all chars lower than ASCII value 32
    /// </summary>
    /// <remarks>Ignores Unix File Systems</remarks>
    /// <param name="path">Path to check</param>
    /// <exception cref="InvalidPathException">If invalid character found</exception>
    public static void ThrowIfPathContainsInvalidChars(string path)
    {
        for (int index = 0; index < path.Length; index++)
        {
            char currentChar = path[ index ];
            if (currentChar < 32 || currentChar == '\"' || currentChar == '<' || currentChar == '>' || currentChar == '|')
            {
                throw new InvalidPathException("Path contains invalid characters", path);
            }
        }
    }

    /// <summary>
    /// Combines given path elements
    /// </summary>
    /// <param name="pathElements">Path elements to combine</param>
    /// <returns>Combined Path</returns>
    public static string Combine(params string[] pathElements)
    {
        if (pathElements == null || pathElements.Length == 0)
        {
            throw new ArgumentNullException(nameof(pathElements), "Cannot be null or empty");
        }

        // Verify not required; System.IO.Path.Combine calls internal path invalid char verifier

        // First Element
        string combinedPath = pathElements[ 0 ];

        // Other elements
        for (int i = 1; i < pathElements.Length; i++)
        {
            string el = pathElements[ i ];

            // Combine
            combinedPath = Path.Combine(combinedPath, el);
        }

        return combinedPath;
    }

    /// <summary>
    /// Returns <see cref="Path.GetRandomFileName"/>
    /// </summary>
    /// <returns><see cref="Path.GetRandomFileName"/></returns>
    public static string GetRandomFileName()
    {
        return Path.GetRandomFileName();
    }

    /// <summary>
    /// Returns <see cref="Path.GetRandomFileName"/> without extension
    /// </summary>
    /// <returns><see cref="Path.GetRandomFileName"/> without extension</returns>
    public static string GetRandomDirectoryName()
    {
        return Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
    }

    /// <summary>
    /// Returns the parent directory path
    ///  </summary>
    /// <param name="fullName">Path to get the parent from</param>
    /// <returns>Parent directory</returns>
    public static string? GetParentPath(string fullName)
    {
        return new QuickIOPathInfo(fullName).ParentFullName;
    }

    /// <summary>
    /// Returns the root directory path
    ///  </summary>
    /// <param name="fullName">Path to get the parent from</param>
    /// <returns>Root directory</returns>
    public static string? GetRoot(string fullName)
    {
        return new QuickIOPathInfo(fullName).RootFullName;
    }


    /// <summary>
    /// Returns true if path is local regular path such as 'C:\folder\folder\file.txt'
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>True if path is local regular path</returns>
    public static bool IsLocalRegularPath(string path)
    {
        return (path.Length >= 3 && char.IsLetter(path[0]) && path[1] == ':' && path[2] == Path.DirectorySeparatorChar);
    }

    /// <summary>
    /// Returns true if path is local UNC path such as '\\?\C:\folder\folder\file.txt'
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>True if path is local UNC path</returns>
    public static bool IsLocalUncPath(string path)
    {
        return (path.Length >= 7 && path[0] == '\\' && path[1] == '\\' && (path[2] == '?' || path[2] == '.') && path[3] == '\\' && IsLocalRegularPath(path.Substring(4)));
    }



    /// <summary>
    /// Returns true if path is share regular path such as '\\server\share\folder\file.txt'
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>True if path is share regular path</returns>
    public static bool IsShareRegularPath(string path)
    {
        if (!path.StartsWith(QuickIOPath.RegularSharePathPrefix))
        {
            return false;
        }
        if (path.StartsWith(QuickIOPath.UncSharePathPrefix))
        {
            return false;
        }

        string[] pathElements = path.Substring( QuickIOPath.RegularSharePathPrefixLength ).Split( '\\' );
        return (pathElements.Length >= 2);
    }

    /// <summary>
    /// Returns true if path is share UNC path such as '\\?\UNC\server\share\folder\file.txt'
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>True if path is share UNC path</returns>
    public static bool IsShareUncPath(string path)
    {
        if (!path.StartsWith(QuickIOPath.UncSharePathPrefix))
        {
            return false;
        }

        string[] pathElements = path.Substring( QuickIOPath.UncSharePathPrefixLength ).Split( '\\' );
        return (pathElements.Length >= 2);
    }

    /// <summary>
    /// Try to parse path
    /// </summary>
    /// <param name="path">Path to parse</param>
    /// <param name="parsePathResult">Result. See <see cref="QuickIOParsePathResult"/></param>
    /// <param name="supportRelativePath">true to support relative path</param>
    /// <returns>True on success. <paramref name="parsePathResult"/> is set.</returns>
    public static bool TryParsePath(string path, [NotNullWhen(true)] out QuickIOParsePathResult? parsePathResult, bool supportRelativePath = true)
    {
        if (QuickIOPath.TryParseLocalRegularPath(path, out parsePathResult))
        {
            return true;
        }

        if (QuickIOPath.TryParseLocalUncPath(path, out parsePathResult))
        {
            return true;
        }
        if (QuickIOPath.TryParseShareRegularPath(path, out parsePathResult))
        {
            return true;
        }
        if (QuickIOPath.TryParseShareUncPath(path, out parsePathResult))
        {
            return true;
        }

        if (supportRelativePath && QuickIOPath.TryParseLocalRegularPath(Path.GetFullPath(path), out parsePathResult))
        {
            return true;
        }

        return false;
    }

    public static QuickIOParsePathResult ParsePath(string path, bool supportRelativePath = true)
    {
        if (!QuickIOPath.TryParsePath(path, out QuickIOParsePathResult? result))
        {
            throw new InvalidPathException(path);
        }

        return result;
    }


    /// <summary>
    /// Returns true if specified <paramref name="path"/> is local regular path and returns result due to <paramref name="parsePathResult"/>
    /// </summary>
    /// <param name="path">Local path to parse</param>
    /// <param name="parsePathResult"><see cref="QuickIOParsePathResult"/></param>
    /// <returns>True if parse succeeded and <paramref name="parsePathResult"/> is filled</returns>
    public static bool TryParseLocalRegularPath(string path, [NotNullWhen(true)] out QuickIOParsePathResult? parsePathResult)
    {
        if (!IsLocalRegularPath(path))
        {
            parsePathResult = null;
            return false;
        }

        parsePathResult = new QuickIOParsePathResult { PathLocation = QuickIOPathLocation.Local, PathType = QuickIOPathType.Regular };

        if (path.Length == 3)
        {
            parsePathResult.IsRoot = true;
            parsePathResult.ParentPath = null;
            parsePathResult.RootPath = null;
            parsePathResult.Name = null;
            parsePathResult.FullNameUnc = QuickIOPath.UncLocalPathPrefix + path;
            parsePathResult.FullName = path;
        }
        else
        {
            parsePathResult.IsRoot = false;
            parsePathResult.FullName = path.TrimEnd(Path.DirectorySeparatorChar);
            parsePathResult.FullNameUnc = QuickIOPath.UncLocalPathPrefix + parsePathResult.FullName;
            parsePathResult.ParentPath = parsePathResult.FullName.Substring(0, parsePathResult.FullName.LastIndexOf(Path.DirectorySeparatorChar));
            parsePathResult.RootPath = path.Substring(0, 3);

            parsePathResult.Name = parsePathResult.FullName.Substring(parsePathResult.FullName.LastIndexOf(Path.DirectorySeparatorChar) + 1);
        }

        return true;
    }

    /// <summary>
    /// Returns true if specified <paramref name="path"/> is local UNC path and returns result due to <paramref name="parsePathResult"/>
    /// </summary>
    /// <param name="path">Local UNC path to parse</param>
    /// <param name="parsePathResult"><see cref="QuickIOParsePathResult"/></param>
    /// <returns>True if parse succeeded and <paramref name="parsePathResult"/> is filled</returns>
    public static bool TryParseLocalUncPath(string path, [NotNullWhen(true)] out QuickIOParsePathResult? parsePathResult)
    {
        if (!IsLocalUncPath(path))
        {
            parsePathResult = null;
            return false;
        }

        parsePathResult = new QuickIOParsePathResult { PathLocation = QuickIOPathLocation.Local, PathType = QuickIOPathType.UNC };

        if (path.Length == 7)
        {
            parsePathResult.IsRoot = true;
            parsePathResult.ParentPath = null;
            parsePathResult.RootPath = null;

            parsePathResult.FullNameUnc = path;
            parsePathResult.FullName = path.Substring(4);
            parsePathResult.Name = null;
        }
        else
        {
            parsePathResult.IsRoot = false;
            parsePathResult.FullNameUnc = path.TrimEnd(Path.DirectorySeparatorChar);
            parsePathResult.FullName = parsePathResult.FullNameUnc.Substring(4);

            parsePathResult.ParentPath = parsePathResult.FullName.Substring(0, parsePathResult.FullName.LastIndexOf(Path.DirectorySeparatorChar));
            parsePathResult.RootPath = path.Substring(4, 3);

            parsePathResult.Name = parsePathResult.FullName.Substring(parsePathResult.FullName.LastIndexOf(Path.DirectorySeparatorChar) + 1);
        }

        return true;
    }

    /// <summary>
    /// Returns true if specified <paramref name="path"/> is share regular path and returns result due to <paramref name="parsePathResult"/>
    /// </summary>
    /// <param name="path">QuickIOShareInfo regular path to parse</param>
    /// <param name="parsePathResult"><see cref="QuickIOParsePathResult"/></param>
    /// <returns>True if parse succeeded and <paramref name="parsePathResult"/> is filled</returns>
    public static bool TryParseShareRegularPath(string path, [NotNullWhen(true)] out QuickIOParsePathResult? parsePathResult)
    {
        if (!IsShareRegularPath(path))
        {
            parsePathResult = null;
            return false;
        }

        parsePathResult = new QuickIOParsePathResult { PathLocation = QuickIOPathLocation.Share, PathType = QuickIOPathType.Regular };

        string cleanedPath = path.TrimEnd( '\\' );

        string[] pathElements = cleanedPath.Substring( QuickIOPath.RegularSharePathPrefixLength ).Split( '\\' );

        string server = pathElements[ 0 ];
        string name = pathElements[ 1 ];

        string rootPath = QuickIOPath.RegularSharePathPrefix + server + @"\" + name;

        string completePath = rootPath;
        for (int i = 2; i < pathElements.Length; i++)
        {
            completePath += "\\" + pathElements[i];
        }

        // set
        parsePathResult.IsRoot = (cleanedPath == rootPath);

        if (parsePathResult.IsRoot)
        {
            parsePathResult.ParentPath = null;
            parsePathResult.RootPath = null;
            parsePathResult.Name = null;
            parsePathResult.FullNameUnc = QuickIOPath.UncSharePathPrefix + server + @"\" + name;
            parsePathResult.FullName = QuickIOPath.RegularSharePathPrefix + server + @"\" + name;
        }
        else
        {
            parsePathResult.FullName = cleanedPath;
            parsePathResult.FullNameUnc = QuickIOPath.UncSharePathPrefix + cleanedPath.Substring(2);
            parsePathResult.ParentPath = completePath.Substring(0, completePath.LastIndexOf(Path.DirectorySeparatorChar));
            parsePathResult.RootPath = rootPath;

            parsePathResult.Name = pathElements[pathElements.Length - 1];
        }

        return true;
    }

    /// <summary>
    /// Returns true if specified <paramref name="path"/> is share UNC path and returns result due to <paramref name="parsePathResult"/>
    /// </summary>
    /// <param name="path">QuickIOShareInfo UNC path to parse</param>
    /// <param name="parsePathResult"><see cref="QuickIOParsePathResult"/></param>
    /// <returns>True if parse succeeded and <paramref name="parsePathResult"/> is filled</returns>
    public static bool TryParseShareUncPath(string path, [NotNullWhen(true)] out QuickIOParsePathResult? parsePathResult)
    {
        if (!IsShareUncPath(path))
        {
            parsePathResult = null;
            return false;
        }

        parsePathResult = new QuickIOParsePathResult { PathLocation = QuickIOPathLocation.Share, PathType = QuickIOPathType.UNC };

        string cleanedPath = path.TrimEnd( '\\' );

        string[] pathElements = cleanedPath.Substring( QuickIOPath.UncSharePathPrefixLength ).Split( '\\' );

        string server = pathElements[ 0 ];
        string name = pathElements[ 1 ];

        string completeRelativePath = server + @"\" + name;
        for (int i = 2; i < pathElements.Length; i++)
        {
            completeRelativePath += "\\" + pathElements[i];
        }

        // set
        parsePathResult.IsRoot = (cleanedPath == (QuickIOPath.UncSharePathPrefix + server + @"\" + name));

        if (parsePathResult.IsRoot)
        {
            parsePathResult.ParentPath = null;
            parsePathResult.RootPath = null;
            parsePathResult.Name = null;
            parsePathResult.FullNameUnc = QuickIOPath.UncSharePathPrefix + server + @"\" + name;
            parsePathResult.FullName = QuickIOPath.RegularSharePathPrefix + server + @"\" + name;
        }
        else
        {
            parsePathResult.FullName = QuickIOPath.RegularSharePathPrefix + completeRelativePath;
            parsePathResult.FullNameUnc = QuickIOPath.UncSharePathPrefix + completeRelativePath;
            parsePathResult.ParentPath = QuickIOPath.RegularSharePathPrefix + completeRelativePath.Substring(0, completeRelativePath.LastIndexOf(Path.DirectorySeparatorChar));
            parsePathResult.RootPath = QuickIOPath.RegularSharePathPrefix + server + @"\" + name;

            parsePathResult.Name = pathElements[pathElements.Length - 1];
        }

        return true;
    }
}
