using AutoMapper;
using GreenCloud.Store.Application.Dtos;
using GreenCloud.Store.Entity;

namespace GreenCloud.Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductForListDto>();
            CreateMap<Product, ProductDetailDto>();
            CreateMap<ProductForCreateDto, Product>().ReverseMap();
            CreateMap<ProductForEditDto, Product>().ReverseMap();
        }
    }
}
