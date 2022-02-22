using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Domain.Exceptions
{
    public class NameUniqueException : System.Exception
    {
        public NameUniqueException()
            : base("NAME_UNIQUE")
        {
        }

        public NameUniqueException(string recordName)
            : base($"{recordName}.NAME_UNIQUE")
        {
        }

    }
}
