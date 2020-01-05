using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Agatha.Application.Products.Queries.GetProductList
{
    public class ProductLookupModel : IHaveCustomMapping
    {
        public ProductLookupModel()
        {
            Images = new HashSet<ProductImage>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Store { get; set; }
        public string Categories { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ProductImage> Images { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductLookupModel>();
        }
    }

}