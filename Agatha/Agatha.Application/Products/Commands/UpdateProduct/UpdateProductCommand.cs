using MediatR;
using System;

namespace Agatha.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public string Tags { get; set; }
        public Decimal Price { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
    }
}
