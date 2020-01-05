using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Images = new HashSet<ProductImage>();
            ProductsSale = new HashSet<ProductSale>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StoreId { get; set; }
        public string Categories { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductSale> ProductsSale { get; set; }
    }
}
