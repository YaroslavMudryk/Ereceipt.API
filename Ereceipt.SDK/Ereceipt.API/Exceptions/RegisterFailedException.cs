using System;
namespace Ereceipt.API.Exceptions
{
    public class RegisterFailedException : Exception
    {
        public RegisterFailedException(string error) : base(error) { }
    }
}