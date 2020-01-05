using Agatha.Application.Interfaces;
using Agatha.Application.Models;
using Agatha.Domain.Entities;
using Agatha.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agatha.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, IDischargeReturn>
    {
        private readonly AgathaDbContext _context;
        private readonly IDischargeService _dischargeService;

        public CreateSaleCommandHandler(AgathaDbContext context, IDischargeService dischargeService)
        {
            _context = context;
            _dischargeService = dischargeService;
        }

        public async Task<IDischargeReturn> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Sale()
            {
                Created = DateTime.Now,
                Address = request.Address,
                Customer = request.Customer,
                ProductsSale = request.ProductsSale,
                Status = "waiting"
            };

            _context.Sales.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var productsSale = request.ProductsSale.ToList();

            var dischargeReturn = _dischargeService.Discharge(new SaleDischarge()
            {
                SaleId = entity.Id,
                Total = productsSale.Sum(ps => ps.UnitPrice * ps.Quantity),
                Customer = request.Customer,
                Payment = new DischargePayment()
                {
                    PaymentMethod = request.Payment.PaymentMethod,
                    CreditCard = new CreditCard()
                    {
                        HolderName = request.Payment.CreditCard.HolderName,
                        Number = request.Payment.CreditCard.Number,
                        ExpMonth = request.Payment.CreditCard.ExpMonth,
                        ExpYear = request.Payment.CreditCard.ExpYear,
                        Cvv = request.Payment.CreditCard.Cvv
                    }
                }
            });

            entity.Status = dischargeReturn.Status;

            _context.Sales.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return dischargeReturn;
        }
    }
}