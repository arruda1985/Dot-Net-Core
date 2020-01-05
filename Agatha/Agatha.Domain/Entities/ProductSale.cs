using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Domain.Entities
{
    public class ProductSale
    {
        public Guid Id { get; set; }
        public Sale Sale { get; set; }
        public Guid ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
