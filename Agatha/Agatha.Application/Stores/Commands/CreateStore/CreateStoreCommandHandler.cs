using Agatha.Domain.Entities;
using Agatha.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly AgathaDbContext _context;

        public CreateStoreCommandHandler(AgathaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = new Store
            {
                Name = request.Name
            };

            _context.Stores.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

