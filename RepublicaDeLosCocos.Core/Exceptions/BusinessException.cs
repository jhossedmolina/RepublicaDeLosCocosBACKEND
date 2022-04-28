using System;

namespace RepublicaDeLosCocos.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string message) : base(message) 
        {

        }
    }
}
