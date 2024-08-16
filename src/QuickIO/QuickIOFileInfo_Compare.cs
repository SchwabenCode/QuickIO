namespace SchwabenCode.QuickIO;

public partial class QuickIOFileInfo
{
    /// <summary>
    /// Checks byte length (NOT CONTENTS!)
    /// </summary>
    /// <param name="file">File to compare with</param>
    /// <returns>Returns true if both <see cref="Bytes"/> properties are equal</returns>
    public bool IsEqualByteLength(QuickIOFileInfo file)
    {
        return (Bytes == file.Bytes);
    }
}
