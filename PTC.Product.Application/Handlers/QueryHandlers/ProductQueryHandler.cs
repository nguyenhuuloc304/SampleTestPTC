using MediatR;
using Microsoft.EntityFrameworkCore;
using PTC.Product.Application.Queries;
using PTC.Product.Application.SharedKernel.Paging;
using PTC.Product.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PTC.Product.Application.Handlers.QueryHandlers
{
    public class ProductQueryHandler :
        IRequestHandler<GetAllProductsQuery, PagedQueryResult<PTC.Product.Domain.Entities.Product>>,
        IRequestHandler<GetProductByIdQuery, PTC.Product.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepo;

        public ProductQueryHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<PagedQueryResult<PTC.Product.Domain.Entities.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var dataQueryable = _productRepo.GetAllProducts();
            var data = await dataQueryable.Skip((query.Page - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .ToListAsync();
            var totalItemCount = dataQueryable.Count();

            return new PagedQueryResult<PTC.Product.Domain.Entities.Product>(data, totalItemCount, query.Page, query.PageSize);
        }

        public async Task<PTC.Product.Domain.Entities.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productRepo.GetByIdAsync(query.Id);
        }
    }
}
