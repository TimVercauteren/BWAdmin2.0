using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException(string message) : base(message) { }
    }
}
