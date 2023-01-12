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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCustomersQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);

        }

        [HttpGet("/{orderId}")]
        public async Task<IActionResult> Get(int orderId)
        {
            var query = new GetCustomerByIdQuery(orderId);
            var order = await _mediator.Send(query);
            return order != null ? Ok(order) : NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return Ok(order);

        }
    }
}
