using Agatha.Application.Exceptions;
using Agatha.Domain.Entities;
using Agatha.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Stores.Queries.GetStore
{
    public class GetStoreQueryHandler : MediatR.IRequestHandler<GetStoreQuery, StoreViewModel>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetStoreQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoreViewModel> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<StoreViewModel>(await _context
                .Stores.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (product == null)
            {
                throw new NotFoundException(nameof(Store), request.Id);
            }

            return product;
        }
    }
}
