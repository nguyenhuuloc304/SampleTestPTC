using AutoMapper;
using PTC.Product.Application.Commands;
using PTC.Product.Application.Responses;

namespace PTC.Product.Application.Mapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<PTC.Product.Domain.Entities.Product, ProductResponse>().ReverseMap();
            CreateMap<PTC.Product.Domain.Entities.Product, CreateProductCommand>().ReverseMap();
            CreateMap<PTC.Product.Domain.Entities.Product, UpdateProductCommand>().ReverseMap();
            CreateMap<PTC.Product.Domain.Entities.Product, DeleteProductCommand>().ReverseMap();
        }
    }
}
