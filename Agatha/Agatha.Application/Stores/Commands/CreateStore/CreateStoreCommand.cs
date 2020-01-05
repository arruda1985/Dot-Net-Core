using MediatR;
using System;

namespace Agatha.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommand : IRequest<Guid>
    {
        public string Name { get; set; }
       
    }
}
