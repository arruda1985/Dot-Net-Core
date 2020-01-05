using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agatha.Application.Interfaces;
using Agatha.Application.Sales.Commands.CreateSale;
using Agatha.Application.Sales.Commands.Queries.GetSale;
using Agatha.Application.Sales.Commands.Queries.GetSaleList;
using Agatha.Domain.Entities;
using Agatha.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agatha.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseController
    {
        // GET api/sales
        [HttpGet]
        public async Task<ActionResult<SalesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSalesListQuery()));
        }

        // GET: api/sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetSaleQuery { Id = id }));
        }

        // POST: api/sales
        [HttpPost]
        public async Task<ActionResult<IDischargeReturn>> Create([FromBody] CreateSaleCommand command)
        {
            var dischargeReturn = await Mediator.Send(command);

            return Ok(dischargeReturn);
        }
    }
}