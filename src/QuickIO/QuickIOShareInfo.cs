namespace SchwabenCode.QuickIO;

/// <summary>
/// Information about a local share
/// </summary>
public partial class QuickIOShareInfo
{
    /// <summary>
    /// Called by enumeration
    /// </summary>
    /// <param name="server">Servername</param>
    /// <param name="shareName">Name of Share</param>
    /// <param name="shareType">Type of share</param>
    /// <param name="remark">Comment or smth</param>
    internal QuickIOShareInfo(string server, string shareName, QuickIOShareType shareType, string remark)
    {
        if (QuickIOShareType.Special == shareType && "IPC$" == shareName)
        {
            shareType = QuickIOShareType.IPC;
        }

        Server = server;
        ShareName = shareName;
        ShareType = shareType;
        Remark = remark;
    }

    /// <summary>
    /// The name of the computer that this share belongs to
    /// </summary>
    public string Server { get; private set; }

    /// <summary>
    /// QuickIOShareInfo name
    /// </summary>
    public string ShareName { get; private set; }

    /// <summary>
    /// QuickIOShareInfo type
    /// </summary>
    public QuickIOShareType ShareType { get; private set; }

    /// <summary>
    /// Comment
    /// </summary>
    public string Remark { get; private set; }

    /// <summary>
    /// Returns true if this is a file system share
    /// </summary>
    public bool IsFileSystem
    {
        get
        {
            if (ShareType == QuickIOShareType.Disk)
            {
                return true;
            }

            // Handle local special shares like C$
            if (QuickIOShareType.Special == ShareType && !string.IsNullOrEmpty(ShareName))
            {
                return true;
            }

            return false;
        }
    }


    /// <summary>
    /// Returns the path to this share
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return FullName;
    }

    /// <summary>
    /// Returns the path
    /// </summary>
    public string FullName
    {
        get { return string.Format(@"\\{0}\{1}", string.IsNullOrEmpty(Server) ? Environment.MachineName : Server, ShareName); }
    }
}
