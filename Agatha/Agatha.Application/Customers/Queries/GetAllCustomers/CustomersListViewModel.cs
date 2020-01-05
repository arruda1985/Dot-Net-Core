using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Agatha.Application.Customers.Queries.GetAllCustomers
{
    public class CustomersListViewModel : IHaveCustomMapping
    {
        public IList<CustomerLookupModel> Customers { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Customer, CustomerLookupModel>();
        }
    }
}