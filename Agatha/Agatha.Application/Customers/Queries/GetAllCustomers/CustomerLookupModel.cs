using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;

namespace Agatha.Application.Customers.Queries.GetAllCustomers
{
    public class CustomerLookupModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Customer, CustomerLookupModel>();
        }
    }
}