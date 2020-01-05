using Agatha.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Stores.Queries.GetStoreList
{

    public class GetStoreQueryHandler : MediatR.IRequestHandler<GetStoresListQuery, StoresListViewModel>
    {
        private readonly AgathaDbContext _context;
        private readonly IMapper _mapper;

        public GetStoreQueryHandler(AgathaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoresListViewModel> Handle(GetStoresListQuery request, CancellationToken cancellationToken)
        {
            return new StoresListViewModel
            {
                Stores = await _context.Stores.ProjectTo<StoreLookupModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
