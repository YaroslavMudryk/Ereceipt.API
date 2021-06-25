using System;
namespace Ereceipt.API.Exceptions
{
    public class AuthFailedException : Exception
    {
        public AuthFailedException(string error) : base(error) { }
    }
}