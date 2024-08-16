namespace SchwabenCode.QuickIO.Win32API;

/// <summary>
/// Container of detailed share information
/// </summary>
public class QuickIOShareDetailedInfo
{
    /// <summary>
    /// Transfers the struct information to the class
    /// </summary>
    /// <param name="shareInfo">share information</param>
    internal QuickIOShareDetailedInfo(Win32ApiShareInfoAdmin shareInfo)
    {
        Name = shareInfo.ShareName;
        Type = shareInfo.ShareType;
        Remark = shareInfo.Remark;

        Permissions = shareInfo.Permissions;
        MaxUsers = shareInfo.MaxUsers;
        CurrentUsers = shareInfo.CurrentUsers;
        Path = shareInfo.Path;
        Password = shareInfo.Password;
    }

    /// <summary>
    /// Name of Share
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Share Type
    /// </summary>
    public QuickIOShareType Type { get; private set; }

    /// <summary>
    /// Remark / Comment
    /// </summary>
    public string Remark { get; private set; }

    /// <summary>
    /// Permissions. Is null, if admin privileges are not granted.
    /// </summary>
    public int? Permissions { get; private set; }

    /// <summary>
    /// MaxUsers of the parallel connected users. Is null, if admin privileges are not granted.
    /// </summary>
    public int? MaxUsers { get; private set; }

    /// <summary>
    /// CurrentUsers connected to the share. Is null, if admin privileges are not granted.
    /// </summary>
    public int? CurrentUsers { get; private set; }

    /// <summary>
    /// Permissions. Is null, if admin privileges are not granted.
    /// </summary>
    public string Path { get; private set; }

    /// <summary>
    /// Password. Is null, if admin privileges are not granted.
    /// </summary>
    public string Password { get; private set; }
}
