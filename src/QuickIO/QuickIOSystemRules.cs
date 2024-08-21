using System.Text;

namespace SchwabenCode.QuickIO;

/// <summary>
/// QuickIOSystemRules
/// </summary>
internal static class QuickIOSystemRules
{
    /// <summary>
    /// UTF8Encoding No Emit
    /// </summary>
    public static UTF8Encoding UTF8EncodingNoEmit = new( encoderShouldEmitUTF8Identifier: false );
}
