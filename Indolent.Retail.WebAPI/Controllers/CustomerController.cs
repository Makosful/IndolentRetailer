using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Indolent.Retail.WebAPI.Controllers;

[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet]
    public ActionResult Read([FromQuery] string uuid = "")
    {
        try
        {
            var customers = _customerService.Read(uuid).ToList();
            var count = customers.Count;

            // Add metadata to header
            Response.Headers.Add("x-customer-count", $"{count}");

            if (count > 0)
                return Ok(customers);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);
            return StatusCode(500);
        }
    }
}