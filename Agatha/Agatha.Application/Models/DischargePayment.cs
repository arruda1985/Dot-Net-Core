using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Models
{
    public class DischargePayment
    {
        public string PaymentMethod { get; set; } //TODO virar enum
        public CreditCard CreditCard { get; set; }
    }

    public class CreditCard
    {
        public string Number { get; set; }
        public string HolderName { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvv { get; set; }
    }
}
