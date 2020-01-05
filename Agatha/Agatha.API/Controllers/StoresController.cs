using System;
using System.Net;
using System.Threading.Tasks;
using Agatha.Application.Stores.Commands.CreateStore;
using Agatha.Application.Stores.Commands.UpdateStore;
using Agatha.Application.Stores.Queries.GetStore;
using Agatha.Application.Stores.Queries.GetStoreList;
using Agatha.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : BaseController
    {

        // GET api/stores
        [HttpGet]
        public async Task<ActionResult<StoresListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetStoresListQuery()));
        }

        // GET: api/stores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreViewModel>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetStoreQuery { Id = id }));
        }

        // POST: api/stores
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStoreCommand command)
        {
            var storeId = await Mediator.Send(command);

            return Ok(storeId);
        }

        // PUT api/stores/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(Guid id, [FromBody]UpdateStoreCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}