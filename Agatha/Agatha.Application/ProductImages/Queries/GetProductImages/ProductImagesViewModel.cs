using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Agatha.Application.ProductImages.Queries.GetProductImages
{
    public class ProductImagesViewModel : IHaveCustomMapping
    {
        public ICollection<ProductImage> Images { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ProductImage, ProductImagesViewModel>();
             
        }
    }

    class PermissionsResolver : IValueResolver<Product, ProductImagesViewModel, bool>
    {
        // TODO: inject your services and helper here
        public PermissionsResolver()
        {

        }

        public bool Resolve(Product source, ProductImagesViewModel dest, bool destMember, ResolutionContext context)
        {
            return false;
        }

    }

}
