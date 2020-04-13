using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListVm>
    {
    }
}
