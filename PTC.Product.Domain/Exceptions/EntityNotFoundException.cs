using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Domain.Exceptions
{
    public class EntityNotFoundException : System.Exception
    {
        public EntityNotFoundException()
            : base("ENTITY_NOT_FOUND")
        {
        }

        public EntityNotFoundException(string module)
            : base($"{module}.ENTITY_NOT_FOUND")
        {
        }

        public EntityNotFoundException(string entityName, object keyValue)
            : base($"{entityName} not found by key {keyValue}.")
        {
        }

    }
}
