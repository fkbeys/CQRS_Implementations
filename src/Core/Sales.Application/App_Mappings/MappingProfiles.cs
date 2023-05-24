using AutoMapper;

namespace Sales.Application.App_Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            ProductMappingProfile productMappingProfile = new();
        }
    }
}
