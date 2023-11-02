using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indolent.Retail.WebAPI.Controllers;

[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> Read([FromQuery] int id = 0, [FromQuery] string customerId = "")
    {
        try
        {
            var orders = _orderService.Read(id, customerId).ToList();
            var count = orders.Count;

            // Add metadata to header
            Response.Headers.Add("x-order-count", $"{count}");

            if (count > 0)
                return Ok(orders);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);
            return StatusCode(500);
        }
    }
}