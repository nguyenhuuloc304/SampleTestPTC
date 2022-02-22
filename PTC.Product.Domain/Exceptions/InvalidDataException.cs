using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Domain.Exceptions
{
    public class InvalidDataException : System.Exception
    {
        public InvalidDataException()
            : base("DATA_NOT_VALID")
        {
        }

        public InvalidDataException(string invalidFieldName)
            : base($"{invalidFieldName}.DATA_NOT_VALID")
        {
        }

    }
}
