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
            // TODO: DOES ONLY WORK IN VISUAL STUDIO RIGHT KNOW
            // https://github.com/aspnet/dnx/issues/3321
            return Environment.CurrentDirectory;
        }
    }
}
