using System;
using System.IO;
using System.Reflection;

namespace SchwabenCode.QuickIO.UnitTests
{
    public abstract class UnitTestBase
    {
        public static string CurrentPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
