using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Domain.Exceptions
{
    public class UniqueException : System.Exception
    {
        public UniqueException()
            : base("UNIQUE")
        {
        }

        public UniqueException(string recordName)
            : base($"{recordName}.UNIQUE")
        {
        }

    }
}
