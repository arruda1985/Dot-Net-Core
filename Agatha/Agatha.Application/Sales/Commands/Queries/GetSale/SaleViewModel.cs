using Agatha.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Agatha.Application.Sales.Commands.Queries.GetSale
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            ProductsSale = new HashSet<ProductSale>();
        }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public ICollection<ProductSale> ProductsSale { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }

        public static SaleViewModel Create(Sale sale, Customer customer, Address address)
        {
            return
                new SaleViewModel()
                {
                    Created = sale.Created,
                    Status = sale.Status,
                    Customer = customer,
                    Address = address,
                    PaymentMethod = "NA",
                    ProductsSale = sale.ProductsSale
                };
        }
    }
}