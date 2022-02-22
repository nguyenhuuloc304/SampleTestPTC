using PTC.Product.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Domain.Repositories
{
    public interface IProductRepository : IRepository<PTC.Product.Domain.Entities.Product>
    {
        IQueryable<PTC.Product.Domain.Entities.Product> GetAllProducts();
    }
}
