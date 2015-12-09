using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchwabenCode.QuickIO
{
    public class QuickIOTransferAlreadyRunningException : Exception
    {
        public QuickIOTransferAlreadyRunningException( string message ) : base( message )
        {

        }
    }
}
