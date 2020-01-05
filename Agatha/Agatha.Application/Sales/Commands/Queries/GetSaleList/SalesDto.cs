using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Sales.Commands.Queries.GetSaleList
{
    public class SalesDto : IHaveCustomMapping
    {
        public SalesDto()
        {
            ProductsSale = new HashSet<ProductSale>();
        }

        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public ICollection<ProductSale> ProductsSale { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Sale, SalesDto>();
        }
    }
}
