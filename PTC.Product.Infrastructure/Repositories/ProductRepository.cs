using PTC.Product.Domain.Repositories;
using PTC.Product.Infrastructure.Data;
using PTC.Product.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PTC.Product.Infrastructure.Repositories
{
    public class ProductRepository : Repository<PTC.Product.Domain.Entities.Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext)
        {

        }

        public IQueryable<PTC.Product.Domain.Entities.Product> GetAllProducts()
        {
            var dataQuery = _productContext.Products.AsQueryable();
            return dataQuery;
        }
    }
}
