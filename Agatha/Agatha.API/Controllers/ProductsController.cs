using System;
using System.Net;
using System.Threading.Tasks;
using Agatha.Application.Products.Commands.CreateProduct;
using Agatha.Application.Products.Commands.UpdateProduct;
using Agatha.Application.Products.Queries.GetProduct;
using Agatha.Application.Products.Queries.GetProductList;
using Agatha.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agatha.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController()
        {
        }

        // GET api/products
        [HttpGet]
        public async Task<ActionResult<ProductsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetProductsListQuery()));
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetProductQuery { Id = id }));
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command)
        { 
            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(Guid id, [FromBody]UpdateProductCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}