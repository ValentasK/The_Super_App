using API.V1.Commands;
using API.V1.Queries;
using API.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "Orders")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOrdersQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);

        }

        [HttpGet("{Orders/orderId}")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            var query = new GetOrderByIdQuery(orderId);
            var order = await _mediator.Send(query);
            return order != null ? Ok(order) : NotFound();

        }

        [HttpPost(Name = "Orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return Ok(order);

        }
    }
}

// https://www.youtube.com/watch?v=2JzQuIvxIqk