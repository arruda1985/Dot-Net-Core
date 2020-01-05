using Agatha.Application.Sales.Commands.Queries.GetSaleList;
using Agatha.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Sales.Commands.Queries.GetSale
{
    public class GetSaleQuery : IRequest<SalesDto>
    {
           public Guid Id { get; set; }
    }
}
