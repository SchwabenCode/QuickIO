using System.Text.RegularExpressions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_Patterns_Tests
{
    [Fact]
    public void Pattern_ShareRoot_Test()
    {
        // Name
        Assert.True(Regex.IsMatch(@"\\server\share", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern), RegexOptions.IgnoreCase), "1 failed");

        // IP
        Assert.True(Regex.IsMatch(@"\\1:2:3:4:5:6:7:8\share\", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "2 failed");
        Assert.True(Regex.IsMatch(@"\\1080:0:0:0:8:800:200C:417A\share", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "3 failed");
        Assert.True(Regex.IsMatch(@"\\255.255.255.0\share", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "4 failed");
        Assert.True(Regex.IsMatch(@"\\192.168.1.19\share", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "5 failed");
        Assert.True(Regex.IsMatch(@"\\::1\share", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "6 failed");

        Assert.True(Regex.IsMatch(@"\\seRver\share", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "8 failed");
        Assert.True(Regex.IsMatch(@"\\server\share\", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "9 failed");

        Assert.False(Regex.IsMatch(@"\\server", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "10 failed");
        Assert.False(Regex.IsMatch(@"\\server\share\ssd", QuickIOPatterns.GetStrict(QuickIOPatterns.RegularShareRootPattern)), "11 failed");
    }
}
