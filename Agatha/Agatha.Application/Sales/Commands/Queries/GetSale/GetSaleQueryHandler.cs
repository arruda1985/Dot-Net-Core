using Agatha.Application.Exceptions;
using Agatha.Application.Sales.Commands.Queries.GetSaleList;
using Agatha.Domain.Entities;
using Agatha.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Sales.Commands.Queries.GetSale
{
    public class GetSaleQueryHandler : MediatR.IRequestHandler<GetSaleQuery, SalesDto>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetSaleQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesDto> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var sale = await _context.Sales.Where(s => s.Id == request.Id).FirstAsync();

            if (sale == null)
            {
                throw new NotFoundException(nameof(sale), request.Id);
            }

            return await _context.Sales.ProjectTo<SalesDto>(_mapper.ConfigurationProvider).FirstAsync();

        }

    }
}
