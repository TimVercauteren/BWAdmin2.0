using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string identifier) : base(string.Format($"Item with identifier \"{identifier}\" was not found"))
        {

        }
    }
}
