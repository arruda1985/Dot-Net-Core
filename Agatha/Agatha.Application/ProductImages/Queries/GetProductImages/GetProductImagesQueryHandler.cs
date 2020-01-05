using Agatha.Application.Exceptions;
using Agatha.Domain.Entities;
using Agatha.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.ProductImages.Queries.GetProductImages
{
    public class GetProductImagesQueryHandler : MediatR.IRequestHandler<GetProductImagesQuery, ProductImagesViewModel>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetProductImagesQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductImagesViewModel> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
        {
            var productImage = _mapper.Map<ProductImagesViewModel>(await _context
                .ProductImages.Where(p => p.Product.Id == request.Product)
                .SingleOrDefaultAsync(cancellationToken));

            if (productImage == null)
            {
                throw new NotFoundException(nameof(Product), request.Product);
            }

            return productImage;
        }
    }
}
