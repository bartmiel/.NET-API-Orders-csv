using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetlandRecruitingTask.Application.Functions.Orders.Query.GetOrderList;

namespace NetlandRecruitingTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders([FromQuery] string? orderNumber,[FromQuery] DateTime? orderDateFrom,[FromQuery] DateTime? orderDateTo,[FromQuery] List<string>? clientCodes)
        {
            var queryWithFilters = new GetOrderListQuery()
            {
                OrderNumber = orderNumber,
                OrderDateFrom = orderDateFrom,
                OrderDateTo = orderDateTo,
                ClientCodes = clientCodes
            };

            var orders = await _mediator.Send(queryWithFilters);
            return Ok(orders);
        }
    }
}