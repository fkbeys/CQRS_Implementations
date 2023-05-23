using AutoMapper;
using Sales.Application.App_Dto;
using Sales.Domain.Domain_Entities;

namespace Sales.Application.App_Mappings
{
    public class CustomMappingProfiles : Profile
    {
        public CustomMappingProfiles()
        {
            CreateMap<Product, ProductDto>();
        }

    }
}
