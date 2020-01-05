using Agatha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Models
{
    public class SaleDischarge
    {
        public Guid SaleId { get; set; }
        public ICollection<Product> Products { get; set; }
        public int Total { get; set; }
        public Customer Customer { get; set; }
        public DischargePayment Payment { get; set; }
    }
}
