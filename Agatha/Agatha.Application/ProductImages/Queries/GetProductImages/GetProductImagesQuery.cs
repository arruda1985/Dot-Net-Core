using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.ProductImages.Queries.GetProductImages
{
    public class GetProductImagesQuery : IRequest<ProductImagesViewModel>
    {
        public Guid Product { get; set; }
    }
}
