using Agatha.Application.Interfaces.Mapping;
using Agatha.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Agatha.Application.Stores.Queries.GetStore
{
    public class StoreViewModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Store, StoreViewModel>();
        }
    }
}