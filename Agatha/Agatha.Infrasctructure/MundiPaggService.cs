using Agatha.Application.Interfaces;
using Agatha.Application.Models;
using Agatha.Domain.Entities;
using MundiAPI.PCL;
using MundiAPI.PCL.Models;
using System;
using System.Linq;

namespace Agatha.Infrasctructure
{
    public class MundiPaggService : IDischargeService
    {
        private readonly string basicAuthUserName;
        private readonly string basicAuthPassword;
        private readonly IMundiAPIClient client;

        public MundiPaggService()
        {
            basicAuthUserName = "sk_test_PWY9ZDPhwNfeMRNv";
            basicAuthPassword = "";

            client = new MundiAPIClient(basicAuthUserName, basicAuthPassword);
        }
        public IDischargeReturn Discharge(SaleDischarge saleDischarge)
        {

            var customer = new CreateCustomerRequest
            {
                Name = string.Format("{0} {1}", saleDischarge.Customer.FirstName, saleDischarge.Customer.LastName),
                Email = saleDischarge.Customer.Contact.Email,
            };

            var request = new CreateChargeRequest()
            {
                Amount = saleDischarge.Total,
                Code = saleDischarge.SaleId.ToString(),
                Customer = customer,
                Payment = new CreatePaymentRequest()
                {
                    PaymentMethod = saleDischarge.Payment.PaymentMethod,
                    CreditCard = new CreateCreditCardPaymentRequest()
                    {
                        Card = new CreateCardRequest
                        {
                            Number = saleDischarge.Payment.CreditCard.Number,
                            HolderName = saleDischarge.Payment.CreditCard.HolderName,
                            ExpMonth = saleDischarge.Payment.CreditCard.ExpMonth,
                            ExpYear = saleDischarge.Payment.CreditCard.ExpYear,
                            Cvv = saleDischarge.Payment.CreditCard.Cvv,
                        }
                    }
                }
            };

            var response = client.Charges.CreateCharge(request);
            
            return new DischargeReturn()
            {
                Amount = response.Amount,
                Code = response.Code,
                Id = response.Id,
                PaidAmount = response.PaidAmount,
                Status = response.Status,
                PaidAt = response.PaidAt,
                CanceledAt = response.CanceledAt
            };
        }
    }
}
