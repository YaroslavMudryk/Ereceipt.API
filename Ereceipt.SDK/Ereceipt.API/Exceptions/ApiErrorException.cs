using System;
namespace Ereceipt.API.Exceptions
{
    public class ApiErrorException : Exception
    {
        public ApiErrorException(string error) : base(error) { }
    }
}