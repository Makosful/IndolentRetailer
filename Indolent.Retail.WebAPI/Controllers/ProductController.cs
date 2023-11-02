using Indolent.Retail.Core.ApplicationServices.Abstractions;
using Indolent.Retail.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indolent.Retail.WebAPI.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> ReadAll([FromQuery] int id = 0)
    {
        try
        {
            var products = _productService.Read(id).ToList();
            var count = products.Count;

            // Add metadata to header
            Response.Headers.Add("x-product-count", $"{count}");

            if (count > 0)
                return Ok(products);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);
            return StatusCode(500);
        }
    }
}