using AutoMapper;
using ProductsAPI.DomainModels;
using ProductsAPI.Profiles.AfterMaps;
using Models = ProductsAPI.Models;

namespace ProductsAPI.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Models.Product, Product>().ReverseMap();

            CreateMap<UpdateProductRequest, Models.Product>();

            CreateMap<AddProductRequest, Models.Product>().
                AfterMap<AddProductRequestAfterMap>();
        }
    }
}
