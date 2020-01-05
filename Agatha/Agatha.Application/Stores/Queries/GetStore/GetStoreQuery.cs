using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Stores.Queries.GetStore
{
    public class GetStoreQuery : IRequest<StoreViewModel>
    {
        public Guid Id { get; set; }
    }

}
