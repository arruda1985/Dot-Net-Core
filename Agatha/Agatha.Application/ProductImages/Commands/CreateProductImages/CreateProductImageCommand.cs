using Agatha.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Agatha.Application.ProductImages.Commands.CreateProductImages
{
    public class CreateProductImageCommand : IRequest<Guid>
    {
        public Product Product { get; set; }
        public string Url { get; set; }

    }
}
