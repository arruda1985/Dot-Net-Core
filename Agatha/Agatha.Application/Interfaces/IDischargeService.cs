using Agatha.Application.Models;
using Agatha.Domain.Entities;
using System.Threading.Tasks;

namespace Agatha.Application.Interfaces
{
    public interface IDischargeService
    {
        IDischargeReturn Discharge(SaleDischarge saleDischarge);
    }
}
