using System;

namespace Agatha.Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }


    }
}
