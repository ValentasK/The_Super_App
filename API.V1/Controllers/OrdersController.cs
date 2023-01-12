using API.V1.Commands;
using API.V1.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/customer")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCustomersQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);

        }

        [HttpGet("/customer/{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var customer = await _mediator.Send(query);
            return customer != null ? Ok(customer) : NotFound();

        }

        [HttpPost("/customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);

        }
    }
}
