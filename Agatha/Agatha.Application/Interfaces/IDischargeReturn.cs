using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Interfaces
{
    public interface IDischargeReturn
    {
        string Status { get; set; }
        int Amount { get; set; }
        //string GatewayId { get; set; }
        string Code { get; set; }
        string Id { get; set; }
        //int CanceledAmount { get; set; }
        int PaidAmount { get; set; }
        DateTime? CanceledAt { get; set; }
        DateTime? PaidAt { get; set; }
    }
}
