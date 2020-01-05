﻿using System;

namespace Agatha.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Customer Customer { get; set; }
    }
}