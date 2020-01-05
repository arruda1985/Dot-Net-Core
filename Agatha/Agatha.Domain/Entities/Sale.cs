using System;
using System.Collections.Generic;

namespace Agatha.Domain.Entities
{
    public class Sale
    {
        public Sale()
        {
            ProductsSale = new HashSet<ProductSale>();
        }

        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public ICollection<ProductSale> ProductsSale { get; set; }
    }
}
