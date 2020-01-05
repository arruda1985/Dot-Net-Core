using Agatha.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Models
{
    public class DischargeReturn : IDischargeReturn
    {
        public string Status { get; set; }
        public int Amount { get; set; }
        public string Code { get; set; }
        public string Id { get; set; }
        public int PaidAmount { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
