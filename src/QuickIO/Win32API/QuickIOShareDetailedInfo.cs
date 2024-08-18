namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Represents detailed information about a shared resource in the QuickIO library.
/// </summary>
/// <param name="Name">The name of the shared resource.</param>
/// <param name="Type">The type of the shared resource.</param>
/// <param name="Remark">A comment or description associated with the shared resource.</param>
/// <param name="Permissions">The permissions set for the shared resource. Can be null.</param>
/// <param name="MaxUsers">The maximum number of users that can simultaneously access the shared resource. Can be null.</param>
/// <param name="CurrentUsers">The current number of users accessing the shared resource. Can be null.</param>
/// <param name="Path">The local path of the shared resource.</param>
/// <param name="Password">The password required to access the shared resource, if any.</param>
public record class QuickIOShareDetailedInfo(
    string Name,
    QuickIOShareType Type,
    string Remark,
    int? Permissions,
    int? MaxUsers,
    int? CurrentUsers,
    string Path,
    string Password)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QuickIOShareDetailedInfo"/> class 
    /// using a <see cref="Win32ApiShareInfoAdmin"/> structure.
    /// </summary>
    /// <param name="shareInfo">A <see cref="Win32ApiShareInfoAdmin"/> structure containing 
    /// information about the shared resource.</param>
    internal QuickIOShareDetailedInfo(Win32ApiShareInfoAdmin shareInfo)
        : this(
              shareInfo.ShareName,
              shareInfo.ShareType,
              shareInfo.Remark,
              shareInfo.Permissions,
              shareInfo.MaxUsers,
              shareInfo.CurrentUsers,
              shareInfo.Path,
              shareInfo.Password)
    { }
}
