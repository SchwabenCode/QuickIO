namespace SchwabenCode.QuickIO;

/// <summary>
/// Result of parsing path
/// </summary>
public class QuickIOParsePathResult
{
    /// <summary>
    /// Full root path
    /// </summary>
    /// <example><b>C:\folder\parent\file.txt</b> returns <b>C:\</b></example>
    /// <remarks>Returns null if source path is Root</remarks>
    public string? RootPath { get; internal set; }

    /// <summary>
    /// Full parent path
    /// </summary>
    /// <example><b>C:\folder\parent\file.txt</b> returns <b>C:\folder\parent</b></example>
    /// <remarks>Returns null if source path is Root</remarks>
    public string? ParentPath { get; internal set; }

    /// <summary>
    /// Name of file or directory
    /// </summary>
    /// <example><b>C:\folder\parent\file.txt</b> returns <b>file.txt</b></example>
    /// <example><b>C:\folder\parent</b> returns <b>parent</b></example>
    /// <remarks>Returns null if source path is Root</remarks>
    public string? Name { get; internal set; }

    /// <summary>
    /// True if source path is root
    /// </summary>
    public bool IsRoot { get; internal set; }

    /// <summary>
    /// Full path without trailing directory separtor char
    /// </summary>
    public string FullName { get; internal set; } = null!;

    /// <summary>
    /// Full UNC path without trailing directory separtor char
    /// </summary>
    public string FullNameUnc { get; internal set; } = null!;

    /// <summary>
    /// <see cref="QuickIOPathType"/>
    /// </summary>
    public QuickIOPathType PathType { get; internal set; }

    /// <summary>
    /// <see cref="QuickIOPathLocation"/>
    /// </summary>
    public QuickIOPathLocation PathLocation { get; internal set; }

}
