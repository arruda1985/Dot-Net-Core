using Agatha.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Customers.Queries.GetAllCustomers
{
    public class GetCustomerQueryHandler : MediatR.IRequestHandler<GetCustomerListQuery, CustomersListViewModel>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return new CustomersListViewModel
            {
                Customers = await _context.Customers.ProjectTo<CustomerLookupModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
