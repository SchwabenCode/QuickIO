using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchwabenCode.QuickIO.Core;

namespace SchwabenCode.QuickIO.UnitTests.TestClasses
{
    public class TestExceptionClass : QuickIOBaseException
    {
        public TestExceptionClass( string message, string path ) : base( message, path )
        {
        }

        public TestExceptionClass( string message, string path, Exception innerException ) : base( message, path, innerException )
        {
        }
    }
}
