using Agatha.Application.Interfaces;
using Agatha.Application.ProductImages.Models;
using Agatha.Domain.Entities;
using Agatha.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly AgathaDbContext _context;
        private readonly IAzureService _azureService;

        public CreateProductCommandHandler(AgathaDbContext context, IAzureService azureService)
        {
            _context = context;
            _azureService = azureService;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imgs = new List<ProductImage>();

            foreach (var image in request.ImagesUploading)
            {

                var fileName = await _azureService.UploadImageAsync(new ImageUpload() { Base64Image = image });

                imgs.Add(new ProductImage()
                {
                    Url = fileName
                });
            }

            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                StoreId = Guid.Parse("DF9D2F10-315E-4429-8EE4-1A15A8B9129B"), //TODO tirar loja fixa
                Categories = request.Categories,
                Tags = request.Tags,
                Price = request.Price,
                Quantity = request.Quantity,
                SKU = request.SKU,
                Images = imgs,
                Created = DateTime.Now

            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

