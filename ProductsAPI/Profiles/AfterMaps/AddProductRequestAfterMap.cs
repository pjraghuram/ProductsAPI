using AutoMapper;
using ProductsAPI.DomainModels;
using System;

namespace ProductsAPI.Profiles.AfterMaps
{
    public class AddProductRequestAfterMap: IMappingAction<AddProductRequest, Models.Product>
    {
        public void Process(AddProductRequest source, Models.Product destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
