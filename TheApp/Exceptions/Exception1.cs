using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheApp.Exceptions
{
    internal class Exception1 : ApplicationException
    {
        public Exception1(string message)
            : base(message)
        {
        }
    }
}
