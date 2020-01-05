using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Domain.Entities
{
    public class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; private set; }

    }
}
