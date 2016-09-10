using System;

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
