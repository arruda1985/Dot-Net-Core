using MediatR;

namespace Agatha.Application.Sales.Commands.Queries.GetSaleList
{
    public class GetSalesListQuery : IRequest<SalesListViewModel>
    {
    }
}