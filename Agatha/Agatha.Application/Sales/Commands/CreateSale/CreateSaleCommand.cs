using Agatha.Application.Interfaces;
using Agatha.Application.Models;
using Agatha.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Agatha.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<IDischargeReturn>
    {
        public CreateSaleCommand()
        {
            ProductsSale = new HashSet<ProductSale>();
        }

        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public ICollection<ProductSale> ProductsSale { get; set; }
        public DischargePayment Payment { get; set; }
    }
}