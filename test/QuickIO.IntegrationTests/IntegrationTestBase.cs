using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SchwabenCode.QuickIO.IntegrationTests
{
    public abstract class IntegrationTestBase
    {
        public static string CurrentPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
