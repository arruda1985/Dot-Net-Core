using Agatha.Domain.Entities;
using System.Collections.Generic;

namespace Agatha.Application.Sales.Commands.Queries.GetSaleList
{
    public class SalesListViewModel
    {
        public SalesListViewModel()
        {
            Sales = new HashSet<SalesDto>();
        }

        public ICollection<SalesDto> Sales { get; set; }
    }
}