using Agatha.Application.Products.Queries.GetProductList;
using Agatha.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Sales.Commands.Queries.GetSaleList
{
    public class GetSalesQueryHandler : MediatR.IRequestHandler<GetSalesListQuery, SalesListViewModel>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetSalesQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesListViewModel> Handle(GetSalesListQuery request, CancellationToken cancellationToken)
        {
            return new SalesListViewModel
            {
                Sales = await _context.Sales.ProjectTo<SalesDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken)
            };
        }
    }
}
