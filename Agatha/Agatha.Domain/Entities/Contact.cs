using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Language { get; set; }
    }
}
