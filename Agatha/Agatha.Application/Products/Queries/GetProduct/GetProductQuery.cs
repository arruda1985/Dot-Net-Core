using MediatR;
using System;

namespace Agatha.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public Guid Id { get; set; }
    }
}
