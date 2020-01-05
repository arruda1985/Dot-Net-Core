using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Products.Queries.GetProduct
{
    public class ProductViewModel : IHaveCustomMapping
    {
        public ProductViewModel()
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

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>());
        }

        class PermissionsResolver : IValueResolver<Product, ProductViewModel, bool>
        {
            // TODO: inject your services and helper here
            public PermissionsResolver()
            {

            }

            public bool Resolve(Product source, ProductViewModel dest, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}
