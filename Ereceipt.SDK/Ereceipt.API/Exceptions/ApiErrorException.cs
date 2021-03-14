using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Exceptions
{
    public class ApiErrorException : Exception
    {
        public ApiErrorException(string error) : base(error)
        {

        }
    }
}