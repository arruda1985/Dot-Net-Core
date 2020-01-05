using Agatha.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Products.Queries.GetProductList
{

    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductsListQuery, ProductsListViewModel>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            return new ProductsListViewModel
            {
                Products = await _context.Products.ProjectTo<ProductLookupModel>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken)
            };
        }
    }
}
