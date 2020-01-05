using Agatha.Domain.Entities;
using Agatha.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.ProductImages.Commands.CreateProductImages
{
    public class CreateProductImagesCommandHandler : IRequestHandler<CreateProductImageCommand, Guid>
    {
        private readonly AgathaDbContext _context;

        public CreateProductImagesCommandHandler(AgathaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var images = new HashSet<ProductImage>
            {
                new ProductImage() { Url = "teste" }
            };

            var entity = new ProductImage
            {
                Product = request.Product,
                Url = request.Url

            };

            _context.ProductImages.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);



            return entity.Id;
        }
    }
}

