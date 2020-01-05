using Agatha.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Agatha.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string[] ImagesUploading { get; set; }

    }


}
