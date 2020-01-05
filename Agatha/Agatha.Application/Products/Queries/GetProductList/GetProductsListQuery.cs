using MediatR;

namespace Agatha.Application.Products.Queries.GetProductList
{
    public class GetProductsListQuery : IRequest<ProductsListViewModel>
    {
    }
}
