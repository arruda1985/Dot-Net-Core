using MediatR;

namespace Agatha.Application.Customers.Queries.GetAllCustomers
{
    public class GetCustomerListQuery : IRequest<CustomersListViewModel>
    {
    }
}
