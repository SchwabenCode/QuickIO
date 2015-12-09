using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Exception of already running transfer activity
    /// </summary>
    public class QuickIOTransferAlreadyRunningException : Exception
    {
        /// <summary>
        /// Creates a new exception of <see cref="QuickIOTransferAlreadyRunningException"/>
        /// </summary>
        /// <param name="message">The error message</param>
        public QuickIOTransferAlreadyRunningException( string message ) : base( message )
        {

        }
    }
}
