using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Exceptions
{
    public class AuthFailedException : Exception
    {
        public AuthFailedException(string error) : base(error) { }
    }
}
