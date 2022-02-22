using MediatR;
using PTC.Product.Application.Commands;
using PTC.Product.Application.Mapper;
using PTC.Product.Application.Responses;
using PTC.Product.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PTC.Product.Application.Handlers.CommandHandlers
{
    public class ProductCommandHandler :
        IRequestHandler<CreateProductCommand, ProductResponse>,
        IRequestHandler<UpdateProductCommand, ProductResponse>,
        IRequestHandler<DeleteProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepo;

        public ProductCommandHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<PTC.Product.Domain.Entities.Product>(request);
            if (productEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newProduct = await _productRepo.AddAsync(productEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }

        public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<PTC.Product.Domain.Entities.Product>(request);
            if (productEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            await _productRepo.UpdateAsync(productEntity.Id, productEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(productEntity);
            return productResponse;
        }

        public async Task<ProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id);
            if (product != null)
            {
                await _productRepo.DeleteAsync(product);
            }

            return new ProductResponse();
        }
    }
}
