using System.Threading.Tasks;
using Agatha.Application.Customers.Queries.GetAllCustomers;
using Agatha.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agatha.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        // GET api/stores
        [HttpGet]
        public async Task<ActionResult<CustomersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCustomerListQuery()));
        }
    }
}