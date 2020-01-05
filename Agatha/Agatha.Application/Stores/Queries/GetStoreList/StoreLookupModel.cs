using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;

namespace Agatha.Application.Stores.Queries.GetStoreList
{
    public class StoreLookupModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Store, StoreLookupModel>();
        }
    }
}