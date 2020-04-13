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
        private readonly ILocalPhotoFileService _localPhotoService;

        public CreateProductCommandHandler(AgathaDbContext context, IAzureService azureService, ILocalPhotoFileService localPhotoService)
        {
            _context = context;
            _azureService = azureService;
            _localPhotoService = localPhotoService;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imgs = new List<ProductImage>();

            if (request.ImagesUploading != null)
                foreach (var image in request.ImagesUploading)
                {

                    //var fileName = await _azureService.UploadImageAsync(new ImageUpload() { Base64Image = image });
                    var fileName = _localPhotoService.Save(new ImageUpload() { Base64Image = image });
                    imgs.Add(new ProductImage()
                    {
                        Url = fileName
                    });
                }

            var entity = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                StoreId = request.StoreId,
                Categories = request.Categories,
                Tags = request.Tags,
                Price = request.Price,
                Quantity = request.Quantity,
                SKU = request.SKU,
                Images = imgs,
                Created = DateTime.Now

            };
            
            if (entity.Id != null)
                _context.Products.Update(entity);
            else
                _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

