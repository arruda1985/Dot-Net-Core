using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
