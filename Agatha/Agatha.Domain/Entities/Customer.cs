using System;
using System.Collections.Generic;

namespace Agatha.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}